using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapDanhMucIICD.Model
{
    class Quytac
    {
        private string ten;
        private string mota;
        private string dvtt;
        private int id;

        public string Ten { get => ten; set => ten = value; }
        public string Mota { get => mota; set => mota = value; }
        public string Dvtt { get => dvtt; set => dvtt = value; }
        public int Id { get => id; set => id = value; }
    }
}
