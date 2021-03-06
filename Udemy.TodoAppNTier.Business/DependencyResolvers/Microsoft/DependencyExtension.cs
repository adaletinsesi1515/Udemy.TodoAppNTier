

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using AutoMapper;
using Udemy.TodoAppNTier.Business.Interfaces;
using Udemy.TodoAppNTier.Business.Mappings.AutoMapper;
using Udemy.TodoAppNTier.Business.Services;
using Udemy.TodoAppNTier.DataAccess.Contexts;
using Udemy.TodoAppNTier.DataAccess.UnitofWork;

namespace Udemy.TodoAppNTier.Business.DependencyResolvers.Microsoft
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddDbContext<TodoContext>(opt =>
            {
                opt.UseSqlServer("server=AB01500-5000; database=TodoDb; integrated security=true;");
                opt.LogTo(Console.WriteLine, LogLevel.Information); 
            });

            var configuration = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new WorkProfile());
            });

            var mapper = configuration.CreateMapper();

            services.AddSingleton(mapper);

            services.AddScoped<IUow, Uow>();
            services.AddScoped<IWorkServices, WorkServices>();
        }
    }
}
