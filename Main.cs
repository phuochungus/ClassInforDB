using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLop;
using System.IO;
using System.Globalization;

namespace quanlySV
{
    internal class app
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap ma lop: ");
            string MaLop = Console.ReadLine();
            string relative_path = @"..\..\DB\" + MaLop + ".json";
            Lop lop = new Lop(MaLop);

            if (File.Exists(relative_path))
            {
                Console.WriteLine("File exist, import data");
                lop.import(relative_path);
                lop.printClassInfor();
            }
            else
            {
                //.json not exist
                lop.enterClassInfor();
                lop.export(); 
            }

        }
    }
}
