using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperGame
{
    public class Game
    {
        public State state = State.GameNotFinished;
        const int size = 10;
        const int mines = 10;
       
        int[,] mapHidden = new int[size, size];
        char[,] map = new char [size, size];

       
        //метод для очистки поля
        public void ClearMap()
        {
            for(int i = 0; i < size; i++)
            {
                for(int j = 0; j <size; j++)
                {
                    map[i, j] = '#';
                    mapHidden[i, j] = 0;
                }
            }
        }
        //метод для расставления мин
        // число 9 это мина
        public void SetMine()
        {
            Random random = new Random();
            int n = 0;
            int s;
            int x;
            int y;
            state = State.GameNotFinished;
            do
            {
                x = random.Next() % size;
                y = random.Next() % size;
                if (mapHidden[x, y] != 9)
                {
                    mapHidden[x, y] = 9;
                    n++;
                }

            } while (n != mines);

            int count = 0;
            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (i >= 0 && i < size && j >= 0 && j < size && mapHidden[i, j] == 9)
                    {
                        count++;
                    }
                }
            }
        }
        //координаты ходов
        // метод для хода пользователя
        public bool CheckLose(int x , char y)
        {
            int i = (int)(y - 'A');
            int j = x - 1;

            if (mapHidden[i, j] == 9)
            {
                for (i = 0; i < size; i++)
                {
                    for (j = 0; j < size; j++)
                    {
                        if (mapHidden[i, j] == 9)
                        {
                            map[i, j] = '*';
                        }
                    }
                }

                PrintMap();
            }

            state = State.GameLost;
            return true;
        }
        //метод для определения победителя 
        public bool CheckWin()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (map[i, j] == '#' && mapHidden[i, j] != 9)
                    {
                        return false;
                    }
                }
            }

            PrintMap();
            state = State.GameWon;
            return true;
        }

        //выводим поле
        public void PrintMap()
        {
            Console.Write(" ");
            for(int i = 1;i <= size; i++)
            {
                Console.Write(i + " ");
            }
            Console.Write("\n---------------------\n");
            for(int i = 0; i < size; i++)
            {
                Console.Write((char)(i + 65) + "|");
                for(int j = 0; j < size; j++)
                {
                    Console.Write(map[i, j] + " ");
                }
                Console.WriteLine(" ");
            }
        }
    }
}




