using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagementData.Entities
{
    class EventArea
    {
        private int id;
        private int eventId;
        private string description;
        private int coordX;
        private int coordY;
        private float price;

        public int Id { get => id; set => id = value; }
        public int EventId { get => eventId; set => eventId = value; }
        public string Description { get => description; set => description = value; }
        public int CoordX { get => coordX; set => coordX = value; }
        public int CoordY { get => coordY; set => coordY = value; }
        public float Price { get => price; set => price = value; }
    }
}
