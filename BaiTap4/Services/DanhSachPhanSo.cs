// File: Services/DanhSachPhanSo.cs
using System;
using BaiTap4.Models;

namespace BaiTap4.Services
{
    public class DanhSachPhanSo : IDisposable
    {
        private PhanSo[] ds;
        private int sl;
        private static int dem = 0;
        private bool disposed = false;
        public void Dispose()
        {
            if (!disposed)
            {
                if (ds != null)
                {
                    for (int i = 0; i < sl; i++)
                        ds[i].Dispose();
                    ds = null;
                    sl = 0;
                }
                dem--;
                disposed = true;
            }
        }
        public DanhSachPhanSo()
        {
            sl = 0;
            ds = null;
            dem++;
        }
        public DanhSachPhanSo(int sl)
        {
            this.sl = sl;
            if (sl > 0)
            {
                ds = new PhanSo[sl];
                for (int i = 0; i < sl; i++)
                    ds[i] = null;
            }
            dem++;
        }
        public DanhSachPhanSo(DanhSachPhanSo other)
        {
            sl = other.sl;
            if (sl > 0 && other.ds != null)
            {
                ds = new PhanSo[sl];
                for (int i = 0; i < sl; i++)
                    ds[i] = new PhanSo(other.ds[i]);
            }
            dem++;
        }
        public int GetSoLuong() => sl;
        public static int GetDem() => dem;
        public void SetSoLuong(int value)
        {
            while (value < 1)
            {
                try
                {
                    Console.Write("So luong khong hop le! Moi ban nhap lai: ");
                    value = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Khong dung dinh dang so nguyen");
                    value = -1;
                }
            }
            sl = value;
        }
        public void Nhap()
        {
            do
            {
                try
                {
                    Console.Write("Nhap so luong phan so: ");
                    sl = Convert.ToInt32(Console.ReadLine());
                    if (sl <= 0)
                        Console.WriteLine("So luong phan so phai > 0! Moi ban nhap lai!");
                }
                catch
                {
                    Console.WriteLine("Khong dung dinh dang so nguyen");
                    sl = -1;
                }
            } while (sl <= 0);
            ds = new PhanSo[sl];
            for (int i = 0; i < sl; i++)
            {
                Console.WriteLine($"Nhap phan so thu {i + 1}:");
                ds[i] = PhanSo.ReadFromConsole();
            }
        }
        public void TimPhanSoLonNhat()
        {
            if (sl == 0 || ds == null)
            {
                Console.WriteLine("Danh sach rong");
                return;
            }
            PhanSo max = new PhanSo(ds[0]);
            for (int i = 1; i < sl; i++)
                if (ds[i].SoSanh(max) > 0)
                    max.Assign(ds[i]);
            Console.Write("Phan so lon nhat: ");
            max.Xuat();
            Console.WriteLine();
        }
        public void SapXepTangDan()
        {
            if (sl == 0 || ds == null)
            {
                Console.WriteLine("Danh sach rong");
                return;
            }
            for (int i = 0; i < sl - 1; i++)
            {
                for (int j = 0; j < sl - i - 1; j++)
                {
                    if (ds[j].SoSanh(ds[j + 1]) > 0)
                    {
                        PhanSo temp = new PhanSo(ds[j]);
                        ds[j].Assign(ds[j + 1]);
                        ds[j + 1].Assign(temp);
                    }
                }
            }
            Console.WriteLine("Day phan so sap xep tang dan:");
            for (int i = 0; i < sl; i++)
            {
                ds[i].Xuat();
                Console.WriteLine();
            }
        }
    }
}