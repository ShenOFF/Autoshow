using AutoShow.View;
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

namespace AutoShow.Pages
{
    /// <summary>
    /// Логика взаимодействия для SaleAutoLook.xaml
    /// </summary>
    public partial class SaleAutoLook : Page
    {
        public static SaleAutoLook saleAutoLook;
        public SaleAutoLook()
        {
            InitializeComponent();
            saleAutoLook = this;
            AllSaleAuto(MainWindow.mainWindow.saleAutos);
        }

        private void Click_Reg_Exit(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.Main());
        }

        private void Click_Search(object sender, RoutedEventArgs e)
        {
            new Windows.SearchSaleAutoLook().Show();
        }

        public void AllSaleAuto(List<Classes.SaleAuto> saleAutos)
        {

            saleAutos = MainWindow.mainWindow.saleAutos/*.FindAll(x => x.login_user.ToString().Contains(Classes.data.name.ToString()) && x.hidden.ToString().Contains("1"))*/;
            accepted_wait.Children.Clear();
            foreach (var item in saleAutos)
            {
                accepted_wait.Children.Add(new SaleAutoElement(item));
            }
        }
    }
}
