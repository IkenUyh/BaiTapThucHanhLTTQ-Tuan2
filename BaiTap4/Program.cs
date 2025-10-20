using System;

namespace PhanSo
{
    public class cPhanSo
    {
        private long tuSo, mauSo;
        private static int dem = 0;
        public void Dispose()
        {
            tuSo = 0;
            mauSo = 1;
            dem--;
            Console.WriteLine("Da giai phong mot phan so");
        }
        public cPhanSo()
        {
            tuSo = 0;
            mauSo = 1;
            dem++;
        }
        public cPhanSo(long tu, long mau)
        {
            tuSo = tu;
            mauSo = mau;
            if (mauSo == 0) mauSo = 1;
            RutGon();
            dem++;
        }
        public cPhanSo(cPhanSo other)
        {
            tuSo = other.tuSo;
            mauSo = other.mauSo;
            dem++;
        }
        public cPhanSo Assign(cPhanSo other)
        {
            this.tuSo = other.tuSo;
            this.mauSo = other.mauSo;
            if (mauSo == 0) mauSo = 1;
            RutGon();
            return this;
        }
        public static int GetDem()
        {
            return dem;
        }
        public long GetTuSo()
        {
            return this.tuSo;
        }
        public long GetMauSo()
        {
            return this.mauSo;
        }
        public void SetTuSo(long tu)
        {
            this.tuSo = tu;
            RutGon();
        }
        public void SetMauSo(long mau)
        {
            this.mauSo = mau;
            while (mauSo == 0)
            {
                try
                {
                    Console.WriteLine("Mau so ban nhap khong hop le!");
                    Console.Write("Moi ban nhap lai: ");
                    this.mauSo = Convert.ToInt64(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Khong dung dinh dang so nguyen");
                    this.mauSo = 0;
                }
            }
            RutGon();
        }
        public void SetTuMau(long tu, long mau)
        {
            this.tuSo = tu;
            this.mauSo = mau;
            while (mauSo == 0)
            {
                try
                {
                    Console.WriteLine("Mau so ban nhap khong hop le! Moi ban nhap lai:");
                    Console.Write("Nhap tu so: ");
                    this.tuSo = Convert.ToInt64(Console.ReadLine());
                    Console.Write("Nhap mau so: ");
                    this.mauSo = Convert.ToInt64(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Khong dung dinh dang so nguyen");
                    this.mauSo = 0;
                }
            }
            RutGon();
        }
        private static long GCD(long a, long b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            while (b != 0)
            {
                long r = a % b;
                a = b;
                b = r;
            }
            return a;
        }
        private static long LCM(long a, long b)
        {
            return Math.Abs(a / GCD(a, b) * b);
        }
        private void RutGon()
        {
            long ucln = GCD(tuSo, mauSo);
            tuSo /= ucln;
            mauSo /= ucln;
            if (mauSo < 0)
            {
                tuSo = -tuSo;
                mauSo = -mauSo;
            }
        }
        public static cPhanSo ReadFromConsole()
        {
            cPhanSo ps = new cPhanSo();
            do
            {
                try
                {
                    Console.Write("Nhap tu so: ");
                    ps.tuSo = Convert.ToInt64(Console.ReadLine());
                    Console.Write("Nhap mau so: ");
                    ps.mauSo = Convert.ToInt64(Console.ReadLine());
                    if (ps.mauSo == 0)
                        Console.WriteLine("Mau so phai khac 0! Moi ban nhap lai!");
                }
                catch
                {
                    Console.WriteLine("Khong dung dinh dang so nguyen");
                    ps.mauSo = 0;
                }
            } while (ps.mauSo == 0);
            ps.RutGon();
            return ps;
        }
        public void Nhap()
        {
            do
            {
                try
                {
                    Console.Write("Nhap tu so: ");
                    tuSo = Convert.ToInt64(Console.ReadLine());
                    Console.Write("Nhap mau so: ");
                    mauSo = Convert.ToInt64(Console.ReadLine());
                    if (mauSo == 0)
                        Console.WriteLine("Mau so phai khac 0! Moi ban nhap lai!");
                }
                catch
                {
                    Console.WriteLine("Khong dung dinh dang so nguyen");
                    mauSo = 0;
                }
            } while (mauSo == 0);
            RutGon();
        }
        public void Xuat()
        {
            if (tuSo == 0)
                Console.Write("0");
            else if (mauSo == 1)
                Console.Write(tuSo);
            else
                Console.Write($"{tuSo}/{mauSo}");
        }
        public cPhanSo Cong(cPhanSo other)
        {
            long bcnn = LCM(mauSo, other.mauSo);
            long tuMoi = tuSo * (bcnn / mauSo) + other.tuSo * (bcnn / other.mauSo);
            return new cPhanSo(tuMoi, bcnn);
        }
        public cPhanSo Tru(cPhanSo other)
        {
            long bcnn = LCM(mauSo, other.mauSo);
            long tuMoi = tuSo * (bcnn / mauSo) - other.tuSo * (bcnn / other.mauSo);
            return new cPhanSo(tuMoi, bcnn);
        }
        public cPhanSo Nhan(cPhanSo other)
        {
            return new cPhanSo(tuSo * other.tuSo, mauSo * other.mauSo);
        }
        public cPhanSo Chia(cPhanSo other)
        {
            if (other.tuSo == 0)
            {
                Console.WriteLine("Khong the chia cho phan so co tu so bang 0");
                return new cPhanSo(0, 1);
            }
            return new cPhanSo(tuSo * other.mauSo, mauSo * other.tuSo);
        }
        public int SoSanh(cPhanSo other)
        {
            long left = tuSo * other.mauSo;
            long right = other.tuSo * mauSo;
            if (left < right) return -1;
            if (left > right) return 1;
            return 0;
        }
    }
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=====CHUONG TRINH XU LY PHAN SO=====");
            Console.WriteLine("Tong so doi tuong: " + cPhanSo.GetDem());
            Console.WriteLine("\n1. Nhap hai phan so:");
            Console.WriteLine("Nhap phan so thu nhat:");
            cPhanSo ps1 = cPhanSo.ReadFromConsole();
            Console.WriteLine("Nhap phan so thu hai:");
            cPhanSo ps2 = cPhanSo.ReadFromConsole();
            Console.WriteLine("\n2. Ket qua cac phep tinh:");
            Console.Write("Tong: ");
            ps1.Cong(ps2).Xuat();
            Console.WriteLine();
            Console.Write("Hieu: ");
            ps1.Tru(ps2).Xuat();
            Console.WriteLine();
            Console.Write("Tich: ");
            ps1.Nhan(ps2).Xuat();
            Console.WriteLine();
            Console.Write("Thuong: ");
            ps1.Chia(ps2).Xuat();
            Console.WriteLine();
            Console.WriteLine("\n3. Nhap day phan so:");
            int n = -1;
            do
            {
                try
                {
                    Console.Write("Nhap so luong phan so: ");
                    n = Convert.ToInt32(Console.ReadLine());
                    if (n <= 0)
                        Console.WriteLine("So luong phan so phai > 0! Moi ban nhap lai!");
                }
                catch
                {
                    Console.WriteLine("Khong dung dinh dang so nguyen");
                    n = -1;
                }
            } while (n <= 0);
            cPhanSo[] dayPhanSo = new cPhanSo[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Nhap phan so thu {i + 1}:");
                dayPhanSo[i] = cPhanSo.ReadFromConsole();
            }
            Console.WriteLine("\n4. Phan so lon nhat:");
            cPhanSo max = new cPhanSo(dayPhanSo[0]);
            for (int i = 1; i < n; i++)
                if (dayPhanSo[i].SoSanh(max) > 0)
                    max.Assign(dayPhanSo[i]);
            Console.Write("Phan so lon nhat: ");
            max.Xuat();
            Console.WriteLine();
            Console.WriteLine("\n5. Day phan so sap xep tang dan:");
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (dayPhanSo[j].SoSanh(dayPhanSo[j + 1]) > 0)
                    {
                        cPhanSo temp = new cPhanSo(dayPhanSo[j]);
                        dayPhanSo[j].Assign(dayPhanSo[j + 1]);
                        dayPhanSo[j + 1].Assign(temp);
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                dayPhanSo[i].Xuat();
                Console.WriteLine();
            }
            for (int i = 0; i < n; i++)
                dayPhanSo[i].Dispose();
            ps1.Dispose();
            ps2.Dispose();
            Console.WriteLine("\nTong so doi tuong sau khi giai phong: " + cPhanSo.GetDem());
            Console.WriteLine("\n=====KET THUC CHUONG TRINH=====");
        }
    }
}