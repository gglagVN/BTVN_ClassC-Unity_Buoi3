using BTVN_Buoi3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTVN_Buoi4
{
    internal class Program
    {
        static List<CONGNHAN> list = new List<CONGNHAN>();
        public static void add()
        {
            CONGNHAN cn = new CONGNHAN();
            Console.WriteLine("ID of employee: ");
            string ID = Console.ReadLine();
            for (int i=0;i<list.Count;i++)
            {
                if (list[i].ID == ID)
                {
                    Console.WriteLine("ID is exist, enter other ID");
                    ID = Console.ReadLine();
                    i = -1;
                }
            }
            cn.ID = ID;
            Console.WriteLine("Name of employee: ");
            cn.Name = Console.ReadLine();
            Console.WriteLine("Address of employee: ");
            cn.Address = Console.ReadLine();
            try
            {
                int age = -1;
                while (age <= 0)
                {
                    Console.WriteLine("Age must >= 0");
                    Console.WriteLine("Age of employee: ");
                    age = int.Parse(Console.ReadLine());
                }
                cn.Age = age;
                Console.WriteLine("Job of employee:\nTruongNhom = 5\nPhoNhom = 4\nCongNhanBac3 = 3\nCongNhanBac2 = 2\nCongNhanBac1 = 1\nKhac = 0");
                int ChucVu = int.Parse(Console.ReadLine());
                cn.ChucVu = (CONGNHAN.Job)ChucVu;
                list.Add(cn);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void display()
        {
            Console.WriteLine("=================LIST OF EMPLOYEE==============");
            Console.WriteLine(string.Format("{0,-10}{1,-25}{2,-25}{3,-5}{4,-20}{5,-15}", "ID", "Name", "Address", "Age", "Job","Salary"));
            foreach (CONGNHAN cn in list)
            {
                Console.WriteLine(string.Format("{0,-10}{1,-25}{2,-25}{3,-5}{4,-20}{5,-15}", cn.ID, cn.Name, cn.Address, cn.Age, cn.ChucVu,cn.TinhLuong()));
            }
        }

        public static void sort()
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (string.Compare(list[i].Name, list[j].Name) > 0)
                    {
                        CONGNHAN temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                    else if(string.Compare(list[i].Name,list[j].Name) == 0 && list[i].TinhLuong() > list[j].TinhLuong())
                    {
                            CONGNHAN temp = list[i];
                            list[i] = list[j];
                            list[j] = temp;
                    }
                }
            }
        }

        public static void findByID(string id)
        {
            foreach (CONGNHAN cn in list)
            {
                if(cn.ID == id)
                {
                    Console.WriteLine("ID is exist!");
                    Console.WriteLine(string.Format("{0,-10}{1,-25}{2,-25}{3,-5}{4,-20}{5,-15}", "ID", "Name", "Address", "Age", "Job", "Salary"));
                    Console.WriteLine(string.Format("{0,-10}{1,-25}{2,-25}{3,-5}{4,-20}{5,-15}", cn.ID, cn.Name, cn.Address, cn.Age, cn.ChucVu, cn.TinhLuong()));
                    return; 
                }
            }
            Console.WriteLine("ID is not exist!");
        }
        static void Main(string[] args)
        {
            int choose = -1;
            list.Add(new CONGNHAN("E01", (CONGNHAN.Job)4, "Nguyen Van Hieu", 21, "Hai Duong"));
            list.Add(new CONGNHAN("E02", (CONGNHAN.Job)4, "Nguyen Van Tung", 21, "Bac Ninh"));
            list.Add(new CONGNHAN("E03", (CONGNHAN.Job)5, "Nguyen Van Nam", 22, "Hai Duong"));
            list.Add(new CONGNHAN("E04", (CONGNHAN.Job)3, "Nguyen Quang Minh", 26, "Phu Tho"));
            list.Add(new CONGNHAN("E05", (CONGNHAN.Job)1, "Dang Tuan Linh", 21, "Ninh Binh"));
            list.Add(new CONGNHAN("E06", (CONGNHAN.Job)0, "Nguyen Van Tung", 21, "Hai Duong"));
            while (choose != 5)
            {
                Console.WriteLine("=======================EMPLOYEE MANAGER==================");
                Console.WriteLine("1. ADD");
                Console.WriteLine("2. DISPLAY");
                Console.WriteLine("3. SORT");
                Console.WriteLine("4. FIND BY ID");
                Console.WriteLine("5. EXIT");
                Console.WriteLine("Enter select number: ");
                try
                {
                    choose = int.Parse(Console.ReadLine());
                    switch (choose)
                    {
                        case 1:
                            add();
                            break;
                        case 2:
                            display();
                            break;
                        case 3:
                            sort();
                            display();
                            break;
                        case 4:
                            Console.WriteLine("Enter ID to find: ");
                            string id = Console.ReadLine();
                            findByID(id);
                            break;
                        case 5:
                            Console.WriteLine("Exit program...");
                            break;
                        default:
                            Console.WriteLine("Please enter number(1-5)");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                }

            }
        }
}
