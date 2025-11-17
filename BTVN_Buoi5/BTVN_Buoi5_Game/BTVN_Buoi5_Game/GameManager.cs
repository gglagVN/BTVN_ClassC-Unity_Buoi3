using System;
using System.Collections.Generic;

namespace BTVN_Buoi5_Game
{
    class GameManager
    {
        private Player player;
        private List<Enemy> enemies;
        public List<Weapon> weapons = new List<Weapon>();
        private GridManager gridManager;
        private int rows = 5;
        private int cols = 5;

        public GameManager()
        {
            gridManager = new GridManager(rows, cols); 
            enemies = new List<Enemy>();
            weapons.Add(new Weapon("Arrow", 4, 3));
            weapons.Add(new Weapon("Sword", 2, 5));
            weapons.Add(new Weapon("Spear", 3, 4));
            weapons.Add(new Weapon("CheatButton", 5, 100));
        }
        public void SpawnEntity(int level)
        {
            Random rd = new Random();
            for (int i = 0; i < level; i++)
            {
                int x, y;
                do
                {
                    x = rd.Next(rows);
                    y = rd.Next(cols);
                } while ((x == player.PosX && y == player.PosY) || enemies.Exists(e => e.PosX == x && e.PosY == y));

                enemies.Add(new Enemy(x, y));
            }
        }
        public bool CheckWinOrLose()
        {
            bool check = false;
            if (enemies.Count == 0)
            {
                Console.WriteLine("Bạn đã thắng!");
                check = true;
                return check;
            }

            foreach (var enemy in enemies)
            {
                enemy.Attack(gridManager.GetGrid(), player);
                if (player.Health <= 0)
                {
                    Console.WriteLine("Bạn đã thua!");
                    check = true;
                    return check;
                }
            }
            return check;
        }

        public void StartBattle()
        {
            player = new Player(0, 0);
            int choose = -1;
            while (choose < 0 || choose > 3 )
            {
                Console.WriteLine("Nhập loại vũ khí bạn muốn chọn:(1-3) \n1.Cung\n2.Kiếm\n3.Giáo");
                choose = int.Parse(Console.ReadLine());
                switch (choose)
                {
                    case 0:
                        player.CurrentWeapon = weapons[3];
                        break;
                    case 1:
                        player.CurrentWeapon = weapons[0];
                        break;
                    case 2:
                        player.CurrentWeapon = weapons[1];
                        break;
                    case 3:
                        player.CurrentWeapon = weapons[2];
                        break;
                    default:
                        Console.WriteLine("Vui lòng chọn vũ khí dựa theo số 1-3");
                        break;
                }
            }
            
            Console.WriteLine($"Player Weapon: {player.CurrentWeapon.Name}");
            Console.WriteLine($"Attack Range: {player.CurrentWeapon.RangeAttack}");
            Console.WriteLine($"Attack Damage: {player.CurrentWeapon.Damage}");
            Console.WriteLine("Nhập độ khó: (1. Dễ \t 2. Thường \t 3. Khó)");
            int level = int.Parse(Console.ReadLine());
            SpawnEntity(level);
            bool check = false;
            while (check == false)
            {
                Console.Clear();
                Console.WriteLine($"Player HP: {player.Health}");
                Console.WriteLine($"Player Weapon: {player.CurrentWeapon.Name}");
                Console.WriteLine($"Attack Range: {player.CurrentWeapon.RangeAttack}");
                Console.WriteLine($"Attack Damage: {player.CurrentWeapon.Damage}");
                Console.WriteLine("Grid:");
                gridManager.UpdateGrid(enemies, player);
                gridManager.DrawGrid();

                player.Move(gridManager.GetGrid());
                player.Attack(gridManager.GetGrid(), enemies);
                foreach(Enemy en in  enemies)
                {
                    Console.WriteLine("Enemy tại vị trí " + en.PosX + "," + en.PosY + " còn " + en.Health + " Máu");
                }

                enemies.RemoveAll(e => e.Health <= 0);
                check = CheckWinOrLose();
                if(!check)
                Console.WriteLine("Nhấn Enter để tiếp tục lượt tiếp theo...");
                Console.ReadLine();
            }
        }
    }
}
