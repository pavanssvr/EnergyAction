using System;
using System.Collections.Generic;
using DAL;
using Model;
using System.Linq;

namespace Services
{
    public class EventService : IEventService
    {
        private readonly AppDbContext _context;

        public EventService(AppDbContext context)
        {
            _context = context;
        }

        public List<Event> GetAllEvents()
        {
            var events = _context.Events.Select(e => new Event()
            {
                 Id = e.Id
                , Name = e.Name
                , ScheduledTime = e.ScheduledTime
                , Location = e.Location
                , Members = e.Members
                , EventOrganizer = e.EventOrganizer
            });
            return events.ToList();
        }
        public Event GetEvent(int eventId)
        {
            try
            {
                return _context.Events.Find(eventId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int InsertEvent(Event eventItem)
        {
            try
            {
                _context.Events.Add(eventItem);
                _context.SaveChanges();
                return eventItem.Id;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateEvent(int eventId, Event eventItem)
        {
            try
            {
                Event objEvent = _context.Events.Find(eventId);
                objEvent.Name = eventItem.Name;
                objEvent.Location = eventItem.Location;
                objEvent.Members = eventItem.Members;
                objEvent.ScheduledTime = eventItem.ScheduledTime;
                objEvent.EventOrganizer = eventItem.EventOrganizer;

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteEvent(int eventId)
        {
            try
            {
                Event obj = _context.Events.Find(eventId);
                _context.Remove(obj);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Event> GetFilteredEvents(string name)
        {
            return _context.Events.Where(e => e.Name == name).ToList();
        }

        public List<Event> GetSortedEvents()
        {
            return _context.Events.OrderByDescending(e => e.ScheduledTime).ToList();
        }
    }
}
