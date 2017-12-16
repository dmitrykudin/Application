using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using NpgsqlTypes;
using Performances.Model;
using Perfomances.DataLayer;
using Performances.DataLayer.PostgreSQL.Helpers;

namespace Performances.DataLayer.PostgreSQL
{
    public class EventRepository : IEventRepository
    {
        private readonly string _connectionString; // = "Server=localhost;Port=5432;User Id=client;Password=passclient;Database=testdb;";

        public EventRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void CreateEvent(CreateEventModel newEvent)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                }
                catch (NpgsqlException ex)
                {
                    
                }

                BitmapByteConverter converter = new BitmapByteConverter();
                newEvent.FilePhoto.Path = converter.ConvertBitmapToByte(newEvent.Photo).ToString();

                using (var tran = connection.BeginTransaction())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.Transaction = tran;
                        command.CommandText = "insert into files (path, fileextension)"
                    }

                    using (var command = connection.CreateCommand())
                    {
                        command.Transaction = tran;
                        command.CommandText =
                            "insert into event (place, participantcount, description, photo, date, time)"
                            + " values (@place, @participantcount, @description, @photo, @date, @time)";
                        command.Parameters.AddWithValue("@place", newEvent.Place);
                        command.Parameters.AddWithValue("@participantcount", newEvent.ParticipantCount);
                        command.Parameters.AddWithValue("@description", newEvent.Description);
                        command.Parameters.AddWithValue("@photo", newEvent.FilePhoto.Id);
                        command.Parameters.AddWithValue("@datetime", new NpgsqlDateTime(newEvent.DateAndTime));
                        command.ExecuteNonQuery();
                    }

                    using (var command = connection.CreateCommand())
                    {
                        // TODO: Add link to creativeteam
                    }
                }
            }
        }

        public void DeleteEvent(Event delEvent)
        {
            throw new NotImplementedException();
        }

        public void DeleteEvent(int eventId)
        {
            throw new NotImplementedException();
        }

        public List<Event> GetAllEvents()
        {
            throw new NotImplementedException();
        }

        public Event GetEventById(int eventId)
        {
            using (var connection = new NpgsqlConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select * from event where id = @EventId";
                    command.Parameters.AddWithValue("@EventId", eventId);
                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            throw new ArgumentException($"Событие с Id {eventId} не нашлось");
                        BitmapByteConverter converter = new BitmapByteConverter();
                        var newEvent = new Event()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Description = reader.GetString(reader.GetOrdinal("description")),
                            ParticipantCount = reader.GetInt32(reader.GetOrdinal("participantcount")),
                            Place = reader.GetString(reader.GetOrdinal("place"))
                            //Photo = converter.ConvertByteToBitmap(reader.(reader.GetOrdinal("photo")))
                            // TODO: Photo and DateTime conversion
                        };

                        return newEvent;
                    }
                }
            }
        }

        public List<Event> GetNearestEvents(User user)
        {
            throw new NotImplementedException();
        }

        public List<Event> GetUserSubscribedEvents(User user)
        {
            throw new NotImplementedException();
        }

        public Event UpdateEvent(Event oldEvent, Event newEvent)
        {
            throw new NotImplementedException();
        }
    }
}
