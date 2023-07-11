using AutoShow.Pages;
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

namespace AutoShow.Windows
{
    /// <summary>
    /// Логика взаимодействия для SearchSaleAutoLook.xaml
    /// </summary>
    public partial class SearchSaleAutoLook : Window
    {
        public SearchSaleAutoLook()
        {
            InitializeComponent();
        }

        private void Click_Main_Accept(object sender, RoutedEventArgs e)
        {
            var data = MainWindow.mainWindow.saleAutos;
            data = data.Where(x => x.data.Contains(tb_data.Text) & x.auto.ToString().Contains(tb_auto.Text) & x.worker.ToString().Contains(tb_worker.Text) & x.customer.ToString().Contains(tb_customer.Text)).ToList();
            SaleAutoLook.saleAutoLook.accepted_wait.Children.Clear();


            foreach (var item in data)
            {
                SaleAutoLook.saleAutoLook.accepted_wait.Children.Add(new View.SaleAutoElement(item));
            }
        }
    }
}
