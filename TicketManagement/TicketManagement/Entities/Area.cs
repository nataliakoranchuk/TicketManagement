using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagement
{
    class Area
    {
        private int id;
        private int layoutId;
        private string description;
        private int coordX;
        private int coordY;


        public int Id { get => id; set => id = value; }
        public int LayoutId { get => layoutId; set => layoutId = value; }
        public string Description { get => description; set => description = value; }
        public int CoordX { get => coordX; set => coordX = value; }
        public int CoordY { get => coordY; set => coordY = value; }
    }
}
