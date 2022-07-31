using MobirollerTestProject.DataAccess.Context;
using MobirollerTestProject.DataAccess.Models;
using MobirollerTestProject.DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories.Repository
{
    public class UserRepository : Repository<User>
    {
        public readonly MobirollerContext _context;
        public UserRepository(MobirollerContext context) : base(context)
        {
            _context = context;
        }

        public User FindUser(LoginViewModel model)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);
            return user;
        }

        public string Register(RegisterViewModel model)
        {
            var user = _context.Users.Where(x => x.Email == model.Email);

            if (user.Count() > 0)
            {
                return "Error";
            }

            _context.Users.Add(new User
            {
                Email = model.Email,
                Password = model.Password
            });
            _context.SaveChanges();

            return "Ok";
        }
    }
}
