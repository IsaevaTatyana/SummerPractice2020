using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Booking
    {
        public int BookingID { get; set; }

        public int BookID { get; set; }

        public int VisitorID { get; set; }

        public DateTime OrderDate { get; set; }

    }
}
