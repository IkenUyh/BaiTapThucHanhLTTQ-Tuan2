// File: Services/CongTy.cs
using System;
using BaiTapNew.Models;

namespace BaiTapNew.Services
{
    public class CongTy : IDisposable
    {
        private BatDongSan[] ct;
        private int sl;
        private static int dem = 0;

        private bool disposed = false;

        public void Dispose()
        {
            if (!disposed)
            {
                if (ct != null)
                {
                    ct = null;
                    sl = 0;
                }
                dem--;
                disposed = true;
            }
        }

        public CongTy()
        {
            sl = 0;
            ct = null;
            dem++;
        }

        public CongTy(int sl)
        {
            this.sl = sl;
            if (sl > 0)
            {
                ct = new BatDongSan[sl];
                for (int i = 0; i < sl; i++)
                    ct[i] = null;
            }
            dem++;
        }

        public CongTy(CongTy other)
        {
            sl = other.sl;
            if (sl > 0 && other.ct != null)
            {
                ct = new BatDongSan[sl];
                for (int i = 0; i < sl; i++)
                {
                    if (other.ct[i].GetLoai() == "Khu Dat")
                        ct[i] = new KhuDat((KhuDat)other.ct[i]);
                    else if (other.ct[i].GetLoai() == "Nha Pho")
                        ct[i] = new NhaPho((NhaPho)other.ct[i]);
                    else
                        ct[i] = new ChungCu((ChungCu)other.ct[i]);
                }
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
            int loai;
            do
            {
                try
                {
                    Console.Write("Nhap so luong cac bat dong san: ");
                    sl = Convert.ToInt32(Console.ReadLine());
                    if (sl < 1) Console.WriteLine("So luong khong hop le! Moi ban nhap lai");
                }
                catch
                {
                    Console.WriteLine("Khong dung dinh dang so nguyen");
                    sl = -1;
                }
            } while (sl < 1);
            ct = new BatDongSan[sl];
            for (int i = 0; i < sl; i++)
            {
                Console.WriteLine("\n======================\n");
                Console.WriteLine("Nhap thong tin bat dong san thu " + (i + 1) + ": ");
                do
                {
                    try
                    {
                        Console.Write("Nhap loai (1: Khu Dat, 2: Nha Pho, 3: Chung Cu): ");
                        loai = Convert.ToInt32(Console.ReadLine());
                        if (loai != 1 && loai != 2 && loai != 3) Console.WriteLine("Loai khong hop le! Moi ban nhap lai");
                    }
                    catch
                    {
                        Console.WriteLine("Khong dung dinh dang so nguyen");
                        loai = -1;
                    }
                } while (loai != 1 && loai != 2 && loai != 3);
                if (loai == 1) ct[i] = new KhuDat();
                else if (loai == 2) ct[i] = new NhaPho();
                else ct[i] = new ChungCu();
                ct[i].Nhap();
            }
        }

        public void Xuat()
        {
            if (ct == null || sl == 0) Console.WriteLine("Danh sach bat dong san rong");
            else
            {
                Console.WriteLine("\n===== THONG TIN CAC BAT DONG SAN =====\n");
                for (int i = 0; i < sl; i++)
                {
                    Console.WriteLine("--- BAT DONG SAN THU " + (i + 1) + " ---");
                    ct[i].Xuat();
                    Console.WriteLine();
                }
            }
        }

        public void TongGiaBan()
        {
            double tongKhuDat = 0, tongNhaPho = 0, tongChungCu = 0;
            for (int i = 0; i < sl; i++)
            {
                if (ct[i].GetLoai() == "Khu Dat") tongKhuDat += ct[i].GetGiaBan();
                else if (ct[i].GetLoai() == "Nha Pho") tongNhaPho += ct[i].GetGiaBan();
                else tongChungCu += ct[i].GetGiaBan();
            }
            Console.WriteLine("Tong gia ban Khu Dat: " + tongKhuDat.ToString("F0"));
            Console.WriteLine("Tong gia ban Nha Pho: " + tongNhaPho.ToString("F0"));
            Console.WriteLine("Tong gia ban Chung Cu: " + tongChungCu.ToString("F0"));
        }

        public void DanhSachDacBiet()
        {
            bool check = false;
            Console.WriteLine("\n===== DANH SACH KHU DAT >100m2 HOAC NHA PHO >60m2 VA NAM >=2019 =====\n");
            for (int i = 0; i < sl; i++)
            {
                if (ct[i].GetLoai() == "Khu Dat" && ct[i].GetDienTich() > 100)
                {
                    check = true;
                    Console.WriteLine("--- BAT DONG SAN THU " + (i + 1) + " ---");
                    ct[i].Xuat();
                    Console.WriteLine();
                }
                else if (ct[i].GetLoai() == "Nha Pho" && ct[i].GetDienTich() > 60 && ((NhaPho)ct[i]).GetNamXayDung() >= 2019)
                {
                    check = true;
                    Console.WriteLine("--- BAT DONG SAN THU " + (i + 1) + " ---");
                    ct[i].Xuat();
                    Console.WriteLine();
                }
            }
            if (!check) Console.WriteLine("Khong co bat dong san thoa man");
        }

        public void TimKiem()
        {
            Console.WriteLine("\n===== TIM KIEM NHA PHO HOAC CHUNG CU =====\n");
            Console.Write("Nhap dia diem tim kiem: ");
            string diaDiemSearch = Console.ReadLine().ToLower();
            double giaMax;
            do
            {
                try
                {
                    Console.Write("Nhap gia toi da: ");
                    giaMax = Convert.ToDouble(Console.ReadLine());
                    if (giaMax <= 0) Console.WriteLine("Gia khong hop le! Moi ban nhap lai");
                }
                catch
                {
                    Console.WriteLine("Khong dung dinh dang so thuc");
                    giaMax = -1;
                }
            } while (giaMax <= 0);
            double dienTichMin;
            do
            {
                try
                {
                    Console.Write("Nhap dien tich toi thieu: ");
                    dienTichMin = Convert.ToDouble(Console.ReadLine());
                    if (dienTichMin <= 0) Console.WriteLine("Dien tich khong hop le! Moi ban nhap lai");
                }
                catch
                {
                    Console.WriteLine("Khong dung dinh dang so thuc");
                    dienTichMin = -1;
                }
            } while (dienTichMin <= 0);

            bool check = false;
            for (int i = 0; i < sl; i++)
            {
                if ((ct[i].GetLoai() == "Nha Pho" || ct[i].GetLoai() == "Chung Cu") &&
                    ct[i].GetDiaDiem().ToLower().Contains(diaDiemSearch) &&
                    ct[i].GetGiaBan() <= giaMax &&
                    ct[i].GetDienTich() >= dienTichMin)
                {
                    check = true;
                    Console.WriteLine("--- BAT DONG SAN THU " + (i + 1) + " ---");
                    ct[i].Xuat();
                    Console.WriteLine();
                }
            }
            if (!check) Console.WriteLine("Khong co bat dong san thoa man");
        }
    }
}