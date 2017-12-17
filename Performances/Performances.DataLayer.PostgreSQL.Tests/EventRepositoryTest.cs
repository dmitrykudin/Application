using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Performances.Model;

namespace Performances.DataLayer.PostgreSQL.Tests
{
    [TestClass]
    public class EventRepositoryTest
    {
        private readonly string _connectionString = "Server=localhost;Port=5432;User Id=client;Password=passclient;Database=testdb;Search Path=test;";
        public List<Guid> ctlist = new List<Guid>();
        public List<Guid> evlist = new List<Guid>();
        public List<Guid> flist = new List<Guid>();

        [TestMethod]
        public void ShouldCreateEvent()
        {
            var creativeteam = new CreativeTeam();
            var photo = new File();

            var newEvent = new Event();
            var file = new File();

            creativeteam.About = "test";
            creativeteam.Email = "test@ya.ru";
            creativeteam.Genre = "rock/hardcore/post-punk";
            creativeteam.Name = "testband";
            creativeteam.Password = "test";
            creativeteam.Rating = 3.2;
            creativeteam.SubscribersCount = 0;

            photo.Bytes = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7 };
            photo.FileExtension = ".jpeg";
            photo.Filename = "test.jpeg";

            CreativeTeamRepository ctr = new CreativeTeamRepository(_connectionString);
            var newct = ctr.CreateCreativeTeam(creativeteam, photo.Bytes, photo.Filename);
            ctlist.Add(newct.Id);
            flist.Add(newct.Photo);

            newEvent.DateAndTime = DateTime.Now;
            newEvent.Description = "Big concert on the street of your city!";
            newEvent.ParticipantCount = 0;
            newEvent.Place = "Saint-Petersburg, Russia";

            file.Bytes = new byte[]{1, 12, 123, 13};
            file.FileExtension = ".jpg";
            file.Filename = "fotka";

            var eventrepository = new EventRepository(_connectionString);
            var result = eventrepository.CreateEvent(newEvent, file.Bytes, file.Filename, newct.Id);
            evlist.Add(result.Id);

            Assert.AreEqual(newEvent.Place, result.Place);
            Assert.AreEqual(newEvent.ParticipantCount, result.ParticipantCount);
            Assert.AreEqual(newEvent.DateAndTime.Date, result.DateAndTime.Date);
        }
    }
}
