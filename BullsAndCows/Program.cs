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
            var game = new Games();

            Console.WriteLine("Компьютер загадал четырехзначеное число. Вам необходимо угадать его за 10 попыток.");
            Console.WriteLine("Быки - нужные цифры на своих местах. Коровы - нужные цифры не на своих местах.\n");

            do
            {
                game.Start();
                Console.WriteLine("\tПопытка\tВвод\tРезультат");
                while (!game.IsLose())
                {
                    var guess = Int32.Parse(Console.ReadLine());
                    game.Guess(guess, out int bulls, out int cows);

                    Console.WriteLine($"\t{game.TriesCount}\t{guess}\tБ{bulls}К{cows - bulls}");

                    if (game.IsWin(bulls) == true)
                    {
                        Console.WriteLine("Вы выиграли!");
                        break;
                    }

                }
                Console.WriteLine("Хотите сыграть еще раз? y/n");
            }
            while (Console.ReadLine() == "y");

            Console.WriteLine("Нажмите любую клавишу");
            Console.ReadKey();
        }
    }
    public class Games
    {
        private int[] Que = { 0, 0, 0, 0 };

        public int TriesCount { get; private set; }

        public void Start()
        {
            TriesCount = 10;
            Random rnd = new Random();
            int j = 0;
            Que[j] = rnd.Next(1, 10);
            for (j = 1; j < 4; j++)
            {
                Que[j] = rnd.Next(1, 10);
                for (int p = 0; p < 4; p++)
                {
                    if ((Que[j] == Que[p]) && (j != p))
                    {
                        j--;
                        break;
                    } // числа не должны повторяться
                }
            }
        }

        public void Guess(int guess, out int bulls, out int cows)
        {
            cows = 0; bulls = 0; // коровы, быки

            int[] num = { 0, 0, 0, 0 };
            int j = 0;
            num[j] = guess / 1000; // тысячные
            num[j + 1] = (guess - num[j] * 1000) / 100; // сотни
            num[j + 2] = (guess - num[j] * 1000 - num[j + 1] * 100) / 10; // десятки
            num[j + 3] = (guess - num[j] * 1000 - num[j + 1] * 100 - num[j + 2] * 10); // единицы

            for (j = 0; j < 4; j++)
            {
                for (int k = 0; k < 4; k++)
                {
                    if (num[j] == Que[k]) cows++;

                }
                if (num[j] == Que[j]) bulls++;
            }

            TriesCount--;
        }

        public bool IsWin(int bull)
        {
            if (bull == 4)
                return true;
            return false;
        }
        public bool IsLose()
        {
            return TriesCount == 0;
        }
    }
}
