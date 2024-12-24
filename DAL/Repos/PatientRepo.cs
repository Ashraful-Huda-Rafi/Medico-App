using DAL.EF;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    public class PatientRepo : IRepo<Patient, int, bool>
    {
        MedicoDbContext db;
        internal PatientRepo()
        {
            db = new MedicoDbContext();
        }
        public bool Add(Patient obj)
        {
            db.Patients.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ext = db.Patients.Find(id);
            db.Patients.Remove(ext);
            return db.SaveChanges() > 0;
        }

        public List<Patient> Get()
        {
            return db.Patients.ToList();
        }

        public Patient Get(int id)
        {
            return db.Patients.Find(id);
        }

        public bool Update(Patient obj)
        {
            var ext = Get(obj.Id);
            db.Entry(ext).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
