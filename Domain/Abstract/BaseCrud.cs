using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Abstract
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
        protected readonly DbSet<T> entries;
        protected readonly DbContext context;
        protected readonly DbSet<T> _ant;
        public IQueryable<T> GetAll()
        
            {
                return entries.AsQueryable();
            }

        public T Get(int idd)
        {
            return entries.Find(idd);
        }

        public T Add(T nazv)
        {
            return entries.Add(nazv);
        }

        public void Delete(T nazv)
        {

            entries.Remove(nazv);
        }

        public void Update(T nazv)
        {
            context.Entry(nazv).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }


    }
}
    
    
    
