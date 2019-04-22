using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Latihan2Xamarin.Models
{
    public class Sale
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long Amount { get; set; }
        public int Percentage { get; set; }
        public string Deal { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerID { get; set; }

    }
}
