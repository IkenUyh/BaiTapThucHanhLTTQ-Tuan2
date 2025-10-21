// File: Models/KhuDat.cs
using System;

namespace BaiTapNew.Models
{
    public class KhuDat : BatDongSan, IDisposable
    {
        private static int dem = 0;
        private bool disposed = false;
        public void Dispose()
        {
            if (!disposed)
            {
                Console.WriteLine("Da huy mot khu dat");
                dem--;
                disposed = true;
            }
        }
        public KhuDat() : base()
        {
            dem++;
        }
        public KhuDat(string diaDiem, double giaBan, double dienTich)
            : base(diaDiem, giaBan, dienTich)
        {
            dem++;
        }
        public KhuDat(KhuDat other) : base(other)
        {
            dem++;
        }
        public static new int GetDem() => dem;
        public override void Nhap()
        {
            base.Nhap();
        }
        public override void Xuat()
        {
            base.Xuat();
        }
        public override string GetLoai() => "Khu Dat";
    }
}