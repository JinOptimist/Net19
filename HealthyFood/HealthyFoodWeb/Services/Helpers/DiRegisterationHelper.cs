using Data.Interface.Repositories;
using Data.Sql.Repositories;
using Data.Sql;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace HealthyFoodWeb.Services.Helpers
{
    public class DiRegisterationHelper
    {
        public void RegisterAllRepositories(IServiceCollection services)
        {
            var dataInterfAceassembly = Assembly.GetAssembly(typeof(IBaseRepository<>));
            var repositoriesAssembly = Assembly.GetAssembly(typeof(BaseRepository<>));

            dataInterfAceassembly
                .GetTypes()
                .Where(
                    type => type.IsInterface
                        && type.GetInterfaces()
                            .Any(i =>
                                i.IsGenericType
                                && i.GetGenericTypeDefinition() == typeof(IBaseRepository<>)
                            )
                    )
                .ToList()
                .ForEach(repositoryInterface =>
                {
                    services.AddScoped(repositoryInterface, serviceProvider =>
                    {
                        var constructorOfRepository =
                            repositoriesAssembly
                                .GetTypes()
                                .First(classType =>
                                    classType.IsClass
                                    && classType.GetInterfaces().Any(i => i == repositoryInterface))
                                .GetConstructors()
                                .OrderByDescending(x => x.GetParameters().Length)
                                .First();

                        return constructorOfRepository
                            .Invoke(constructorOfRepository
                                .GetParameters()
                                .Select(param => serviceProvider.GetService(param.ParameterType))
                                .ToArray());
                    });
                });
        }

		public void RegisterAllServices(IServiceCollection services)
		{
			var scopedRegistration = typeof(ScopedRegistrationAttribute);

			var types = AppDomain.CurrentDomain.GetAssemblies()
			.SelectMany(s => s.GetTypes())
			.Where(p => p.IsDefined(scopedRegistration, false) && !p.IsInterface)
			.Select(impl => new
			{
				Service = impl.GetInterface($"I{impl.Name}"),
				Implementation = impl
			})
			.Where(x => x.Service != null);

			foreach (var type in types)
			{
				services.AddScoped(type.Service, type.Implementation);
			}
		}
	}
}
