using BLL.Classes;
using BLL.Classes.BLLService;
using PL.MenuSection.CreateObject;
using PL.MenuSection.WorckWithObjectMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PL.MenuSection.Menu
{
    public class Menu
    {
        private int IndexOfChosenObj { get; set; }
        private Service service;
        private ConsoleColor consoleColor;
        private IWorckWithObjectMenu worckWithObject;
        private ICreateObject createObject;

        public Menu(Service service, IWorckWithObjectMenu worckWithObject, ICreateObject createObject, ConsoleColor consoleColor)
        {
            this.service = service;
            this.worckWithObject = worckWithObject;
            this.createObject = createObject;
            this.consoleColor = consoleColor;

        }

        public void MainMenu()
        {
            Console.CursorVisible = false;
            Console.WindowHeight = 42;
            String[] mainMenuSection = new String[] { "Головне меню", "Продивитися набір", "Добавити до набору", "Вийти з програми" };
            PrintMainMenuSections(mainMenuSection);

            while (true)
            {
                PrintMainMenuSections(mainMenuSection);
                MainMenuChooseSections();
            }
        }
        private void PrintMainMenuSections(String[] mainMenuSection)
        {
            Console.Clear();
            Console.WriteLine(mainMenuSection[0].PadLeft(17, '*').PadRight(22, '*'));
            for (int i = 1; i < mainMenuSection.Length; i++)
                Console.WriteLine(i + ") " + mainMenuSection[i]);
        }
        private void MainMenuChooseSections()
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    Console.WriteLine("...\n");
                    MenuChooseSection();
                    break;

                case ConsoleKey.D2:
                    createObject.AddObjectSection();
                    Console.Clear();

                    break;

                case ConsoleKey.Escape:
                case ConsoleKey.D3:
                    Exit();
                    break;

                default:
                    Console.WriteLine("... Невідома команда\n");
                    break;

                case ConsoleKey.DownArrow:
                case ConsoleKey.UpArrow:
                case ConsoleKey.LeftArrow:
                case ConsoleKey.RightArrow:
                    break;
            }
        }

        private void MenuChooseSection()
        {
            Console.Clear();
            while (true)
            {
                PrintFindObjs();
                if (Console.KeyAvailable)
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.UpArrow:
                            if (!(IndexOfChosenObj - 1 < 0))
                                IndexOfChosenObj -= 1;
                            break;

                        case ConsoleKey.DownArrow:
                            if (IndexOfChosenObj + 1 < service.GetAnimals().Count)
                                IndexOfChosenObj += 1;
                            break;

                        case ConsoleKey.Delete:
                            if (service.GetAnimals().Count > 0)
                                service.GetAnimals().RemoveAt(IndexOfChosenObj);
                            if (!(IndexOfChosenObj - 1 < 0))
                                IndexOfChosenObj -= 1;
                            Console.Clear();
                            break;

                        case ConsoleKey.Enter: /*Enter*/
                            if (service.GetAnimals().Count > 0)
                                worckWithObject.WorckWithObject(IndexOfChosenObj);
                            Console.Clear();
                            break;

                        case ConsoleKey.Escape: /*Esc*/
                            Console.Clear();
                            return;
                    }
            }
        }

        private void PrintFindObjs()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write($"Знайдені тварини: \ttime '{service.simulation.GetTime()}'   ");
            Console.WriteLine($"\n\nУсього тварин {service.GetAnimals().Count}:\n");

            switch (service.GetAnimals().Count)
            {
                case 0:
                    Console.WriteLine("Об'єкт не знайдено...");
                    break;

                default:

                    for (int i = 0; i < service.GetAnimals().Count; i++)
                    {
                        if (IndexOfChosenObj == i)
                            Console.ForegroundColor = consoleColor;

                        Console.WriteLine(service.GetAnimals()[i]);
                        Console.ResetColor();
                    }
                    break;
            }
        }

        private void Exit()
        {
            Environment.Exit(0);
        }

        /////////////////////////



        /////////////////////////

    }
}