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

namespace AutoShow.View
{
    /// <summary>
    /// Логика взаимодействия для SaleAutoElement.xaml
    /// </summary>
    public partial class SaleAutoElement : UserControl
    {
        Classes.SaleAuto saleAuto;
        public SaleAutoElement(Classes.SaleAuto saleAuto)
        {
            InitializeComponent();
            this.saleAuto = saleAuto;

            data.Content = saleAuto.data;
            customer.Content=saleAuto.customer;
            worker.Content=saleAuto.worker;
            auto.Content=saleAuto.auto;
        }

        private void delete(object sender, MouseButtonEventArgs e)
        {
            string query = $"DELETE FROM SaleAuto where kod_sale = {saleAuto.kod_sale}";
            Connection.Select(query);
            //Connection.Ubuntu(query);
            MainWindow.mainWindow.LoadSaleAuto();
            MainWindow.mainWindow.frame.Navigate(new Pages.SaleAutoLook());
        }
    }
}
