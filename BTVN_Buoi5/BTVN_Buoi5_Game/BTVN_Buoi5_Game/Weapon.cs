using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTVN_Buoi5_Game
{
    internal class Weapon
    {
        private string name;
        private int damage;
        private int rangeAttack;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int RangeAttack
        {
            get { return rangeAttack; }
            set { rangeAttack = value; }
        }
        public int Damage
        {
            get { return damage; }
            set {  damage = value; }
        }

        public Weapon(string name, int rangeAttack, int damage)
        {
            Name = name;
            RangeAttack = rangeAttack;
            Damage = damage;
        }
    }
}
