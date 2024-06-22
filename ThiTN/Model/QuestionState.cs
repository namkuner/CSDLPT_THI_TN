using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThiTN.Model
{
    internal class QuestionState
    {
        public int MaCauHoi { get; set; }
        public string MaMH { get; set; }
        public string TrinhDo { get; set; }
        public string NoiDung { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
        public string DapAn { get; set; }
        public string MaGV { get; set; }

        public QuestionState(int maCauHoi, string maMH, string trinhDo, string noiDung, string a, string b, string c, string d, string dapAn, string maGV)
        {
            MaCauHoi = maCauHoi;
            MaMH = maMH;
            TrinhDo = trinhDo;
            NoiDung = noiDung;
            A = a;
            B = b;
            C = c;
            D = d;
            DapAn = dapAn;
            MaGV = maGV;
        }

        public QuestionState Clone()
        {
            return (QuestionState)MemberwiseClone();
        }
    }
}
