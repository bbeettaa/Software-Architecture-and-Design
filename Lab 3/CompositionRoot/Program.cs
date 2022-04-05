using BLL.Classes.BLLService;
using BLL.Новая_папка;
using DAL.Classes;
using PL.MenuSection.CreateObject;
using PL.MenuSection.Menu;
using PL.MenuSection.WorckWithObjectMenu;
using System;
using System.Text;

namespace CompositionRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            Simulation simulation = new Simulation();
            Service service = new EntityService(simulation, new BLL.Bll.ChangeState(simulation), new BLL.Classes.Builder.Director(), new BinaryProvider());

            Menu menu = new(service, new WorckWithObjectMenu(service), new CreateObject(service), ConsoleColor.Green);
            menu.MainMenu();
        }
    }
}
