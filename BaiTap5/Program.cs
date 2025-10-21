// File: Program.cs
using System;
using BaiTapNew.Models;
using BaiTapNew.Services;

namespace BaiTapNew
{
    class Program
    {
        static void Main(string[] args)
        {
            CongTy ct = new CongTy();
            Console.WriteLine("\n===== CHUONG TRINH QUAN LY BAT DONG SAN CONG TY DAI PHU =====\n");
            Console.WriteLine("1. Nhap danh sach cac bat dong san: ");
            ct.Nhap();
            Console.WriteLine("Danh sach cac bat dong san vua nhap: ");
            ct.Xuat();
            Console.WriteLine("2. Tong gia ban cho 3 loai: ");
            ct.TongGiaBan();
            Console.WriteLine("3. Danh sach khu dat >100m2 hoac nha pho >60m2 va nam xay dung >=2019: ");
            ct.DanhSachDacBiet();
            Console.WriteLine("4. Tim kiem nha pho hoac chung cu theo yeu cau: ");
            ct.TimKiem();
        }
    }
}