using System;
using System.Collections.Generic;
using System.Text;

namespace Latihan2Xamarin.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string ProfileImageUrl { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longtitude { get; set; }
    }
}
