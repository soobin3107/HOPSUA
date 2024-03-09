using System;
using System.Text;

namespace HOPSUA
{
    public class HopSua
    {
        public string NhanHieu { get; set; }
        public float TrongLuong { get; set; }
        public NGAY HanSuDung { get; set; }
    }

    public class NGAY
    {
        const int minYear = 1900, maxYear = 10000;
        public int Ngay { get; set; }
        public int Thang { get; set; }
        public int Nam { get; set; }

        public bool KTNN(int year)
        {
            return ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0));
        }

        public int TimSoNgayTrongThang()
        {
            int NgayTrongThang;
            switch (Thang)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    NgayTrongThang = 31;
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    NgayTrongThang = 30;
                    break;
                case 2:
                    NgayTrongThang = KTNN(Nam) ? 29 : 28;
                    break;
                default:
                    NgayTrongThang = 0;
                    break;
            }
            return NgayTrongThang;
        }

        public void XuatNgay()
        {
            Console.WriteLine($"{Ngay}/{Thang}/{Nam}");
        }

        public void NhapHSD()
        {
            do
            {
                Console.Write("Nhập vào Năm: ");
                Nam = int.Parse(Console.ReadLine());
                if (Nam < minYear || Nam > maxYear)
                    Console.WriteLine("Dữ liệu nhập không hợp lệ. Xin kiểm tra lại!");
            } while (Nam < minYear || Nam > maxYear);

            do
            {
                Console.Write("Nhập vào Tháng: ");
                Thang = int.Parse(Console.ReadLine());
                if (Thang < 1 || Thang > 12)
                    Console.WriteLine("Dữ liệu nhập không hợp lệ. Xin kiểm tra lại!");
            } while (Thang < 1 || Thang > 12);

            int NgayTrongThang = TimSoNgayTrongThang();
            do
            {
                Console.Write("Nhập vào Ngày: ");
                Ngay = int.Parse(Console.ReadLine());
                if (Ngay < 1 || Ngay > NgayTrongThang)
                    Console.WriteLine("Dữ liệu nhập không hợp lệ. Xin kiểm tra lại!");
            } while (Ngay < 1 || Ngay > NgayTrongThang);
        }
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
            a.HanSuDung = new NGAY();
            a.HanSuDung.NhapHSD();
        }

        public static void XuatHS(HopSua a)
        {
            Console.WriteLine($"Nhãn Hiệu: {a.NhanHieu}");
            Console.WriteLine($"Trọng Lượng: {a.TrongLuong}(g)");
            Console.Write($"Hạn Sử Dụng: ");
            a.HanSuDung.XuatNgay();
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
