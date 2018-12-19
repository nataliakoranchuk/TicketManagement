using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementData.Entities;
using TicketManagementData.Repository;

namespace TicketManagementBusiness.Test.FakeRepository
{
    internal class FakeTicketRepository : ITicketRepository
    {
        private IDictionary<int, Area> areaInMemoryStorage;
        private IDictionary<int, EventArea> eventAreaInMemoryStorage;
        private IDictionary<int, Event> eventInMemoryStorage;
        private IDictionary<int, EventSeat> eventSeatInMemoryStorage;
        private IDictionary<int, Layout> layoutInMemoryStorage;
        private IDictionary<int, Seat> seatInMemoryStorage;
        private IDictionary<int, Venue> venueInMemoryStorage;

        public FakeTicketRepository()
        {
            areaInMemoryStorage = new Dictionary<int, Area>();
            eventAreaInMemoryStorage = new Dictionary<int, EventArea>();
            eventInMemoryStorage = new Dictionary<int, Event>();
            eventSeatInMemoryStorage = new Dictionary<int, EventSeat>();
            layoutInMemoryStorage = new Dictionary<int, Layout>();
            seatInMemoryStorage = new Dictionary<int, Seat>();
            venueInMemoryStorage = new Dictionary<int, Venue>();
        }

        public Area GetAreaById(int id)
        {
            return areaInMemoryStorage[id];
        }

        public List<Area> GetAllAreasByLayoutId(int layoutId)
        {
            List<Area> ret = new List<Area>();
            foreach (Area v in areaInMemoryStorage.Values)
                if (v.LayoutId == layoutId) ret.Add(v);

            return ret;
        }

        public void CreateArea(Area item)
        {
            if (areaInMemoryStorage.Keys.Count == 0) item.Id = 1;
            else item.Id = areaInMemoryStorage.Keys.Max() + 1;
            areaInMemoryStorage.Add(item.Id, item);
        }

        public void UpdateArea(Area item)
        {
            areaInMemoryStorage[item.Id] = item;
        }

        public void DeleteArea(int id)
        {
            areaInMemoryStorage.Remove(id);
        }

        public EventArea GetEventAreaById(int id)
        {
            return eventAreaInMemoryStorage[id];
        }

        public void CreateEventArea(EventArea item)
        {
            if (eventAreaInMemoryStorage.Keys.Count == 0) item.Id = 1;
            else item.Id = eventAreaInMemoryStorage.Keys.Max() + 1;
            eventAreaInMemoryStorage.Add(item.Id, item);
        }

        public void UpdateEventArea(EventArea item)
        {
            eventAreaInMemoryStorage[item.Id] = item;
        }

        public void DeleteEventArea(int id)
        {
            eventAreaInMemoryStorage.Remove(id);
        }

        public Event GetEventById(int id)
        {
            return eventInMemoryStorage[id];
        }

        public List<Event> GetAllEventsByVenueId(int venueId)
        {
            List<Event> allEvent = new List<Event>();
            foreach (Layout _layout in layoutInMemoryStorage.Values)
                if (_layout.VenueId == venueId)
                    foreach (Event _event in eventInMemoryStorage.Values)
                        if(_event.LayoutId == _layout.Id)
                            allEvent.Add(_event);

            return allEvent;
        }

        public void CreateEvent(Event item)
        {
            if (eventInMemoryStorage.Keys.Count == 0) item.Id = 1;
            else item.Id = eventInMemoryStorage.Keys.Max() + 1;
            eventInMemoryStorage.Add(item.Id, item);
        }

        public void UpdateEvent(Event item)
        {
            eventInMemoryStorage[item.Id] = item;
        }

        public void DeleteEvent(int id)
        {
            eventInMemoryStorage.Remove(id);
        }

        public EventSeat GetEventSeatById(int id)
        {
            return eventSeatInMemoryStorage[id];
        }

        public void CreateEventSeat(EventSeat item)
        {
            if (eventSeatInMemoryStorage.Keys.Count == 0) item.Id = 1;
            else item.Id = eventSeatInMemoryStorage.Keys.Max() + 1;
            eventSeatInMemoryStorage.Add(item.Id, item);
        }

        public void UpdateEventSeat(EventSeat item)
        {
            eventSeatInMemoryStorage[item.Id] = item;
        }

        public void DeleteEventSeat(int id)
        {
            eventSeatInMemoryStorage.Remove(id);
        }

        public Layout GetLayoutById(int id)
        {
            return layoutInMemoryStorage[id];
        }

        public void CreateLayout(Layout item)
        {
            if (layoutInMemoryStorage.Keys.Count == 0) item.Id = 1;
            else item.Id = layoutInMemoryStorage.Keys.Max() + 1;
            layoutInMemoryStorage.Add(item.Id, item);
        }

        public void UpdateLayout(Layout item)
        {
            layoutInMemoryStorage[item.Id] = item;
        }

        public List<Layout> GetAllLayoutsByVenueId(int venueId)
        {
            List<Layout> ret = new List<Layout>();
            foreach (Layout v in layoutInMemoryStorage.Values)
                if (v.VenueId == venueId) ret.Add(v);

            return ret;
        }

        public void DeleteLayout(int id)
        {
            layoutInMemoryStorage.Remove(id);
        }

        public Seat GetSeatById(int id)
        {
            return seatInMemoryStorage[id];
        }

        public void CreateSeat(Seat item)
        {
            if (seatInMemoryStorage.Keys.Count == 0) item.Id = 1;
            else item.Id = seatInMemoryStorage.Keys.Max() + 1;
            seatInMemoryStorage.Add(item.Id, item);
        }

        public void UpdateSeat(Seat item)
        {
            seatInMemoryStorage[item.Id] = item;
        }

        public void DeleteSeat(int id)
        {
            seatInMemoryStorage.Remove(id);
        }

        public List<Seat> GetAllSeatsByAreaId(int areaId)
        {
            List<Seat> ret = new List<Seat>();
            foreach (Seat v in seatInMemoryStorage.Values)
                if (v.AreaId == areaId) ret.Add(v);

            return ret;
        }

        public Venue GetVenueById(int id)
        {
            return venueInMemoryStorage[id];
        }

        public Venue GetVenueByName(string name)
        {
            foreach (Venue v in venueInMemoryStorage.Values)
                if (v.Name == name) return v;
            return null;
        }

        public Venue GetVenueByLayoutId(int layoutId)
        {
            return venueInMemoryStorage[layoutInMemoryStorage[layoutId].VenueId];
        }

        public void CreateVenue(Venue item)
        {
            if (venueInMemoryStorage.Keys.Count == 0) item.Id = 1;
            else item.Id = venueInMemoryStorage.Keys.Max() + 1;
            venueInMemoryStorage.Add(item.Id, item);
        }

        public void UpdateVenue(Venue item)
        {
            venueInMemoryStorage[item.Id] = item;
        }

        public void DeleteVenue(int id)
        {
            venueInMemoryStorage.Remove(id);
        }

        public void DeleteAllVenue()
        {
            areaInMemoryStorage.Clear();
            eventAreaInMemoryStorage.Clear();
            eventInMemoryStorage.Clear();
            eventSeatInMemoryStorage.Clear();
            layoutInMemoryStorage.Clear();
            seatInMemoryStorage.Clear();
            venueInMemoryStorage.Clear();
        }
    }
}
