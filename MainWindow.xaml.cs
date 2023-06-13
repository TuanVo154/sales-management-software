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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QLBanHang
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnSanPham_Click(object sender, RoutedEventArgs e)
        {
            form_SanPham formSanPham = new form_SanPham();
            formSanPham.Owner = Window.GetWindow(this);
            this.Hide();
            formSanPham.Show();
        }

        private void btnKhachHang_Click(object sender, RoutedEventArgs e)
        {
            form_KhachHang formKhachHang = new form_KhachHang();
            formKhachHang.Owner = Window.GetWindow(this);
            this.Hide();
            formKhachHang.Show();
        }

        private void btnQLMuaBan_Click(object sender, RoutedEventArgs e)
        {
            form_MuaBan formMuaBan = new form_MuaBan();
            formMuaBan.Owner = Window.GetWindow(this);
            this.Hide();
            formMuaBan.Show();
        }

        private void btnThongKe_Click(object sender, RoutedEventArgs e)
        {
            form_ThongKe formThongKe = new form_ThongKe();
            formThongKe.Owner = Window.GetWindow(this);
            this.Hide();
            formThongKe.Show();
        }
    }
}
