using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementData.Entities;

namespace TicketManagementData.Repository
{
    public class SqlEventRepository : IRepository<Event>
    {
        public void Create(Event item)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.AddWithValue("@layoutId_p", item.LayoutId);
            cmd.Parameters.AddWithValue("@description_p", item.Description);
            cmd.Parameters.AddWithValue("@name_p", item.Name);
            cmd.CommandText = "EXEC [EventCreate] @name = @name_p, @description = @description_p, @layoutId = @layoutId_p";
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
            cmd.Parameters.AddWithValue("@id_p", id);
            cmd.CommandText = "EXEC [EventDelete] @id = @id_p";
            cmd.ExecuteNonQuery();
        }

        public Event GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Event item)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.AddWithValue("@id_p", item.Id);
            cmd.Parameters.AddWithValue("@layoutId_p", item.LayoutId);
            cmd.Parameters.AddWithValue("@description_p", item.Description);
            cmd.Parameters.AddWithValue("@name_p", item.Name);
            cmd.CommandText = "EXEC [EventUpdate] @id = @id_p, @name = @name_p, @description = @description_p, @layoutId = @layoutId_p";
            cmd.ExecuteNonQuery();
        }
    }
}
