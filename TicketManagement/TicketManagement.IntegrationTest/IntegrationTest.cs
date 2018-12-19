using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementData.Entities;
using TicketManagementData.Repository;

namespace TicketManagement.IntegrationTest
{
    using NUnit.Framework;
    using TicketManagementBusiness;
    using TicketManagementData;

    [TestFixture]
    public class IntegrationTest
    {
        private SqlTicketRepository sqlRep;
        private Business _business;

        [SetUp]
        public void SetUp()
        {
            sqlRep = new SqlTicketRepository();
            sqlRep.DeleteAllVenue();
            _business = new Business(sqlRep);
        }

        [Test]
        public void Test1()
        {
            /////////////////////////////////////////////
            /// Venue part
            /// 

            Venue[] _venue = new Venue[]
            {
                new Venue("Venue1_d", "Venue1_n", "", ""),
                new Venue("Venue2_d", "Venue2_n", "", "")
            };
            foreach (Venue v in _venue)
                Assert.AreEqual(0, _business.CreateVenue(v));

            // check unique name
            Venue v3 = new Venue("Venue3_d", "Venue1_n", "", "");
            Assert.AreNotEqual(0, _business.CreateVenue(v3));

            // set not unique name
            _venue[1].Name = "Venue1_n";
            Assert.AreNotEqual(0, _business.UpdateVenue(_venue[1]));

            // set unique name
            _venue[1].Name = "Venue1_n_update";
            Assert.AreEqual(0, _business.UpdateVenue(_venue[1]));


            /////////////////////////////////////////////
            /// Layout part
            /// 

            Layout[] _layout = new Layout[]
            {
                new Layout(_venue[0].Id, "Layout1_d", "Layout1_name"),
                new Layout(_venue[0].Id, "Layout2_d", "Layout2_name"),
                new Layout(_venue[1].Id, "Layout2_d", "Layout2_name")
            };
            foreach (Layout l in _layout)
                Assert.AreEqual(0, _business.CreateLayout(l));

            // layout name should me unique in venue
            Layout l4 = new Layout(_venue[0].Id, "Layout4_d", "Layout1_name");
            Assert.AreNotEqual(0, _business.CreateLayout(l4));

            // event can't be created without any seats;
            Event _e = new Event("Event1_name", "Event1_desc", _layout[0].Id, DateTime.Today.AddDays(2));
            Assert.AreNotEqual(0, _business.CreateEvent(_e));


            /////////////////////////////////////////////
            /// Area part
            /// 

            Area[] _area = new Area[]
            {
                new Area(_layout[0].Id, "Area1_d", 1, 1),
                new Area(_layout[0].Id, "Area2_d", 2, 2),
                new Area(_layout[0].Id, "Area3_d", 3, 3),
                new Area(_layout[1].Id, "Area4_d", 4, 4),
            };
            foreach (Area a in _area)
            {
                Assert.AreEqual(0, _business.CreateArea(a));

                for (int i = 0; i < 6; i++)
                {
                    Seat _seat = new Seat(a.Id, i, i);
                    Assert.AreEqual(0, _business.CreateSeat(_seat));
                }

                // row and number should be unique for area;
                Seat _s = new Seat(a.Id, 2, 2);
                Assert.AreNotEqual(0, _business.CreateSeat(_s));
            }

            // area description should be unique in layout
            Area a5 = new Area(_layout[0].Id, "Area2_d", 5, 5);
            Assert.AreNotEqual(0, _business.CreateArea(a5));


            Event[] _event = new Event[]
            {
                new Event("Event1_name", "Event1_desc", _layout[0].Id, DateTime.Today.AddDays(2)),
                new Event("Event2_name", "Event2_desc", _layout[0].Id, DateTime.Today.AddDays(3)),
                new Event("Event3_name", "Event3_desc", _layout[1].Id, DateTime.Today.AddDays(4)),
            };
            foreach (Event e in _event)
                Assert.AreEqual(0, _business.CreateEvent(e));

            Assert.AreEqual(0, _business.DeleteEvent(_event[2].Id));

            _event[0].Description = "Event1_desc_update";
            _event[0].Name = "Event1_name_update";
            _event[0].StartDate = DateTime.Today.AddDays(5);
            Assert.AreEqual(0, _business.UpdateEvent(_event[0]));
        }

        [TearDown]
        public void TearDown()
        {
        }
    }
}
