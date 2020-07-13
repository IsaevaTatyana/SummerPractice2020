using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class GivenBook
    {
        public int GiveID { get; set; }

        public int BookID { get; set; }

        public int VisitorID { get; set; }

        public DateTime GivenDate { get; set; }

        public DateTime ReturnDate { get; set; }

    }
}
