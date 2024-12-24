using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ITokenRepo<CLASS, ID, RESULT> : IRepo<CLASS, ID, RESULT>
    {
        CLASS GetByTokenKeyUserIdExpiredNull(int user_id, string key);
    }
}
