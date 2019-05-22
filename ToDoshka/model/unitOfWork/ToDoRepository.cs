using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ToDoshka.Model
{
    public class ToDoRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        ToDoContext _context;
        DbSet<TEntity> _dbSet;

        public ToDoRepository(ToDoContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public void Create(TEntity item)
        {
            _dbSet.Add(item);
        }

        public TEntity FindById(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<TEntity> Get()
        {
            return _dbSet.ToList();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public void Remove(TEntity item)
        {
            _dbSet.Remove(item);
        }

        public void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
