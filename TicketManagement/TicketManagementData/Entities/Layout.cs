using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagementData.Entities
{
    public class Layout
    {
        private int id = -1;
        private int venueId;
        private string description;
        private string name;

        public Layout()
        {
        }

        public Layout(int venueId, string description, string name)
        {
            this.venueId = venueId;
            this.description = description;
            this.name = name;
        }

        public int Id { get => id; set => id = value; }
        public int VenueId { get => venueId; set => venueId = value; }
        public string Description { get => description; set => description = value; }
        public string Name { get => name; set => name = value; }
    }
}
