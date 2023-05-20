
using Dta.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dta
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDta(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApiProjectBolsaEmpleo_Context>(options =>
            options.UseSqlServer( configuration.GetConnectionString("BolsaEmpleo_Context") ?? throw new InvalidOperationException("Connection string 'BolsaEmpleo_Context' not found.")));

            services.AddScoped<ApiProjectBolsaEmpleo_Context>(); //services.AddScoped<IMyDbContext, MyDbContext>();

            return services;
        }
    }
}
