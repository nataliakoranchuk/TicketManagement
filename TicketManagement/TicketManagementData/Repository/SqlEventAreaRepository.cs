using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementData.Entities;

namespace TicketManagementData.Repository
{
    class SqlEventAreaRepository : IRepository<EventArea>
    {
        public void Create(EventArea item)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.Add("@eventId", item.EventId);
            cmd.Parameters.Add("@description", item.Description);
            cmd.Parameters.Add("@coordX", item.CoordX);
            cmd.Parameters.Add("@coordY", item.CoordY);
            cmd.Parameters.Add("@price", item.Price);
            cmd.CommandText = "Insert into eventArea(eventId,description,coordX,coordY,price) output inserted.id values(@eventId,@description,@coordX,@coordY,@price)";
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
                item.Id = (int)reader[0];
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public EventArea GetById(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandText = "select*from eventArea where id = @id";
            EventArea ev = new EventArea();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    ev.EventId = (int)reader[1];
                    ev.Description = (string) reader[2];
                    ev.CoordX = (int) reader[3];
                    ev.CoordY = (int) reader[4];
                    ev.Price = (float) reader[5];
                }
            }

            return ev;
        }

        public void Update(EventArea item)
        {
            throw new NotImplementedException();
        }
    }
}
