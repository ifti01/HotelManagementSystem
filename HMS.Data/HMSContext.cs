using HMS.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HMS.Data
{
    public   class HMSContext : IdentityDbContext<HMSUser>
    {
        public HMSContext() : base("HMSConnectionString")
        {
        }

        public static HMSContext Create()
        {
                return new HMSContext();
        }
        
        public DbSet<AccomodationType> AccomodationTypes { get; set; }
        public DbSet<Accomodations> Accomodationses { get; set; }
        public DbSet<AccomodationPackages> AccomodationPackageses { get; set; }
        public DbSet<Bookings> Bookingses { get; set; } 
        //public DbSet<HMSUser> Users { get; set; }
    }
}
