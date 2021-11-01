using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IRepositoryEF<T> where T : class
    {
        IEnumerable<T> GetModel();
        T GetModelById(int id);
        int AddModel(T entity);
        int DeleteModel(int id);
        int Complete(); //unit Of Work
        int UpdateModel(T Model);
    }
}
