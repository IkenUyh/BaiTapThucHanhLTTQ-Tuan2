using System;

namespace InRaLichTrongThang
{
    class CDate
    {
        private int thang, nam;
        private static int dem = 0;
        public void Dispose()
        {
            --dem;
            Console.WriteLine("Da huy mot khoang thoi gian");
        }
        public CDate()
        {
            DateTime now = DateTime.Now;
            thang = now.Month;
            nam = now.Year;
            dem++;
        }
        public CDate(int thang)
        {
            DateTime now = DateTime.Now;
            this.thang = thang;
            nam = now.Year;
            if (thang < 1 || thang > 12)
                this.thang = now.Month;
            dem++;
        }
        public CDate(int thang, int nam)
        {
            DateTime now = DateTime.Now;
            this.thang = thang;
            this.nam = nam;
            if (thang < 1 || thang > 12)
                this.thang = now.Month;
            if (nam < 1)
                this.nam = now.Year;
            dem++;
        }
        public CDate(CDate d)
        {
            DateTime now = DateTime.Now;
            this.thang = d.thang;
            this.nam = d.nam;
            if (thang < 1 || thang > 12)
                this.thang = now.Month;
            if (nam < 1)
                this.nam = now.Year;
            dem++;
        }
        public CDate Assign(CDate d)
        {
            DateTime now = DateTime.Now;
            this.thang = d.thang;
            this.nam = d.nam;
            if (thang < 1 || thang > 12)
                this.thang = now.Month;
            if (nam < 1)
                this.nam = now.Year;
            return this;
        }
        public int GetThang()
        {
            return this.thang;
        }
        public int GetNam()
        {
            return this.nam;
        }
        public static int GetDem()
        {
            return dem;
        }
        public void SetThang(int thang)
        {
            this.thang = thang;
            while (!KiemTraHopLe())
            {
                try
                {
                    Console.WriteLine("Thang ban nhap khong hop le!");
                    Console.Write("Moi ban nhap lai: ");
                    this.thang = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    System.Console.WriteLine("Khong dung dinh dang so nguyen");
                    thang = -1;
                }
            }
        }
        public void SetNam(int nam)
        {
            this.nam = nam;
            while (!KiemTraHopLe())
            {
                try
                {
                    Console.WriteLine("Nam ban nhap khong hop le!");
                    Console.Write("Moi ban nhap lai: ");
                    this.nam = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    System.Console.WriteLine("Khong dung dinh dang so nguyen");
                    nam = -1;
                }
            }
        }
        public void SetThangNam(int thang, int nam)
        {
            this.thang = thang;
            this.nam = nam;
            while (!KiemTraHopLe())
            {
                try
                {
                    Console.WriteLine("Thang nam ban nhap khong hop le! Moi ban nhap lai:");
                    Console.Write("Nhap thang: ");
                    this.thang = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Nhap nam: ");
                    this.nam = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    System.Console.WriteLine("Khong dung dinh dang so nguyen");
                    thang = -1; nam = -1;
                }
            }
        }
        public bool KiemTraHopLe()
        {
            return nam >= 1 && thang >= 1 && thang <= 12;
        }
        private static bool NamNhuan(int n)
        {
            return (n % 4 == 0 && n % 100 != 0) || (n % 400 == 0);
        }
        public static int SoNgayTrongThang(int thang, int nam)
        {
            int[] nThang = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if (thang == 2 && NamNhuan(nam)) return 29;
            return nThang[thang];
        }
        public void Nhap()
        {
            do
            {
                try
                {
                    Console.Write("Nhap thang: ");
                    thang = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Nhap nam: ");
                    nam = Convert.ToInt32(Console.ReadLine());
                    if (!KiemTraHopLe())
                        Console.WriteLine("Thang nam khong hop le! Moi ban nhap lai!");
                }
                catch
                {
                    System.Console.WriteLine("Khong dung dinh dang so nguyen");
                    thang = -1; nam = -1;
                }
            } while (!KiemTraHopLe());
        }
        public static CDate ReadFromConsole()
        {
            CDate d = new CDate();
            do
            {
                try
                {
                    Console.Write("Nhap thang: ");
                    d.thang = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Nhap nam: ");
                    d.nam = Convert.ToInt32(Console.ReadLine());
                    if (d.thang < 1 || d.thang > 12 || d.nam < 1)
                        Console.WriteLine("Thang nam khong hop le moi ban nhap lai:");
                }
                catch
                {
                    System.Console.WriteLine("Khong dung dinh dang so nguyen");
                    d.thang = -1; d.nam = -1;
                }
            } while (d.thang < 1 || d.thang > 12 || d.nam < 1);
            return d;
        }
        public void InLich()
        {
            DateTime NgayDauTien = new DateTime(nam, thang, 1);
            int NgayTrongThang = SoNgayTrongThang(thang, nam);
            int NgayDauTrongThang = (int)NgayDauTien.DayOfWeek;
            Console.WriteLine($"Month: {thang}/{nam}");
            Console.WriteLine("Sun Mon Tue Wed Thu Fri Sat");
            for (int i = 0; i < NgayDauTrongThang; i++)
                Console.Write("    ");
            for (int day = 1; day <= NgayTrongThang; day++)
            {
                Console.Write($"{day,4}");
                if ((day + NgayDauTrongThang) % 7 == 0 || day == NgayTrongThang)
                    Console.WriteLine();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=====CHUONG TRINH TINH SO NGAY VA IN LICH TRONG THANG=====");
            Console.WriteLine("Tong So Doi Tuong: " + CDate.GetDem());

            CDate date = new CDate();
            date.Nhap();
            Console.WriteLine("\n1. So ngay trong thang:");
            Console.WriteLine($"Thang: {date.GetThang()}/{date.GetNam()}");
            int soNgay = CDate.SoNgayTrongThang(date.GetThang(), date.GetNam());
            Console.WriteLine($"So ngay trong thang {date.GetThang()}/{date.GetNam()} la: {soNgay}");

            Console.WriteLine("\n2. Lich cua thang:");
            date.InLich();

            Console.WriteLine("\nTong so doi tuong khi tao: " + CDate.GetDem());
            date.Dispose();
            Console.WriteLine("Tong so doi tuong sau khi huy mot doi tuong: " + CDate.GetDem());
            Console.WriteLine("\n=====KET THUC CHUONG TRINH=====");
        }
    }
}