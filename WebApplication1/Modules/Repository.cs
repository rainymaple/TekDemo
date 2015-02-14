using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Modules
{
    public class Repository<T> :IRepository<T> where T : Product
    {
        private readonly Database _db;

        public Repository(Database db)
        {
            _db = db;
        }

        public IEnumerable<T> GetAll()
        {
            return _db.DbSet<T>().AsEnumerable();
        }

        public T GetById(int id)
        {
            return _db.DbSet<T>().FirstOrDefault(c => c.Id == id);
        }
    }

    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
    }
}