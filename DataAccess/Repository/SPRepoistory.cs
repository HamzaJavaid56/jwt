using Dapper;
using DataAccess.Context;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public static class SPRepoistory<T> where T : class

    {
        //readonly string connString = Startup.StaticConfig.GetConnectionString("DefaultConnection");


        static SPRepoistory()
        {

        }
        public static List<T> GetListWithSp(string procedureName, string connString)

        {

            using (SqlConnection sqlCon = new SqlConnection(connString))
            {

                sqlCon.Open();
                return sqlCon.Query<T>(procedureName, commandType: System.Data.CommandType.StoredProcedure).ToList();
            }
        }

        public static List<T> GetListWithStoreProcedure(string proc, DynamicParameters obj)
        {
            using (SqlConnection sqlCon = new SqlConnection("Data Source=.;Initial Catalog=testing_db;Integrated Security=True"))
            {
                sqlCon.Open();
                return sqlCon.Query<T>(proc, obj, commandType: System.Data.CommandType.StoredProcedure).ToList();
            }
        }

        public static T GetSingleObjectWithStoreProcedure(string proc, DynamicParameters obj)
        {
            using (SqlConnection sqlCon = new SqlConnection("Data Source=.;Initial Catalog=testing_db;Integrated Security=True"))
            {
                sqlCon.Open();
                return sqlCon.Query<T>(proc, obj, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            }
        }


    }
}
