using BACKENDD.Models;
using System.Linq;

namespace BACKENDD.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {

            // Если таблица Contacts не пуста, то выходим

            // Иначе добавляем несколько начальных данных
            var contacts = new Contact[]
            {
                new Contact { Name = "Пример", SecName = "Пример", Age = 30, Email = "Пример@example.com", Message = "Пример!!!!" },
            };

            context.Contacts.AddRange(contacts);
            context.SaveChanges();  // Сохраняем изменения
        }
    }
}
