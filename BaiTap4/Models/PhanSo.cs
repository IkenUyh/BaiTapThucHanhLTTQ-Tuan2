// File: Models/PhanSo.cs
using System;

namespace BaiTap4.Models
{
    public class PhanSo : IDisposable
    {
        private long tuSo, mauSo;
        private static int dem = 0;
        private bool disposed = false;
        public void Dispose()
        {
            if (!disposed)
            {
                tuSo = 0;
                mauSo = 1;
                dem--;
                Console.WriteLine("Da giai phong mot phan so");
                disposed = true;
            }
        }
        public PhanSo()
        {
            tuSo = 0;
            mauSo = 1;
            dem++;
        }
        public PhanSo(long tu, long mau)
        {
            tuSo = tu;
            mauSo = mau;
            if (mauSo == 0) mauSo = 1;
            RutGon();
            dem++;
        }
        public PhanSo(PhanSo other)
        {
            tuSo = other.tuSo;
            mauSo = other.mauSo;
            dem++;
        }
        public PhanSo Assign(PhanSo other)
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
        public static PhanSo ReadFromConsole()
        {
            PhanSo ps = new PhanSo();
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
        public PhanSo Cong(PhanSo other)
        {
            long bcnn = LCM(mauSo, other.mauSo);
            long tuMoi = tuSo * (bcnn / mauSo) + other.tuSo * (bcnn / other.mauSo);
            return new PhanSo(tuMoi, bcnn);
        }
        public PhanSo Tru(PhanSo other)
        {
            long bcnn = LCM(mauSo, other.mauSo);
            long tuMoi = tuSo * (bcnn / mauSo) - other.tuSo * (bcnn / other.mauSo);
            return new PhanSo(tuMoi, bcnn);
        }
        public PhanSo Nhan(PhanSo other)
        {
            return new PhanSo(tuSo * other.tuSo, mauSo * other.mauSo);
        }
        public PhanSo Chia(PhanSo other)
        {
            if (other.tuSo == 0)
            {
                Console.WriteLine("Khong the chia cho phan so co tu so bang 0");
                return new PhanSo(0, 1);
            }
            return new PhanSo(tuSo * other.mauSo, mauSo * other.tuSo);
        }
        public int SoSanh(PhanSo other)
        {
            long left = tuSo * other.mauSo;
            long right = other.tuSo * mauSo;
            if (left < right) return -1;
            if (left > right) return 1;
            return 0;
        }
    }
}