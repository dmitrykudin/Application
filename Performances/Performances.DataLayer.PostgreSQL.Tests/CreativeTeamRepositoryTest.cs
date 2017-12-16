using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Performances.Model;

namespace Performances.DataLayer.PostgreSQL.Tests
{
    [TestClass]
    public class CreativeTeamRepositoryTest
    {
        private readonly string _connectionString = "Server=localhost;Port=5432;User Id=client;Password=passclient;Database=testdb;Search Path=test;";

        [TestMethod]
        public void ShouldCreateCreativeTeam()
        {
            var creativeteam = new CreativeTeam();
            var photo = new File();

            creativeteam.About = "";
            creativeteam.Email = "ourrockband@ya.ru";
            creativeteam.Genre = "rock/hardcore/post-punk";
            creativeteam.Name = "dicklovers";
            creativeteam.Password = "lovedicks";
            creativeteam.Rating = 3.2;
            creativeteam.SubscribersCount = 0;

            photo.Bytes = new byte[]{0, 1, 2, 3, 4, 5, 6, 7};
            photo.FileExtension = ".jpeg";
            photo.Filename = "dicklovers.jpeg";

            var creativeteamrepository = new CreativeTeamRepository(_connectionString);
            var result = creativeteamrepository.CreateCreativeTeam(creativeteam, photo.Bytes, photo.Filename);

            Assert.AreEqual(creativeteam.Name, result.Name);
            Assert.AreEqual(creativeteam.SubscribersCount, result.SubscribersCount);
        }
    }
}
