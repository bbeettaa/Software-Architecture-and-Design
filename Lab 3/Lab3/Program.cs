using System;
using System.Text;
using System.Threading;

namespace BLL
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            Menu.MainMenu();
        }
    }
}
