using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagementData.Entities
{
    public class EventSeat
    {
        private int id = -1;
        private int eventAreaId;
        private int row;
        private int number;
        private string state;

        public EventSeat()
        {
        }

        public EventSeat(int eventAreaId,int row,int number,string state)
        {
            this.eventAreaId = eventAreaId;
            this.row = row;
            this.number = number;
            this.state = state;
        }

        public int Id { get => id; set => id = value; }
        public int EventAreaId { get => eventAreaId; set => eventAreaId = value; }
        public int Row { get => row; set => row = value; }
        public int Number { get => number; set => number = value; }
        public string State { get => state; set => state = value; }
    }
}
