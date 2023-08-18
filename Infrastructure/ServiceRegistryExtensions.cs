using AirportManagement.Domain;
using AirportManagement.Infrastructure;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceRegistryExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IFlightManager, FlightManager>()
                .AddScoped<IBaggageManager, BaggageManager>()
                .AddScoped<IPassengerManager, PassengerManager>();

            return services;
        }
    }
}
