using DataToCSVFileMVCApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace DataToCSVFileMVCApp.Controllers
{
    public class HomeController : Controller
    {
        string connecetionstring = "Data Source=LAPTOP-7UIHE5VR\\SQLEXPRESS;Initial Catalog=EventBookingManagement;Integrated Security=True";
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult EventDisplay()
        {
            List<Event> events = new List<Event>();
            SqlConnection connection = new SqlConnection(connecetionstring);
            connection.Open();
            SqlCommand command = new SqlCommand("EventList", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Event e = new Event
                {
                    ID = Convert.ToInt32(reader["ID"]),
                    Name = Convert.ToString(reader["Name"]),
                    Quantity = Convert.ToInt32(reader["Quantity"]),
                    Date = Convert.ToDateTime(reader["Date"]),
                };
                events.Add(e);
            }
            return View(events);
        }
        public ActionResult CSV()
        {
            List<Event> events = new List<Event>();
            SqlConnection connection = new SqlConnection(connecetionstring);
            connection.Open();
            SqlCommand command = new SqlCommand("EventList", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Event e = new Event
                {
                    ID = Convert.ToInt32(reader["ID"]),
                    Name = Convert.ToString(reader["Name"]),
                    Quantity = Convert.ToInt32(reader["Quantity"]),
                    Date = Convert.ToDateTime(reader["Date"]),
                };
                events.Add(e);
            }
            var builder = new StringBuilder();
            builder.AppendLine("ID,Name,Quantity,Date");
            foreach (var i in events)
            {
                builder.AppendLine($"{i.ID},{i.Name},{i.Quantity},{i.Date}");
            }
            return File(Encoding.UTF8.GetBytes(builder.ToString()), "csv", "Event.csv");
        }
    }
}