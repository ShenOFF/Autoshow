using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для Buy.xaml
    /// </summary>
    public partial class Buy : Page
    {
        public int customer_i;
        public int worker_i;
        Classes.Auto auto;
        public Buy(Classes.Auto auto)
        {
            InitializeComponent();
            this.auto = auto;
            LoadCBWorker();
            LoadCBCustomer();
            auto_buy.Content = auto.auto_name;
            data_buy.Content = System.DateTime.Now.ToShortDateString();
        }

        private void Click_Reg_Exit(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.Main());
        }

        private void Click_Main_Accept(object sender, RoutedEventArgs e)
        {
            customer_i= MainWindow.mainWindow.customers[cb_worker_buy.SelectedIndex].kod_customer;
            worker_i = MainWindow.mainWindow.workers[cb_worker_buy.SelectedIndex].kod_worker;
            string query = $"INSERT INTO SaleAuto(data,worker,auto,customer) values('{data_buy.Content}','{customer_i}','{auto.kod_auto}','{worker_i}')";
            Connection.Select(query);
            //Connection.Ubuntu(query);

            MessageBox.Show("Вы успешно приобрели машину,спасибо за покупку!🤝💵");

            MainWindow.mainWindow.LoadSaleAuto();
            MainWindow.mainWindow.frame.Navigate(new Pages.Main());
        }

        public void LoadCBWorker()
        {
            DataTable hotel_query = Connection.Select("SELECT * FROM Worker");
            for (int i = 0; i < hotel_query.Rows.Count; i++)
            {
                string worker_id = Convert.ToString(hotel_query.Rows[i][0]) + "-" + Convert.ToString(hotel_query.Rows[i][1]); ;

                cb_worker_buy.Items.Add(worker_id);
            }
        }

        public void LoadCBCustomer()
        {
            DataTable hotel_query = Connection.Select("SELECT * FROM Customer");
            for (int i = 0; i < hotel_query.Rows.Count; i++)
            {
                string customer_id = Convert.ToString(hotel_query.Rows[i][0]) + "-" + Convert.ToString(hotel_query.Rows[i][1]); ;

                cb_customer_buy.Items.Add(customer_id);
            }
        }
    }
}
