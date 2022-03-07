/*using BLL.Bll;
using BLL.Classes;
using BLL.Classes.Builder;
using BLL.Новая_папка;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace Bll
{
    class Menu
    {
        static private int IndexOfChosenObj { get; set; }
        static private ConsoleColor consoleColor = ConsoleColor.Green;
        //private List<Shape> objList = new List<Shape>();
        static private Simulation simulation = new Simulation();
        static private ChangeState changeState = new ChangeState();
        static private Director director = new Director();

        static public void MainMenu()
        {
            Console.CursorVisible = false;
            Console.WindowHeight = 42;
            String[] mainMenuSection = new String[] { "Головне меню", "Продивитися набір", "Добавити до набору", "Вийти з програми" };
            PrintMainMenuSections(mainMenuSection);
            simulation.StartNotify();
            while (true)
            {
                PrintMainMenuSections(mainMenuSection);
                MainMenuChooseSections();
            }
        }
        static private void PrintMainMenuSections(String[] mainMenuSection)
        {
            Console.Clear();
            Console.WriteLine(mainMenuSection[0].PadLeft(17, '*').PadRight(22, '*'));
            for (int i = 1; i < mainMenuSection.Length; i++)
                Console.WriteLine(i + ") " + mainMenuSection[i]);
        }
        static private void MainMenuChooseSections()
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    Console.WriteLine("...\n");
                    WorckWithObjMenu();
                    break;

                case ConsoleKey.D2:
                    AddObjectSection();
                    Console.Clear();

                    break;

                case ConsoleKey.Escape:
                case ConsoleKey.D3:
                    Environment.Exit(0);
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

        static private void WorckWithObjMenu()
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
                            if (IndexOfChosenObj + 1 < simulation.GetAnimals().Count)
                                IndexOfChosenObj += 1;
                            break;

                        case ConsoleKey.Delete:
                            if (simulation.GetAnimals().Count > 0)
                                simulation.GetAnimals().RemoveAt(IndexOfChosenObj);
                            if (!(IndexOfChosenObj - 1 < 0))
                                IndexOfChosenObj -= 1;
                            Console.Clear();
                            break;

                        case ConsoleKey.Enter: *//*Enter*//*
                            if (simulation.GetAnimals().Count > 0)
                                WorckWithObject();
                            break;

                        case ConsoleKey.Escape: *//*Esc*//*
                            Console.Clear();
                            return;
                    }
            }
        }

        static private void PrintFindObjs()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write($"Знайдені тварини: \ttime '{simulation.GetTime()}'   ");
            Console.WriteLine($"\n\nУсього тварин {simulation.GetAnimals().Count}:\n");

            switch (simulation.GetAnimals().Count)
            {
                case 0:
                    Console.WriteLine("Об'єкт не знайдено...");
                    break;

                default:

                    for (int i = 0; i < simulation.GetAnimals().Count; i++)
                    {
                        if (IndexOfChosenObj == i)
                            Console.ForegroundColor = consoleColor;

                        Console.WriteLine(simulation.GetAnimals()[i]);
                        Console.ResetColor();
                    }
                    break;
            }
            // }
        }

        static private void Exit()
        {
            Environment.Exit(0);
        }

        /////////////////////////


        static private void WorckWithObject()
        {
            List<Animal> animals = simulation.GetAnimals();
            List<Object> info = animals[IndexOfChosenObj].getAllInfo();
            Console.Clear();
            PrintAnimalInfo(info);
            // ConsoleKeyInfo inputKey = Console.ReadKey();
            while (true)
            {
                if (Console.KeyAvailable)
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.Escape: *//*Esc*//*
                            Console.Clear();
                            return;

                        case ConsoleKey.F1:
                            changeState.ChangeCanFeed(animals[IndexOfChosenObj]);
                            break;
                        case ConsoleKey.F2:
                            changeState.FeedOn_10_Point(animals[IndexOfChosenObj]);
                            break;
                        case ConsoleKey.PageUp:
                            changeState.SpeedUp(simulation);
                            break;
                        case ConsoleKey.PageDown:
                            changeState.SlowDown(simulation);
                            break;
                        case ConsoleKey.Spacebar:
                            changeState.Pause(simulation);
                            break;
                        default:
                            break;

                    }
                info = animals[IndexOfChosenObj].getAllInfo();
                PrintAnimalInfo(info);
            }

        }

        static private void PrintAnimalInfo(List<Object> info)
        {
            Console.SetCursorPosition(0, 0);
            String hud =
                String.Format("{0,-10} {1,-10} || {2,-10} {3,-8} {4,-15}\n", info[0], info[1], info[2], info[3], "time: " + simulation.GetTime()) +
                String.Format("{0,-10} {1,-10} || {2,-10} {3,-15}\n", info[4], info[5], info[20], info[21]) +
                String.Format("{0,-10} {1,-10} || {2,-10} \n", "", "", simulation.GetAnimals()[IndexOfChosenObj].locality.GetOwner().ToString()) +
                String.Format("  {0,-10}{0,-10}||{0,-10}{0,-15}  \n", new String('_', 10)) +
                String.Format("{0,-10} {1,-10} || {2,-10} {3,-15}\n", "", "", info[6], info[7]) +
                String.Format("{0,-10} {1,-10} || {2,-10} {3,-15}\n", info[8], info[9], info[14], info[15]) +
                String.Format("{0,-10} {1,-10} || {2,-10} {3,-15}\n", info[10], info[11], info[16], info[17]) +
                String.Format("{0,-10} {1,-10} || {2,-10} {3,-15}\n", info[12], info[13], info[18], info[19]) +
                String.Format("  {0,-10}{0,-10}||{0,-10}{0,-15}  \n", new String('_', 10));
            hud += String.Format("{0,-10}  ", simulation.GetAnimals()[IndexOfChosenObj].history.ToString());
            Console.WriteLine(hud);

            List<String> str = changeState.GetMethodsAndValues();
            Console.SetCursorPosition(55, 15);
            Console.WriteLine(String.Format("F1 {0}: {1}  ", str[0], str[str.Count - 3]));
            Console.SetCursorPosition(55, 16);
            Console.WriteLine(String.Format("F2 {0}  ", str[1]));
            Console.SetCursorPosition(55, 17);
            Console.WriteLine(String.Format("PageUp {0}: speed = {1}   ", str[2], str[str.Count - 2]));
            Console.SetCursorPosition(55, 18);
            Console.WriteLine(String.Format("PageDown {0}  ", str[3]));
            Console.SetCursorPosition(55, 19);
            Console.WriteLine(String.Format("Spacebar {0}: {1}    ", str[4], str[str.Count - 1]));


        }


        /////////////////////////

        static private void AddObjectSection()
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
                            if (choosenObj + 1 < GetAssemblyTypesAnimal().Count)
                                choosenObj += 1;
                            break;

                        case ConsoleKey.Delete:
                            if (simulation.GetAnimals().Count > 0)
                                simulation.GetAnimals().RemoveAt(choosenObj);
                            if (!(choosenObj - 1 < 0))
                                choosenObj -= 1;
                            Console.Clear();
                            break;

                        case ConsoleKey.Enter: *//*Enter*//*
                            AppendObjectInDatabase(choosenObj);
                            return;

                        case ConsoleKey.Escape: *//*Esc*//*
                            Console.Clear();
                            return;
                    }
            }
        }
        static private void PrintAddObjSection(int choosenObj)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("****Добавити тварину****");

            for (int i = 0; i < GetAssemblyTypesAnimal().Count; i++)
            {
                if (i == choosenObj)
                    Console.ForegroundColor = consoleColor;

                Console.WriteLine($"{i + 1}) {GetAssemblyTypesAnimal()[i].Name}");
                Console.ResetColor();
            }
        }
        static private bool IsObjectChoosen(int choosenObj, ConsoleKeyInfo keyInfo)
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.DownArrow:
                case ConsoleKey.UpArrow:
                    return true;

                case (ConsoleKey)13: *//*Enter*//*
                    AppendObjectInDatabase(choosenObj + 1);
                    return false;

                case (ConsoleKey)27: *//*Esc*//*
                    Console.Clear();
                    return false;

                default:
                    while (!(keyInfo.KeyChar >= 48 && keyInfo.KeyChar <= 57))
                        keyInfo = Console.ReadKey();
                    *//*                       service.AppendObjectInDatabase(keyInfo.KeyChar - '0');
                                           WorckWithObj(true);*//*
                    return false;
            }

        }


        static public void AppendObjectInDatabase(int choosenObj)
        {
            bool enterValue = true;
            int localityType = 0;
            List<Type> list = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Namespace == "BLL.Classes.Builder").ToList();
            list = (from x in list where !typeof(Director).Name.Contains(x.Name) select x).ToList();
            list = (from x in list where !typeof(IBuilder).Name.Contains(x.Name) select x).ToList();
            list = (from x in list where !x.Name.Contains("<>c") select x).ToList();

            localityType = ChooseAnimalLocality(list);
            if (localityType >= 0 && localityType <= 1)
            {
                Console.Write($"\nТварина {GetAssemblyTypesAnimal()[choosenObj].Name}, Введіть ім'я: ");
                String name = InputString();
                var obj = Activator.CreateInstance(list[choosenObj]);
                switch (localityType)
                {
                    case 0:
                        simulation.AddAnimal(director.BuildHomeAnimal((IBuilder)obj, name));
                        break;
                    case 1:
                        simulation.AddAnimal(director.BuildWildAnimal((IBuilder)obj, name));
                        break;
                }
            }
            WorckWithObjMenu();
        }

        static public int ChooseAnimalLocality(List<Type> list)
        {
            //list.Sort((emp1, emp2) => emp1.Name.CompareTo(emp2.Name));
            Console.Write("Виберіть місце розташування тварини: 1) Дім, 2) На волі: ");
            return Console.ReadKey().KeyChar - '0' - 1;
        }

        static public String InputString()
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

                    case ConsoleKey.Enter: *//*Enter*//*
                        return str;

                    case ConsoleKey.Escape: *//*Esc*//*
                        return null;

                    default:
                        Console.SetCursorPosition(l, t);
                        str += ((char)key.KeyChar);
                        Console.Write(str + new string(' ', 30));
                        break;
                }
            }
        }

        static public List<Type> GetAssemblyTypesAnimal()
        {
            List<Type> list = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Namespace == "BLL.Classes.Animals").ToList();
            list.Sort((emp1, emp2) => emp1.Name.CompareTo(emp2.Name));
            list = (from x in list where !typeof(Animal).Name.Contains(x.Name) select x).ToList();
            list = (from x in list where !x.Name.Contains("<>c") select x).ToList();

            return list;
        }

    }
}*/