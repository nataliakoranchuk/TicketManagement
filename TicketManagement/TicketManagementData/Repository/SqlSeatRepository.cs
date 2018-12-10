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
            cmd.CommandText = "select areaId,row,number from seat where id = @id";
            Seat seat = null;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    seat = new Seat();
                    seat.AreaId =(int)reader[0];
                    seat.Row = (int)reader[1];
                    seat.Number =(int)reader[2];
                }
            }

            return seat;
        }

        public void Create(Seat item)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.AddWithValue("@areaId", item.AreaId);
            cmd.Parameters.AddWithValue("@row", item.Row);
            cmd.Parameters.AddWithValue("@number",item.Number);
            cmd.CommandText = "Insert into seat(areaId,row,number) output inserted.id values(@areaId,@row,@number)";
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                    item.Id = (int) reader[0];
            }
        }

        public void Update(Seat item)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.AddWithValue("@id", item.Id);
            cmd.Parameters.AddWithValue("@areaId", item.AreaId);
            cmd.Parameters.AddWithValue("@row", item.Row);
            cmd.Parameters.AddWithValue("@number", item.Number);
            cmd.CommandText = "update seat set areaId=@areaId,row=@row,number=@number where id=@id";
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
