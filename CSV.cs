using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV
{
    class DTBComparer : IComparer<SinhVien>
    {
        public int Compare(SinhVien x, SinhVien y)
        {
            if(x.DTB == y.DTB) return 0;
            if (x.DTB > y.DTB) return 1;
            else return -1;
        }
    }
    internal class SinhVien : IComparable<SinhVien>
    {
        public string MS { get; set; }
        public string HoTen { get; set; }
        public DateTime NgSinh { get; set; }
        public double DTB { get; set; }

        public int CompareTo(SinhVien other)
        {
            return this.DTB.CompareTo(other.DTB);
        }

        public void enterStudentInfor()
        {
            Console.Write("Nhap mssv: ");
            MS = Console.ReadLine();
            Console.Write("Nhap ho ten: ");
            HoTen = Console.ReadLine();
            try
            {
                Console.Write("Nhap ngay sinh: ");
                NgSinh = DateTime.ParseExact(Console.ReadLine(), "dd/M/yyyy", CultureInfo.InvariantCulture);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            try
            {
                Console.Write("Nhap DTB: ");
                DTB = Convert.ToDouble(Console.ReadLine());
                if (DTB < 0 || DTB > 10) throw new Exception("DTB not between 0 and 10");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public void getInfor()
        {
            Console.WriteLine("MSSV: {0}", MS);
            Console.WriteLine("Ho va ten: {0}", HoTen);
            Console.WriteLine("Nam sinh: {0}", NgSinh.ToString("dd/MM/yyyy"));
            Console.WriteLine("DTB: {0}", DTB);
        }
    }
}
