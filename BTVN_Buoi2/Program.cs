using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Diagnostics;
using System.Data;

namespace BTVN_Buoi2
{
    internal class Program
    {
        static void Bai1()
        {

            Stack <char> stack = new Stack <char>();
            stack.Push('a');
            Console.WriteLine("Enter bracket: ");
            string bracket = Console.ReadLine();
            for(int i = 0;i<bracket.Length;i++)
            {
                if(bracket[i] == '(' || bracket[i] == '[' || bracket[i] == '{')
                stack.Push(bracket[i]);
                else if (bracket[i] == ')')
                {

                    if (stack.Peek() == 'a' || stack.Pop() != '(' )
                    {
                        Console.WriteLine("❌ No");
                        return;
                    }
                }
                else if (bracket[i] == '}')
                {

                    if (stack.Peek() == 'a' || stack.Pop() != '{')
                    {
                        Console.WriteLine("❌ No");
                        return;
                    }
                }
                else if (bracket[i] == ']')
                {

                    if (stack.Peek() == 'a' || stack.Pop() != '[')
                    {
                        Console.WriteLine("❌ No");
                        return;
                    }
                }
            }

            
            if(stack.Count > 1)
            {
                Console.WriteLine("❌ No");
                return;
            }
            Console.WriteLine("✨ Yes");
        }

        static void Bai2()
        {
            Console.WriteLine("Enter string: ");
            string s = Console.ReadLine();
            Stack <char> stack = new Stack<char>();
            for(int i=0; i<s.Length;i++)
            {
                stack.Push(s[i]);
            }
            foreach(char c in stack)
            {
                Console.Write(c);
            }
            Console.WriteLine("");
        }
        struct Product
        {
            public string name;
            public double price;
            public int quantity;

            public Product(string name, double price, int quantity)
            {
                this.name = name;
                this.price = price;
                this.quantity = quantity;
            }
        }
        public static void Bai3()
        {
            Dictionary<string, Dictionary<string, Product>> ProductManager = new Dictionary<string, Dictionary<string, Product>>();
            ProductManager["Dang Tuan Linh"] = new Dictionary<string, Product>();
            ProductManager["Dang Tuan Linh"]["SP01"] = new Product("Bim Bim", 10000,10);
            ProductManager["Dang Tuan Linh"]["SP02"] = new Product("Kem", 20000, 90);
            ProductManager["Dang Tuan Linh"]["SP03"] = new Product("Banh", 30000, 50);
            ProductManager["Nguyen Van Hieu"] = new Dictionary<string, Product>();
            ProductManager["Nguyen Van Hieu"]["SP01"] = new Product("Bim Bim", 10000,10);
            ProductManager["Nguyen Van Hieu"]["SP02"] = new Product("Kem", 20000, 10);
            ProductManager["Nguyen Van Hieu"]["SP03"] = new Product("Banh", 30000, 20);
            ProductManager["Nguyen Van Tung"] = new Dictionary<string, Product>();
            ProductManager["Nguyen Van Tung"]["SP01"] = new Product("Bim Bim", 10000, 10);
            ProductManager["Nguyen Van Tung"]["SP02"] = new Product("Kem", 20000, 40);
            ProductManager["Nguyen Van Tung"]["SP03"] = new Product("Banh", 30000, 10);
            ProductManager["Nguyen Quang Minh"] = new Dictionary<string, Product>();
            ProductManager["Nguyen Quang Minh"]["SP01"] = new Product("Bim Bim", 10000, 10);
            ProductManager["Nguyen Quang Minh"]["SP02"] = new Product("Kem", 20000, 20);

            Product product1 = new Product();
            Console.WriteLine("Enter name of employee: ");
            string NameEmployee = Console.ReadLine();
            if (ProductManager.ContainsKey(NameEmployee))
            {
                Console.WriteLine("Name of employee is exist!");
                Console.WriteLine("Enter serial product: ");
                string serialProduct = Console.ReadLine();
                if (ProductManager[NameEmployee].ContainsKey(serialProduct))
                {
                    Console.WriteLine("Serial product is exist!");
                    product1.name = ProductManager[NameEmployee][serialProduct].name;
                    product1.price = ProductManager[NameEmployee][serialProduct].price;
                    Console.WriteLine("Quantity of sell product want to add: ");
                    product1.quantity = int.Parse(Console.ReadLine()) + ProductManager[NameEmployee][serialProduct].quantity;
                    ProductManager[NameEmployee][serialProduct] = product1;
                    Console.WriteLine("Number of sell product: " + ProductManager[NameEmployee][serialProduct].quantity);
                }
                else
                {
                    Console.WriteLine("Serial product is not exist!");
                    Console.WriteLine("Add name of product");
                    product1.name = Console.ReadLine();
                    Console.WriteLine("Add price of product");
                    product1.price = double.Parse(Console.ReadLine());
                    Console.WriteLine("Add quantity sell of product");
                    product1.quantity = int.Parse(Console.ReadLine());
                    ProductManager[NameEmployee][serialProduct] = product1;
                    Console.WriteLine("Number of sell product: " + ProductManager[NameEmployee][serialProduct].quantity);
                }
            }
            else
            {
                ProductManager[NameEmployee] = new Dictionary<string, Product>();
                Console.WriteLine("Name of employee is not exist!");
                Console.WriteLine("Enter serial product: ");
                string serialProduct = Console.ReadLine();
                Console.WriteLine("Add name of product");
                product1.name = Console.ReadLine();
                Console.WriteLine("Add price of product");
                product1.price = double.Parse(Console.ReadLine());
                Console.WriteLine("Add quantity sell of product");
                product1.quantity = int.Parse(Console.ReadLine());
                ProductManager[NameEmployee][serialProduct] = product1;
                Console.WriteLine("Number of sell product: " + ProductManager[NameEmployee][serialProduct].quantity);
            }
            int max = 0;
            string Human = "";
            foreach (var name in ProductManager)
            {
                int total = 0;
                foreach(var SP in ProductManager[name.Key])
                {
                    total += SP.Value.quantity;
                }
                if(total > max)
                {
                    max = total;
                    Human = name.Key;
                }      
            }
            Console.WriteLine("Employee of the year: " + Human);
            Dictionary<string,int> numberSellProduct = new Dictionary<string,int>();
            foreach (var name in ProductManager)
            {
                foreach (var SP in ProductManager[name.Key])
                {
                    if(numberSellProduct.ContainsKey(SP.Key))
                        numberSellProduct[SP.Key] += SP.Value.quantity;
                    else 
                        numberSellProduct[SP.Key] = SP.Value.quantity;
                }
                
            }

            int maxSell = 0;
            string productName = "";
            foreach(var numberSell in numberSellProduct)
            {
                if(numberSell.Value > maxSell)
                {
                    productName = numberSell.Key;
                    maxSell = numberSell.Value;
                }
            }
            Console.WriteLine("Product have max sell number: " + productName);

        }
        static void Main(string[] args)
        {
            int choice = -1;
            while (choice != 4)
            {
                Console.WriteLine("Nhap bai de kiem tra: (4 de thoat)");
                choice = int.Parse(Console.ReadLine());
            
                switch(choice)
                {
                    case 1:
                        Bai1();
                        break;
                    case 2:
                        Bai2(); break;
                    case 3:
                        Bai3(); break;
                }

            }
            
        }
    }
}
