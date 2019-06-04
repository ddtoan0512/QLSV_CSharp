using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV
{
    class SVIENBLL
    {
        SVIENDAL dalSV;
        public SVIENBLL()
        {
            dalSV = new SVIENDAL();
        }

        public DataTable getAllSVien()
        {
            return dalSV.getAllSVien();
        }

        public bool ThemSV(tblSVIEN sv)
        {
            return dalSV.ThemSV(sv);
        }

        public bool CapNhatSV(tblSVIEN sv)
        {
            return dalSV.CapNhatSV(sv);
        }

        public bool XoaSV(tblSVIEN sv)
        {
            return dalSV.XoaSV(sv);
        }
        public DataTable TimKiemSV(string sv)
        {
            return dalSV.TimKiemSV(sv);
        }
    }
}
