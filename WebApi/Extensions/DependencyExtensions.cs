using App.Core.ApplicationService.ApplicationSerrvices.Products;
using App.Core.ApplicationService.IRepositories;
using App.Core.Entities.Model;
using App.Infrastucture.EF.Database;
using App.Infrastucture.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Extensions
{
    public static class DependencyExtensions
    {
        public static void AddDependency(this IServiceCollection services)
        {
            AddRepositories(services);
            AddServices(services);
        }
        private  static void AddRepositories(IServiceCollection services)
        {
            services.AddTransient<IMovieRepository<Movie>, MovieEfRepository<Movie>>();
        }
        private static void AddServices(IServiceCollection services)
        {
            services.AddTransient<IMovieService, MovieService>();
            
        }
    }
}
