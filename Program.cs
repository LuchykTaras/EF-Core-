using System;
using System.Text;

namespace Hogwartz_App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Коректний показ кирилиці
            Console.OutputEncoding = Encoding.UTF8;

            var wizardService = new WizardService();

            // ==========================================
            // ЕТАП 1: Додавання та виведення чарівників
            // ==========================================
            Console.WriteLine("=== ЕТАП 1: Додавання чарівників ===");
            wizardService.AddInitialWizards();

            Console.WriteLine("\nСписок усіх чарівників у базі даних:");
            var allWizards = wizardService.GetWizardsWithWands();
            foreach (var wizard in allWizards)
            {
                Console.WriteLine($"- {wizard.Name} (Факультет: {wizard.House}, Статус: {wizard.BloodStatus})");
            }

            Console.WriteLine(new string('-', 60));

            // ==========================================
            // ЕТАП 2: Фільтрація за факультетом
            // ==========================================
            Console.WriteLine("=== ЕТАП 2: Фільтрація (Тільки Грифіндор) ===");
            var gryffindors = wizardService.GetGryffindorWizards();
            foreach (var wizard in gryffindors)
            {
                Console.WriteLine($"Ім'я: {wizard.Name}, Статус крові: {wizard.BloodStatus}");
            }

            // ==========================================
            // ЕТАП 3: Оновлення Рона Візлі (CRUD - Update)
            // ==========================================
            wizardService.UpdateRonWeasley();

            // Перевіряємо результат після оновлення
            Console.WriteLine("\nПеревірка фільтрації після оновлення Рона:");
            var gryffindorsAfterUpdate = wizardService.GetGryffindorWizards();
            foreach (var wizard in gryffindorsAfterUpdate)
            {
                Console.WriteLine($"Ім'я: {wizard.Name}, Статус крові: {wizard.BloodStatus}");
            }
        }
    }
}