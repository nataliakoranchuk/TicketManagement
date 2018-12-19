using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagementData.Entities;

namespace TicketManagementData.Repository
{
    public class SqlTicketRepository : ITicketRepository
    {
        public Area GetAreaById(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandText = "select layoutId,description,coordX,coordY from area where id = @id";
            Area ar = null;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    ar = new Area();
                    ar.Id = id;
                    ar.LayoutId = (int)reader[0];
                    ar.Description = (string)reader[1];
                    ar.CoordX = (int)reader[2];
                    ar.CoordY = (int)reader[3];
                    // Console.Read();
                }
            }

            return ar;
        }

        public List<Area> GetAllAreasByLayoutId(int layoutId)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.AddWithValue("@id", layoutId);
            cmd.CommandText = "select a.id,a.layoutId,a.description,a.coordX,a.coordY from area a where a.layoutId=@id";
            List<Area> areaList = new List<Area>();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Area ar = new Area();
                    ar.Id = (int)reader[0];
                    ar.LayoutId = (int)reader[1];
                    ar.Description = (string)reader[2];
                    ar.CoordX = (int)reader[3];
                    ar.CoordY = (int)reader[4];
                    areaList.Add(ar);
                }
            }

            return areaList;
        }

        public void CreateArea(Area item)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.AddWithValue("@layoutId", item.LayoutId);
            cmd.Parameters.AddWithValue("@description", item.Description);
            cmd.Parameters.AddWithValue("@coordX", item.CoordX);
            cmd.Parameters.AddWithValue("@coordY", item.CoordY);
            cmd.CommandText = "Insert into area(layoutId,description,coordX,coordY) output inserted.id values(@layoutId,@description,@coordX,@coordY)";
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                    item.Id = (int)reader[0];
            }
        }

        public void UpdateArea(Area item)
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

        public void DeleteArea(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandText = "delete from area where id = @id";
            cmd.ExecuteNonQuery();
        }

        public void CreateEventArea(EventArea item)
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
                    item.Id = (int)reader[0];
            }
        }

        public void DeleteEventArea(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandText = "delete from eventArea where id = @id";
            cmd.ExecuteNonQuery();
        }

        public EventArea GetEventAreaById(int id)
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
                    ev.Id = id;
                    ev.EventId = (int)reader[0];
                    ev.Description = (string)reader[1];
                    ev.CoordX = (int)reader[2];
                    ev.CoordY = (int)reader[3];
                    ev.Price = (float)reader[4];
                }
            }

            return ev;
        }

        public void UpdateEventArea(EventArea item)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.AddWithValue("@id", item.Id);
            cmd.Parameters.AddWithValue("@eventId", item.EventId);
            cmd.Parameters.AddWithValue("description", item.Description);
            cmd.Parameters.AddWithValue("@coordX", item.CoordX);
            cmd.Parameters.AddWithValue("@coordY", item.CoordY);
            cmd.Parameters.AddWithValue("@price", item.Price);
            cmd.CommandText = "update eventArea set eventId=@eventId,description=@description,coordX=@coordX,coordY=@coordY where id=@id";
            cmd.ExecuteNonQuery();
        }

        public void CreateEvent(Event item)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.AddWithValue("@layoutId_p", item.LayoutId);
            cmd.Parameters.AddWithValue("@description_p", item.Description);
            cmd.Parameters.AddWithValue("@name_p", item.Name);
            cmd.Parameters.AddWithValue("@startDate_p", item.StartDate);
            cmd.CommandText = "EXEC [EventCreate] @name = @name_p, @description = @description_p, @layoutId = @layoutId_p, @startDate = @startDate_p";
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                    item.Id = (int)reader[0];
            }
        }

        public void DeleteEvent(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.AddWithValue("@id_p", id);
            cmd.CommandText = "EXEC [EventDelete] @id = @id_p";
            cmd.ExecuteNonQuery();
        }

        public Event GetEventById(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandText = "select name,description,layoutId,startDate from event where id = @id";
            Event ar = null;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    ar = new Event();
                    ar.Id = id;
                    ar.Name = (string)reader[0];
                    ar.Description = (string)reader[1];
                    ar.LayoutId = (int)reader[2];
                    ar.StartDate = DateTime.Parse((string)reader[3]);
                }
            }

            return ar;
        }

        public List<Event> GetAllEventsByVenueId(int venueId)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.AddWithValue("@id", venueId);
            cmd.CommandText = "select e.id,e.name,e.description,e.layoutId,e.startDate from event e " +
                              "inner join layout l on l.id = e.layoutId " +
                              "where l.venueId = @id";
            List<Event> eventList = new List<Event>();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Event ar = new Event();
                    ar.Id = (int)reader[0];
                    ar.Name = (string)reader[1];
                    ar.Description = (string)reader[2];
                    ar.LayoutId = (int)reader[3];
                    ar.StartDate = (DateTime)reader[4];
                    eventList.Add(ar);
                }
            }

            return eventList;
        }

        public void UpdateEvent(Event item)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.AddWithValue("@id_p", item.Id);
            cmd.Parameters.AddWithValue("@layoutId_p", item.LayoutId);
            cmd.Parameters.AddWithValue("@description_p", item.Description);
            cmd.Parameters.AddWithValue("@name_p", item.Name);
            cmd.Parameters.AddWithValue("@startDate_p", item.StartDate);
            cmd.CommandText = "EXEC [EventUpdate] @id = @id_p, @name = @name_p, @description = @description_p, @layoutId = @layoutId_p, @startDate = @startDate_p";
            cmd.ExecuteNonQuery();
        }

        public EventSeat GetEventSeatById(int id)
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
                    ev.Id = id;
                    ev.EventAreaId = (int)reader[0];
                    ev.Row = (int)reader[1];
                    ev.Number = (int)reader[2];
                    ev.State = (string)reader[3];
                }
            }

            return ev;
        }

        public void CreateEventSeat(EventSeat item)
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

        public void DeleteEventSeat(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandText = "delete from eventSeat where id = @id";
            cmd.ExecuteNonQuery();
        }

        public void UpdateEventSeat(EventSeat item)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.AddWithValue("@id", item.Id);
            cmd.Parameters.AddWithValue("@eventAreaId", item.EventAreaId);
            cmd.Parameters.AddWithValue("@row", item.Row);
            cmd.Parameters.AddWithValue("@number", item.Number);
            cmd.Parameters.AddWithValue("@state", item.State);
            cmd.CommandText = "update eventSeat set eventAreaId=@eventAreaId,row=@row,number=@number,state=@state where id =@id";
            cmd.ExecuteNonQuery();

        }

        public Layout GetLayoutById(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.CommandText = "select venueId,description,name from layout where id = @id";
            Layout layout = null;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    layout = new Layout();
                    layout.Id = id;
                    layout.VenueId = (int)reader[0];
                    layout.Description = (string)reader[1];
                    layout.Name = (string)reader[2];
                }
            }

            return layout;
        }

        public void CreateLayout(Layout item)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.AddWithValue("@venueId", item.VenueId);
            cmd.Parameters.AddWithValue("@description", item.Description);
            cmd.Parameters.AddWithValue("@name", item.Name);
            cmd.CommandText = "Insert into layout(venueId,description,name)output inserted.id values(@venueId,@description,@name)";
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                    item.Id = (int)reader[0];
            }
        }

        public void UpdateLayout(Layout item)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.AddWithValue("@id", item.Id);
            cmd.Parameters.AddWithValue("@venueId", item.VenueId);
            cmd.Parameters.AddWithValue("@description", item.Description);
            cmd.Parameters.AddWithValue("@name", item.Name);
            cmd.CommandText = "update layout set venueId=@venueId,description=@description,name=@name  where id=@id";
            cmd.ExecuteNonQuery();
        }

        public List<Layout> GetAllLayoutsByVenueId(int venueId)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.AddWithValue("@venueId", venueId);
            List<Layout> layoutList = new List<Layout>();
            cmd.CommandText = "select l.id,l.venueId,l.description,l.name from layout l where l.venueId=@venueId";
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Layout layout = new Layout();
                    layout.Id = (int)reader[0];
                    layout.VenueId = (int)reader[1];
                    layout.Description = (string)reader[2];
                    layout.Name = (string)reader[3];
                    layoutList.Add(layout);
                }
            }

            return layoutList;
        }

        public void DeleteLayout(int id)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandText = "delete from layout where id = @id";
            cmd.ExecuteNonQuery();
        }

        public Seat GetSeatById(int id)
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
                    seat.Id = id;
                    seat.AreaId = (int)reader[0];
                    seat.Row = (int)reader[1];
                    seat.Number = (int)reader[2];
                }
            }

            return seat;
        }

        public void CreateSeat(Seat item)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.AddWithValue("@areaId", item.AreaId);
            cmd.Parameters.AddWithValue("@row", item.Row);
            cmd.Parameters.AddWithValue("@number", item.Number);
            cmd.CommandText = "Insert into seat(areaId,row,number) output inserted.id values(@areaId,@row,@number)";
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                    item.Id = (int)reader[0];
            }
        }

        public void UpdateSeat(Seat item)
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

        public void DeleteSeat(int id)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandText = "delete from seat where id = @id";
            cmd.ExecuteNonQuery();
        }

        public List<Seat> GetAllSeatsByAreaId(int areaId)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.AddWithValue("@areaId", areaId);
            cmd.CommandText = "select s.id,s.areaId,s.row,s.number from seat s where @areaId = s.areaId";
            List<Seat> seatList = new List<Seat>();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Seat seat = new Seat();
                    seat.Id = (int)reader[0];
                    seat.AreaId = (int)reader[1];
                    seat.Row = (int)reader[2];
                    seat.Number = (int)reader[3];
                    seatList.Add(seat);
                }
            }

            return seatList;
        }

        public Venue GetVenueById(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandText = "select description,name,address,phone from venue where id = @id";
            Venue ven = null;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    ven = new Venue();
                    ven.Id = id;
                    ven.Description = (string)reader[0];
                    ven.Name = (string)reader[1];
                    ven.Address = (string)reader[2];
                    ven.Phone = (string)reader[3];
                }
            }

            return ven;
        }

        public Venue GetVenueByName(string name)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.AddWithValue("@name", name);
            cmd.CommandText = "select id,description,name,address,phone from venue where name = @name";
            Venue ven = null;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    ven = new Venue();
                    ven.Id = (int)reader[0];
                    ven.Description = (string)reader[1];
                    ven.Name = (string)reader[2];
                    ven.Address = (string)reader[3];
                    ven.Phone = (string)reader[4];
                }
            }

            return ven;
        }

        public Venue GetVenueByLayoutId(int layoutId)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.AddWithValue("@id", layoutId);
            cmd.CommandText = "select v.id,v.description,v.name,v.address,v.phone from venue v " +
                              "inner join layout l on l.venueId = v.id " +
                              "where l.id = @id";
            Venue ven = null;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    ven = new Venue();
                    ven.Id = (int)reader[0];
                    ven.Description = (string)reader[1];
                    ven.Name = (string)reader[2];
                    ven.Address = (string)reader[3];
                    ven.Phone = (string)reader[4];
                }
            }

            return ven;
        }

        public void CreateVenue(Venue item)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.AddWithValue("@description", item.Description);
            cmd.Parameters.AddWithValue("@name", item.Name);
            cmd.Parameters.AddWithValue("@address", item.Address);
            cmd.Parameters.AddWithValue("@phone", item.Phone);
            cmd.CommandText = "Insert venue(description,name,address,phone)output inserted.id values(@description,@name,@address,@phone)";
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                    item.Id = (int)reader[0];
            }
        }

        public void UpdateVenue(Venue item)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.AddWithValue("@description", item.Description);
            cmd.Parameters.AddWithValue("@name", item.Name);
            cmd.Parameters.AddWithValue("@address", item.Address);
            cmd.Parameters.AddWithValue("@phone", item.Phone);
            cmd.Parameters.AddWithValue("@id", item.Id);
            cmd.CommandText = "update venue set description = @description, name = @name, address = @address, phone=@phone where id=@id";
            cmd.ExecuteNonQuery();
        }

        public void DeleteVenue(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandText = "delete from venue where id = @id";
            cmd.ExecuteNonQuery();
        }

        public void DeleteAllVenue()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnectionDB.getInstance().SqlConnections;
            cmd.CommandText = "delete from venue";
            cmd.ExecuteNonQuery();
        }
    }
}
