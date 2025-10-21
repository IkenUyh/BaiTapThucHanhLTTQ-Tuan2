// File: Program.cs
using System;
using BaiTap4.Models;
using BaiTap4.Services;

namespace BaiTap4
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=====CHUONG TRINH XU LY PHAN SO=====");
            Console.WriteLine("Tong so doi tuong: " + PhanSo.GetDem());
            Console.WriteLine("\n1. Nhap hai phan so:");
            Console.WriteLine("Nhap phan so thu nhat:");
            PhanSo ps1 = PhanSo.ReadFromConsole();
            Console.WriteLine("Nhap phan so thu hai:");
            PhanSo ps2 = PhanSo.ReadFromConsole();
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
            DanhSachPhanSo dsps = new DanhSachPhanSo();
            dsps.Nhap();
            Console.WriteLine("\n4. Phan so lon nhat:");
            dsps.TimPhanSoLonNhat();
            Console.WriteLine("\n5. Day phan so sap xep tang dan:");
            dsps.SapXepTangDan();
            dsps.Dispose();
            ps1.Dispose();
            ps2.Dispose();
            Console.WriteLine("\nTong so doi tuong sau khi giai phong: " + PhanSo.GetDem());
            Console.WriteLine("\n=====KET THUC CHUONG TRINH=====");
        }
    }
}