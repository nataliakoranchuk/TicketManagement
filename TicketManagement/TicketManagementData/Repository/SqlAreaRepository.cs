using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementData.Entities;

namespace TicketManagementData.Repository
{
    public class SqlAreaRepository :IRepository<Area>
    {
   
        public Area GetById(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandText = "select layoutId,description,,coordX,coordY from area where id = @id";
            Area ar = null;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    ar = new Area();
                    ar.LayoutId =(int)reader[0];
                    ar.Description=(string)reader[1];
                    ar.CoordX = (int) reader[2];
                    ar.CoordY = (int) reader[3];
                    // Console.Read();
                }
            }

            return ar;
        }

        public void Create(Area item)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.AddWithValue("@layoutId",item.LayoutId);
            cmd.Parameters.AddWithValue("@description", item.Description);
            cmd.Parameters.AddWithValue("@coordX", item.CoordX);
            cmd.Parameters.AddWithValue("@coordY", item.CoordY);
            cmd.CommandText = "Insert into area(layoutId,description,coordX,coordY) output inserted.id values(@layoutId,@description,@coordX,@coordY)";
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                    item.Id = (int) reader[0];
            }
        }

        public void Save()
        {

        }

        public void Update(Area item) 
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.AddWithValue("@id", item.Id);
            cmd.Parameters.AddWithValue("@layoutId", item.LayoutId);
            cmd.Parameters.AddWithValue("@description", item.Description);
            cmd.Parameters.AddWithValue("@coordX", item.CoordX);
            cmd.Parameters.AddWithValue("@coordY", item.CoordY);
            cmd.CommandText = "update area set layoutId =@layoutId,description=@description,coordX=@coordX,coordY=@coordY where id=@id";
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandText = "delete from area where id = @id";
            cmd.ExecuteNonQuery();
        }
    }
}
