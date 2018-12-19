using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagementData.Entities
{
    public class Event
    {
        private int id = -1;
        private string name;
        private string description;
        private int layoutId;
        private DateTime startDate;

        public Event()
        {
        }

        public Event(string name, string description, int layoutId, DateTime startDate)
        {
            this.name = name;
            this.description = description;
            this.layoutId = layoutId;
            this.startDate = startDate;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public int LayoutId { get => layoutId; set => layoutId = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
    }
}
