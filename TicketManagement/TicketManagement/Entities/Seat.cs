using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagement
{
    class Seat
    {
        private int id;
        private int areaId;
        private int row;
        private int number;

        public int Id { get => id; set => id = value; }
        public int AreaId { get => areaId; set => areaId = value; }
        public int Row { get => row; set => row = value; }
        public int Number { get => number; set => number = value; }
    }
}
