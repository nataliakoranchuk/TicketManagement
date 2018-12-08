using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagementData.Entities
{
    public class Seat
    {
        private int id;
        private int areaId;
        private int row;
        private int number;

        public Seat()
        {
        }

        public Seat(int areaId, int row, int number)
        {
            this.areaId = areaId;
            this.row = row;
            this.number = number;
        }

        public int Id { get => id; set => id = value; }
        public int AreaId { get => areaId; set => areaId = value; }
        public int Row { get => row; set => row = value; }
        public int Number { get => number; set => number = value; }
    }
}
