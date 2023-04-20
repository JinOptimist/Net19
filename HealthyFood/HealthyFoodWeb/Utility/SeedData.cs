using Data.Interface.Models;
using Data.Interface.Repositories;
using static System.Formats.Asn1.AsnWriter;

namespace HealthyFoodWeb.Utility
{
    public static class SeedData
    {
        public static void Seed(this WebApplication webApplication)
        {
            using (var scope = webApplication.Services.CreateScope())
            {
                SeedUsers(scope);
                SeedManufacturer(scope);
                SeedStoreItems(scope);
                SeedCarts(scope);
            }
        }

        private static void SeedCarts(IServiceScope scope)
        {
            var cartRepository = scope.ServiceProvider.GetRequiredService<ICartRepository>();
            var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();


            if (!cartRepository.Any())
            {
                var user = userRepository.GetFirst();

                var productdefault = new Cart
                {
                    Name = "Sup",
                    Price = 10,
                    Customer = user
                };
                cartRepository.Add(productdefault);
            }
        }

        private static void SeedUsers(IServiceScope scope)
        {
            var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();

            if (!userRepository.Any())
            {
                var admin = new User
                {
                    Name = "Admin",
                    Password = "123",
                    AvatarUrl = "NoAvatar"
                };
                userRepository.Add(admin);
            }
        }

        private static void SeedManufacturer(IServiceScope scope)
        {
            var manufacturerRepository = scope.ServiceProvider.GetRequiredService<IManufacturerRepository>();

            if (!manufacturerRepository.Any())
            {
                var adminManufacturer = new Manufacturer
                {
                    Name = "AdminManufacturer",
                };
                manufacturerRepository.Add(adminManufacturer);
            }
        }

        private static void SeedStoreItems(IServiceScope scope)
        {
            var storeCatalogueRepository = scope.ServiceProvider.GetRequiredService<IStoreCatalogueRepository>();
            var manufacturerRep = scope.ServiceProvider.GetRequiredService<IManufacturerRepository>();

            if (!storeCatalogueRepository.Any())
            {
                var manufacturer = manufacturerRep.GetFirst();
                var adminItem = new StoreItem
                {
                    Name = "Admin",
                    Price = 16,
                    ImageUrl = "NoImage",
                    Manufacturer = manufacturer

                };
                storeCatalogueRepository.Add(adminItem);
            }
        }
    }
}