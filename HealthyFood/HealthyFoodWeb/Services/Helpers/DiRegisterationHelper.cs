using Data.Interface.Repositories;
using Data.Sql.Repositories;
using System.Reflection;

namespace HealthyFoodWeb.Services.Helpers
{
	public class DiRegisterationHelper
	{
		public void RegisterAllRepositories(IServiceCollection services)
		{
			var dataInterfaceAssembly = Assembly.GetAssembly(typeof(IBaseRepository<>));
			var repositoriesAssembly = Assembly.GetAssembly(typeof(BaseRepository<>));

			dataInterfaceAssembly
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

			var firstList = AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(s => s.GetTypes())
				.Where(p => p.IsDefined(scopedRegistration, false) && p.IsClass)
				.ToList();

			var secondList = AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(s => s.GetTypes())
				.Where(t => t.GetConstructors().Any(c => c.IsDefined(scopedRegistration, false)))
				.ToList();

			firstList.Concat(secondList).Distinct().ToList()
				.ForEach(realize =>
				{
					var inte = realize.GetInterface($"I{realize.Name}");
					services.AddScoped(inte, x =>
					{
						var constructorOfService = realize.GetConstructors()
						.FirstOrDefault(c => c.IsDefined(scopedRegistration, false));

						if (constructorOfService == null)
						{
						constructorOfService = realize.GetConstructors().First();
						}

						return constructorOfService
							.Invoke(constructorOfService
								.GetParameters()
								.Select(param => x.GetService(param.ParameterType))
								.ToArray());
					});
				});
		}
	}
}
