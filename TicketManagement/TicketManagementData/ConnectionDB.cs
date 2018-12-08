using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TicketManagementData.Entities
{
    public class ConnectionDB
    {
        private SqlConnection sqlConnections;
        public SqlConnection SqlConnections { get => sqlConnections; set => sqlConnections = value; }

        // singelton
        private static ConnectionDB instance =null;

        private ConnectionDB()
        {
        }

        public static ConnectionDB getInstance()
        {
            if(instance==null) instance = new ConnectionDB();
            return instance;
        }

        public void connecting()
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\couse\\epam\\Git\\TicketManagement\\DB\\db.mdf;Integrated Security=True;Connect Timeout=30";

            SqlConnections = new SqlConnection(connectionString);
            try
            {
                SqlConnections.Open();
                Console.WriteLine(SqlConnections.State);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
