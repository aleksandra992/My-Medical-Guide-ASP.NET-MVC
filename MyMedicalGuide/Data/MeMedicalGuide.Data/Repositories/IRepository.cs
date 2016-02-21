namespace MyMedicalGuide.Data.Repositories
{
    using System;
    using System.Linq;

    using MyMedicalGuide.Data.Common.Models;

    public interface IRepository<T, TKey> : IDisposable where T : BaseModel<TKey>
    {
        IQueryable<T> AllWithDeleted();

        IQueryable<T> All();

        T GetById(object id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void HardDelete(T entity);

        int SaveChanges();

        void Dispose();
    }
}