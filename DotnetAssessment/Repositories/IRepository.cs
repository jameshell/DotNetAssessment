using System;
using System.Collections.Generic;
using dotnetAssessment.Models;

namespace dotnetAssessment.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(Guid id);
    }
}