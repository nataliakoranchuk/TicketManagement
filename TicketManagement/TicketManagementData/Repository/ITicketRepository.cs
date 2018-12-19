using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementData.Entities;

namespace TicketManagementData.Repository
{
    public interface ITicketRepository
    {
        Area GetAreaById(int id);

        List<Area> GetAllAreasByLayoutId(int layoutId);

        void CreateArea(Area item);

        void UpdateArea(Area item);

        void DeleteArea(int id);

        EventArea GetEventAreaById(int id);

        void CreateEventArea(EventArea item);

        void UpdateEventArea(EventArea item);

        void DeleteEventArea(int id);

        Event GetEventById(int id);

        List<Event> GetAllEventsByVenueId(int venueId);

        void CreateEvent(Event item);

        void UpdateEvent(Event item);

        void DeleteEvent(int id);

        EventSeat GetEventSeatById(int id);

        void CreateEventSeat(EventSeat item);

        void UpdateEventSeat(EventSeat item);

        void DeleteEventSeat(int id);

        Layout GetLayoutById(int id);

        void CreateLayout(Layout item);

        void UpdateLayout(Layout item);

        List<Layout> GetAllLayoutsByVenueId(int venueId);

        void DeleteLayout(int id);

        Seat GetSeatById(int id);

        void CreateSeat(Seat item);

        void UpdateSeat(Seat item);

        void DeleteSeat(int id);

        List<Seat> GetAllSeatsByAreaId(int areaId);

        Venue GetVenueById(int id);

        Venue GetVenueByName(string name);

        Venue GetVenueByLayoutId(int layoutId);

        void CreateVenue(Venue item);

        void UpdateVenue(Venue item);

        void DeleteVenue(int id);

        void DeleteAllVenue();
    }
}
