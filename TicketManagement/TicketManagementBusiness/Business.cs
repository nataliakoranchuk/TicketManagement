using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementData.Entities;
using TicketManagementData.Repository;

namespace TicketManagementBusiness
{
    public class Business
    {
        private const int EventError = 0;
        private const int EventErrorSeats = EventError + 1;
        private const int EventErrorSameTime = EventError + 2;
        private const int EventErrorPast = EventError + 3;

        private const int VenueError = 100;
        private const int LayoutError = 200;
        private const int AreaError = 300;
        private const int SeatError = 400;

        private Dictionary<int, string> error = new Dictionary<int, string>()
        {
            {EventErrorSeats, "Event can't be created without any seats"},
            {EventErrorSameTime, "Can't create event for the same venue in the same time"},
            {EventErrorPast, "Can't create event in the past"},
        };

        public int CreateEvent(Event ev)
        {
            return 0;
        }
    }
}
