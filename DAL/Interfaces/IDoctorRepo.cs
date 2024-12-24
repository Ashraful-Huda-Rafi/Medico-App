using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDoctorRepo<CLASS, ID, RESULT> : IRepo<CLASS, ID, RESULT>
    {
        List<CLASS> Search(string search_value);
    }
}
