using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;
using TicTacToe.Services;

namespace TicTacToe
{
    public static class ServiceRegister
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection @this)
        {
            var serviceType = typeof(Service);
            var definedTypes = serviceType.Assembly.DefinedTypes;

            var services = definedTypes
                .Where(x => x.GetTypeInfo().GetCustomAttribute<Service>() != null);

            foreach (var service in services)
            {
                @this.AddTransient(service);
            }


            return @this;
        }
    }
}
