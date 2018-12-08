using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagementData.Entities
{
    internal class EventSeat
    {
        private int id;
        private int eventAreaId;
        private int row;
        private int number;
        private bool state;

        public int Id { get => id; set => id = value; }
        public int EventAreaId { get => eventAreaId; set => eventAreaId = value; }
        public int Row { get => row; set => row = value; }
        public int Number { get => number; set => number = value; }
        public bool State { get => state; set => state = value; }
    }
}
