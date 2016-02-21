using MyMedicalGuide.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMedicalGuide.Data.Repositories
{
    using MyMedicalGuide.Data.Common.Models;

    public class EfGenericRepository<T, TKey> : IRepository<T, TKey> where T : BaseModel<TKey>
    {
        public EfGenericRepository(IMyMedicalGuideDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
            }

            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }

        protected IDbSet<T> DbSet { get; set; }

        protected IMyMedicalGuideDbContext Context { get; set; }


        public IQueryable<T> AllWithDeleted()
        {
            return this.DbSet;
        }

        public virtual IQueryable<T> All()
        {
            return this.DbSet.Where(x => !x.IsDeleted);
        }

        public virtual T GetById(object id)
        {
            return this.DbSet.Find(id);
        }

        public virtual void Add(T entity)
        {
            this.DbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Modified);
        }

        public virtual void Delete(T entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.Now;
            this.Update(entity);
        }

        public void HardDelete(T entity)
        {
            this.DbSet.Remove(entity);
        }

        public int SaveChanges()
        {
            return this.Context.SaveChanges();
        }

        public void Dispose()
        {
            this.Context.Dispose();
        }


        protected void ChangeEntityState(T entity, EntityState state)
        {
            var entry = this.Context.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            entry.State = state;
        }
    }
}