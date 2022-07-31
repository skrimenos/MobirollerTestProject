using MobirollerTestProject.DataAccess.Context;
using MobirollerTestProject.DataAccess.Models;
using MobirollerTestProject.DataAccess.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Repositories.Repository
{
    public class TurkishRepository : Repository<Turkish>
    {
        public readonly MobirollerContext _context;
        public TurkishRepository(MobirollerContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<IndexViewModel> GetAll()
        {

            return (from s in _context.Turkishes
                    select new IndexViewModel
                    {
                        Id = s.Id,
                        Category = s.DcKategori,
                        Time = s.DcZaman,
                        Event = s.DcOlay
                    });
        }
    }
}
