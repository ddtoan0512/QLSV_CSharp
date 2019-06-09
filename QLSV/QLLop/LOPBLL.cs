using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace QLSV
{
    class LOPBLL
    {
        LOPDAL dalLOP;
        public LOPBLL()
        {
            dalLOP = new LOPDAL(); //s
        }

        public DataTable getAllLop()
        {
            return dalLOP.getAllLop();
        }

        public bool ThemLop(tblLop lop)
        {
            return dalLOP.ThemLop(lop);
        }

        public bool CapNhatLop(tblLop lop)
        {
            return dalLOP.CapNhatLop(lop);
        }

        public bool XoaLop(tblLop lop)
        {
            return dalLOP.XoaLop(lop);
        }
        public DataTable TimKiemLop(string lop)
        {
            return dalLOP.TimKiemLop(lop);
        }
    }
}
