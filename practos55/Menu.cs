using System;
using System.Xml.Serialization;
using System.IO;

namespace practos55
{
    public class Menu
    {
        static public string[] options;
        public int selectedOption;
        static public string[][] comennt = new string[6][];
        static public string[] mainMenu;
        static public int priceF = 0;
        static public string zakaz;
        static int[][] price = new int[6][];
        public Menu(string[] menuOptions)
        {
            options = menuOptions;
            selectedOption = 0;
        }

        static public void Tort()
        {
            
            mainMenu = new string[] { "Форма торта", "Размер торта", "Вкус коржей", "Колличество коржей", "Глазурь", "Декор", "Конец заказа" };
            options = mainMenu;
            Form();
            Price();
        }
        /// <summary>
        /// заполнение массива цен
        /// </summary>
        static void Price()
        {

            price[0] = new int[] { 500, 550, 550, 750 };
            price[1] = new int[] { 2000, 4000, 1000 };
            price[2] = new int[] { 150, 150, 200, 250, 200, 250, 250, 200 };
            price[3] = new int[] { 200, 400, 600, 800, 1000 };
            price[4] = new int[] { 200, 200, 300, 250 };
            price[5] = new int[] { 500, 300, 1000, 300, 700 };

        }
        /// <summary>
        /// цены
        /// </summary>
        static void Form()
        {
            
            comennt[0] = new string[]
{
                "Круг - 500",
                "Квадрат - 550",
                "Прямоугольник - 550",
                "Сердечко - 750"
};
            comennt[1] = new string[]
            {
                "Маленький (Диаметр - 16 см, 8 порций) - 2000",
                "Средний (Диаметр - 18 см, 10 порций) - 4000",
                "Большой (Диаметр - 28 см, 24 порций) - 10000"
            };
            comennt[2] = new string[]
            {
                "Ванильный - 150",
                "Шоколадный - 150",
                "Соленая карамель - 200",
                "Тыквенный - 250",
                "Сникерс - 200",
                "Фисташковый - 250",
                "Клубничный - 250",
                "Персиковый - 200"
            };
            comennt[3] = new string[]
            {
                "1 корж - 200",
                "2 коржа - 400",
                "3 коржа - 600",
                "4 коржа - 800",
                "5 коржей - 1000"
            };
            comennt[4] = new string[]
            {
                "Шоколадная - 200",
                "Ванильная - 200",
                "Фисташковая - 300",
                "Клубничная - 250"
            };
            comennt[5] = new string[]
            {
                "Фрукты - 500",
                "Подтеки - 300",
                "Фигурки - 1000",
                "Блестки - 300",
                "Ягоды - 700"
            };

        }

        public void Glasurka()
        {
            Console.WriteLine("Заказ тортов в ГЛАЗУРЬКА, есть все что вы захотите!!!");
            Console.WriteLine("Собирите торт на ваш выбор<3");
            Console.WriteLine("----------------------------------------------------------------------------------");
        }

        public void PrintZakaz()
        {
            Console.WriteLine("\n---------------------------------------------------------------------------------");
            Console.WriteLine($"Цена: {priceF}");
            Console.WriteLine($"Ваш заказ: {zakaz}");
        }
        public void Choice()
        {
            Console.WriteLine("Для выхода нажмите Escape");
            Console.WriteLine("Выберите лвл");
            Console.WriteLine("--------------------------------");
        }

        public void FinishZakaz()   
        {
            string content = $"Заказ от: {DateTime.Now}\n";
            File.AppendAllText(Program.path, content);
            content = $"\tЗаказ: {zakaz}\n";
            File.AppendAllText(Program.path, content);
            content = $"\tЦена: {priceF}\n\n";
            File.AppendAllText(Program.path, content);
            priceF = 0;
            zakaz = "";
        }


        public void DisplayMenu()
        {
            ConsoleKeyInfo keyInfo;

            do
            { 
                Console.Clear();
               
                if(options==mainMenu) Glasurka();
                else Choice();

                for (int i = 0; i < options.Length; i++)
                {
                    if (i == selectedOption)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("-> " + options[i]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("   " + options[i]);
                    }
                }
                if (options == mainMenu) PrintZakaz();
               

                keyInfo = Console.ReadKey();
               
                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    selectedOption = (selectedOption - 1 + options.Length) % options.Length;
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    selectedOption = (selectedOption + 1) % options.Length;
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    int temp = 0;
                    if (options == mainMenu)
                    {
                        if (selectedOption == 6)
                        {
                            FinishZakaz();

                        }
                        else
                        {
                            options = comennt[selectedOption];
                            temp = selectedOption;
                        }
                       
                        selectedOption = 0;
                        
                    }
                    else
                    {
                        priceF += price[temp][selectedOption];
                        zakaz += comennt[temp][selectedOption] + ", ";
                        options = mainMenu;
                        selectedOption = 0;
                    }

                }
                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    options = mainMenu;
                    selectedOption = 0;

                }

            } while (true);
        }

    }
}
