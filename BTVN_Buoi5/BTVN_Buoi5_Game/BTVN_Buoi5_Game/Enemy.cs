using System;

namespace BTVN_Buoi5_Game
{
    class Enemy : Character
    {
        private Random rd = new Random();

        public Enemy(int x, int y) : base(x, y, 10, 1, 10) 
        {
        }

        public override void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0)
                Health = 0;
        }

        public override void Move(char[,] grid)
        {
            int a = rd.Next(1, 5);
            int newX = PosX, newY = PosY;

            switch (a)
            {
                case 1: newX = PosX + 1; break; 
                case 2: newX = PosX - 1; break; 
                case 3: newY = PosY + 1; break; 
                case 4: newY = PosY - 1; break; 
            }

            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);

            if (newX >= 0 && newX < rows &&
                newY >= 0 && newY < cols &&
                grid[newX, newY] == 'X')
            {
                grid[newX, newY] = '1'; 
                grid[PosX, PosY] = 'X';
                PosX = newX;
                PosY = newY;
            }
        }

        public void Attack(char[,] grid, Player player)
        {
            if (CheckRangeAttack(player))
            {
                player.TakeDamage(Damage);
            }
            else
            {
                Move(grid); 
            }
        }
        public bool CheckRangeAttack(Player player)
        {
            return (Math.Abs(player.PosX - PosX) <= RangeAttack && player.PosY == PosY) ||
                   (Math.Abs(player.PosY - PosY) <= RangeAttack && player.PosX == PosX);
        }
    }
}
