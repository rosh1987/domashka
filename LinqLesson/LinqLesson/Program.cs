using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            List<People> peoples = new List<People>()
            {
                new People { Name = "Иван", Age = 31, Sex = "Male", Balance = 400 },
                new People { Name = "Женя", Age = 24, Sex = "Male", Balance = 21000 },
                new People { Name = "Даша", Age = 22, Sex = "Female", Balance = 570 },
                new People { Name = "Леша", Age = 25, Sex = "Male", Balance = 14758 },
                new People { Name = "Соня", Age = 27, Sex = "Female", Balance = 4792 }
            };

            Console.WriteLine("Самый старший");

            var result = peoples.OrderByDescending(x => x.Age).FirstOrDefault();
           
            Console.WriteLine(result.Name + " " + result.Age + " " + result.Sex + " " + result.Balance);
           
            Console.WriteLine("Самый богатый");

            result = peoples.OrderByDescending(x => x.Balance).FirstOrDefault();

            Console.WriteLine(result.Name + " " + result.Age + " " + result.Sex + " " + result.Balance);
           
            Console.WriteLine("Сколько людей имеют баланс выше 4000");

            var resultBalance = peoples.Where(x => x.Balance > 4000);
            var resultCaunt = peoples.Where(x => x.Balance > 4000).Count();
            Console.WriteLine("Количетсво таких людей = " + resultCaunt + ". Кто они?");

            foreach (People people in resultBalance)
            {
                Console.WriteLine(people.Name + " " + people.Age + " " + people.Sex + " " + people.Balance);
            }
           
            Console.WriteLine("Сортировка по возасту");

            var sortAge = peoples.OrderByDescending(x => x.Age);

            foreach (People people in sortAge)
            {
                Console.WriteLine(people.Name + " " + people.Age + " " + people.Sex + " " + people.Balance);
            }

            
            Console.WriteLine("Сортировка по балансу");

            var sortBalance = peoples.OrderByDescending(x => x.Balance);

            foreach (People people in sortBalance)
            {
                Console.WriteLine(people.Name + " " + people.Age + " " + people.Sex + " " + people.Balance);
            }

           
            Console.WriteLine("Сортировка по полу");

            var sortSex = peoples.OrderBy(x => x.Sex);
            foreach (People people in sortSex)
            {
                Console.WriteLine(people.Name + " " + people.Age + " " + people.Sex + " " + people.Balance);
            }
        }
    }
}
