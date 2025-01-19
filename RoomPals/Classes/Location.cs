using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RoomPals.Classes
{
    public class Location
    {
        public string city { get; set; }
        public string postal_code { get; set; }
        public string street { get; set; }
        public short street_number { get; set; }

        public Location(string City, string Postal_Code, string Street, short Street_number)
        {
            this.city = City;
            this.postal_code = Postal_Code;
            this.street = Street;
            this.street_number = Street_number;
        }
        public Location(string City)
        {
            city = City;
            postal_code = "Unknown";
            street = "Unknown";
            street_number = 0;
        }

        public Location() { } // needed in some cases when creating new student object (e.g. sign up)
    }
}