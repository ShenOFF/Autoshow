using AutoShow.Classes;
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
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public static Main main;
        public Main()
        {
            InitializeComponent();
            main = this;
            
            parrent.Children.Clear();
            foreach (var item in MainWindow.mainWindow.autos)
                parrent.Children.Add(new CarsProduct(item));

            //MessageBox.Show(Classes.data.role);
            if (Classes.data.role=="Admin")
            {
                user_wait_role.Visibility = Visibility.Hidden;
                add_b_customer_user.Visibility = Visibility.Hidden;
            }
            if (Classes.data.role == "User")
            {
                admin_role.Visibility = Visibility.Hidden;
            }
            if (Classes.data.role == "Reader")
            {
                admin_role.Visibility = Visibility.Hidden;
                user_wait_role.Visibility = Visibility.Hidden;
                add_b_customer_user.Visibility = Visibility.Hidden;
            }
        }

        private void Click_AddItems(object sender, MouseButtonEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.AddProducts(MainWindow.mainWindow));
        }

        private void Click_Search(object sender, RoutedEventArgs e)
        {
            new WIndows.SearchMain().Show();
        }

        private void Click_clear_filter(object sender, RoutedEventArgs e)
        {

        }

        private void add_marka(object sender, MouseButtonEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.AddMarks(MainWindow.mainWindow));
        }

        private void add_worker(object sender, MouseButtonEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.Worker());
        }

        private void add_customer(object sender, MouseButtonEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.Customer());
        }

        private void add_wait(object sender, MouseButtonEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.WaitAccept());
        }

        private void Click_accepted(object sender, MouseButtonEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.ResultAccept());
        }

        private void Exit_to_login(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.Login(MainWindow.mainWindow));
        }

        private void btn_top(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.TopList());
        }

        private void add_customer_user(object sender, MouseButtonEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.Customer());
        }

        private void add_wait_customer(object sender, MouseButtonEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.AddCustomerWait());
        }

        private void add_marks(object sender, MouseButtonEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.Marks());
        }

        private void look_saleauto(object sender, MouseButtonEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.SaleAutoLook());
        }
    }
}
