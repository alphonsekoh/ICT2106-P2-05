using PainAssessment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PainAssessment.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly HospitalContext _context;
        public GenericRepository(HospitalContext context)
        {
            this._context = context;
        }
        public T GetById<T1, TId>(TId id)
        {
            return _context.Set<T>().Find(id);
        }
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
        public void Delete(int id)
        {
            T entityToDelete = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(entityToDelete);
        }
    }
}
