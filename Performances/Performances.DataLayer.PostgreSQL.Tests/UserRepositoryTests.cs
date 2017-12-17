using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Performances.Model;
using Performances.DataLayer.PostgreSQL;

namespace Performances.DataLayer.PostgreSQL.Tests
{
    [TestClass]
    public class UserRepositoryTests
    {
        private readonly string _connectionString = "Server=localhost;Port=5432;User Id=client;Password=passclient;Database=testdb;Search Path=test;";
        public List<Guid> _tempUsers = new List<Guid>();

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
            _tempUsers.Add(result.Id);

            Assert.AreEqual(user.Name, result.Name);
            Assert.AreEqual(user.Surname, result.Surname);
        }

        //[TestMethod]
        //public void ShouldGetAllUsers()
        //{
            
        //}

        [TestMethod]
        public void ShouldGetUserById()
        {
            var user = new User
            {
                Age = 18,
                City = "Питер",
                Email = "text@yandex.ru",
                Name = "Марина",
                Surname = "Купцова",
                Password = "12345",
            };

            var file = new File
            {
                Bytes = new byte[0],
                FileExtension = ".jpg",
                Filename = "fotka"
            };

            var repository = new UserRepository(_connectionString);
            var resultUser = repository.CreateUser(user, file);
            _tempUsers.Add(resultUser.Id);

            var result = repository.GetUserById(resultUser.Id);

            Assert.AreEqual(user.City, result.City);
            Assert.AreEqual(user.Email, result.Email);
        }

        [TestCleanup]
        public void Clean()
        {
            foreach (var id in _tempUsers)
                new UserRepository(_connectionString).DeleteUser(id);
        }
    }
}
