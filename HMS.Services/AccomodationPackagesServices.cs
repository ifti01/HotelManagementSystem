using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Data;
using HMS.Entities;

namespace HMS.Services
{
    public class AccomodationPackagesServices
    {
        public IEnumerable<AccomodationPackages> GetAllAccomodationPackages()
        {
            var context = new HMSContext();

            return context.AccomodationPackageses.ToList();
        }

        public IEnumerable<AccomodationPackages> SearchAccomodationPackages(string searchTerm)
        {
            var context = new HMSContext();

            var accomodationPackages = context.AccomodationPackageses.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                accomodationPackages = accomodationPackages.Where(a => a.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            return accomodationPackages.ToList();
        }

        public AccomodationPackages GetAccomodationPackageByID(int ID)
        {
            using (var context = new HMSContext())
            {
                return context.AccomodationPackageses.Find(ID);

            }
        }
        public bool SaveAccomodationPackage(AccomodationPackages accomodationPackages)
        {
            var context = new HMSContext();

            context.AccomodationPackageses.Add(accomodationPackages);

            return context.SaveChanges() > 0;
        }

        public bool UpdateAccomodationPackage(AccomodationPackages accomodationPackages)
        {
            var context = new HMSContext();

            context.Entry(accomodationPackages).State = EntityState.Modified;

            return context.SaveChanges() > 0;
        }

        public bool DeleteAccomodationPackage(AccomodationPackages accomodationPackages)
        {
            var context = new HMSContext();

            context.Entry(accomodationPackages).State = EntityState.Deleted;

            return context.SaveChanges() > 0;
        }
    }
}
