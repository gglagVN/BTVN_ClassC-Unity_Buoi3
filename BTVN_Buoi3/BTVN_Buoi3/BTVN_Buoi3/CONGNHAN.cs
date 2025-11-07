using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTVN_Buoi3
{
    internal class CONGNHAN : Person
    {
        private string iD;
        private Job chucVu;
        public string ID
        {
            get { return iD; }
            set { iD = value; }
        }
        public Job ChucVu
        {
            get { return chucVu; }
            set { chucVu = value; }
        }
        public enum Job
        {
            TruongNhom = 5,
            PhoNhom = 4,
            CongNhanBac3 = 3,
            CongNhanBac2 = 2,
            CongNhanBac1 = 1,
            Khac = 0
        }

        public CONGNHAN(string iD, Job chucVu, string name, int age, string address) : base(name,age,address)
        {
            ChucVu = chucVu;
            ID = iD;
        }

        public CONGNHAN()
        {
        }
        public double TinhLuong()
        {
            if ((int)ChucVu == 1)
                return 3 * 8000000;
            else if ((int)ChucVu == 2)
                return 2.5 * 80000000;
            else if ((int)ChucVu == 3)
                return 2 * 8000000;
            else if ((int)ChucVu == 4)
                return 1.5 * 8000000;
            else if ((int)ChucVu == 5)
                return 1.2 * 8000000;
            else
                return 8000000;
        }

    }
}
