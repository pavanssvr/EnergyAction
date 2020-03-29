using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IEventService
    {
        List<Event> GetAllEvents();
        Event GetEvent(int eventId);
        int InsertEvent(Event eventItem);
        void UpdateEvent(int eventId, Event eventItem);
        void DeleteEvent(int eventId);
    }
}
