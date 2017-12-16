using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using NpgsqlTypes;
using Performances.Model;

namespace Performances.DataLayer.PostgreSQL
{
    public class CreativeTeamRepository : ICreativeTeamRepository
    {
        private readonly string _connectionString; // = "Server=localhost;Port=5432;User Id=client;Password=passclient;Database=testdb;Search Path=test;";

        public CreativeTeamRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public CreativeTeam CreateCreativeTeam(CreativeTeam creativeTeam, byte[] photo, string filename)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                }
                catch (NpgsqlException ex)
                {
                    throw ex;
                }

                using (var tran = connection.BeginTransaction())
                {
                    File file = new File();
                    file.Id = Guid.NewGuid();
                    file.Bytes = photo;
                    file.Filename = filename;
                    file.FileExtension = filename.Split('.').Last();
                    creativeTeam.Id = Guid.NewGuid();
                    creativeTeam.Photo = file.Id;

                    using (var command = connection.CreateCommand())
                    {
                        command.Transaction = tran;
                        command.CommandText =
                            "insert into files (id, filename, fileextension, bytes)" +
                            "values (@id, @filename, @fileextension, @bytes)";
                        command.Parameters.AddWithValue("@id", file.Id);
                        command.Parameters.AddWithValue("@filename", file.Filename);
                        command.Parameters.AddWithValue("@fileextension", file.FileExtension);
                        command.Parameters.AddWithValue("@bytes", file.Bytes);
                        command.ExecuteNonQuery();
                    }

                    using (var command = connection.CreateCommand())
                    {
                        command.Transaction = tran;
                        command.CommandText =
                            "insert into creativeteam (id, name, genre, about, subscriberscount, rating, password, email, photo)"
                            + " values (@id, @name, @genre, @about, @subscriberscount, @rating, @password, @email, @photo)";
                        command.Parameters.AddWithValue("@id", creativeTeam.Id);
                        command.Parameters.AddWithValue("@name", creativeTeam.Name);
                        command.Parameters.AddWithValue("@genre", creativeTeam.Genre);
                        command.Parameters.AddWithValue("@about", creativeTeam.About);
                        command.Parameters.AddWithValue("@photo", creativeTeam.Photo);
                        command.Parameters.AddWithValue("@subscriberscount", creativeTeam.SubscribersCount);
                        command.Parameters.AddWithValue("@rating", creativeTeam.Rating);
                        command.Parameters.AddWithValue("@password", creativeTeam.Password);
                        command.Parameters.AddWithValue("@email", creativeTeam.Email);
                        command.ExecuteNonQuery();
                    }
                    tran.Commit();
                }
            }
            return creativeTeam;
        }

        public void DeleteCreativeTeam(CreativeTeam creativeTeam)
        {
            throw new NotImplementedException();
        }

        public void DeleteCreativeTeam(int creativeTeamId)
        {
            throw new NotImplementedException();
        }

        public CreativeTeam GetCreativeTeamById(int creativeTeamId)
        {
            throw new NotImplementedException();
        }

        public CreativeTeam UpdateCreativeTeam(CreativeTeam oldCreativeTeam, CreativeTeam newCreativeTeam)
        {
            throw new NotImplementedException();
        }
    }
}
