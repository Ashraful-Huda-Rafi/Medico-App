using DAL.EF;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    public class AdminRepo : IRepo<Admin, int, bool>
    {
        MedicoDbContext db;
        internal AdminRepo()
        {
            db = new MedicoDbContext();
        }
        public bool Add(Admin obj)
        {
            db.Admins.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ext = db.Admins.Find(id);
            db.Admins.Remove(ext);
            return db.SaveChanges() > 0;
        }

        public List<Admin> Get()
        {
            return db.Admins.ToList();
        }

        public Admin Get(int id)
        {
            return db.Admins.Find(id);
        }

        public bool Update(Admin obj)
        {
            var ext = Get(obj.Id);
            db.Entry(ext).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
