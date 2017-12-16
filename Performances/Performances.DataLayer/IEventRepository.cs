using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Performances.Model;

namespace Perfomances.DataLayer
{
    public interface IEventRepository
    {
        void CreateEvent(CreateEventModel newEvent);
        Event GetEventById(int eventId);
        void DeleteEvent(Event delEvent);
        void DeleteEvent(int eventId);
        Event UpdateEvent(Event oldEvent, Event newEvent);
        List<Event> GetAllEvents();
        List<Event> GetUserSubscribedEvents(User user);
        List<Event> GetNearestEvents(User user);
    }
}
