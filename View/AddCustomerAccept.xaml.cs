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
    /// Логика взаимодействия для AddCustomerAccept.xaml
    /// </summary>
    public partial class AddCustomerAccept : UserControl
    {
        Classes.WaitCustomer waitcustomer;
        public AddCustomerAccept(Classes.WaitCustomer waitCustomer)
        {
            InitializeComponent();
            this.waitcustomer = waitCustomer;
            name_customer.Content = waitCustomer.Name;
            Sur_name.Content = waitCustomer.Sur_name;
            Last_name.Content = waitCustomer.Last_name;
            passport_date.Content = waitCustomer.passport_date;
        }

        private void accept(object sender, MouseButtonEventArgs e)
        {
            for (int i = 0; i < MainWindow.mainWindow.customers.Count; i++)
            {
                var cus = MainWindow.mainWindow.customers[i];
                if (waitcustomer.Name == cus.Name && waitcustomer.passport_date == cus.passport_date)
                {
                    MessageBox.Show("Введенные данные уже существуют в БД!");
                    return;
                }
            }
            string query = $"INSERT INTO Customer(Sur_name,Name,Last_name,passport_date,addres,City,Years_old,gender,login_user) values('{waitcustomer.Sur_name}','{waitcustomer.Name}','{waitcustomer.Last_name}','{waitcustomer.passport_date}','{waitcustomer.addres}','{waitcustomer.City}','{waitcustomer.Years_old}','{waitcustomer.gender}','{waitcustomer.login_user}')";
            Connection.Select(query);
            //Connection.Ubuntu(query);
            Connection.Select("DELETE FROM WaitCustomer WHERE kod_customer=" + waitcustomer.kod_customer);
            //Connection.Ubuntu("DELETE FROM WaitCustomer WHERE kod_customer=" + waitcustomer.kod_customer);
            MessageBox.Show("Запрос одобрен!");


            MainWindow.mainWindow.LoadCustomer();
            MainWindow.mainWindow.LoadWaitCustomer();
            MainWindow.mainWindow.frame.Navigate(new Pages.AddCustomerWait());
        }

        private void reject(object sender, MouseButtonEventArgs e)
        {
            Connection.Select("DELETE FROM WaitCustomer WHERE kod_customer=" + waitcustomer.kod_customer);
            //Connection.Ubuntu("DELETE FROM WaitCustomer WHERE kod_customer=" + waitcustomer.kod_customer);
            MainWindow.mainWindow.LoadWaitCustomer();
            MainWindow.mainWindow.frame.Navigate(new Pages.AddCustomerWait());
        }
    }
}
