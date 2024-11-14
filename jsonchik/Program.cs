using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jsonchik
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string filePath = "jsonchik.json";

            Json_books_task6 task = new Json_books_task6();
            task.ProcessBooks(filePath, Encoding.UTF8);

            Console.ReadKey();
        }
    }
}
