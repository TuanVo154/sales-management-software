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
    /// Interaction logic for form_KhachHang.xaml
    /// </summary>
    public partial class form_KhachHang : Window
    {
        public form_KhachHang()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            this.Owner.Show();
        }
    }
}
