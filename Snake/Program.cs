using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        struct Coor
        {//Coordinate system
            public int x;
            public int y;
        }
        struct State
        {
            public char[,] matrix;
            public Coor head;
            public Coor direction;
            public int points;
        }
        static void Main(string[] args)
        {
            State gameState = new State();

            Console.Write("Game size (suggested 25): ");
            int size = int.Parse(Console.ReadLine());
            gameState.matrix = new char[size+2,size+2];

            Initialize(ref gameState);
            Render(gameState);
        }


        static void Initialize(ref State state)
        {
            int sideLength = state.matrix.GetLength(0);
            //Fills the matrix with the sides and the empty background
            for(int i = 0; i < sideLength; i++)
            {
                for (int j = 0; j < sideLength; j++)
                {
                    if (i == 0 | j == 0 | j == sideLength - 1 | i == sideLength - 1)
                        state.matrix[i, j] = '#';
                    else
                        state.matrix[i, j] = '.';
                }
            }
            //Sets the player position to the middle of the screen and its direction to the right
            state.head = new Coor { x = sideLength / 2, y = sideLength / 2 };
            state.matrix[state.head.x, state.head.y] = 's';
            state.direction = new Coor { x = 0, y = 1 };
            state.points = 0;
        }

        static void Render(State state)
        {
            Console.Clear();
            //Draws the stage
            for(int i = 0; i < state.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < state.matrix.GetLength(0); j++)
                {
                    switch (state.matrix[i, j])
                    {
                        case '#': Console.BackgroundColor = ConsoleColor.White; break;
                        case '.': Console.BackgroundColor = ConsoleColor.Black; break;
                        case 's': Console.BackgroundColor = ConsoleColor.Green; break;
                        case 'a': Console.BackgroundColor = ConsoleColor.Red; break;
                    }
                    Console.Write("  ");
                }
                Console.WriteLine();
            }
            //Points
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Points: {0}", state.points);
        }
    }
}
