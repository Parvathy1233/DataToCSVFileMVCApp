using DataToCSVFileMVCApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataToCSVFileMVCApp.Controllers
{
    public class HomeController : Controller
    {
        string connecetionstring = "Data Source=LAPTOP-7UIHE5VR\\SQLEXPRESS;Initial Catalog=EventBookingManagement;Integrated Security=True";
        public ActionResult Index()
        {
            //iuiiui
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
            while(reader.Read())
            {
                Event e = new Event
                {
                    ID = Convert.ToInt32(reader["ID"]),
                    Name = Convert.ToString(reader["Name"]),
                    Quantity = Convert.ToInt32(reader["Quantity"]),
                    Date = Convert.ToDateTime(reader["date"]),
                };
                events.Add(e);
            }
            return View(events);
        }

    }
}