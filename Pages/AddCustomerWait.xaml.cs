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
    /// Логика взаимодействия для AddCustomerWait.xaml
    /// </summary>
    public partial class AddCustomerWait : Page
    {
        public static AddCustomerWait customerWait;
        public AddCustomerWait()
        {
            InitializeComponent();
            customerWait = this;
            queue_wait.Children.Clear();
            foreach (var item in MainWindow.mainWindow.waitCustomers)
                queue_wait.Children.Add(new AddCustomerAccept(item));
        }

        private void Click_Reg_Exit(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.Main());
        }

        private void Click_Search(object sender, RoutedEventArgs e)
        {
            new Windows.SearchWaitCustomer().Show();
        }
    }
}
