using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomPals.Classes
{
    public class Room : Location
    {
        public int room_id { get; set; }
        public SqlMoney price { get; set; }
        public short number_of_roomates { get; set; }
        public float size { get; set; }

        public Room(string Country, string City, string Postal_Code, string Street, short Street_number, int Room_id,
            SqlMoney Price, short Number_of_roomates, float Size): base(Country,
                                                                        City,
                                                                        Postal_Code,
                                                                        Street,
                                                                        Street_number)
        {

            this.room_id = Room_id;
            this.price = Price;
            this.number_of_roomates = Number_of_roomates;
            this.size = Size;
        }



    }
}
