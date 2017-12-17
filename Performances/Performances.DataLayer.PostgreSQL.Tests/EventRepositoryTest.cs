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
        public List<Guid> _tempCreativeTeam = new List<Guid>();
        public List<Guid> _tempEvent = new List<Guid>();

        [TestMethod]
        public void ShouldCreateEvent()
        {
            var creativeteam = new CreativeTeam
            {
                About = "test",
                Email = "test@ya.ru",
                Genre = "rock/hardcore/post-punk",
                Name = "testband",
                Password = "test",
                Rating = 3.2,
                SubscribersCount = 0
            };
            var photo = new File
            {
                Bytes = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7 },
                FileExtension = ".jpeg",
                Filename = "test.jpeg"
            };

            var newEvent = new Event
            {
                DateAndTime = DateTime.Now,
                Description = "Big concert on the street of your city!",
                ParticipantCount = 0,
                Place = "Saint-Petersburg, Russia"
            };
            var file = new File
            {
                Bytes = new byte[] { 1, 12, 123, 13 },
                FileExtension = ".jpg",
                Filename = "fotka"
            };
            
            var creativeteamRepository = new CreativeTeamRepository(_connectionString);
            var newcreativeteam = creativeteamRepository.CreateCreativeTeam(creativeteam, photo.Bytes, photo.Filename);
            _tempCreativeTeam.Add(newcreativeteam.Id);
            
            var eventrepository = new EventRepository(_connectionString);
            var result = eventrepository.CreateEvent(newEvent, file.Bytes, file.Filename, newcreativeteam.Id);
            _tempEvent.Add(result.Id);

            Assert.AreEqual(newEvent.Place, result.Place);
            Assert.AreEqual(newEvent.ParticipantCount, result.ParticipantCount);
            Assert.AreEqual(newEvent.DateAndTime.Date, result.DateAndTime.Date);
        }

        [TestMethod]
        public void ShouldGetAllEvents()
        {
            var creativeteam = new CreativeTeam
            {
                About = "test",
                Email = "test@ya.ru",
                Genre = "rock/hardcore/post-punk",
                Name = "testband",
                Password = "test",
                Rating = 3.2,
                SubscribersCount = 0
            };
            var photo = new File
            {
                Bytes = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7 },
                FileExtension = ".jpeg",
                Filename = "test.jpeg"
            };

            var creativeteam2 = new CreativeTeam
            {
                About = "test2",
                Email = "test@ya.ru",
                Genre = "rock/hardcore/post-punk",
                Name = "testband2",
                Password = "test2",
                Rating = 3.2,
                SubscribersCount = 0
            };
            var photo2 = new File
            {
                Bytes = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7 },
                FileExtension = ".jpeg",
                Filename = "test.jpeg"
            };

            var newEvent = new Event
            {
                DateAndTime = DateTime.Now,
                Description = "Big concert on the street of your city!",
                ParticipantCount = 0,
                Place = "Saint-Petersburg, Russia"
            };
            var newEvent2 = new Event
            {
                DateAndTime = DateTime.Now,
                Description = "Big concert on the street of your city!",
                ParticipantCount = 0,
                Place = "SPb, Russia"
            };
            var file = new File
            {
                Bytes = new byte[] { 1, 12, 123, 13 },
                FileExtension = ".jpg",
                Filename = "fotka"
            };

            var creativeteamRepository = new CreativeTeamRepository(_connectionString);
            var newcreativeteam = creativeteamRepository.CreateCreativeTeam(creativeteam, photo.Bytes, photo.Filename);
            _tempCreativeTeam.Add(newcreativeteam.Id);
            var newcreativeteam2 = creativeteamRepository.CreateCreativeTeam(creativeteam2, photo2.Bytes, photo2.Filename);
            _tempCreativeTeam.Add(newcreativeteam2.Id);

            var eventrepository = new EventRepository(_connectionString);
            var result = eventrepository.CreateEvent(newEvent, file.Bytes, file.Filename, newcreativeteam.Id);
            var result2 = eventrepository.CreateEvent(newEvent2, file.Bytes, file.Filename, newcreativeteam2.Id);
            _tempEvent.Add(result.Id);
            _tempEvent.Add(result2.Id);

            Assert.AreEqual(newEvent.Place, result.Place);
            Assert.AreEqual(newEvent2.Place, result2.Place);
        }

        [TestMethod]
        public void ShouldGetCreativeTeamEvents()
        {
            var creativeteam = new CreativeTeam
            {
                About = "test",
                Email = "test@ya.ru",
                Genre = "rock/hardcore/post-punk",
                Name = "testband",
                Password = "test",
                Rating = 3.2,
                SubscribersCount = 0
            };
            var photo = new File
            {
                Bytes = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7 },
                FileExtension = ".jpeg",
                Filename = "test.jpeg"
            };
            var newEvent = new Event
            {
                DateAndTime = DateTime.Now,
                Description = "Big concert on the street of your city!",
                ParticipantCount = 0,
                Place = "Saint-Petersburg, Russia"
            };
            var newEvent2 = new Event
            {
                DateAndTime = DateTime.Now,
                Description = "Big concert on the street of your city!",
                ParticipantCount = 0,
                Place = "SPb, Russia"
            };
            var file = new File
            {
                Bytes = new byte[] { 1, 12, 123, 13 },
                FileExtension = ".jpg",
                Filename = "fotka"
            };
            
            var creativeteamRepository = new CreativeTeamRepository(_connectionString);
            var newcreativeteam = creativeteamRepository.CreateCreativeTeam(creativeteam, photo.Bytes, photo.Filename);
            _tempCreativeTeam.Add(newcreativeteam.Id);

            var eventrepository = new EventRepository(_connectionString);
            var result = eventrepository.CreateEvent(newEvent, file.Bytes, file.Filename, newcreativeteam.Id);
            var result2 = eventrepository.CreateEvent(newEvent2, file.Bytes, file.Filename, newcreativeteam.Id);
            _tempEvent.Add(result.Id);
            _tempEvent.Add(result2.Id);

            List<Event> events = new List<Event>();
            events = eventrepository.GetCreativeTeamEvents(newcreativeteam);

            var resultsevents = events.Find(x => x.Id == result.Id);
            Assert.AreEqual(result.Place, resultsevents.Place);

            resultsevents = events.Find(x => x.Id == result2.Id);
            Assert.AreEqual(result2.Photo, resultsevents.Photo);
        }

        [TestMethod]
        public void ShouldGetEventById()
        {
            var creativeteam = new CreativeTeam
            {
                About = "test",
                Email = "test@ya.ru",
                Genre = "rock/hardcore/post-punk",
                Name = "testband",
                Password = "test",
                Rating = 3.2,
                SubscribersCount = 0
            };
            var photo = new File
            {
                Bytes = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7 },
                FileExtension = ".jpeg",
                Filename = "test.jpeg"
            };
            var newEvent = new Event
            {
                DateAndTime = DateTime.Now,
                Description = "Big concert on the street of your city!",
                ParticipantCount = 0,
                Place = "Saint-Petersburg, Russia"
            };
            var file = new File
            {
                Bytes = new byte[] { 1, 12, 123, 13 },
                FileExtension = ".jpg",
                Filename = "fotka"
            };

            var creativeteamRepository = new CreativeTeamRepository(_connectionString);
            var newcreativeteam = creativeteamRepository.CreateCreativeTeam(creativeteam, photo.Bytes, photo.Filename);
            _tempCreativeTeam.Add(newcreativeteam.Id);

            var eventrepository = new EventRepository(_connectionString);
            var result = eventrepository.CreateEvent(newEvent, file.Bytes, file.Filename, newcreativeteam.Id);
            _tempEvent.Add(result.Id);

            var resultEvent = eventrepository.GetEventById(result.Id);

            Assert.AreEqual(newEvent.Place, resultEvent.Place);
            Assert.AreEqual(newEvent.Description, resultEvent.Description);
        }
        // TODO: GetUserUpcomingEvents test method, GetUserSubscribedEvents test method, UpdateEvent test method
        //[TestMethod]
        //public void ShouldGetUserSubscribedEvents()
        //{

        //}

        [TestCleanup]
        public void Clean()
        {
            foreach (var id in _tempEvent)
                new EventRepository(_connectionString).DeleteEvent(id);
        }
    }
}
