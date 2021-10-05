using IntergalacticAirways.DTO.Configuration;
using IntergalacticeAirways.DataAccess.Contract;
using IntergalacticeAirways.DataAccess.Implementation;
using IntergalacticeAirways.DataAccess.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalacticAirways.Service
{
    public static class IntergalacticAirwaysBootstrapper
    {
        public static IServiceCollection AddIntergalacticeAirwaysService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IRestClient, RestClient>();
            services.AddScoped<IStarshipService, StarshipService>();
            services.AddAutoMapper(typeof(IntergalacticAirwaysBootstrapper));
            return services;
        }
    }
}
