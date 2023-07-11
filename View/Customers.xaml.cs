using AutoShow.Classes;
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
    /// Логика взаимодействия для Customers.xaml
    /// </summary>
    public partial class Customers : UserControl
    {
        Classes.Customer customer;
        public Customers(Classes.Customer customer)
        {

            InitializeComponent();
            this.customer = customer;
            name_customer.Content=customer.Name;
            passport_date.Content = customer.passport_date;
            Sur_name.Content = customer.Sur_name;
            Last_name.Content = customer.Last_name;
            gender.Content = customer.gender;
            addres.Content=customer.addres;
            city.Content = customer.City;
            if (Classes.data.role == "User")
            {
                admin_role2.Visibility = Visibility.Hidden;
            }
        }

        private void change(object sender, MouseButtonEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.ChangeCustomer(customer));
        }

        private void delete(object sender, MouseButtonEventArgs e)
        {
            string query = $"DELETE FROM Customer where kod_customer = {customer.kod_customer}";
            Connection.Select(query);
            //Connection.Ubuntu(query);
            MainWindow.mainWindow.LoadCustomer();
            MainWindow.mainWindow.frame.Navigate(new Pages.Customer());
        }
    }
}
