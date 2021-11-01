using Dapper;
using DataAccess.Model;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessOperations.Services
{
    public class DapperService : IDapperService
    {
      

        public IEnumerable<customer> GetListWithSp(string connString)
        {
            var proc = "SP_Get_Customers";
            var cus = SPRepoistory<customer>.GetListWithSp(proc, connString);
            return cus;
        }

        public IEnumerable<customer> GetListWithParaSp(customer obj)
        {
            string proc = "SP_Get_Customer_By_Id";
            var parameters = new DynamicParameters();
            parameters.Add("@customer_id", obj.customer_id);
            var response = SPRepoistory<customer>.GetListWithStoreProcedure(proc, parameters);
            return response;
        }

        public string GetSingleObjectWithStoreProcedure(customer obj)
        {
            string proc = "SP_Insert_Customer";
            var parameters = new DynamicParameters();
            parameters.Add("@customer_name", obj.customer_name);
            var response = SPRepoistory<string>.GetSingleObjectWithStoreProcedure(proc, parameters);
            return response;
        }
    }
}
