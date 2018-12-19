using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagementData.Entities
{
    public class Venue
    {
        private int id = -1;
        private string description;
        private string name;
        private string address;
        private string phone;

        public Venue()
        {
        }

        public Venue(string description, string name, string address, string phone)
        {
            this.description = description;
            this.name = name;
            this.address = address;
            this.phone = phone;
        }

        public int Id { get => id; set => id = value; }
        public string Description { get => description; set => description = value; }
        public string Address { get => address; set => address = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Name { get => name; set => name = value; }
    }
}
