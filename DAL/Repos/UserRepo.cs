using DAL.EF;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    public class UserRepo : IUserRepo<User, int, bool>
    {
        MedicoDbContext db;
        internal UserRepo()
        {
            db = new MedicoDbContext();
        }
        public bool Add(User obj)
        {
            db.Users.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ext = db.Users.Find(id);
            db.Users.Remove(ext);
            return db.SaveChanges() > 0;
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public User Get(string userName, string password, string userType)
        {
            return db.Users.Where(u => u.UserName.Equals(userName) && u.Password.Equals(password) && u.UserType.Equals(userType)).FirstOrDefault();
        }

        public bool Update(User obj)
        {
            var ext = Get(obj.Id);
            db.Entry(ext).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
