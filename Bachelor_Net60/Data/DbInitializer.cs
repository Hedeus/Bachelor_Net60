using CifrovikDEL.Context;
using CifrovikDEL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Bachelor_Net60.Data
{
    class DbInitializer
    {
        private readonly CifrovikDB _db;
        private readonly ILogger<DbInitializer> _Logger;
        public DbInitializer(CifrovikDB db, ILogger<DbInitializer> Logger)
        {
            _db = db;
            _Logger = Logger;
        }
        public async Task InitializeAsync()
        {
            var timer = Stopwatch.StartNew();
            _Logger.LogInformation("Инициализация БД...");
            //_Logger.LogInformation("Удаление существующей БД...");
            //await _db.Database.EnsureDeletedAsync().ConfigureAwait(false);
            //_Logger.LogInformation("Удаление существующей БД выполнено за {0} мс", timer.ElapsedMilliseconds);

            _Logger.LogInformation("Миграция БД...");
            await _db.Database.MigrateAsync();
            _Logger.LogInformation("Миграция БД выполнена за {0} мс", timer.ElapsedMilliseconds);


            if (await _db.Products.AnyAsync()) return;

            await InitializeCategories();
            await InitializeProducts();

            _Logger.LogInformation("Инициализация БД выполнена за {0} с", timer.Elapsed.TotalSeconds);
        }

        private const int __CategoriesCount = 10;
        private Categories[] _Categories;
        private async Task InitializeCategories()
        {
            var timer = Stopwatch.StartNew();
            _Logger.LogInformation("Инициализация Категорий...");

            _Categories = new Categories[__CategoriesCount];
            for (var i = 0; i < __CategoriesCount; i++)
                _Categories[i] = new Categories { Name = $"Категория {i + 1}" };
            await _db.Categories.AddRangeAsync(_Categories);
            await _db.SaveChangesAsync();

            _Logger.LogInformation("Инициализация Категорий выполнена за {0} мс", timer.ElapsedMilliseconds);
        }
        private const int __ProductsCount = 10;
        private Products[] _Products;
        private async Task InitializeProducts()
        {
            var timer = Stopwatch.StartNew();
            _Logger.LogInformation("Инициализация Продуктов...");

            var rnd = new Random();
            _Products = Enumerable.Range(1, __ProductsCount)
                .Select(i => new Products
                {
                    Name = $"Продукт {i}",
                    Category = rnd.NewItem(_Categories)
                })
                .ToArray();
            await _db.Products.AddRangeAsync(_Products);
            await _db.SaveChangesAsync();

            _Logger.LogInformation("Инициализация Продуктов выполнена за {0} мс", timer.ElapsedMilliseconds);
        }
        //private async Task InitializePrices()
        //{

        //}
    }
}
