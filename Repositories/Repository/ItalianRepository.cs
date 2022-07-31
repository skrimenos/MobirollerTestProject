using MobirollerTestProject.DataAccess.Context;
using MobirollerTestProject.DataAccess.Models;
using MobirollerTestProject.DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories.Repository
{
    public class ItalianRepository : Repository<Italian>
    {
        public readonly MobirollerContext _context;

        public ItalianRepository(MobirollerContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<IndexViewModel> GetAll()
        {
            return (from s in _context.Italians
                    select new IndexViewModel
                    {
                        Id = s.Id,
                        Category = s.DcCategoria,
                        Time = s.DcOrario,
                        Event = s.DcEvento
                    });
        }
    }
}
