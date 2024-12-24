using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class TokenRepo : ITokenRepo<Token, int, bool>
    {
        MedicoDbContext db;
        public TokenRepo()
        {
            db = new MedicoDbContext();
        }
        public bool Add(Token obj)
        {
            db.Tokens.Add(obj);
            return db.SaveChanges() > 0;
        }

        public Token GetByTokenKeyUserIdExpiredNull(int user_id, string key)
        {
            return db.Tokens.SingleOrDefault(t => t.UserId == user_id && t.TKey.Equals(key) && t.DelatedAt == null);
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Token> Get()
        {
            throw new NotImplementedException();
        }

        public Token Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Token obj)
        {
            throw new NotImplementedException();
        }
    }
}
