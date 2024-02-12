using Domain.Abstractions.Repositories;
using Domain.UnitOfWork;
using Infrustructure.Persistence;
using Infrustructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Infrustructure
{
    public static class Extension
    {
        public static IServiceCollection AddInfrustructre(this IServiceCollection services
            , IConfiguration configuration)
        {
            var assembly = typeof(Extension).Assembly;

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseInMemoryDatabase(databaseName: "Battle"));

            services.AddScoped<IHorseRepository, HorseRepository>();
            services.AddScoped<ISamuraiRepository, SamuraiRepository>();
            services.AddScoped<IBattleRepository, BattleRepository>();
            services.AddScoped<IUnitOfWork,UnitOfWork.UnitOfWork>();

            return services;
        }
    }
}