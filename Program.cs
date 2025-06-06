using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Fitness.Infrastructure;
using Fitness.Infrastructure.Models;

class Program
{
    static async Task Main(string[] args)
    {
        var services = new ServiceCollection();
        services.AddDbContext<FitnessContext>(options =>
            options.UseSqlite("Data Source=fitness.db"));
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped(typeof(ICrudServiceAsync<>), typeof(CrudServiceAsync<>));

        var serviceProvider = services.BuildServiceProvider();

        var clientService = serviceProvider.GetRequiredService<ICrudServiceAsync<ClientModel>>();
        var workoutService = serviceProvider.GetRequiredService<ICrudServiceAsync<WorkoutModel>>();

        var client = new ClientModel { Name = "Иван Иванов" };
        await clientService.CreateAsync(client);
        Console.WriteLine($"Создан клиент: {client.Name} (Id = {client.Id})");

        var workout = new WorkoutModel { Description = "Тренировка 1", ClientId = client.Id };
        await workoutService.CreateAsync(workout);
        Console.WriteLine($"Создана тренировка: {workout.Description} для клиента {client.Name}");

        var clients = await clientService.ReadAllAsync();
        foreach (var c in clients)
        {
            Console.WriteLine($"Клиент: {c.Name} (Id = {c.Id})");
        }

        Console.WriteLine("Программа завершена. Нажмите любую клавишу...");
        Console.ReadKey();
    }
}