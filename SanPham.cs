using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang
{
    internal class SanPham
    {
        private String _MaSP;
        private String _TenSP;
        private int _GiaBan;

        public String MaSP {
            get { return _MaSP; }
            set { _MaSP = value; }
        }

        public String TenSP
        {
            get { return _TenSP; }
            set { _TenSP = value; }
        }

        public int GiaBan
        {
            get { return _GiaBan; }
            set { _GiaBan = value; }
        }

        public bool kiemtraMaSP()
        {
            if (MaSP == "") return false;
            if (MaSP.Length > 10) return false;
            //....
            return true;
        }
        public bool kiemtraTenSP()
        {
            if (TenSP.Length > 50) return false;
            return true;
        }
        public bool kiemtraGiaBan()
        {
            if (GiaBan < 0) return false;
            return true;
        }
    }
}
