using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QLBanHang
{
    internal class Model_SanPham : Model
    {
        //private List<SanPham> ListSanPham;
        private SqlDataAdapter sdaSanPham;
        private DataSet dsSanPham;
        private DataTable dtSanPham;

        public Model_SanPham()
        {
            //ListSanPham = new List<SanPham>();
            sdaSanPham = new SqlDataAdapter();
            dsSanPham = new DataSet();
            dtSanPham = new DataTable();

            String sel_sql = "SELECT * FROM SanPham;";
            SqlCommand sel_Command = new SqlCommand(sel_sql, db.getConnect);
            sdaSanPham.SelectCommand = sel_Command;

            String ins_sql = "INSERT INTO SanPham(MaSP, TenSP, GiaBan) VALUES(@masp, @tensp, @giaban);";
            SqlCommand ins_Command = new SqlCommand(ins_sql, db.getConnect);
            SqlParameter ins_masp = new SqlParameter();
            ins_masp.ParameterName = "@masp";
            ins_masp.SqlDbType = SqlDbType.NVarChar;
            ins_masp.SourceColumn = "MaSP";
            SqlParameter ins_tensp = new SqlParameter();
            ins_tensp.ParameterName = "@tensp";
            ins_tensp.SqlDbType = SqlDbType.NVarChar;
            ins_tensp.SourceColumn = "TenSP";
            SqlParameter ins_giaban = new SqlParameter();
            ins_giaban.ParameterName = "@giaban";
            ins_giaban.SqlDbType = SqlDbType.Int;
            ins_giaban.SourceColumn = "GiaBan";

            ins_Command.Parameters.Add(ins_masp);
            ins_Command.Parameters.Add(ins_tensp);
            ins_Command.Parameters.Add(ins_giaban);

            sdaSanPham.InsertCommand = ins_Command;

            String del_sql = "DELETE FROM SanPham WHERE MaSP=@masp;";
            SqlCommand del_Command = new SqlCommand(del_sql, db.getConnect);
            SqlParameter del_masp = new SqlParameter();
            del_masp.ParameterName = "@masp";
            del_masp.SqlDbType= SqlDbType.NVarChar;
            del_masp.SourceColumn = "MaSP";
            
            del_Command.Parameters.Add(del_masp);

            sdaSanPham.DeleteCommand = del_Command;

            String upd_sql = "UPDATE SanPham SET TenSP=@tensp, GiaBan=@giaban WHERE MaSP=@masp;";
            SqlCommand upd_Command = new SqlCommand(upd_sql, db.getConnect);
            SqlParameter upd_masp = new SqlParameter();
            upd_masp.ParameterName = "@masp";
            upd_masp.SqlDbType = SqlDbType.NVarChar;
            upd_masp.SourceColumn = "MaSP";
            SqlParameter upd_tensp = new SqlParameter();
            upd_tensp.ParameterName = "@tensp";
            upd_tensp.SqlDbType = SqlDbType.NVarChar;
            upd_tensp.SourceColumn = "TenSP";
            SqlParameter upd_giaban = new SqlParameter();
            upd_giaban.ParameterName = "@giaban";
            upd_giaban.SqlDbType = SqlDbType.Int;
            upd_giaban.SourceColumn = "GiaBan";

            upd_Command.Parameters.Add(upd_masp);
            upd_Command.Parameters.Add(upd_tensp);
            upd_Command.Parameters.Add(upd_giaban);

            sdaSanPham.UpdateCommand = upd_Command;

            sdaSanPham.Fill(dsSanPham);
            dtSanPham = dsSanPham.Tables[0];
        }

        public List<SanPham> DSSanPham()
        {
            List<SanPham> listSanPham = new List<SanPham>();
            foreach (DataRow r in dtSanPham.Rows)
            {
                SanPham sanpham = new SanPham();
                sanpham.MaSP = r["MaSP"].ToString();
                sanpham.TenSP = r["TenSP"].ToString();
                sanpham.GiaBan = int.Parse(r["GiaBan"].ToString());
                listSanPham.Add(sanpham);
            }
            
            return listSanPham;
        }

        public void ThemSP(SanPham sanpham)
        {
            String thongbao = "";
            if (sanpham.kiemtraMaSP() == false)
                thongbao += "Mã sản phẩm sai. ";
            if (sanpham.kiemtraTenSP() == false)
                thongbao += "Tên sản phẩm sai. ";
            if (sanpham.kiemtraGiaBan() == false)
                thongbao += "Giá bán sai.";
            if (thongbao == "")
            {
                DataRow r = dtSanPham.NewRow();
                r["MaSP"] = sanpham.MaSP;
                r["TenSP"] = sanpham.TenSP;
                r["GiaBan"] = sanpham.GiaBan;
                dtSanPham.Rows.Add(r);
                sdaSanPham.Update(dsSanPham);
            }
            else
            {
                MessageBox.Show(thongbao);
            }

            
        }

        public void XoaSP(int sp)
        {
            dtSanPham.Rows[sp].Delete();
            sdaSanPham.Update(dsSanPham);
        }

        public List<SanPham> TimKiemSP(String masp, String tensp, String giaban)
        {
            List<SanPham> listSanPham = new List<SanPham>();

            String sql = "SELECT * FROM SanPham ";
            if (masp != "" || tensp != "" || giaban != "")
                sql += "WHERE ";
            if (masp != "")
                sql += " MaSP LIKE '%" + masp + "%'";
            if (tensp != "")
            {
                if (masp != "")
                    sql += " OR ";
                sql += " TenSP LIKE N'%" + tensp + "%'";
            }
            if (giaban != "")
            {
                if (masp != "" || tensp != "")
                    sql += " OR ";
                sql += " giaban LIKE '%" + giaban + "%'";
            }

            SqlCommand cmd=new SqlCommand(sql, db.getConnect);
            sdaSanPham = new SqlDataAdapter(cmd);
            dsSanPham = new DataSet();
            sdaSanPham.Fill(dsSanPham);
            dtSanPham = dsSanPham.Tables[0];

            foreach (DataRow dr in dtSanPham.Rows)
            {
                SanPham s = new SanPham();
                s.MaSP = dr["MaSP"].ToString();
                s.TenSP = dr["TenSP"].ToString();
                s.GiaBan = int.Parse(dr["GiaBan"].ToString());
                listSanPham.Add(s);
            }
            return listSanPham;
        }
    }
}
