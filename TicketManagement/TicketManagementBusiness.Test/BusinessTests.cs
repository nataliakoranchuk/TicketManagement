using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementBusiness.Test.FakeRepository;
using TicketManagementData.Entities;
using TicketManagementData.Repository;

namespace TicketManagementBusiness.Test
{
    using NUnit.Framework;

    [TestFixture]
    public class BusinessTests
    {
        private ITicketRepository ticketRep;

        private Business _business;

        [SetUp]
        public void Init()
        {
            ticketRep = new FakeTicketRepository();

            _business = new Business(ticketRep);
        }

        /// <summary>
        /// Event can't be created without any seats
        /// </summary>
        [TestCase(0, 0)] // have seats
        [TestCase(1, 1)] // don't have seats
        public void EventTestSeats(int layoutNum, int _areEqual)
        {
            Venue v1 = new Venue("", "A1", "", "");
            ticketRep.CreateVenue(v1);
            Layout[] layout = new Layout[]
            {
                new Layout(v1.Id, "L1_d", "L1"),
                new Layout(v1.Id, "L2_d", "L2")

            };
            ticketRep.CreateLayout(layout[0]);
            ticketRep.CreateLayout(layout[1]);

            Area a1 = new Area(layout[0].Id, "A1", 0, 0);
            Area a2 = new Area(layout[1].Id, "A2", 0, 0);
            ticketRep.CreateArea(a1);
            ticketRep.CreateArea(a2);

            Seat s1 = new Seat(a1.Id, 0, 0);
            ticketRep.CreateSeat(s1);

            Event e1 = new Event("", "", layout[layoutNum].Id, DateTime.Now.AddDays(3));

            if (_areEqual == 0)
                Assert.AreEqual(0, _business.CreateEvent(e1));
            else Assert.AreNotEqual(0, _business.CreateEvent(e1));
        }

        /// <summary>
        /// Is event in the past?
        /// </summary>
        [TestCase(1, 0)] //future
        [TestCase(-1, 1)] //past
        public void EventTestTime1(int _day, int _areEqual)
        {
            Venue v1 = new Venue("", "A1", "", "");
            ticketRep.CreateVenue(v1);
            Layout l1 = new Layout(v1.Id, "", "L1");
            ticketRep.CreateLayout(l1);
            Area a1 = new Area(l1.Id, "A1", 0, 0);
            ticketRep.CreateArea(a1);
            Seat s1 = new Seat(a1.Id, 0, 0);
            ticketRep.CreateSeat(s1);

            Event e1 = new Event("", "", l1.Id, DateTime.Now.AddDays(_day));

            if (_areEqual == 0)
                Assert.AreEqual(0, _business.CreateEvent(e1));
            else Assert.AreNotEqual(0, _business.CreateEvent(e1));
        }

        /// <summary>
        /// The time of event is correct but we try to update and set new time
        /// </summary>
        [TestCase(1, 0)] //future
        [TestCase(-1, 1)] //past
        public void EventTestTime2(int _day, int _areEqual)
        {
            Venue v1 = new Venue("", "A1", "", "");
            ticketRep.CreateVenue(v1);
            Layout l1 = new Layout(v1.Id, "", "L1");
            ticketRep.CreateLayout(l1);
            Area a1 = new Area(l1.Id, "A1", 0, 0);
            ticketRep.CreateArea(a1);
            Seat s1 = new Seat(a1.Id, 0, 0);
            ticketRep.CreateSeat(s1);
            Event e1 = new Event("", "", l1.Id, DateTime.Now.AddDays(3));
            ticketRep.CreateEvent(e1);

            e1.StartDate = DateTime.Now.AddDays(_day);

            if (_areEqual == 0)
                Assert.AreEqual(0, _business.UpdateEvent(e1));
            else Assert.AreNotEqual(0, _business.UpdateEvent(e1));
        }

        /// <summary>
        /// we do not create event for the same venue in the same time
        /// </summary>
        [TestCase(0, 1)] //same time
        [TestCase(1, 0)] //
        [TestCase(2, 0)] //
        public void EventTestVenueTime1(int _d, int _areEqual)
        {
            DateTime[] d = new DateTime[]
            {
                DateTime.Now.AddDays(1),
                DateTime.Now.AddDays(2),
                DateTime.Now.AddDays(3)
            };

            Venue v1 = new Venue("", "A1", "", "");
            ticketRep.CreateVenue(v1);
            Layout l1 = new Layout(v1.Id, "", "L1");
            ticketRep.CreateLayout(l1);
            Area a1 = new Area(l1.Id, "A1", 0, 0);
            ticketRep.CreateArea(a1);
            Seat s1 = new Seat(a1.Id, 0, 0);
            ticketRep.CreateSeat(s1);
            Event e1 = new Event("", "", l1.Id, d[0]);
            ticketRep.CreateEvent(e1);

            Venue v2 = new Venue("", "A2", "", "");
            ticketRep.CreateVenue(v2);
            Layout l2 = new Layout(v2.Id, "", "L2");
            ticketRep.CreateLayout(l2);
            Area a2 = new Area(l2.Id, "A1", 0, 0);
            ticketRep.CreateArea(a2);
            Seat s2 = new Seat(a2.Id, 0, 0);
            ticketRep.CreateSeat(s2);
            Event e2 = new Event("", "", l2.Id, d[1]);
            ticketRep.CreateEvent(e2);

            Event e3 = new Event("", "", l1.Id, d[_d]);

            if (_areEqual == 0)
                Assert.AreEqual(0, _business.CreateEvent(e3));
            else Assert.AreNotEqual(0, _business.CreateEvent(e3));
        }

        /// <summary>
        /// All events are correct and now we try to change some event
        /// </summary>
        [TestCase(0, 0)] //
        [TestCase(1, 1)] //same time
        [TestCase(2, 0)] //
        public void EventTestVenueTime2(int _d, int _areEqual)
        {
            DateTime[] d = new DateTime[]
            {
                DateTime.Now.AddDays(1),
                DateTime.Now.AddDays(2),
                DateTime.Now.AddDays(3)
            };

            Venue v1 = new Venue("", "A1", "", "");
            ticketRep.CreateVenue(v1);
            Layout l1 = new Layout(v1.Id, "", "L1");
            ticketRep.CreateLayout(l1);
            Area a1 = new Area(l1.Id, "A1", 0, 0);
            ticketRep.CreateArea(a1);
            Seat s1 = new Seat(a1.Id, 0, 0);
            ticketRep.CreateSeat(s1);
            Event e1 = new Event("", "", l1.Id, d[0]);
            ticketRep.CreateEvent(e1);

            Venue v2 = new Venue("", "A2", "", "");
            ticketRep.CreateVenue(v2);
            Layout l2 = new Layout(v2.Id, "", "L2");
            ticketRep.CreateLayout(l2);
            Area a2 = new Area(l2.Id, "A1", 0, 0);
            ticketRep.CreateArea(a2);
            Seat s2 = new Seat(a2.Id, 0, 0);
            ticketRep.CreateSeat(s2);
            Event e2 = new Event("", "", l2.Id, d[1]);
            ticketRep.CreateEvent(e2);
            Event e3 = new Event("", "", l2.Id, DateTime.Now.AddDays(10));
            ticketRep.CreateEvent(e3);

            e3.StartDate = d[_d];

            if (_areEqual == 0)
                Assert.AreEqual(0, _business.UpdateEvent(e3));
            else Assert.AreNotEqual(0, _business.UpdateEvent(e3));
        }

        /// <summary>
        /// The names are not unique?
        /// </summary>
        [TestCase("A1", 1)] //not unique
        [TestCase("A2", 0)] //unique
        public void VenueTest1(string _name, int _areEqual)
        {
            Venue v1 = new Venue("", "A1", "", "");
            ticketRep.CreateVenue(v1);

            Venue v2 = new Venue("", _name, "", "");

            if (_areEqual == 0)
                Assert.AreEqual(0, _business.CreateVenue(v2));
            else Assert.AreNotEqual(0, _business.CreateVenue(v2));
        }

        /// <summary>
        /// The names are unique but we try to update and set name to not unique
        /// </summary>
        [TestCase("A1", 1)] //not unique
        [TestCase("A2", 0)] //unique
        public void VenueTest2(string _name, int _areEqual)
        {
            Venue v1 = new Venue("", "A1", "", "");
            Venue v2 = new Venue("", "A3", "", "");
            ticketRep.CreateVenue(v1);
            ticketRep.CreateVenue(v2);
            v2.Name = _name;

            if (_areEqual == 0)
                Assert.AreEqual(0, _business.UpdateVenue(v2));
            else Assert.AreNotEqual(0, _business.UpdateVenue(v2));
        }

        /// <summary>
        /// The names are not unique inside Venue?
        /// </summary>
        [TestCase("L1", 1)] //not unique
        [TestCase("L2", 0)] //unique
        public void LayoutTest1(string _name, int _areEqual)
        {
            Venue v1 = new Venue("", "A1", "", "");
            Venue v2 = new Venue("", "A2", "", "");
            ticketRep.CreateVenue(v1);
            ticketRep.CreateVenue(v2);

            Layout l1 = new Layout(v1.Id, "", "L1");
            Layout l2 = new Layout(v2.Id, "", "L2");
            ticketRep.CreateLayout(l1);
            ticketRep.CreateLayout(l2);

            Layout l3 = new Layout(v1.Id, "", _name);

            if (_areEqual == 0)
                Assert.AreEqual(0, _business.CreateLayout(l3));
            else Assert.AreNotEqual(0, _business.CreateLayout(l3));
        }

        /// <summary>
        /// The names are unique inside Venue but we try to update and set name to not unique
        /// </summary>
        [TestCase("L1", 0)] //unique
        [TestCase("L2", 1)] //not unique
        public void LayoutTest2(string _name, int _areEqual)
        {
            Venue v1 = new Venue("", "A1", "", "");
            Venue v2 = new Venue("", "A2", "", "");
            ticketRep.CreateVenue(v1);
            ticketRep.CreateVenue(v2);

            Layout l1 = new Layout(v1.Id, "", "L1");
            Layout l2 = new Layout(v2.Id, "", "L2");
            Layout l3 = new Layout(v2.Id, "", "L3");
            ticketRep.CreateLayout(l1);
            ticketRep.CreateLayout(l2);
            ticketRep.CreateLayout(l3);
            l3.Name = _name;

            if (_areEqual == 0)
                Assert.AreEqual(0, _business.UpdateLayout(l3));
            else Assert.AreNotEqual(0, _business.UpdateLayout(l3));
        }

        /// <summary>
        /// The description are not unique inside Layout?
        /// </summary>
        [TestCase("A1", 1)] //not unique
        [TestCase("A2", 0)] //unique
        public void AreaTest1(string _description, int _areEqual)
        {
            Layout l1 = new Layout(1, "", "L1");
            Layout l2 = new Layout(1, "", "L2");
            ticketRep.CreateLayout(l1);
            ticketRep.CreateLayout(l2);

            Area a1 = new Area(l1.Id, "A1", 0, 0);
            Area a2 = new Area(l2.Id, "A2", 0, 0);
            ticketRep.CreateArea(a1);
            ticketRep.CreateArea(a2);

            Area a3 = new Area(l1.Id, _description, 0, 0);

            if (_areEqual == 0)
                Assert.AreEqual(0, _business.CreateArea(a3));
            else Assert.AreNotEqual(0, _business.CreateArea(a3));
        }

        /// <summary>
        /// The description are unique inside Layout but we try to update and set description to not unique
        /// </summary>
        [TestCase("A1", 0)] //unique
        [TestCase("A2", 1)] //not unique
        public void AreaTest2(string _description, int _areEqual)
        {
            Layout l1 = new Layout(1, "", "L1");
            Layout l2 = new Layout(1, "", "L2");
            ticketRep.CreateLayout(l1);
            ticketRep.CreateLayout(l2);

            Area a1 = new Area(l1.Id, "A1", 0, 0);
            Area a2 = new Area(l2.Id, "A2", 0, 0);
            Area a3 = new Area(l2.Id, "A3", 0, 0);
            ticketRep.CreateArea(a1);
            ticketRep.CreateArea(a2);
            ticketRep.CreateArea(a3);
            a3.Description = _description;

            if (_areEqual == 0)
                Assert.AreEqual(0, _business.UpdateArea(a3));
            else Assert.AreNotEqual(0, _business.UpdateArea(a3));
        }

        /// <summary>
        /// The row and number are unique inside Area?
        /// </summary>
        [TestCase(1, 1, 1)] //not unique
        [TestCase(1, 2, 0)] //unique
        [TestCase(2, 1, 0)] //unique
        [TestCase(2, 2, 0)] //unique
        public void SeatTest1(int _row, int _number, int _areEqual)
        {
            Area a1 = new Area(1, "A1", 0, 0);
            Area a2 = new Area(1, "A2", 0, 0);
            ticketRep.CreateArea(a1);
            ticketRep.CreateArea(a2);

            Seat s1 = new Seat(a1.Id, 1, 1);
            Seat s2 = new Seat(a2.Id, 2, 2);
            ticketRep.CreateSeat(s1);
            ticketRep.CreateSeat(s2);

            Seat s3 = new Seat(a1.Id, _row, _number);

            if(_areEqual == 0)
                Assert.AreEqual(0, _business.CreateSeat(s3));
            else Assert.AreNotEqual(0, _business.CreateSeat(s3));
        }

        /// <summary>
        /// The row and number are unique inside Area but we try to update and set it to not unique
        /// </summary>
        [TestCase(1, 1, 0)] //unique
        [TestCase(1, 2, 0)] //unique
        [TestCase(2, 1, 0)] //unique
        [TestCase(2, 2, 1)] //not unique
        public void SeatTest2(int _row, int _number, int _areEqual)
        {
            Area a1 = new Area(1, "A1", 0, 0);
            Area a2 = new Area(1, "A2", 0, 0);
            ticketRep.CreateArea(a1);
            ticketRep.CreateArea(a2);

            Seat s1 = new Seat(a1.Id, 1, 1);
            Seat s2 = new Seat(a2.Id, 2, 2);
            Seat s3 = new Seat(a2.Id, 3, 3);
            ticketRep.CreateSeat(s1);
            ticketRep.CreateSeat(s2);
            ticketRep.CreateSeat(s3);
            s3.Row = _row;
            s3.Number = _number;

            if (_areEqual == 0)
                Assert.AreEqual(0, _business.UpdateSeat(s3));
            else Assert.AreNotEqual(0, _business.UpdateSeat(s3));
        }
    }
}
