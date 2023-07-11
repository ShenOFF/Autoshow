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
    /// Логика взаимодействия для SearchCustomer.xaml
    /// </summary>
    public partial class SearchCustomer : Window
    {
        public SearchCustomer()
        {
            InitializeComponent();
        }

        private void Click_Main_Accept_user(object sender, RoutedEventArgs e)
        {
            var data = MainWindow.mainWindow.customers;
            data = data.Where(x => x.Sur_name.Contains(tb_sur_name.Text) & x.Last_name.Contains(tb_Last_name.Text) & x.Name.Contains(tb_name.Text)
              & x.passport_date.ToString().Contains(tb_passport.Text) & x.Years_old.ToString().Contains(tb_years_old.Text) & x.City.Contains(tb_city.Text) & x.addres.Contains(tb_addres.Text) & x.gender.Contains(tb_gender.Text)).ToList();
            Customer.customer.accepted_wait.Children.Clear();
            foreach (var item in data)
            {
                Customer.customer.accepted_wait.Children.Add(new View.Customers(item));
            }
        }

       
    }
}
