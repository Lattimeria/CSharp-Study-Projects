using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows
{
    class Program
    {
        static void Main(string[] args)
        {
            // игра быки и коровы.
            Console.WriteLine("Компьютер загадал четырехзначеное число. Вам необходимо угадать его за 10 попыток.");
            Console.WriteLine("Быки - нужные цифры на своих местах. Коровы - нужные цифры не на своих местах.\n");

            do
            {
                int[] Que = GenerateNumber();
                Games game = new Games();
                bool g = game.Game(Que);
                if (g == true)
                    Console.WriteLine("Вы выиграли!");
                else
                    Console.WriteLine("Вы проиграли :(");
                Console.WriteLine("Хотите сыграть еще раз? y/n");
            }
            while (Console.ReadLine() == "y");
            Console.WriteLine("Нажмите любую клавишу");
            Console.ReadKey();
        }
        static int[] GenerateNumber() // генерация загадываемого числа
        {
            Random rnd = new Random();
            int[] Que = { 0, 0, 0, 0 };
            int j = 0;
            Que[j] = rnd.Next(1, 10);
            for (j = 1; j < 4; j++)
            {
                Que[j] = rnd.Next(1, 10);
                for (int p = 0; p < 4; p++)
                {
                    if ((Que[j] == Que[p]) && (j != p)) { j--; break; } // числа не должны повторяться
                }
            }
            return Que;
        }

    }
    class Games
    {
        public bool Game(int[] Que)
        {
            Console.WriteLine("\tПопытка\tВвод\tРезультат");
            for (int i = 10; i > 0; i--)
            {
                int num; //введенное пользователем число
                //Console.WriteLine($"Попыток:{i}");
                num = Int32.Parse(Console.ReadLine());

                int[] Num = { 0, 0, 0, 0 };
                int j = 0;
                Num[j] = num / 1000; // тысячные
                Num[j + 1] = (num - Num[j] * 1000) / 100; // сотни
                Num[j + 2] = (num - Num[j] * 1000 - Num[j + 1] * 100) / 10; // десятки
                Num[j + 3] = (num - Num[j] * 1000 - Num[j + 1] * 100 - Num[j + 2] * 10); // единицы

                int cow = 0, bull = 0; // коровы, быки
                for (j = 0; j < 4; j++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        if (Num[j] == Que[k]) cow++;

                    }
                    if (Num[j] == Que[j]) bull++;
                }
                //Console.WriteLine($"Б{bull}К{cow - bull}");
                Console.WriteLine($"\t{i}\t{num}\tБ{bull}К{cow - bull}");
                if (bull == 4)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
