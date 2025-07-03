using SmartWatchesAPI.Models;


namespace SmartWatchesAPI.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Categories.Any())
            {
                return;
            }

            var categories = new Category[]
            {
                new Category { Name = "Deportivos", Description = "Relojes inteligentes diseñados para actividades físicas y deportes" },
                new Category { Name = "Elegantes", Description = "Relojes inteligentes con diseño sofisticado para uso formal" },
                new Category { Name = "Básicos", Description = "Relojes inteligentes con funciones esenciales a precio accesible" },
                new Category { Name = "Premium", Description = "Relojes inteligentes de alta gama con tecnología avanzada" }
            };

            context.Categories.AddRange(categories);
            context.SaveChanges();

            var products = new Product[]
            {
                new Product
                {
                    Name = "Apple Watch SE Sport",
                    Description = "Reloj inteligente deportivo con GPS, resistente al agua y monitor de frecuencia cardíaca",
                    Price = 279.99m,
                    ImageUrl = "https://images.unsplash.com/photo-1434493789847-2f02dc6ca35d?w=400",
                    CategoryId = 1,
                    Stock = 15,
                    Brand = "Apple",
                    Model = "SE Sport"
                },
                new Product
                {
                    Name = "Garmin Forerunner 245",
                    Description = "GPS running smartwatch con métricas avanzadas de entrenamiento",
                    Price = 349.99m,
                    ImageUrl = "https://images.unsplash.com/photo-1508685096489-7aacd43bd3b1?w=400",
                    CategoryId = 1,
                    Stock = 12,
                    Brand = "Garmin",
                    Model = "Forerunner 245"
                },

                new Product
                {
                    Name = "Samsung Galaxy Watch 4 Classic",
                    Description = "Elegante smartwatch con bisel giratorio y funciones premium",
                    Price = 399.99m,
                    ImageUrl = "https://images.unsplash.com/photo-1523275335684-37898b6baf30?w=400",
                    CategoryId = 2,
                    Stock = 8,
                    Brand = "Samsung",
                    Model = "Galaxy Watch 4 Classic"
                },
                new Product
                {
                    Name = "Fossil Gen 6",
                    Description = "Smartwatch elegante con Wear OS y diseño clásico",
                    Price = 299.99m,
                    ImageUrl = "https://images.unsplash.com/photo-1529679111474-9462e9d1baa0?w=400",
                    CategoryId = 2,
                    Stock = 10,
                    Brand = "Fossil",
                    Model = "Gen 6"
                },

               
                new Product
                {
                    Name = "Xiaomi Mi Band 7",
                    Description = "Pulsera inteligente básica con gran autonomía y funciones esenciales",
                    Price = 59.99m,
                    ImageUrl = "https://images.unsplash.com/photo-1544117519-31a4b719223d?w=400",
                    CategoryId = 3,
                    Stock = 25,
                    Brand = "Xiaomi",
                    Model = "Mi Band 7"
                },
                new Product
                {
                    Name = "Amazfit Bip 3",
                    Description = "Smartwatch básico con GPS y hasta 14 días de batería",
                    Price = 89.99m,
                    ImageUrl = "https://images.unsplash.com/photo-1551698618-1dfe5d97d256?w=400",
                    CategoryId = 3,
                    Stock = 20,
                    Brand = "Amazfit",
                    Model = "Bip 3"
                },

                new Product
                {
                    Name = "Apple Watch Series 8",
                    Description = "El smartwatch más avanzado de Apple con sensor de temperatura",
                    Price = 549.99m,
                    ImageUrl = "https://images.unsplash.com/photo-1546868871-7041f2a55e12?w=400",
                    CategoryId = 4,
                    Stock = 6,
                    Brand = "Apple",
                    Model = "Series 8"
                },
                new Product
                {
                    Name = "TAG Heuer Connected",
                    Description = "Reloj inteligente de lujo con materiales premium y artesanía suiza",
                    Price = 1299.99m,
                    ImageUrl = "https://images.unsplash.com/photo-1522312346375-d1a52e2b99b3?w=400",
                    CategoryId = 4,
                    Stock = 3,
                    Brand = "TAG Heuer",
                    Model = "Connected"
                }
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}