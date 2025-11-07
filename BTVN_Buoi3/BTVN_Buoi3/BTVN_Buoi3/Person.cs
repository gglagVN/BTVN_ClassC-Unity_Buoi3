using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTVN_Buoi3
{
    internal class Person
    {
        private string name;
        private int age;
        private string address;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public Person(string name, int age, string address)
        {
            Name = name;
            Age = age;
            Address = address;
        }

        public Person()
        {
        }
    }
}
