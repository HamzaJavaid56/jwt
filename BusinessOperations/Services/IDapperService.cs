using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessOperations.Services
{
   public interface IDapperService
    {
        IEnumerable<customer> GetListWithSp(string connString);
        IEnumerable<customer> GetListWithParaSp(customer obj);
        string GetSingleObjectWithStoreProcedure(customer obj);
    }
}
