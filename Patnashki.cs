using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Patnashky
    {
        public int x = 3;
        public int y = 3;
        public int tmp;
        public int count;
        public int countOfEnd = 150;

        public int[,] game = new int[,]
           {
               {1, 2, 3, 4},
               {5, 6, 7, 8},
               {9, 10, 11, 12},
               {13, 14, 15, 0}
           };

        public int[,] gamePole = new int[,]
        {
               {1, 2, 4, 3},
               {5, 6, 7, 9},
               {11, 10, 8, 12},
               {15, 14, 13, 0}
        };

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < gamePole.GetLength(0); i++)
            {
                for (int j = 0; j < gamePole.GetLength(1); j++)
                {
                    str += string.Format("{0, 6}", gamePole[i, j]);
                }
                str += "\n\n";
            }
            return str;
        }

        public void Print()
        {
            for (int i = 0; i < gamePole.GetLength(0); i++)
            {
                for (int j = 0; j < gamePole.GetLength(1); j++)
                {
                    Console.Write(gamePole[i, j]);
                }
                Console.Write("\n");
            }
        }

        public void PrintSize()
        {
            Console.Clear();
            Console.CursorTop = 0;
            Console.CursorLeft = 20;
            Console.WriteLine("Кол-во ходов: " + count);
        }

        public bool MoveUp()
        {
            if (y > 0)
            {
                tmp = gamePole[y, x];
                gamePole[y, x] = gamePole[y - 1, x];
                gamePole[y - 1, x] = tmp;
                y--;
                count++;
                return true;
            }
            return false;
        }

        public bool Moveleft()
        {
            if (x > 0)
            {
                tmp = gamePole[y, x];
                gamePole[y, x] = gamePole[y, x - 1];
                gamePole[y, x - 1] = tmp;
                x--;
                count++;
                return true;
            }
            return false;
        }

        public bool MoveRight()
        {
            if (x < 3)
            {
                tmp = gamePole[y, x];
                gamePole[y, x] = gamePole[y, x + 1];
                gamePole[y, x + 1] = tmp;
                x++;
                count++;
                return true;
            }
            return false;
        }

        public bool MoveDown()
        {
            if (y < 3)
            {
                tmp = gamePole[y, x];
                gamePole[y, x] = gamePole[y + 1, x];
                gamePole[y + 1, x] = tmp;
                y++;
                count++;
                return true;
            }
            return false;
        }

        public bool WinOfGame()
        {
            int countItem = 0;
            for (int i = 0; i < gamePole.GetLength(0); i++)
            {
                for (int j = 0; j < gamePole.GetLength(1); j++)
                {
                    if (gamePole[i, j] == game[i, j])
                    {
                        countItem++;
                    }
                }
            }

            if (countItem == 16)
            {
                Console.CursorTop = 3;
                Console.CursorLeft = 50;
                Console.WriteLine("ПОБЕДА");
                return true;
            }
            return false;
        }
        public bool loseOfGame()
        {
            Console.CursorTop = 3;
            Console.CursorLeft = 50;
            Console.WriteLine("ПРОИГРАШЬ");
            return false;
        }

        class Program
        {
            static void Main(string[] args)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Clear();

                Patnashky patnash = new Patnashky();
                Console.CursorVisible = false;

                while (true)
                {
                    Console.WriteLine(patnash.ToString());
                    ConsoleKeyInfo keyInfo = Console.ReadKey();

                    if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        patnash.MoveDown();
                    }

                    else if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        patnash.MoveUp();
                    }

                    else if (keyInfo.Key == ConsoleKey.LeftArrow)
                    {
                        patnash.Moveleft();
                    }

                    else if (keyInfo.Key == ConsoleKey.RightArrow)
                    {
                        patnash.MoveRight();
                    }

                    else if (keyInfo.Key == ConsoleKey.Escape)
                    {
                        break;
                    }

                    patnash.PrintSize();

                    if (patnash.WinOfGame() == true)
                    {
                        break;
                    }
                    else if (patnash.count == patnash.countOfEnd)
                    {
                        patnash.loseOfGame();
                        break;
                    }
                }
            }
        }
    }
}



