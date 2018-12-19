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
        private const int VenueErrorUniqueName = VenueError + 1;

        private const int LayoutError = 200;
        private const int LayoutErrorUniqueName = LayoutError + 1;

        private const int AreaError = 300;
        private const int AreaErrorUniqueDescription = AreaError + 1;

        private const int SeatError = 400;
        private const int SeatErrorUniqueRowNumber = SeatError + 1;

        private ITicketRepository ticketRep;

        public int lastError = 0;

        private static Dictionary<int, string> error = new Dictionary<int, string>()
        {
            { EventErrorSeats, "Event can't be created without any seats" },
            { EventErrorSameTime, "Can't create event for the same venue in the same time" },
            { EventErrorPast, "Can't create event in the past" },

            { VenueErrorUniqueName, "Venue must have unique name" },

            { LayoutErrorUniqueName, "layout name should me unique in venue" },

            { AreaErrorUniqueDescription, "Area description should be unique in layout"},

            { SeatErrorUniqueRowNumber, "Seat row and number should be unique for area"}
        };

        public Business(ITicketRepository ticketRep)
        {
            this.ticketRep = ticketRep;
        }

        public string GetErrorDescription(int idError)
        {
            if (error.ContainsKey(idError)) return error[idError];
            return "";
        }

        private int ValidateVenue(Venue vn)
        {
            Venue chVn = ticketRep.GetVenueByName(vn.Name);

            if (chVn != null && chVn.Id != vn.Id)
            {
                lastError = VenueErrorUniqueName;
                return lastError;
            }

            return 0;
        }

        private int ValidateEvent(Event ev)
        {
            // check time
            if (ev.StartDate < DateTime.Now)
            {
                lastError = EventErrorPast;
                return lastError;
            }

            // check that we do not create event for the same venue in the same time.
            Venue vn = ticketRep.GetVenueByLayoutId(ev.LayoutId);
            List<Event> lEv = ticketRep.GetAllEventsByVenueId(vn.Id);
            foreach (Event evF in lEv)
            {
                if (evF.StartDate == ev.StartDate && evF.Id != ev.Id)
                {
                    lastError = EventErrorSameTime;
                    return lastError;
                }
            }

            // event can't be created without any seats
            bool isFind = false;
            List<Area> lArea = ticketRep.GetAllAreasByLayoutId(ev.LayoutId);
            foreach (Area _area in lArea)
            {
                List<Seat> lSeat = ticketRep.GetAllSeatsByAreaId(_area.Id);
                if (lSeat.Count > 0)
                {
                    isFind = true;
                    break;
                }
            }
            if (!isFind)
            {
                lastError = EventErrorSeats;
                return lastError;
            }

            return 0;
        }

        private int ValidateLayout(Layout lay)
        {
            List<Layout> chLay = ticketRep.GetAllLayoutsByVenueId(lay.VenueId);

            foreach (var la in chLay)
            {
                if (la.Name == lay.Name && la.Id != lay.Id)
                {
                    lastError = LayoutErrorUniqueName;
                    return lastError;
                }
            }

            return 0;
        }

        private int ValidateArea(Area ar)
        {
            List<Area> chAr = ticketRep.GetAllAreasByLayoutId(ar.LayoutId);

            foreach (var ar1 in chAr)
            {
                if ( ar1.Description == ar.Description && ar1.Id!=ar.Id )
                {
                    lastError = AreaErrorUniqueDescription;
                    return lastError;
                }
            }

            return 0;
        }

        private int ValidateSeat(Seat st)
        {
            List<Seat> chSeat = ticketRep.GetAllSeatsByAreaId(st.AreaId);
            foreach (var chS in chSeat)
            {
                if (chS.Row == st.Row && chS.Number == st.Number && chS.Id != st.Id)
                {
                    lastError = SeatErrorUniqueRowNumber;
                    return lastError;
                }
            }

            return 0;
        }

        public int CreateEvent(Event ev)
        {
            int ret = ValidateEvent(ev);
            if (ret != 0) return ret;

            ticketRep.CreateEvent(ev);
            return 0;
        }

        public int UpdateEvent(Event ev)
        {
            int ret = ValidateEvent(ev);
            if (ret != 0) return ret;

            ticketRep.UpdateEvent(ev);
            return 0;
        }

        public int DeleteEvent(int idEvent)
        {
            ticketRep.DeleteEvent(idEvent);
            return 0;
        }

        public int CreateVenue(Venue vn)
        {
            int ret = ValidateVenue(vn);
            if (ret != 0) return ret;

            ticketRep.CreateVenue(vn);
            return 0;
        }

        public int UpdateVenue(Venue vn)
        {
            int ret = ValidateVenue(vn);
            if (ret != 0) return ret;

            ticketRep.UpdateVenue(vn);
            return 0;
        }

        public int DeleteVenue(int idVenue)
        {
            ticketRep.DeleteVenue(idVenue);
            return 0;
        }

        public int CreateSeat(Seat seat)
        {
            int ret = ValidateSeat(seat);
            if (ret != 0) return ret;

            ticketRep.CreateSeat(seat);
            return 0;
        }

        public int UpdateSeat(Seat seat)
        {
            int ret = ValidateSeat(seat);
            if (ret != 0) return ret;

            ticketRep.UpdateSeat(seat);
            return 0;
        }

        public int DeleteSeat(int idSeat)
        {
            ticketRep.DeleteSeat(idSeat);
            return 0;
        }

        public int CreateArea(Area ar)
        {
            int ret = ValidateArea(ar);
            if (ret != 0) return ret;

            ticketRep.CreateArea(ar);
            return 0;
        }

        public int UpdateArea(Area ar)
        {
            int ret = ValidateArea(ar);
            if (ret != 0) return ret;

            ticketRep.UpdateArea(ar);
            return 0;
        }

        public int DeleteArea(int idArea)
        {
            ticketRep.DeleteArea(idArea);
            return 0;
        }

        public int CreateLayout(Layout lay)
        {
            int ret = ValidateLayout(lay);
            if (ret != 0) return ret;

            ticketRep.CreateLayout(lay);
            return 0;
        }

        public int UpdateLayout(Layout lay)
        {
            int ret = ValidateLayout(lay);
            if (ret != 0) return ret;

            ticketRep.UpdateLayout(lay);
            return 0;
        }

        public int DeleteLayout(int idlay)
        {
            ticketRep.DeleteLayout(idlay);
            return 0;
        }

    }
}
