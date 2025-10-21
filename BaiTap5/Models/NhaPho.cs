// File: Models/NhaPho.cs
using System;

namespace BaiTapNew.Models
{
    public class NhaPho : BatDongSan, IDisposable
    {
        private int namXayDung;
        private int soTang;
        private static int dem = 0;
        private bool disposed = false;
        public void Dispose()
        {
            if (!disposed)
            {
                Console.WriteLine("Da huy mot nha pho");
                dem--;
                disposed = true;
            }
        }
        public NhaPho() : base()
        {
            namXayDung = 0;
            soTang = 0;
            dem++;
        }
        public NhaPho(string diaDiem, double giaBan, double dienTich, int namXayDung, int soTang)
            : base(diaDiem, giaBan, dienTich)
        {
            this.namXayDung = namXayDung;
            this.soTang = soTang;
            dem++;
        }
        public NhaPho(NhaPho other) : base(other)
        {
            namXayDung = other.namXayDung;
            soTang = other.soTang;
            dem++;
        }
        public int GetNamXayDung() => namXayDung;
        public int GetSoTang() => soTang;
        public static new int GetDem() => dem;
        public void SetNamXayDung(int value)
        {
            while (value <= 0)
            {
                try
                {
                    Console.Write("Nam xay dung khong hop le! Moi ban nhap lai: ");
                    value = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Khong dung dinh dang so nguyen");
                    value = -1;
                }
            }
            namXayDung = value;
        }
        public void SetSoTang(int value)
        {
            while (value <= 0)
            {
                try
                {
                    Console.Write("So tang khong hop le! Moi ban nhap lai: ");
                    value = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Khong dung dinh dang so nguyen");
                    value = -1;
                }
            }
            soTang = value;
        }
        public override void Nhap()
        {
            base.Nhap();
            int temp;
            do
            {
                try
                {
                    Console.Write("Nhap nam xay dung: ");
                    temp = Convert.ToInt32(Console.ReadLine());
                    if (temp <= 0) Console.WriteLine("Nam xay dung khong hop le! Moi ban nhap lai");
                }
                catch
                {
                    Console.WriteLine("Khong dung dinh dang so nguyen");
                    temp = -1;
                }
            } while (temp <= 0);
            namXayDung = temp;
            do
            {
                try
                {
                    Console.Write("Nhap so tang: ");
                    temp = Convert.ToInt32(Console.ReadLine());
                    if (temp <= 0) Console.WriteLine("So tang khong hop le! Moi ban nhap lai");
                }
                catch
                {
                    Console.WriteLine("Khong dung dinh dang so nguyen");
                    temp = -1;
                }
            } while (temp <= 0);
            soTang = temp;
        }
        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine("Nam xay dung: " + namXayDung);
            Console.WriteLine("So tang: " + soTang);
        }
        public override string GetLoai() => "Nha Pho";
    }
}