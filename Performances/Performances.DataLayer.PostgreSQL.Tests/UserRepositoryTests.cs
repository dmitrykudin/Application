using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Performances.Model;

namespace Performances.DataLayer.PostgreSQL.Tests
{
    [TestClass]
    public class UserRepositoryTests
    {
        private readonly string _connectionString = "Server=localhost;Port=5432;User Id=client;Password=passclient;Database=testdb;"; 
        [TestMethod]
        public void ShouldCreateNewUser()
        {
            var user = new User();
            var file = new File();

            user.Age = 18;
            user.City = "Питер";
            user.Email = "text@yandex.ru";
            user.Name = "Марина";
            user.Surname = "Купцова";
            user.Password = "12345";
            
            file.Bytes = new byte[0];
            file.FileExtension = ".jpg";
            file.Filename = "fotka";

            var usersRepository = new UserRepository(_connectionString);
            var result = usersRepository.CreateUser(user, file);

            Assert.AreEqual(user.Name, result.Name);
            Assert.AreEqual(user.Surname, result.Surname);
        }
    }
}
