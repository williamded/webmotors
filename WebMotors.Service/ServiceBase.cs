using System;
using System.Collections.Generic;
using WebMotors.Domain.Interfaces.Repositories;
using WebMotors.Domain.Interfaces.Services;
using WebMotors.Infra.Data.Repositories;

namespace WebMotors.Service
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {

        private readonly IRepositoryBase<TEntity> db = new RespositoryBase<TEntity>();
        public void Delete(TEntity obj)
        {
            db.Delete(obj);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return db.GetAll();
        }

        public TEntity GetById(int id)
        {
            return db.GetById(id);
        }

        public void Insert(TEntity obj)
        {
            db.Insert(obj);
        }

        public void Update(TEntity obj)
        {
            db.Update(obj);
        }
    }
}
