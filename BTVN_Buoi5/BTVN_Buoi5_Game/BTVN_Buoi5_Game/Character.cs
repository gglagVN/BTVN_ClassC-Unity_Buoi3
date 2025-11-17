using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTVN_Buoi5_Game
{
    abstract class Character
    {   
        private int posX;
        private int posY;
        private int damage;
        private int rangeAttack;
        private int health;
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int Damage { get; set; }
        public int RangeAttack { get; set; }
        public int Health { get; set; }

        protected Character(int posX, int posY, int damage, int rangeAttack, int health)
        {
            PosX = posX;
            PosY = posY;
            Damage = damage;
            RangeAttack = rangeAttack;
            Health = health;
        }

        public abstract void Move(char[,] grid);
        public abstract void TakeDamage(int damage);
        
        public virtual void Attack(char[,] grid)
        {
            
        }
        public virtual bool CheckRangeAttack(char[,] grid)
        {
            return false;
        }
    }
}
