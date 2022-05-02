using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeofGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Position of Live Cells");

            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Position of Row and Column (r,c)");

            LifeGrid grid = new LifeGrid(25, 25);

            for (int i = 0; i < n; i++)
            {
                var position = Console.ReadLine();

                var positions = position.Split(' ');
                int x = Convert.ToInt32(positions[0]);
                int y = Convert.ToInt32(positions[1]);

                grid.Cells[x, y].Alive = true;
            }

            Console.WriteLine("Enter the Position of Generation, which you are needed?");
            var gen = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= gen; i++)
            {
                grid.GetNextGeneration();

            }


            for (int i = 0; i < grid.Columns; i++)
                for (int j = 0; j < grid.Rows; j++)
                {
                    if (grid.Cells[i, j].Alive)
                    {
                        Console.WriteLine("(" + i + " " + j + ")");
                    }
                }
            Console.ReadLine();

        }

    }
}
