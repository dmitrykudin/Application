using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Perfomances.DataLayer;
using Performances.Model;

namespace Performances.DataLayer.PostgreSQL
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public User CreateUser(User user, File photo)
        {
            photo.Id = Guid.NewGuid();
            user.Id = Guid.NewGuid();
            user.Photo = photo.Id;
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.Transaction = transaction;
                        command.CommandText = "insert into files (id, fileextension, filename, bytes)" +
                                              "values (@id, @fileextension, @filename, @bytes)";
                        command.Parameters.AddWithValue("@id", photo.Id);
                        command.Parameters.AddWithValue("@fileextension", photo.FileExtension);
                        command.Parameters.AddWithValue("@filename", photo.Filename);
                        command.Parameters.AddWithValue("@bytes", photo.Bytes);
                        command.ExecuteNonQuery();
                    }

                    using (var command = connection.CreateCommand())
                    {
                        command.Transaction = transaction;
                        command.CommandText =
                            "insert into users (id, name, surname, email, password, city, age, photo) " +
                            "values (@id, @name, @surname, @email, @password, @city, @age, @photo)";
                        command.Parameters.AddWithValue("@id", user.Id);
                        command.Parameters.AddWithValue("@name", user.Name);
                        command.Parameters.AddWithValue("@surname", user.Surname);
                        command.Parameters.AddWithValue("@email", user.Email);
                        command.Parameters.AddWithValue("@password", user.Password);
                        command.Parameters.AddWithValue("@city", user.City);
                        command.Parameters.AddWithValue("@age", user.Age);
                        command.Parameters.AddWithValue("@photo", user.Photo);
                        command.ExecuteNonQuery();
                    }
                    
                    transaction.Commit();
                }
            }
            return user;
        }

        public void DeleteUser(Guid userId)
        {
            var user = new User();
            user = GetUserById(userId);
            DeleteUser(user);
        }

        public void DeleteUser(User user)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.Transaction = transaction;
                        command.CommandText = "delete from subscribes where userid=@id";
                        command.Parameters.AddWithValue("id", user.Id);
                        command.ExecuteNonQuery();
                    }
                    using (var command = connection.CreateCommand())
                    {
                        command.Transaction = transaction;
                        command.CommandText = "delete from userevent where userid=@id";
                        command.Parameters.AddWithValue("@id", user.Id);
                        command.ExecuteNonQuery();
                    }
                    using (var command = connection.CreateCommand())
                    {
                        command.Transaction = transaction;
                        command.CommandText = "update user set photo=null where id=@id";
                        command.Parameters.AddWithValue("@id", user.Id);
                        command.ExecuteNonQuery();
                    }
                    using (var command = connection.CreateCommand())
                    {
                        command.Transaction = transaction;
                        command.CommandText = "delete from file where id=@fileid";
                        command.Parameters.AddWithValue("@fileid", user.Photo);
                        command.ExecuteNonQuery();
                    }
                    using (var command = connection.CreateCommand())
                    {
                        command.Transaction = transaction;
                        command.CommandText = "delete from user where id=@id";
                        command.Parameters.AddWithValue("@id", user.Id);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public List<User> GetAllUsers()
        {
            var AllUsers = new List<User>();
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select * from user";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var user = new User()
                            {
                                Id = reader.GetGuid(reader.GetOrdinal("id")),
                                Photo = reader.GetGuid(reader.GetOrdinal("photo")),
                                Password = reader.GetString(reader.GetOrdinal("password")),
                                Age = reader.GetInt32(reader.GetOrdinal("age")),
                                Surname = reader.GetString(reader.GetOrdinal("surname")),
                                Email = reader.GetString(reader.GetOrdinal("email")),
                                City = reader.GetString(reader.GetOrdinal("city")),
                                Name = reader.GetString(reader.GetOrdinal("name"))
                            };
                            AllUsers.Add(user);
                        }
                    }
                }
            }
            return AllUsers;
        }

        public User GetUserById(Guid userId)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select * from user where u.Id = @id";
                    command.Parameters.AddWithValue("@Id", userId);
                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            throw new ArgumentException($"Пользователь с Id {userId} не найден");
                        var user = new User()
                        {
                            Id = reader.GetGuid(reader.GetOrdinal("id")),
                            Photo = reader.GetGuid(reader.GetOrdinal("photo")),
                            Password = reader.GetString(reader.GetOrdinal("password")),
                            Age = reader.GetInt32(reader.GetOrdinal("age")),
                            Surname = reader.GetString(reader.GetOrdinal("surname")),
                            Email = reader.GetString(reader.GetOrdinal("email")),
                            City = reader.GetString(reader.GetOrdinal("city")),
                            Name = reader.GetString(reader.GetOrdinal("name"))
                         };

                        return user;

                    }
                }
            }
        }

        public void GoToEvent(Guid userId, Guid eventId)
        {
            bool status = true;
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText =
                        "insert into userevent (status, userid, eventid) values (@status, @userid, @eventid)";
                    command.Parameters.AddWithValue("@status", status);
                    command.Parameters.AddWithValue("@userid", userId);
                    command.Parameters.AddWithValue("@eventid", eventId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Subscribe(Guid userId, Guid creativeteamId)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText =
                        "insert into subscribes (userid, creativeteamid) " +
                        "values (@userid, @teamid)";
                    command.Parameters.AddWithValue("@userid", userId);
                    command.Parameters.AddWithValue("@teamid", creativeteamId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public User UpdateUser(User user, User newUser)
        {
            throw new NotImplementedException();
        }
    }
}
