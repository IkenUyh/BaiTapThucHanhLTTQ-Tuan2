// File: Models/ChungCu.cs
using System;

namespace BaiTapNew.Models
{
    public class ChungCu : BatDongSan, IDisposable
    {
        private int tang;
        private static int dem = 0;
        private bool disposed = false;
        public void Dispose()
        {
            if (!disposed)
            {
                Console.WriteLine("Da huy mot chung cu");
                dem--;
                disposed = true;
            }
        }
        public ChungCu() : base()
        {
            tang = 0;
            dem++;
        }
        public ChungCu(string diaDiem, double giaBan, double dienTich, int tang)
            : base(diaDiem, giaBan, dienTich)
        {
            this.tang = tang;
            dem++;
        }
        public ChungCu(ChungCu other) : base(other)
        {
            tang = other.tang;
            dem++;
        }
        public int GetTang() => tang;
        public static new int GetDem() => dem;
        public void SetTang(int value)
        {
            while (value <= 0)
            {
                try
                {
                    Console.Write("Tang khong hop le! Moi ban nhap lai: ");
                    value = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Khong dung dinh dang so nguyen");
                    value = -1;
                }
            }
            tang = value;
        }
        public override void Nhap()
        {
            base.Nhap();
            int temp;
            do
            {
                try
                {
                    Console.Write("Nhap tang: ");
                    temp = Convert.ToInt32(Console.ReadLine());
                    if (temp <= 0) Console.WriteLine("Tang khong hop le! Moi ban nhap lai");
                }
                catch
                {
                    Console.WriteLine("Khong dung dinh dang so nguyen");
                    temp = -1;
                }
            } while (temp <= 0);
            tang = temp;
        }
        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine("Tang: " + tang);
        }
        public override string GetLoai() => "Chung Cu";
    }
}