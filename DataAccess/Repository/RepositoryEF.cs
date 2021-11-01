using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class RepositoryEF<T> : IRepositoryEF<T> where T : class
    {
        private readonly ApplicationContext _context;
        DbSet<T> dbEntities;
        public RepositoryEF(ApplicationContext context)
        {
            _context = context;
            dbEntities = _context.Set<T>();

        }

        public IEnumerable<T> GetModel()
        {
            return dbEntities;
        }

        public T GetModelById(int id)
        {

            var result = dbEntities.Find(id);
            return result;

        }

        public int AddModel(T entity)
        {
            dbEntities.Add(entity);
            return _context.SaveChanges();

        }

        public int Complete()
        {
            return _context.SaveChanges();

        }

        public int DeleteModel(int id)
        {
            T model = dbEntities.Find(id);
            dbEntities.Remove(model);
            return _context.SaveChanges();
        }

        public int UpdateModel(T Model)
        {
            _context.Entry(Model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return _context.SaveChanges();

        }


    }
}
