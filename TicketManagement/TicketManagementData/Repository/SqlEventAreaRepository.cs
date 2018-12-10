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
            cmd.Parameters.AddWithValue("@eventId", item.EventId);
            cmd.Parameters.AddWithValue("@description", item.Description);
            cmd.Parameters.AddWithValue("@coordX", item.CoordX);
            cmd.Parameters.AddWithValue("@coordY", item.CoordY);
            cmd.Parameters.AddWithValue("@price", item.Price);
            cmd.CommandText = "Insert into eventArea(eventId,description,coordX,coordY,price) output inserted.id values(@eventId,@description,@coordX,@coordY,@price)";
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                    item.Id = (int) reader[0];
            }
        }

        public void Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandText = "delete from eventArea where id = @id";
            cmd.ExecuteNonQuery();
        }

        public EventArea GetById(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandText = "select eventId, description, coordX, coordY, price from eventArea where id = @id";
            EventArea ev = null;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    ev = new EventArea();
                    ev.EventId = (int)reader[0];
                    ev.Description = (string) reader[1];
                    ev.CoordX = (int) reader[2];
                    ev.CoordY = (int) reader[3];
                    ev.Price = (float) reader[4];
                }
            }

            return ev;
        }

        public void Update(EventArea item)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.AddWithValue("@id", item.Id);
            cmd.Parameters.AddWithValue("@eventId", item.EventId);
            cmd.Parameters.AddWithValue("description", item.Description);
            cmd.Parameters.AddWithValue("@coordX", item.CoordX);
            cmd.Parameters.AddWithValue("@coordY", item.CoordY);
            cmd.Parameters.AddWithValue("@price", item.Price);
            cmd.CommandText ="update eventArea set eventId=@eventId,description=@description,coordX=@coordX,coordY=@coordY where id=@id";
            cmd.ExecuteNonQuery();
        }
    }
}
