using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace SustentabilidadeEscolar.WebApi
{
    public static  class ServicesExtensions
    {
        public static void AddMongo(this IServiceCollection services, IConfigurationSection configuration)
        {
            services.AddSingleton(new MongoClient(configuration.GetSection("ConnectionString").Value));
        }
    }
}
