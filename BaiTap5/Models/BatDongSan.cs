// File: Models/BatDongSan.cs
using System;

namespace BaiTapNew.Models
{
    public abstract class BatDongSan : IDisposable
    {
        protected string diaDiem;
        protected double giaBan;
        protected double dienTich;
        protected static int dem = 0;
        private bool disposed = false;
        public void Dispose()
        {
            if (!disposed)
            {
                Console.WriteLine("Da huy mot bat dong san");
                dem--;
                disposed = true;
            }
        }
        public BatDongSan()
        {
            diaDiem = "";
            giaBan = 0;
            dienTich = 0;
            dem++;
        }
        public BatDongSan(string diaDiem, double giaBan, double dienTich)
        {
            this.diaDiem = diaDiem;
            this.giaBan = giaBan;
            this.dienTich = dienTich;
            dem++;
        }
        public BatDongSan(BatDongSan other)
        {
            diaDiem = other.diaDiem;
            giaBan = other.giaBan;
            dienTich = other.dienTich;
            dem++;
        }
        public string GetDiaDiem() => diaDiem;
        public double GetGiaBan() => giaBan;
        public double GetDienTich() => dienTich;
        public static int GetDem() => dem;
        public void SetDiaDiem(string value) => diaDiem = value;
        public void SetGiaBan(double value)
        {
            while (value <= 0)
            {
                try
                {
                    Console.Write("Gia ban khong hop le! Moi ban nhap lai: ");
                    value = Convert.ToDouble(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Khong dung dinh dang so thuc");
                    value = -1;
                }
            }
            giaBan = value;
        }
        public void SetDienTich(double value)
        {
            while (value <= 0)
            {
                try
                {
                    Console.Write("Dien tich khong hop le! Moi ban nhap lai: ");
                    value = Convert.ToDouble(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Khong dung dinh dang so thuc");
                    value = -1;
                }
            }
            dienTich = value;
        }
        public virtual void Nhap()
        {
            Console.Write("Nhap dia diem: ");
            diaDiem = Console.ReadLine();
            double temp;
            do
            {
                try
                {
                    Console.Write("Nhap gia ban (VND): ");
                    temp = Convert.ToDouble(Console.ReadLine());
                    if (temp <= 0) Console.WriteLine("Gia ban khong hop le! Moi ban nhap lai");
                }
                catch
                {
                    Console.WriteLine("Khong dung dinh dang so thuc");
                    temp = -1;
                }
            } while (temp <= 0);
            giaBan = temp;
            do
            {
                try
                {
                    Console.Write("Nhap dien tich (m2): ");
                    temp = Convert.ToDouble(Console.ReadLine());
                    if (temp <= 0) Console.WriteLine("Dien tich khong hop le! Moi ban nhap lai");
                }
                catch
                {
                    Console.WriteLine("Khong dung dinh dang so thuc");
                    temp = -1;
                }
            } while (temp <= 0);
            dienTich = temp;
        }
        public virtual void Xuat()
        {
            Console.WriteLine("Dia diem: " + diaDiem);
            Console.WriteLine("Gia ban (VND): " + giaBan.ToString("F0"));
            Console.WriteLine("Dien tich (m2): " + dienTich.ToString("F2"));
            Console.WriteLine("Loai: " + GetLoai());
        }
        public abstract string GetLoai();
    }
}