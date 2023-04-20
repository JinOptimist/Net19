using Data.Interface.Models;
using Data.Interface.Repositories;

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
                SeedGame(scope);
                SeedReview(scope);
                SeedWikiMcImages(scope);
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

        private static void SeedWikiMcImages(IServiceScope scope)
        {
            var wikiMcImagesRepository = scope.ServiceProvider.GetRequiredService<IWikiMcRepository>();

            if (!wikiMcImagesRepository.Any())
            {
                var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();
                var randomUser = userRepository.GetFirst();
                var image1 = new WikiMcImage
                {
                    ImgUrl = "https://avatars.dzeninfra.ru/get-zen_doc/41204/pub_5b00259fad0f222dd299aae7_5b005a50a936f4e52e30b616/scale_1200",
                    Year = 2023,
                    ImgType = ImgTypeEnum.Proteins,
                    ImageUploader = randomUser,
                    Tags = new List<WikiTags>
                        {
                            new WikiTags
                            {
                                TagName = "Protein"
                            },
                            new WikiTags
                            {
                                TagName = "Muscles"
                            },
                        }
                };
                wikiMcImagesRepository.Add(image1);

                var image2 = new WikiMcImage
                {
                    ImgUrl = "https://www.health.com/thmb/nxURaqGxebTJBMzXi5jZpaAL02Q=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/Healthy-Fats-Food-GettyImages-1301412044-2000-8ab23a10624d42df85fa3f37d7c76a6b.jpg",
                    Year = 2023,
                    ImgType = ImgTypeEnum.Fats,
                    ImageUploader = randomUser,
                    Tags = new List<WikiTags>
                        {
                            new WikiTags
                            {
                                TagName = "Fat"
                            },
                            new WikiTags
                            {
                                TagName = "Polyunsaturated fats"
                            },
                        }
                };
                wikiMcImagesRepository.Add(image2);

                var image3 = new WikiMcImage
                {
                    ImgUrl = "https://medlineplus.gov/images/Carbohydrates_share.jpg",
                    Year = 2023,
                    ImgType = ImgTypeEnum.Carbs,
                    ImageUploader = randomUser,
                    Tags = new List<WikiTags>
                        {
                            new WikiTags
                            {
                                TagName = "Carb"
                            },
                            new WikiTags
                            {
                                TagName = "Complex carbs"
                            },
                        }
                };
                wikiMcImagesRepository.Add(image3);
            }
        }
    }
}