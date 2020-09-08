using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MyProject.Data;

namespace MyProject.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public bool CheckIfExists(Expression<Func<T, bool>> predicate)
        {
            return false;
        }

        public List<T> Collection()
        {
            return _dbSet.ToList();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Delete(Expression<Func<T, bool>> predicate)
        {
            var f= _dbSet.FirstOrDefault(predicate);
            _dbSet.Remove(f);

        }

        public List<T> GetBy(Expression<Func<T, bool>> predicate)
        {
           return _dbSet.Where(predicate).ToList();
        }

        public T GetSingle(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public void Insert(T t)
        {
            _dbSet.Add(t);
        }

        public void Update(T t)
        {
            _dbSet.Update(t);
        }
    
    }
}