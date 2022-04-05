using BLL.Classes;
using BLL.Classes.BLLService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.MenuSection.CreateObject
{
    public class CreateObject : ICreateObject
    {
        Service service;
        ConsoleColor consoleColor { get; set; }
        public CreateObject(Service service) {
            this.service = service;
            this.consoleColor = ConsoleColor.Green;
        }
        public void AddObjectSection()
        {
            Console.Clear();
            int choosenObj = 0;
            while (true)
            {
                PrintAddObjSection(choosenObj);
                if (Console.KeyAvailable)
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.UpArrow:
                            if (!(choosenObj - 1 < 0))
                                choosenObj -= 1;
                            break;

                        case ConsoleKey.DownArrow:
                            if (choosenObj + 1 < service.GetAssemblyTypesAnimal().Count)
                                choosenObj += 1;
                            break;

                        case ConsoleKey.Delete:
                            if (service.GetAnimals().Count > 0)
                                service.DeleteAnimal(choosenObj);
                            if (!(choosenObj - 1 < 0))
                                choosenObj -= 1;
                            Console.Clear();
                            break;

                        case ConsoleKey.Enter: /*Enter*/
                            AppendObjectInDatabase(choosenObj);
                            return;

                        case ConsoleKey.Escape: /*Esc*/
                            Console.Clear();
                            return;
                    }
            }
        }
        private void PrintAddObjSection(int choosenObj)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("****Добавити тварину****");

            for (int i = 0; i < service.GetAssemblyTypesAnimal().Count; i++)
            {
                if (i == choosenObj)
                    Console.ForegroundColor = consoleColor;

                Console.WriteLine($"{i + 1}) {service.GetAssemblyTypesAnimal()[i].Name}");
                Console.ResetColor();
            }
        }
        private void AppendObjectInDatabase(int choosenObj)
        {
            Console.Write($"\nТварина {service.GetAssemblyTypesAnimal()[choosenObj].Name}, Введіть ім'я: ");
            String name = InputString();
            int localityType = ChooseAnimalLocality();
            service.AppendObject(choosenObj,localityType,name);
            //MenuChooseSection();
        }
        private int ChooseAnimalLocality()
        {
            Console.Write("\nВиберіть місце розташування тварини: 1) Дім, 2) На волі: ");
            return Console.ReadKey().KeyChar - '0' - 1;
        }
        private String InputString()
        {
            String str = "";
            (int l, int t) = Console.GetCursorPosition();
            ConsoleKeyInfo key;
            while (true)
            {
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.DownArrow:
                        break;

                    case ConsoleKey.Delete:
                        Console.Clear();
                        break;
                    case ConsoleKey.Backspace:
                        if (str.Length - 1 >= 0)
                            str = str.Remove(str.Length - 1);
                        Console.SetCursorPosition(l, t);
                        Console.Write(str + new string(' ', 30));
                        break;

                    case ConsoleKey.Enter: /*Enter*/
                        return str;

                    case ConsoleKey.Escape: /*Esc*/
                        return null;

                    default:
                        Console.SetCursorPosition(l, t);
                        str += ((char)key.KeyChar);
                        Console.Write(str + new string(' ', 30));
                        break;
                }
            }
        }
    }
}
