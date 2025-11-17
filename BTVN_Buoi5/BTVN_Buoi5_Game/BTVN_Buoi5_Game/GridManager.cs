using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTVN_Buoi5_Game
{
    class GridManager
    {
        int xWide = 5;
        int yHigh = 5;
        List<Enemy> enemies = new List<Enemy>();
        Character player;
        char[,] grid;

        public GridManager(int xWide = 5, int yHigh = 5)
        {
            this.xWide = xWide;
            this.yHigh = yHigh;
            grid = new char[xWide, yHigh];
            enemies = new List<Enemy>();
        }

        public void SpawnTile()
        {
            for (int i = 0; i < xWide; i++)
            {
                for (int j = 0; j < yHigh; j++)
                {
                    grid[i, j] = 'X';
                }
            }
        }
        public void UpdateGrid(List<Enemy> enemies ,Player player)
        {
            SpawnTile();
            int xP = player.PosX;
            int yP = player.PosY;
            grid[xP, yP] = '0';
            foreach (Enemy enemy in enemies)
            {
                int xE = enemy.PosX;
                int yE = enemy.PosY;
                grid[xE, yE] = '1';
            }
        }
        public void DrawGrid()
        {
            for (int i = 0; i < xWide; i++)
            {
                for (int j = 0; j < yHigh; j++)
                {
                    Console.Write(grid[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public char[,] GetGrid() => grid;
    }
}
