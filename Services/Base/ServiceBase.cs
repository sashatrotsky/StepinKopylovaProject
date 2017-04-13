using Domain.Abstract;
using Repository.Base;
using Repository.Repositories;
using System.Collections.Generic;


namespace Services.Base
{
    public interface IServiceBase<T> where T : class
    {

        IEnumerable<T> GetAll();
        T Get(int idd);
        void Add(T nazv);
        void Update(T nazv);
        void Delete(T nazv);
    }
    public class ServiceBase<T> where T : class
    {
        public IRepositoryBase<T> bd;

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

        public void Update(T nazv)
        {
            bd.Update(nazv);
        }

        public void Save()
        {
            bd.Save();
        }
    }
}