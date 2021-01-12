using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Entities
{
   public class Accomodations
    {
        public int ID { get; set; }
        public int AccomodationPackagesID { get; set; }

        public AccomodationPackages AccomodationPackages { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
