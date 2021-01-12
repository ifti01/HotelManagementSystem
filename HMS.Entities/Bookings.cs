using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Entities
{
   public class Bookings
    {
        public int ID { get; set; }
        public int AccomodationsID { get; set; }

        public Accomodations Accomodations { get; set; }
        public DateTime FromDate { get; set; }

        /// <summary>
        /// no of date staying
        /// </summary>
        public int Duration { get; set; }
    }
}
