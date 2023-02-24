using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataToCSVFileMVCApp.Models
{
    public class Event
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
    }
}