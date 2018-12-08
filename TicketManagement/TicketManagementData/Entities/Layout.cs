using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagementData.Entities
{
    public class Layout
    {
        private int id;
        private int venueId;
        private string description;

        public Layout()
        {
        }

        public Layout(int id, int venueId, string description)
        {
            this.id = id;
            this.venueId = venueId;
            this.description = description;
        }

        public int Id { get => id; set => id = value; }
        public int VenueId { get => venueId; set => venueId = value; }
        public string Description { get => description; set => description = value; }
    }
}
