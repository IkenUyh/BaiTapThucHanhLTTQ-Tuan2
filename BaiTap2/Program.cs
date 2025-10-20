using System;
using System.IO;

namespace FileExplorer
{
    class ThuMuc
    {
        private string path;
        private static int dem = 0;
        public void Dispose()
        {
            --dem;
            Console.WriteLine("Da huy mot khoang thoi gian");
        }
        public ThuMuc()
        {
            path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            dem++;
        }
        public ThuMuc(string path)
        {
            this.path = NormalizePath(path);
            if (!Directory.Exists(this.path))
                this.path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            dem++;
        }
        public string GetPath()
        {
            return this.path;
        }
        public void SetPath(string path)
        {
            this.path = NormalizePath(path);
            while (!KiemTraHopLe())
            {
                try
                {
                    Console.WriteLine("Duong dan khong hop le! Moi ban nhap lai:");
                    this.path = NormalizePath(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Nhap sai dinh dang");
                    this.path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                }
            }
        }
        private string NormalizePath(string inputPath)
        {
            if (string.IsNullOrEmpty(inputPath)) return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string normalizedPath = inputPath.Trim();
            if (normalizedPath.StartsWith("~"))
                normalizedPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + normalizedPath.Substring(1);
            return Path.GetFullPath(normalizedPath); 
        }
        public bool KiemTraHopLe()
        {
            return Directory.Exists(path);
        }
        public void Nhap()
        {
            Console.WriteLine("Nhap vao duong dan cua thu muc muon xem! (Vi du: ~/Desktop, C:\\Users\\YourName\\, /Users/yourname/)");
            input:
            try
            {
                do
                {
                    path = NormalizePath(Console.ReadLine());
                    if (!Directory.Exists(path))
                    {
                        Console.WriteLine("Duong dan khong ton tai! Vui long thu lai.");
                    }
                } while (!Directory.Exists(path));
            }
            catch
            {
                Console.WriteLine("Input khong hop le! Xin thu lai.");
                goto input;
            }
        }
        public void Xuat()
        {
            Console.WriteLine("Da truy cap vao duong dan " + path);

            string[] files = Directory.GetFiles(path);
            if (files.Length == 0) Console.WriteLine("Duong dan nay khong co file nao!");
            else Console.WriteLine("Cac file co trong duong dan:");
            foreach (string file in files)
            {
                FileInfo in4 = new FileInfo(file);
                Console.WriteLine($"{in4.LastWriteTime:dd/MM/yyyy hh:mm tt}\t{in4.Length} Bytes\t{in4.Name}");
            }

            string[] folders = Directory.GetDirectories(path);
            if (folders.Length == 0) Console.WriteLine("Duong dan nay khong co thu muc nao!");
            else Console.WriteLine("Cac thu muc co trong duong dan:");
            foreach (string folder in folders)
            {
                DirectoryInfo in4 = new DirectoryInfo(folder);
                Console.WriteLine($"{in4.LastWriteTime:dd/MM/yyyy hh:mm tt}\t<DIR>\t{in4.Name}");
            }

            long s = 0;
            foreach (string file in files)
            {
                s += new FileInfo(file).Length;
            }
            string root = Path.GetPathRoot(path);
            if (!string.IsNullOrEmpty(root))
            {
                DriveInfo drive = new DriveInfo(root);
                Console.WriteLine($"\t{files.Length} File(s)\t{s} Bytes");
                Console.WriteLine($"\t{folders.Length} Dir(s)");
                Console.WriteLine($"\t{drive.TotalSize} Bytes total\t{drive.AvailableFreeSpace} Bytes free");
            }
            else
            {
                Console.WriteLine($"\t{files.Length} File(s)\t{s} Bytes");
                Console.WriteLine($"\t{folders.Length} Dir(s)");
                Console.WriteLine("\tKhong the hien thi thong tin dung luong tren he thong nay.");
            }
        }
        public static int GetDem()
        {
            return dem;
        }
    }
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=====CHUONG TRINH HIEN THI DANH SACH TEP VA THU MUC=====");
            Console.WriteLine("Tong So Doi Tuong: " + ThuMuc.GetDem());
            ThuMuc a = new ThuMuc();
            a.Nhap();
            a.Xuat();
            Console.WriteLine("\nTong so doi tuong khi tao: " + ThuMuc.GetDem());
            a.Dispose();
            Console.WriteLine("Tong so doi tuong sau khi huy: " + ThuMuc.GetDem());
            Console.WriteLine("\n=====KET THUC CHUONG TRINH=====");
        }
    }
}