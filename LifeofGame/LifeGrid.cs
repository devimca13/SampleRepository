using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeofGame
{
  
        public class LifeGrid
        {
            // A live cell which has fewer than two live neighbours dies(underpopulation).
            // A live cell which has more than three live neighbours dies(overpopulation).
            // A live cell which has two or three live neighbours lives (Contiues to live in next generation)
            // A dead cell which has exactly three live neighbours will get live (Reproduction).

            public CellStatus[,] Cells;

            public int Columns;
            public int Rows;

            public LifeGrid(int row, int column)
            {
                Columns = column;
                Rows = row;

                Cells = new CellStatus[row, column];
                for (int x = 0; x < column; x++)
                    for (int y = 0; y < row; y++)
                        Cells[x, y] = new CellStatus();

                GetNeighborsLocation();
            }


            private void GetNeighborsLocation()
            {
                for (int x = 0; x < Columns; x++)
                {
                    for (int y = 0; y < Rows; y++)
                    {
                        bool isLeftEnd = (x == 0);
                        bool isRightEnd = (x == Columns - 1);
                        bool isTopEnd = (y == 0);
                        bool isBottomEnd = (y == Rows - 1);

                        int Left = isLeftEnd ? Columns - 1 : x - 1;
                        int Right = isRightEnd ? 0 : x + 1;
                        int Top = isTopEnd ? Rows - 1 : y - 1;
                        int Bottom = isBottomEnd ? 0 : y + 1;

                        Cells[x, y].cellstatus.Add(Cells[Left, Top]);
                        Cells[x, y].cellstatus.Add(Cells[x, Top]);
                        Cells[x, y].cellstatus.Add(Cells[Right, Top]);
                        Cells[x, y].cellstatus.Add(Cells[Left, y]);
                        Cells[x, y].cellstatus.Add(Cells[Right, y]);
                        Cells[x, y].cellstatus.Add(Cells[Left, Bottom]);
                        Cells[x, y].cellstatus.Add(Cells[x, Bottom]);
                        Cells[x, y].cellstatus.Add(Cells[Right, Bottom]);
                    }
                }
            }

            public void GetNextGeneration()
            {
                foreach (var cell in Cells)
                {



                    var childItems = from child in cell.cellstatus
                                     where child.Alive == true
                                     select child;

                    int AliveNeighbor = childItems.Count();

                    // Set alive Cell for Next Generation 
                    cell.NextAlive = (cell.Alive && AliveNeighbor == 2) || AliveNeighbor == 3;
                }

                foreach (var cell in Cells)
                    cell.Alive = cell.NextAlive;
            }

        }

    }
