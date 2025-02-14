using MoscowZooAccounting.Abstractions;
using MoscowZooAccounting.Animals;
using MoscowZooAccounting.Items;
using MoscowZooAccounting.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MoscowZooAccounting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Поскольку Сергей Александрович сказал, что отрисовывать красивую менюшку не нужно, то
            // красоту наведу в следующий раз (наверное), а так - пока просто демонстрация((

            // Starting to build a service collection
            var services = new ServiceCollection();

            services.AddSingleton<VetClinic>();
            services.AddSingleton<MoscowZoo>();
            services.AddSingleton<MoscowZooItemsStorage>();
            services.AddSingleton<KindAnimalsListInformer>();
            services.AddSingleton<InventoryStorage>();
            services.AddSingleton<InventoryCountInformer>();
            services.AddSingleton<FoodCountInformer>();
            services.AddSingleton<AnimalCountInformer>();

            services.AddSingleton<IZoo>(sp => sp.GetRequiredService<MoscowZoo>());
            services.AddSingleton<IClinicProvider>(sp => sp.GetRequiredService<VetClinic>());
            services.AddSingleton<IInventoryStorageProvider>(sp => sp.GetRequiredService<InventoryStorage>());

            // Getting a service provider
            var serviceProvider = services.BuildServiceProvider();

            var animalCounter = serviceProvider.GetRequiredService<AnimalCountInformer>();
            var foodCounter = serviceProvider.GetRequiredService<FoodCountInformer>();
            var inventoryCounter = serviceProvider.GetRequiredService<InventoryCountInformer>();
            var kindAnimalsCounter = serviceProvider.GetRequiredService<KindAnimalsListInformer>();

            var inventoryStorage = serviceProvider.GetRequiredService<InventoryStorage>();

            var zoo = serviceProvider.GetRequiredService<MoscowZoo>();
            zoo.SendAnimal += inventoryStorage.AddInventory;

            var items = serviceProvider.GetRequiredService<MoscowZooItemsStorage>();
            items.SendItem += inventoryStorage.AddInventory;


            Console.WriteLine("Scenario #1: adding animals with poor health\n");

            zoo.AddAnimal(new Monkey(2, 4, 6));
            zoo.AddAnimal(new Rabbit(1, 4, 7));
            zoo.AddAnimal(new Tiger(9, 3));
            zoo.AddAnimal(new Wolf(8, 2));

            Console.WriteLine(animalCounter.GetInfo());
            Console.WriteLine(foodCounter.GetInfo());
            Console.WriteLine(inventoryCounter.GetInfo());
            Console.WriteLine(kindAnimalsCounter.GetInfo());

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Scenario #2: adding only predators and not so kind herbos\n");

            zoo.AddAnimal(new Monkey(2, 6, 4));
            zoo.AddAnimal(new Rabbit(1, 7, 1));
            zoo.AddAnimal(new Tiger(9, 8));
            zoo.AddAnimal(new Wolf(8, 6));

            Console.WriteLine(animalCounter.GetInfo());
            Console.WriteLine(foodCounter.GetInfo());
            Console.WriteLine(inventoryCounter.GetInfo());
            Console.WriteLine(kindAnimalsCounter.GetInfo());

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Scenario #3: finally adding kind animals\n");

            zoo.AddAnimal(new Rabbit(3, 8, 8));
            zoo.AddAnimal(new Monkey(4, 10, 7));

            Console.WriteLine(animalCounter.GetInfo());
            Console.WriteLine(foodCounter.GetInfo());
            Console.WriteLine(inventoryCounter.GetInfo());
            Console.WriteLine(kindAnimalsCounter.GetInfo());

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Scenario #4: adding a cople of items to the zoo\n");

            items.AddItem(new Table());
            items.AddItem(new Computer());

            Console.WriteLine(animalCounter.GetInfo());
            Console.WriteLine(foodCounter.GetInfo());
            Console.WriteLine(inventoryCounter.GetInfo());
            Console.WriteLine(kindAnimalsCounter.GetInfo());

        }
    }
}
