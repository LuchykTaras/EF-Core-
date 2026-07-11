using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Hogwartz_App.Models;

namespace Hogwartz_App
{
    public class WizardService
    {
        public List<Wizard> GetWizardsWithWands()
        {
            using (var context = new HogwartsDbContext())
            {
                return context.Wizards.Include(w => w.Wand).ToList();
            }
        }

        // --- ЗАВДАННЯ 2.1: Додавання 5 чарівників (без року, бо його немає в моделі) ---
        public void AddInitialWizards()
        {
            using (var context = new HogwartsDbContext())
            {
                // Перевірка, щоб не дублювати при повторних запусках
                if (context.Wizards.Any(w => w.Name == "Гаррі Поттер")) return;

                var w1 = new Wizard { Name = "Гаррі Поттер", House = "Грифіндор", BloodStatus = "Напівкровний", IsActive = true };
                var w2 = new Wizard { Name = "Герміона Грейнджер", House = "Грифіндор", BloodStatus = "Маґлонароджена", IsActive = true };
                var w3 = new Wizard { Name = "Рон Візлі", House = "Грифіндор", BloodStatus = "Невідомо", IsActive = true }; // Потім оновимо
                var w4 = new Wizard { Name = "Драко Мелфой", House = "Слизерин", BloodStatus = "Чистокровний", IsActive = true };
                var w5 = new Wizard { Name = "Луна Лавґуд", House = "Рейвенклов", BloodStatus = "Чистокровний", IsActive = true };

                context.Wizards.AddRange(w1, w2, w3, w4, w5);
                context.SaveChanges();
                Console.WriteLine("Чарівників успішно додано до бази даних!");
            }
        }

        // --- ЗАВДАННЯ 2.2: Фільтрація (Грифіндор) ---
        public List<Wizard> GetGryffindorWizards()
        {
            using (var context = new HogwartsDbContext())
            {
                return context.Wizards
                              .Where(w => w.House == "Грифіндор")
                              .ToList();
            }
        }

        // --- ЗАВДАННЯ 2.2: Оновлення даних Рона Візлі ---
        public void UpdateRonWeasley()
        {
            using (var context = new HogwartsDbContext())
            {
                var ron = context.Wizards.FirstOrDefault(w => w.Name == "Рон Візлі");

                if (ron != null)
                {
                    // Оскільки року немає, демонструємо UPDATE на прикладі статусу крові
                    ron.BloodStatus = "Чистокровний";
                    context.SaveChanges();
                    Console.WriteLine("\n[Успішно оновлено]: Статус крові Рона Візлі змінено на 'Чистокровний'.");
                }
                else
                {
                    Console.WriteLine("\n[Помилка]: Рона Візлі не знайдено в базі даних.");
                }
            }
        }
    }
}