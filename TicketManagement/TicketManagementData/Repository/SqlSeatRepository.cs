using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using TicketManagementData.Entities;

namespace TicketManagementData.Repository
{
    public class SqlSeatRepository:IRepository<Seat>
    {

        public Seat GetById(int id)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandText = "select*from seat where id = @id";
            var seat = new Seat();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    seat.AreaId =(int)reader[1];
                    seat.Row = (int)reader[2];
                    seat.Number =(int)reader[3];
                }
            }

            return seat;
        }

        public void Create(Seat item)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.Add("@areaId", item.AreaId);
            cmd.Parameters.Add("@row", item.Row);
            cmd.Parameters.Add("@number",item.Number);
            cmd.CommandText = "Insert into seat(areaId,row,number)output inserted.id values(@areaId,@row,@number)";
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
                item.Id = (int)reader[0];
            reader.Close();

        }

        public void Update(Seat item)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.Add("@id", item.Id);
            cmd.Parameters.Add("@areaId", item.AreaId);
            cmd.Parameters.Add("@row", item.Row);
            cmd.CommandText = "update seat set areaId=@areaId,row=@row where id=@id";
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandText = "delete from seat where id = @id";
            cmd.ExecuteNonQuery();
        }
    }
}
