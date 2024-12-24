using DAL.EF;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Data.Common.CommandTrees.ExpressionBuilder;
using System.Linq;

namespace DAL.Repos
{
    public class DoctorRepo : IDoctorRepo<Doctor, int, bool>
    {
        MedicoDbContext db;
        internal DoctorRepo()
        {
            db = new MedicoDbContext();
        }
        public bool Add(Doctor obj)
        {
            db.Doctors.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ext = db.Doctors.Find(id);
            db.Doctors.Remove(ext);
            return db.SaveChanges() > 0;
        }

        public List<Doctor> Get()
        {
            return db.Doctors.ToList();
        }

        public Doctor Get(int id)
        {
            return db.Doctors.Find(id);
        }

        public bool Update(Doctor obj)
        {
            var ext = Get(obj.Id);
            db.Entry(ext).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }

        public List<Doctor> Search(string search_value)
        {
            var results = db.Doctors.Where(d => d.Name.StartsWith(search_value) || d.Name.Contains(search_value) || d.Name.EndsWith(search_value) ||
                d.Email.StartsWith(search_value) || d.Email.Contains(search_value) || d.Email.EndsWith(search_value) ||
                d.Specialization.StartsWith(search_value) || d.Specialization.Contains(search_value) || d.Specialization.EndsWith(search_value));

            return results.ToList();
        }

        private bool IsMatch(Doctor d, string search_value)
        {
            return false;
        }
    }
}
