﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagement
{
    class Venue
    {
        private int id;
        private string description;
        private string adress;
        private int phone;

        public int Id { get => id; set => id = value; }
        public string Description { get => description; set => description = value; }
        public string Adress { get => adress; set => adress = value; }
        public int Phone { get => phone; set => phone = value; }
    }
}
