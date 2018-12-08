using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using TicketManagementData.Entities;

namespace TicketManagementData.Repository
{
    internal class SqlVenueRepository:IRepository<Venue>
    {
        public Venue GetById(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandText = "select*from area where id = @id";
            Venue ven = new Venue();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    ven.Description =(string)reader[1];
                    ven.Adress = (string) reader[2];
                    ven.Phone = (int) reader[3];
                }
            }

            return ven;
        }

        public void Create(Venue item)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.Add("@description", item.Description);
            cmd.Parameters.Add("@adress", item.Adress);
            cmd.Parameters.Add("@phone", item.Phone);
            cmd.CommandText = "Insert venue(description,adress,phone)output inserted.id values(@description,@adress,@phone)";
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
                item.Id = (int)reader[0];
        }

        public void Update(Venue item)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.Add("@description", item.Description);
            cmd.Parameters.Add("@adress", item.Adress);
            cmd.Parameters.Add("@phone", item.Phone);
            cmd.CommandText = "update venue set description = @description, adress = @adress,phone=@phone where id=@id";
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandText = "delete area where id = @id";
            cmd.ExecuteNonQuery();
        }
    }
}
