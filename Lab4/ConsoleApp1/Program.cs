using BLL.Classes.BLL.Context;
using BLL.Classes.FileFound;
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
            MainWindow m = new MainWindow(new UserContext(new EntityRepository(),new FileFinder()));

            app.Run(m);
        }
    }
}
