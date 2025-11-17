using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTVN_Buoi5_Game
{
    internal class Player : Character
    {
        private Weapon currentWeapon;
        public Weapon CurrentWeapon
        {
            get { return currentWeapon; }
            set { currentWeapon = value; }
        }

        public Player(int x, int y) : base(x, y, 5, 2, 20)
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
            bool isMove = false;
            while(!isMove)
            {
                Console.WriteLine("Nhap huong di chuyen: (W,A,S,D)");
                string a = Console.ReadLine();
                char direct = char.Parse(a.ToUpper());
                int newX = PosX;
                int newY = PosY;
                switch (direct)
                {
                    case 'W': newX = PosX - 1; break;
                    case 'A': newY = PosY - 1; break;
                    case 'S': newX = PosX + 1; break;
                    case 'D': newY = PosY + 1; break;
                    default:
                        Console.WriteLine("Huong khong hop le! Hay nhap lai (W/A/S/D).");
                        continue;
                }
                if (newX >= 0 && newX < grid.GetLength(0) && newY >= 0 && newY < grid.GetLength(1))
                {
                    if (grid[newX, newY] == 'X')
                    {
                        grid[PosX, PosY] = 'X';
                        grid[newX, newY] = '0'; 
                        PosX = newX;
                        PosY = newY;
                        isMove = true;
                    }
                    else if (grid[newX, newY] == '1')
                    {
                        Console.WriteLine("Co quai o day khong di duoc");
                    }
                }
                else
                {
                    Console.WriteLine("Ban dang co di ra ngoai ban do!");
                }
            }
        }
        public void Attack(char[,] grid, List<Enemy> enemies)
        {
            Enemy target = CheckRangeAttack(enemies);
            if (target != null)
            {
                target.TakeDamage(CurrentWeapon.Damage);
                Console.WriteLine($"Bạn tấn công Enemy tại ({target.PosX},{target.PosY})!");
                if (target.Health <= 0)
                {
                    Console.WriteLine("Enemy đã bị hạ!");
                    grid[target.PosX, target.PosY] = 'X';
                    enemies.Remove(target);
                }
            }
        }
        public Enemy CheckRangeAttack(List<Enemy> enemies)
        {
            foreach (var enemy in enemies)
            {
                if ((Math.Abs(enemy.PosX - PosX) <= CurrentWeapon.RangeAttack && enemy.PosY == PosY) ||
                    (Math.Abs(enemy.PosY - PosY) <= CurrentWeapon.RangeAttack && enemy.PosX == PosX))
                {
                    return enemy;
                }
            }
            return null;
        }
    }
}
