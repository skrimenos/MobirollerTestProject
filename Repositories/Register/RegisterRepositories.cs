using Microsoft.Extensions.DependencyInjection;
using Repositories.Interfaces;
using Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Register
{
    public class RegisterRepositories
    {
        public static IServiceCollection RepositoryRegister(IServiceCollection service)
        {
            service.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            service.AddTransient<TurkishRepository>();
            service.AddTransient<ItalianRepository>();
            service.AddTransient<UserRepository>();

            return service;
        }
    }
}
