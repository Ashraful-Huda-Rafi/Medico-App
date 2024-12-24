using DAL.EF;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    internal class BloodDonorRepo : IRepo<BloodDonor, int, bool>
    {
        MedicoDbContext db;
        internal BloodDonorRepo()
        {
            db = new MedicoDbContext();
        }
        public bool Add(BloodDonor obj)
        {
            db.BloodDonors.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ext = db.BloodDonors.Find(id);
            db.BloodDonors.Remove(ext);
            return db.SaveChanges() > 0;
        }

        public List<BloodDonor> Get()
        {
            return db.BloodDonors.ToList();
        }

        public BloodDonor Get(int id)
        {
            return db.BloodDonors.Find(id);
        }

        public bool Update(BloodDonor obj)
        {
            var ext = Get(obj.Id);
            db.Entry(ext).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
