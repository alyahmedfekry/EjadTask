using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
namespace Application
{
    public static class Extension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services
            , IConfiguration configuration)
        {
            var assembly = typeof(Extension).Assembly;
          
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(assembly);
            });

            services.AddValidatorsFromAssembly(assembly);

            return services;
        }
    }
}
