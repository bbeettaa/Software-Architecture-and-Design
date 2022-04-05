using BLL.Classes;
using BLL.Classes.BLLService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.MenuSection.WorckWithObjectMenu
{
    public class WorckWithObjectMenu : IWorckWithObjectMenu
    {
        private Service service;

        public WorckWithObjectMenu(Service service) {
            this.service = service;
        }

        public void WorckWithObject(int IndexOfChosenObj)
        {
            List<Animal> animals = service.GetAnimals();
            List<Object> info = service.GetAnimals()[IndexOfChosenObj].getAllInfo();
            Console.Clear();
            PrintAnimalInfo(info, IndexOfChosenObj);
            // ConsoleKeyInfo inputKey = Console.ReadKey();
            while (true)
            {
                if (Console.KeyAvailable)
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.F1:
                            service.changeState.ChangeCanFeed(service.GetAnimals()[IndexOfChosenObj]);
                            break;
                        case ConsoleKey.F2:
                            service.changeState.FeedOn_10_Point(service.GetAnimals()[IndexOfChosenObj]);
                            break;
                        case ConsoleKey.PageUp:
                            service.changeState.SpeedUp();
                            break;
                        case ConsoleKey.PageDown:
                            service.changeState.SlowDown();
                            break;
                        case ConsoleKey.Spacebar:
                            service.changeState.Pause();
                            break;
                        case ConsoleKey.Escape:
                        case ConsoleKey.Backspace:
                            return;
                        default:
                            break;

                    }
                //service.ChangeState(Console.ReadKey().KeyChar - '0', IndexOfChosenObj);
                //System.Diagnostics.Debug.WriteLine(((int)Console.ReadKey().Key) - 112);

                info = service.GetAnimals()[IndexOfChosenObj].getAllInfo();
                PrintAnimalInfo(info, IndexOfChosenObj);
            }

        }
        private void PrintAnimalInfo(List<Object> info, int IndexOfChosenObj)
        {
            Console.SetCursorPosition(0, 0);
            String hud =
                String.Format("{0,-10} {1,-10} || {2,-10} {3,-8} {4,-15}\n", info[0], info[1], info[2], info[3], "time: " + service.simulation.GetTime()) +
                String.Format("{0,-10} {1,-10} || {2,-10} {3,-15}\n", info[4], info[5], info[20], info[21]) +
                String.Format("{0,-10} {1,-10} || {2,-10} \n", "", "", service.GetAnimals()[IndexOfChosenObj].locality.GetOwner().ToString()) +
                String.Format("  {0,-10}{0,-10}||{0,-10}{0,-15}  \n", new String('_', 10)) +
                String.Format("{0,-10} {1,-10} || {2,-10} {3,-15}\n", "", "", info[6], info[7]) +
                String.Format("{0,-10} {1,-10} || {2,-10} {3,-15}\n", info[8], info[9], info[14], info[15]) +
                String.Format("{0,-10} {1,-10} || {2,-10} {3,-15}\n", info[10], info[11], info[16], info[17]) +
                String.Format("{0,-10} {1,-10} || {2,-10} {3,-15}\n", info[12], info[13], info[18], info[19]) +
                String.Format("  {0,-10}{0,-10}||{0,-10}{0,-15}  \n", new String('_', 10));
            hud += String.Format("{0,-10}  ", service.GetAnimals()[IndexOfChosenObj].history.ToString());
            Console.WriteLine(hud);

            List<String> str = service.changeState.GetMethodsAndValues();
            Console.SetCursorPosition(55, 15);
            Console.WriteLine(String.Format("F1 {0}: {1}  ", str[0], str[^3]));
            Console.SetCursorPosition(55, 16);
            Console.WriteLine(String.Format("F2 {0}  ", str[1]));
            Console.SetCursorPosition(55, 17);
            Console.WriteLine(String.Format("PageUp {0}: speed = {1}   ", str[2], str[^2]));
            Console.SetCursorPosition(55, 18);
            Console.WriteLine(String.Format("PageDown {0}  ", str[3]));
            Console.SetCursorPosition(55, 19);
            Console.WriteLine(String.Format("Spacebar {0}: {1}    ", str[4], str[^1]));


        }
    }
}
