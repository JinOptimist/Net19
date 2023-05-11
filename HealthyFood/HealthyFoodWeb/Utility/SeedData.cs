using Data.Interface.Models;
using Data.Interface.Repositories;
using Data.Sql.Repositories;
using static System.Formats.Asn1.AsnWriter;

namespace HealthyFoodWeb.Utility
{
    public static class SeedData
    {
        private const int MIN_GAME_COUNT = 20;
        private const int MIN_STORE_COUNT = 20;

        public static void Seed(this WebApplication webApplication)
        {
            using (var scope = webApplication.Services.CreateScope())
            {
                SeedUsers(scope);
                SeedManufacturer(scope);
                SeedStoreItems(scope);
                SeedGame(scope);
                SeedReview(scope);
                SeedGameCategory(scope);
                SeedWikiMcImages(scope);
                //SeedImageTags(scope);
            }
        }

        private static void SeedUsers(IServiceScope scope)
        {
            var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();

            if (!userRepository.Any())
            {
                var user = new User
                {
                    Name = "Admin",
                    Password = "123",
                    AvatarUrl = "NoAvatar",
                    Role = MyRole.Admin
                };
                userRepository.Add(user);
            }

            var admin = userRepository.GetByName("Admin");
            if (admin.Role != MyRole.Admin)
            {
                admin.Role = MyRole.Admin;
                userRepository.Update(admin);
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

            if (storeCatalogueRepository.Count() < MIN_STORE_COUNT)
            {
                var manufacturer = manufacturerRep.GetFirst();

                for (int i = 0; i < MIN_STORE_COUNT; i++)
                {
                    var adminItem = new StoreItem
                    {
                        Name = $"Admin{i}",
                        Price = 1+i,
                        ImageUrl = "NoImage",
                        Manufacturer = manufacturer

                    };
                    storeCatalogueRepository.Add(adminItem);
                }
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

        private static void SeedGameCategory(IServiceScope scope)
        {
            var defaultGenres = new List<string> { "Action", "Fight", "RPG", "Horror" };

            var gameCategoryRepository = scope.ServiceProvider
                .GetRequiredService<IGameCategoryRepository>();

            foreach (var genreName in defaultGenres)
            {
                if (gameCategoryRepository.Get(genreName) == null)
                {
                    var gameCatalog = new GameCategory
                    {
                        Name = genreName
                    };
                    gameCategoryRepository.Add(gameCatalog);
                }
            }
        }

        //private static void SeedImageTags(IServiceScope scope)
        //{
        //    var defaultTags = new List<string> { "Sport", "Protein", "Fat", "Carbs", "Life", "Health" };

        //    var tagRepository = scope.ServiceProvider
        //        .GetRequiredService<IWikiTagRepository>();

        //    foreach (var tagName in defaultTags)
        //    {
        //        if (tagRepository.GetOrCreateTag(tagName) == null)
        //        {
        //            var tagCatalog = new WikiTags
        //            {
        //                TagName = tagName
        //            };
        //            tagRepository.Add(tagCatalog);
        //        }
        //    }
        //}

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