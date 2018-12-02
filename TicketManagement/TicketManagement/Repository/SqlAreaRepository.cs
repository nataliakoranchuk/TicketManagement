using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagement.Repository
{
    class SqlAreaRepository : IRepository<Area>
    {
        public Area GetById(int id)
        {
            return new Area();
        }

        public void Create(Area item)
        {
        }

        public void Save()
        {
        }

        public void Update(Area item)
        {
        }

        public void Delete(int id)
        {
        }
    }
}
