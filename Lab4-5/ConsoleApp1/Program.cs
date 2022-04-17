using BLL.Classes.BLL.Context;
using BLL.Classes.Finder;
using BLL.Classes.Memento;
using DAL.Classes.Repository;
using PL;
using System;


namespace ConsoleApp1
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            App app = new App();
            MainWindow m = new MainWindow(new UserContext(new EntityRepository(),new CareTaker(),new ContentFinder()));

            app.Run(m);
        }
    }
}
