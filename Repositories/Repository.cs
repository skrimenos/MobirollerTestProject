using Microsoft.EntityFrameworkCore;
using MobirollerTestProject.DataAccess.Context;
using MobirollerTestProject.DataAccess.ViewModels;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly MobirollerContext _context;

        public Repository(MobirollerContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<T> entity)
        {
            _context.Set<T>().AddRange(entity);
            _context.SaveChanges();
        }
    }
}
