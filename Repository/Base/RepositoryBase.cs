using System.Data.Entity;
using System.Linq;
using Domain.Abstract;

namespace Repository.Base
{
    public interface IRepositoryBase<T> where T : class
    {
        IQueryable<T> GetAll();
        T Add(T nazv);
        T Get(int id);
        void Delete(T nazv);
        void Update(T nazv);
        void Save();

    }

    public abstract class RepositoryBase<T> where T : class
    {
        protected RepositoryBase(DbContext context)
        {
            Context = context;
            Entries = Context.Set<T>();
        }
        protected readonly DbSet<T> Entries;
        protected readonly DbContext Context;
        protected readonly DbSet<T> _ant;
    
        public IQueryable<T> GetAll()
        
            {
                return Entries.AsQueryable();
            }

        public T Get(int idd)
        {
            return Entries.Find(idd);
        }

        public T Add(T nazv)
        {
            return Entries.Add(nazv);
        }

        public void Delete(T nazv)
        {

            Entries.Remove(nazv);
        }

        public void Update(T nazv)
        {
            Context.Entry(nazv).State = EntityState.Modified;
        }

        public void Save()
        {
            Context.SaveChanges();
        }


    }
}
    
    
    
