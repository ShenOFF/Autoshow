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
    /// Логика взаимодействия для CarsProduct.xaml
    /// </summary>
    public partial class CarsProduct : UserControl
    {
        
        Classes.Auto auto;
        Classes.Customer customer;
        public CarsProduct(Classes.Auto auto)
        {
            InitializeComponent();
            this.auto = auto;
            product_name.Content = auto.auto_name;
            marka.Content=auto.marka;
            color.Content = auto.color;
            year.Content = auto.year_create + "год";
            price.Content = "Итого: " + auto.price;

            if (Classes.data.role == "Reader")
            {
                
                main_button.Visibility = Visibility.Hidden;
                user_role.Visibility = Visibility.Hidden;
                admin_role2.Visibility = Visibility.Hidden;
            }

            if (Classes.data.role == "Admin")
            {
                user_role.Visibility = Visibility.Hidden;
            }
            if (Classes.data.role == "User")
            {
                main_button.Visibility = Visibility.Hidden;
            }

        }

        private void change(object sender, MouseButtonEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.ChangeProduct(auto));
        }

        private void delete(object sender, MouseButtonEventArgs e)
        {
            string query = $"DELETE FROM Auto where kod_auto = {auto.kod_auto}";
            Connection.Select(query);
            //Connection.Ubuntu(query);
            MainWindow.mainWindow.LoadAuto();
            MainWindow.mainWindow.frame.Navigate(new Pages.Main());
        }

        private void buy(object sender, MouseButtonEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.Buy(auto));
        }

        private void order(object sender, MouseButtonEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.Order(auto));
        }

        private void delete_hidden(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
