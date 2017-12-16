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

        public User CreateUser(User user, byte[] photo, string filename, string fileextension)
        {
            var file = new File();
            file.Id = new Guid();
            user.Id = new Guid();
            user.Photo = file.Id;
            using (var connection = new NpgsqlConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.Transaction = transaction;
                        command.CommandText =
                            "insert into user (id, name, surname, email, password, city, age, photo) " +
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
                    using (var command = connection.CreateCommand())
                    {
                        command.Transaction = transaction;
                        command.CommandText = "insert into files (id, fileextension, filename, bytes)" +
                                              "values (@id, @fileextension, @filename, @bytes)";
                        command.Parameters.AddWithValue("@id", file.Id);
                        command.Parameters.AddWithValue("@fileextension", fileextension);
                        command.Parameters.AddWithValue("@filename", filename);
                        command.Parameters.AddWithValue("@bytes", photo);
                    }
                }
            }
        }

        public void DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int userId)
        {
            throw new NotImplementedException();
        }

        public User UpdateUser(User user, User newUser)
        {
            throw new NotImplementedException();
        }
    }
}
