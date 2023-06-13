using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QLBanHang
{
    /// <summary>
    /// Interaction logic for form_SanPham.xaml
    /// </summary>
    public partial class form_SanPham : Window
    {
        private List<SanPham> listSanPham;
        private Controller_SanPham controller;
        public form_SanPham()
        {
            InitializeComponent();
            listSanPham = new List<SanPham>();
            controller = new Controller_SanPham();
            listSanPham = controller.DSSanPham();

            lstSanPham.ItemsSource = null;
            lstSanPham.ItemsSource = listSanPham;
        }

        private void btnDong_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            this.Owner.Show();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            SanPham sanpham = new SanPham();
            sanpham.MaSP = txtMaSP.Text;
            sanpham.TenSP = txtTenSP.Text;
            sanpham.GiaBan = int.Parse(txtGiaBan.Text);

            controller.ThemSP(sanpham);

            listSanPham.Add(sanpham);
            lstSanPham.ItemsSource = null;
            lstSanPham.ItemsSource = listSanPham;

            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtGiaBan.Text = "";
        }

        private void lstSanPham_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstSanPham.SelectedIndex > -1)
            {
                SanPham sanpham = new SanPham();
                sanpham = (SanPham)lstSanPham.SelectedItem;
                txtMaSP.Text = sanpham.MaSP;
                txtTenSP.Text = sanpham.TenSP;
                txtGiaBan.Text = sanpham.GiaBan.ToString();
            }

        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            int idx = lstSanPham.SelectedIndex;
            controller.XoaSP(idx);
            listSanPham.RemoveAt(idx);
            lstSanPham.ItemsSource = null;
            lstSanPham.ItemsSource = listSanPham;
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtGiaBan.Text = "";
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, RoutedEventArgs e)
        {
            String masp = txtMaSP.Text;
            String tensp = txtTenSP.Text;
            String giaban = txtGiaBan. Text;

            listSanPham = new List<SanPham>();
            listSanPham = controller.TimKiemSP(masp, tensp, giaban);
            lstSanPham.ItemsSource = null;
            lstSanPham.ItemsSource = listSanPham;

            //MessageBox.Show(sql);

        }
    }
}
