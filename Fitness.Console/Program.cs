using Fitness.Common;
using System;
using System.Collections.Generic;

namespace Fitness.Console
{
    internal class Program
    {
        public delegate void MembershipAddedHandler(Membership membership);
        public static event MembershipAddedHandler? OnMembershipAdded;

        static void Main(string[] args)
        {
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;

            var workoutService = new CrudService<Workout>();

            workoutService.Create(new Workout("Кардіо Інтенсив", "Кардіо", 45, 500));
            workoutService.Create(new Workout("Силовий Тренінг", "Сила", 60, 600));
            workoutService.Create(new Workout("Йога", "Гнучкість", 40, 200));
            workoutService.Create(new Workout("HIIT", "Кардіо", 30, 450));
            workoutService.Create(new Workout("Пілатес", "Гнучкість", 50, 300));
            workoutService.Create(new Workout("Кросфіт", "Сила", 55, 650));

            string filePath = "workouts.json";

            workoutService.Save(filePath);
            System.Console.WriteLine($"\nДані збережено у файл: {filePath}");

            System.Console.WriteLine("\nПісля очищення:");
            var emptyService = new CrudService<Workout>();
            foreach (var w in emptyService.ReadAll())
            {
                System.Console.WriteLine(w);
            }

            emptyService.Load(filePath);
            System.Console.WriteLine("\nПісля завантаження з файлу:");
            foreach (var w in emptyService.ReadAll())
            {
                System.Console.WriteLine(w);
            }

            System.Console.WriteLine("\nСписок тренувань\n");
            foreach (var workout in workoutService.ReadAll())
            {
                System.Console.WriteLine(workout);
            }

            List<Membership> memberships = new List<Membership>();

            OnMembershipAdded += membership =>
            {
                System.Console.WriteLine($"\nДодано новий абонемент: {membership}");
            };

            AddMembership(memberships, new Membership("Місячний", DateTime.Now, 800));
            AddMembership(memberships, new Membership("Річний", DateTime.Now.AddDays(-30), 9000));
            AddMembership(memberships, new Membership("3-місячний", DateTime.Now.AddDays(-15), 2100));

            System.Console.WriteLine("\nСписок абонементів:\n");
            foreach (var membership in memberships)
            {
                System.Console.WriteLine(membership);
            }

            System.Console.WriteLine($"\nЗагальна сума продажів абонементів: {memberships.CalculateTotalPrice()} грн");

            System.Console.ReadLine();
        }

        public static void AddMembership(List<Membership> memberships, Membership newMembership)
        {
            memberships.Add(newMembership);
            OnMembershipAdded?.Invoke(newMembership);
        }
    }
}