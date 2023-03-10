using Microsoft.EntityFrameworkCore;
using dotnetAssessment.core.Models;

namespace dotnetAssessment.data.Repositories.Impl
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DatabaseContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public Repository(DatabaseContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }
        
        public T GetById(Guid id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }

        public void Insert(T entity)
        {
            if(entity == null) throw new ArgumentNullException("entity");

            entities.Add(entity);
        }

        public void Update(T entity)
        {
            if(entity == null) throw new ArgumentNullException("entity");
        }

        public void Delete(Guid id)
        {
            if(id == null) throw new ArgumentNullException("entity");

            T entity = entities.SingleOrDefault(s => s.Id == id);
            entities.Remove(entity);
        }
    }
}