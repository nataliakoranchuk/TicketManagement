using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagementData.Repository
{
    interface IRepository<T>
        where T : class
    {
        T GetById(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
       

    }
}
