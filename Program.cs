using System;
using System.Text;

namespace HOPSUA
{
    public class HopSua
    {
        public string NhanHieu { get; set; }
        public float TrongLuong { get; set; }
        public DateTime HanSuDung { get; set; }
    }

    public class NhapXuatHopSua
    {
        public static void NhapHS(ref HopSua a)
        {
            Console.Write("Nhập Nhãn Hiệu: ");
            a.NhanHieu = Console.ReadLine();

            Console.Write("Nhập Trọng Lượng: ");
            a.TrongLuong = float.Parse(Console.ReadLine());

            Console.WriteLine("--Nhập Hạn Sử Dụng--");
            Console.Write("Nhập Năm: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Nhập Tháng: ");
            int month = int.Parse(Console.ReadLine());

            Console.Write("Nhập Ngày: ");
            int day = int.Parse(Console.ReadLine());

            a.HanSuDung = new DateTime(year, month, day);
        }

        public static void XuatHS(HopSua a)
        {
            Console.WriteLine($"Nhãn Hiệu: {a.NhanHieu}");
            Console.WriteLine($"Trọng Lượng: {a.TrongLuong}(g)");
            Console.WriteLine($"Hạn Sử Dụng: {a.HanSuDung.ToString("dd/MM/yyyy")}");
        }
    }

    public class Program
    {
        const int N = 100;

        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            HopSua[] hs = new HopSua[N];
            int n = 0;

            NhapDSHS(hs, ref n);
            XuatDSHS(hs, n);
            Console.ReadLine();
        }

        static void NhapDSHS(HopSua[] hs, ref int n)
        {
            Console.Write("Nhập số lượng Hộp Sữa: ");
            n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                hs[i] = new HopSua();
                Console.WriteLine("---------------------------");
                Console.WriteLine($"Hộp sữa thứ {i + 1}");
                NhapXuatHopSua.NhapHS(ref hs[i]);
            }
        }

        static void XuatDSHS(HopSua[] hs, int n)
        {
            Console.WriteLine("=-=DANH SÁCH CÁC HỘP SỮA=-=");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"---Hộp Sữa thứ {i + 1}---");
                NhapXuatHopSua.XuatHS(hs[i]);
                Console.WriteLine("---------------------------");
            }
        }
    }
}
