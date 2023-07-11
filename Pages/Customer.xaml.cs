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
    /// Логика взаимодействия для Customer.xaml
    /// </summary>
    public partial class Customer : Page
    {
        public static Customer customer;

        public Customer()
        {
            InitializeComponent();
            customer = this;
            if (Classes.data.role == "Admin")
            {
                AllResultAcceptLook(MainWindow.mainWindow.customers);
            }
            if (Classes.data.role == "User")
            {
                AllResultAcceptLookUser(MainWindow.mainWindow.customers);
            }
            //LoadDataCustomer();
            //LoadDataCustomerCustom();
            //if (Classes.data.role == "User")
            //{
            //    delete_role.Visibility = Visibility.Hidden;
            //    listView_customer.Visibility = Visibility.Hidden;
            //    btn_change_admin.Visibility = Visibility.Hidden;


            //}
            //if (Classes.data.role == "Admin")
            //{
            //    listView_customer_custom.Visibility = Visibility.Hidden;
            //    btn_change_user.Visibility = Visibility.Hidden;
            //}
        }

        private void Click_Main_add(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.AddCustomer());
        }

        //private void Click_Main_change(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        MainWindow.mainWindow.frame.Navigate(new Pages.ChangeCustomer(MainWindow.mainWindow.customers[listView_customer.SelectedIndex]));
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Ошибка,попробуйте еще раз !!!");
        //    }


        //}

        //private void Click_Main_delete(object sender, RoutedEventArgs e)
        //{

        //    try
        //    {
        //        Connection.Select("DELETE FROM Customer WHERE kod_customer=" + MainWindow.mainWindow.customers[listView_customer.SelectedIndex].kod_customer);
        //        Connection.Ubuntu("DELETE FROM Customer WHERE kod_customer=" + MainWindow.mainWindow.customers[listView_customer.SelectedIndex].kod_customer);
        //        MainWindow.mainWindow.LoadCustomer();
        //        MainWindow.mainWindow.frame.Navigate(new Pages.Customer());
        //        MessageBox.Show("Вы успешно удалили покупателя!");
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Данная запись связана с другой табицей!");
        //    }
        //}

        private void Click_Reg_Exit(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.Main());
        }
        public void AllResultAcceptLook(List<Classes.Customer> customers)
        {

            customers = MainWindow.mainWindow.customers/*.FindAll(x => x.login_user.ToString().Contains(Classes.data.name.ToString()) && x.hidden.ToString().Contains("1"))*/;
            accepted_wait.Children.Clear();
            foreach (var item in customers)
            {
                accepted_wait.Children.Add(new Customers(item));
            }
        }

        public void AllResultAcceptLookUser(List<Classes.Customer> customers)
        {

            customers = MainWindow.mainWindow.customers.FindAll(x => x.login_user.ToString().Contains(Classes.data.name.ToString()));
            accepted_wait.Children.Clear();
            foreach (var item in customers)
            {
                accepted_wait.Children.Add(new Customers(item));
            }
        }
        //public void LoadDataCustomer()
        //{
        //    //Вывод данных о пользователях
        //    listView_customer.Items.Clear();
        //    var a = MainWindow.mainWindow.customers/*.FindAll(x=>x.role=="User")*/;
        //    for (int i = 0; i < a.Count; i++)
        //    {
        //        listView_customer.Items.Add(a[i]);
        //    }


        //}

        //public void LoadDataCustomerCustom()
        //{
        //    //Вывод данных о пользователях
        //    listView_customer_custom.Items.Clear();
        //    var a = MainWindow.mainWindow.customers.FindAll(x => x.login_user == Classes.data.name);
        //    for (int i = 0; i < a.Count; i++)
        //    {
        //        listView_customer_custom.Items.Add(a[i]);
        //    }


        //}

        //private void Click_Main_search(object sender, RoutedEventArgs e)
        //{

        //}

        private void Click_Search(object sender, RoutedEventArgs e)
        {
            new Windows.SearchCustomer().Show();
        }

        private void Click_Add_Customer(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.AddCustomer());
        }

        //private void Click_Main_change_user(object sender, RoutedEventArgs e)
        //{

        //    MainWindow.mainWindow.frame.Navigate(new Pages.ChangeCustomer(MainWindow.mainWindow.customers[listView_customer_custom.SelectedIndex]));
        //}
    }
}
