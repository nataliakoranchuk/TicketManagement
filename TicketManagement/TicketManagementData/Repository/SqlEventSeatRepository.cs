using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using TicketManagementData.Entities;

namespace TicketManagementData.Repository
{
    class SqlEventSeatRepository : IRepository<EventSeat>
    {
        public void Create(EventSeat item)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.AddWithValue("@eventAreaId", item.EventAreaId);
            cmd.Parameters.AddWithValue("@row", item.Row);
            cmd.Parameters.AddWithValue("@number", item.Number);
            cmd.Parameters.AddWithValue("@state", item.State);
            cmd.CommandText = "Insert into eventSeat(eventAreaId,row,number,state) output inserted.id values(@eventId,@row,@number,@state)";
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                    item.Id = (int)reader[0];
            }
        }

        public void Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandText = "delete from eventSeat where id = @id";
            cmd.ExecuteNonQuery();
        }

        public EventSeat GetById(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandText = "select eventAreaId,row,number,state from eventArea where id = @id";
            EventSeat ev = null;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    ev = new EventSeat();
                    ev.EventAreaId = (int) reader[0];
                    ev.Row = (int) reader[1];
                    ev.Number = (int) reader[2];
                    ev.State = (string) reader[3];
                }
            }

            return ev;
        }
        public void Update(EventSeat item)
        {
           SqlCommand cmd = new SqlCommand();
           cmd.Connection = ConnectionDB.getInstance().SqlConnections;
           cmd.Parameters.AddWithValue("@id", item.Id);
            cmd.Parameters.AddWithValue("@eventAreaId", item.EventAreaId);
            cmd.Parameters.AddWithValue("@row", item.Row);
            cmd.Parameters.AddWithValue("@number", item.Number);
            cmd.Parameters.AddWithValue("@state", item.State);
            cmd.CommandText ="update eventSeat set eventAreaId=@eventAreaId,row=@row,number=@number,state=@state where id =@id";
            cmd.ExecuteNonQuery();

        }
    }
}
