using CSV;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CLop
{
    class LopEnumerator : IEnumerator
    {
        private List<SinhVien> _list;
        private int _index = -1;
        public object Current => _list[_index];

        public LopEnumerator(List<SinhVien> list) => _list = list;


        public bool MoveNext()
        {
            _index++;
            return _index < _list.Count;
        }

        public void Reset()
        {
            _index = -1;
        }
    }

    internal class Lop : IEnumerable
    {
        public List<SinhVien> DSSV { get; set; }
        public string MaLop { get; set; }
        public int Siso { get; set; }
        public int[] arr = { 1, 2, 3 };

        public IEnumerator GetEnumerator()
        {
            return new LopEnumerator(DSSV);
        }
        public SinhVien this[int key]
        {
            get => DSSV[key];
            set => DSSV[key] = value;
        }

        public Lop(string maLop) => MaLop = maLop;

        public void enterClassInfor()
        {
            Console.Write("Nhap so luong sinh vien: ");
            int n = Convert.ToInt32(Console.ReadLine());
            DSSV = new List<SinhVien>(n);
            for (int i = 0; i < n; i++)
            {
                DSSV.Add(new SinhVien());
                Console.WriteLine();
                DSSV[i].enterStudentInfor();
            }
            DSSV.Sort(new DTBComparer());
        }
        public void export()
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(this);
                File.WriteAllText(@"..\..\DB\" + MaLop + ".json", jsonString);
                Console.WriteLine("Exported to {0}.json sucessfully", MaLop);
            }
            catch (Exception e)
            {
                Console.WriteLine("Fail to export to {0}.json", MaLop);
                Console.Write(e.Message);
            }
        }
        public void import(string path)
        {
            try
            {
                string jsonString = File.ReadAllText(path);
                DSSV = JsonSerializer.Deserialize<List<SinhVien>>(jsonString);
                Siso = DSSV.Count;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
                //
            }
        }
        public void printClassInfor()
        {
            Console.WriteLine("Ma lop: {0}", MaLop);
            Console.WriteLine("Si so: {0}", Siso);
            foreach (var s in DSSV)
            {
                Console.WriteLine();
                s.getInfor();
            }
        }
    }
}
