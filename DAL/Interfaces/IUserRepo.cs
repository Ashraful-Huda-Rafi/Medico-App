using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserRepo<CLASS, ID, RESULT> : IRepo<CLASS, ID, RESULT>
    {
        CLASS Get(string userName, string password, string userType);
    }
}
