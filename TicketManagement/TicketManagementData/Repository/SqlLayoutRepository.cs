using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using TicketManagementData.Entities;

namespace TicketManagementData.Repository
{
    class SqlLayoutRepository:IRepository<Layout>
    {
        public Layout GetById(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.CommandText = "select*from seat where id = @id";
            Layout layout = null;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    layout = new Layout();
                    layout.VenueId = (int)reader[1];
                    layout.Description =(string)reader[2];
                }
            }

            return layout;
        }

        public void Create(Layout item)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.Add("@venueId", item.VenueId);
            cmd.Parameters.Add("@description", item.Description);
            cmd.CommandText = "Insert into layout(venueId,description)output inserted.id values(@venueId,@description)";
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                    item.Id = (int) reader[0];
            }
        }

        public void Update(Layout item)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.Add("@id", item.Id);
            cmd.Parameters.Add("@venueId", item.VenueId);
            cmd.Parameters.Add("@description",item.Description);
            cmd.CommandText = "update seat layout  where id=@id";
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandText = "delete from layout where id = @id";
            cmd.ExecuteNonQuery();
        }

  
    }
}
