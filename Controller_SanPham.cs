using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang
{
    internal class Controller_SanPham
    {
        private Model_SanPham modelSanPham;

        public Controller_SanPham()
        {
            modelSanPham = new Model_SanPham();

        }

        public List<SanPham> DSSanPham()
        {
            List<SanPham> listSanPham = new List<SanPham>();
            listSanPham = modelSanPham.DSSanPham();
            return listSanPham;
        }

        public void ThemSP(SanPham sanpham)
        {
            modelSanPham.ThemSP(sanpham);
        }
        public void XoaSP(int sp)
        {
            modelSanPham.XoaSP(sp);
        }

        public List<SanPham> TimKiemSP(String masp, String tensp, String giaban) {
            List<SanPham> listSanPham = new List<SanPham>();
            listSanPham = modelSanPham.TimKiemSP(masp, tensp, giaban);
            return listSanPham;
        }

    }
}
