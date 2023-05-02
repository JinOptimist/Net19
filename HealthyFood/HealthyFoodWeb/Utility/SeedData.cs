using Data.Interface.Models;
using Data.Interface.Repositories;
using Data.Sql.Repositories;
using static System.Formats.Asn1.AsnWriter;

namespace HealthyFoodWeb.Utility
{
    public static class SeedData
    {
        private const int MIN_GAME_COUNT = 100;
        private const int MIN_CART_COUNT = 100;

        public static void Seed(this WebApplication webApplication)
        {
            using (var scope = webApplication.Services.CreateScope())
            {
                SeedUsers(scope);
                SeedManufacturer(scope);
                SeedStoreItems(scope);
                SeedGame(scope);
                SeedReview(scope);
                SeedCart(scope);
            }
        }

        private static void SeedCart(IServiceScope scope)
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

            if (cartRepository.Count() < MIN_CART_COUNT)
            {
                var randomUser = userRepository.GetFirst();

                for (int i = 0; i < MIN_CART_COUNT; i++)
                {
                    var product = new Cart
                    {
                        Name = $"Sup {i}",
                        Price = 10,
                        Customer = randomUser

                    };
                    cartRepository.Add(product);
                }
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
        private static void SeedGame(IServiceScope scope)
        {
            var gameRepository = scope.ServiceProvider.GetRequiredService<IGameRepository>();
            if (!gameRepository.Any())
            {
                var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();
                var randomUser = userRepository.GetFirst();
                var game = new Game
                {
                    Name = "BestOfTheBestGame",
                    Price = 1000,
                    CoverUrl = "",
                    Creater = randomUser

                };
                gameRepository.Add(game);
            }


            if (gameRepository.Count() < MIN_GAME_COUNT)
            {
                var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();
                var randomUser = userRepository.GetFirst();

                for (int i = 0; i < MIN_GAME_COUNT; i++)
                {
                    var game = new Game
                    {
                        Name = $"RichGame№{i}",
                        Price = 100 + i,
                        CoverUrl = "https://i.imgur.com/eOtEAB7.jpg",
                        Creater = randomUser

                    };
                    gameRepository.Add(game);
                }
            }

        }
        private static void SeedReview(IServiceScope scope)
        {
            var reviewRepository = scope.ServiceProvider.GetRequiredService<IReviewRepository>();
            if (!reviewRepository.Any())
            {
                var review = new Review
                {
                    TextReview = "",
                    Date = DateTime.Now
                };
            }
        }
    }
}