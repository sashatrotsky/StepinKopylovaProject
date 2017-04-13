using Domain.Abstract;
using Repository.Base;
using Repository.Repositories;
using System.Collections.Generic;


namespace Services.Base
{
    public interface IServiceBase<T> where T : class
    {

        IEnumerable<T> GetAll();
        T Get(int id);
        void Add(T item);
        void Update(T item);
        void Delete(int id);
    }
    public class ServiceBase<T> where T : EntitiesBase
    {
        private IRepositoryBase<T> bd;

        public ServiceBase(IRepositoryBase<T> repository)
        {
            bd = repository;
        }

        public IEnumerable<T> GetAll()
        {
            return bd.GetAll();
        }

        public T Get(int idd)
        {
            return bd.Get(idd);
        }

        public void Add(T nazv)
        {
            bd.Add(nazv);
        }

        public void Delete(T nazv)
        {
            bd.Delete(nazv);
        }

        public void Update(T item)
        {
            bd.Update(item);
        }

        public void Save()
        {
            bd.Save();
        }
    }
}