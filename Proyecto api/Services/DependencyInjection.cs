using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.IServices;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICandidatoServicio, CandidatoServicio>();
            services.AddScoped<ICandidatoHabilidadServicios, CandidatoHabilidadServicios>();
            services.AddScoped<ICandidatoOfertaServicios, CandidatoOfertaServicios>(); 
            services.AddScoped<IOfertaHabilidadServicios, OfertaHabilidadServicios>();
            services.AddScoped<IHabilidadServicios, HabilidadServicios>();
            services.AddScoped<IFormacionServicios, FormacionServicios>();            
            services.AddScoped<IOfertaServicios, OfertaServicios>();
           
            return services;
        }
    }
}
