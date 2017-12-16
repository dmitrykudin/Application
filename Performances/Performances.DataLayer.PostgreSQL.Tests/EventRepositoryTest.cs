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
        [TestMethod]
        public void ShouldCreateEvent()
        {
            var newEvent = new Event();
            var file = new File();
            Guid id = new Guid("82773a61-ce8a-49bc-b0dd-d47d968bffcb");

            newEvent.DateAndTime = DateTime.Now;
            newEvent.Description = "Big concert on the street of your city!";
            newEvent.ParticipantCount = 0;
            newEvent.Place = "Saint-Petersburg, Russia";

            file.Bytes = new byte[]{1, 12, 123, 13};
            file.FileExtension = ".jpg";
            file.Filename = "fotka";

            var eventrepository = new EventRepository(_connectionString);
            var result = eventrepository.CreateEvent(newEvent, file.Bytes, file.Filename, id);

            Assert.AreEqual(newEvent.Place, result.Place);
            Assert.AreEqual(newEvent.ParticipantCount, result.ParticipantCount);
        }
    }
}
