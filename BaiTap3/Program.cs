using System;

namespace MaTran
{
    class CMatrix
    {
        private int[,] matrix;
        private int n, m; 
        private static int dem = 0;
        public void Dispose()
        {
            --dem;
            Console.WriteLine("Da huy mot ma tran");
        }
        public CMatrix()
        {
            n = 0;
            m = 0;
            matrix = null;
            dem++;
        }
        public CMatrix(int n, int m)
        {
            this.n = n > 0 ? n : 1;
            this.m = m > 0 ? m : 1;
            matrix = new int[this.n, this.m];
            Random rand = new Random();
            for (int i = 0; i < this.n; i++)
                for (int j = 0; j < this.m; j++)
                    matrix[i, j] = rand.Next(-100, 101);
            dem++;
        }
        public CMatrix(CMatrix other)
        {
            this.n = other.n;
            this.m = other.m;
            this.matrix = new int[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    this.matrix[i, j] = other.matrix[i, j];
            dem++;
        }
        public CMatrix Assign(CMatrix other)
        {
            if (other == null || other.matrix == null)
            {
                this.n = 0;
                this.m = 0;
                this.matrix = null;
                return this;
            }
            this.n = other.n;
            this.m = other.m;
            this.matrix = new int[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    this.matrix[i, j] = other.matrix[i, j];
            return this;
        }
        public int GetSoDong()
        {
            return n;
        }
        public int GetSoCot()
        {
            return m;
        }
        public static int GetDem()
        {
            return dem;
        }
        public void Nhap()
        {
            do
            {
                try
                {
                    Console.Write("Nhap so dong n: ");
                    n = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Nhap so cot m: ");
                    m = Convert.ToInt32(Console.ReadLine());
                    if (n < 1 || m < 1)
                        Console.WriteLine("So dong va so cot phai lon hon 0! Moi nhap lai!");
                }
                catch
                {
                    Console.WriteLine("Khong dung dinh dang so nguyen");
                    n = -1; m = -1;
                }
            } while (n < 1 || m < 1);
            matrix = new int[n, m];
            Console.WriteLine("Nhap cac phan tu cua ma tran:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    try
                    {
                        Console.Write($"Nhap phan tu [{i},{j}]: ");
                        matrix[i, j] = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Khong dung dinh dang so nguyen, nhap lai!");
                        j--;
                    }
                }
            }
        }
        public void Xuat()
        {
            if (matrix == null || n == 0 || m == 0)
            {
                Console.WriteLine("Ma tran rong!");
                return;
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write($"{matrix[i, j],5}");
                Console.WriteLine();
            }
        }
        private bool LaSoNguyenTo(int num)
        {
            if (num < 2) return false;
            for (int i = 2; i <= Math.Sqrt(num); i++)
                if (num % i == 0) return false;
            return true;
        }
        public bool TimKiem(int x)
        {
            if (matrix == null || n == 0 || m == 0)
            {
                Console.WriteLine("Ma tran rong!");
                return false;
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] == x)
                    {
                        Console.WriteLine($"Phan tu {x} duoc tim thay tai vi tri [{i},{j}]");
                        return true;
                    }
                }
            }
            Console.WriteLine($"Phan tu {x} khong co trong ma tran");
            return false;
        }
        public void XuatSoNguyenTo()
        {
            if (matrix == null || n == 0 || m == 0)
            {
                Console.WriteLine("Ma tran rong!");
                return;
            }
            Console.WriteLine("Cac phan tu la so nguyen to trong ma tran:");
            bool found = false;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (LaSoNguyenTo(matrix[i, j]))
                    {
                        Console.WriteLine($"So nguyen to {matrix[i, j]} tai vi tri [{i},{j}]");
                        found = true;
                    }
                }
            }
            if (!found)
                Console.WriteLine("Khong co so nguyen to trong ma tran.");
        }
        public int TimDongCoNhieuSoNguyenToNhat()
        {
            if (matrix == null || n == 0 || m == 0)
            {
                Console.WriteLine("Ma tran rong!");
                return -1;
            }
            int maxCount = 0;
            int maxRow = 0;
            for (int i = 0; i < n; i++)
            {
                int count = 0;
                for (int j = 0; j < m; j++)
                {
                    if (LaSoNguyenTo(matrix[i, j]))
                        count++;
                }
                if (count > maxCount)
                {
                    maxCount = count;
                    maxRow = i;
                }
            }
            if (maxCount == 0)
            {
                Console.WriteLine("Khong co so nguyen to trong ma tran.");
                return -1;
            }
            Console.WriteLine($"Dong {maxRow} co nhieu so nguyen to nhat ({maxCount} so nguyen to).");
            return maxRow;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=====CHUONG TRINH XU LY MA TRAN=====");
            Console.WriteLine("Nhap thong tin ma tran:");
            CMatrix mat = new CMatrix();
            mat.Nhap();
            Console.WriteLine("\nMa tran vua nhap:");
            mat.Xuat();
            Console.Write("\nNhap gia tri can tim: ");
            try
            {
                int x = Convert.ToInt32(Console.ReadLine());
                mat.TimKiem(x);
            }
            catch
            {
                Console.WriteLine("Khong dung dinh dang so nguyen!");
            }
            Console.WriteLine();
            mat.XuatSoNguyenTo();
            Console.WriteLine();
            mat.TimDongCoNhieuSoNguyenToNhat();
            mat.Dispose();
            Console.WriteLine("=====KET THUC CHUONG TRINH=====");
        }
    }
}