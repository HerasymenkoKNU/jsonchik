using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace jsonchik
{
    public class Deserializer
    {
        public static T DeserializeFile<T>(string filePath, Encoding encoding)
        {
            try
            {
                // Отримуємо розширення файлу
                string extension = Path.GetExtension(filePath).ToLower();

                if (extension == ".json")
                {
                    // Якщо розширення json, читаємо файл і десеріалізуємо його
                    string jsonContent = File.ReadAllText(filePath, encoding);
                    return JsonSerializer.Deserialize<T>(jsonContent);
                }
                else
                {
                    Console.WriteLine("Це розширення не підтримується");
                    return default;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при десеріалізації: {ex.Message}");
                return default;
            }
        }
    }

    public class Json_books_task6
    {
        public class PublishingHouse
        {
            // 2. Для угнорування айді можна використати JsonIgnore, таким чином значення усюди буде 0
            //[JsonIgnore]
            public int Id { get; set; }
            public string Name { get; set; }
            public string Adress { get; set; }
        }

        public class Book
        {
            // 3. Щоб зчитувати Title як Name, необхідно вказати JsonPropertyName() (обов'язково в вхідному файлі також!)
            //[JsonPropertyName("Name")]
            public string Title { get; set; }
            public PublishingHouse PublishingHouse { get; set; }
        }

        public void ProcessBooks(string filePath, Encoding encoding)
        {
            try
            {
                // Десеріалізуємо файл у список книг
                List<Book> books = Deserializer.DeserializeFile<List<Book>>(filePath, encoding);

                // Виведення інформації про книги
                foreach (var book in books)
                {
                    Console.WriteLine($"Title: {book.Title}");
                    Console.WriteLine($"Publishing House: {book.PublishingHouse.Name}, Id: {book.PublishingHouse.Id}, Address: {book.PublishingHouse.Adress}");
                    Console.WriteLine(new string('-', 40));
                }
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("Метод не підтримується!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }
    }
}
