using practos55;
using System;
using System.IO;

namespace practos55
{
    public class Program
    {
        public static string path = "zakaz.txt";
        public static void Main()
        {
            if (!File.Exists(path))
            {
                File.Create(path);
            }

            Menu.Tort();
           
            Menu menu = new Menu(Menu.options);
            menu.DisplayMenu();
            Console.WriteLine("Selected option: " + Menu.options[menu.selectedOption]);
        }
    }
}