using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagement
{
    class Layout
    {
        private int id;
        private int vanueId;
        private string description;

        public int Id { get => id; set => id = value; }
        public int VanueId { get => vanueId; set => vanueId = value; }
        public string Description { get => description; set => description = value; }
    }
}
