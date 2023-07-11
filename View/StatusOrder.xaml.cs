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
    /// Логика взаимодействия для StatusOrder.xaml
    /// </summary>
    public partial class StatusOrder : UserControl
    {
        Classes.Waiting waiting;
        public StatusOrder(Classes.Waiting waiting)
        {
            InitializeComponent();
            this.waiting = waiting;
            name_customer.Content = waiting.customer;
            auto.Content = waiting.auto;
            worker.Content = waiting.worker;
            status.Content = waiting.status;
            if (Classes.data.role=="User")
            {
                admin_role.Visibility = Visibility.Hidden;
                
            }
            if (Classes.data.role == "Admin")
            {
                admin_role2.Visibility = Visibility.Hidden;
                admin_role3.Visibility = Visibility.Hidden;
            }
            if (status.Content.ToString() == "Одобрено") { status.Foreground = System.Windows.Media.Brushes.Green; }
            if (status.Content.ToString() == "Отказано") { status.Foreground = System.Windows.Media.Brushes.Red; }
            if (status.Content.ToString().Length == 0) { status.Content = "Ожидание"; }
            if (status.Content.ToString() == "Ожидание") { status.Foreground = System.Windows.Media.Brushes.Orange; }


        }

        private void change(object sender, MouseButtonEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.WaitingChange(waiting));
        }

        private void delete_hidden(object sender, MouseButtonEventArgs e)
        {
            Connection.Select($"UPDATE Waiting SET hidden='0' WHERE login_user='{waiting.login_user}'");
            //Connection.Ubuntu($"UPDATE Waiting SET hidden='0' WHERE login_user='{waiting.login_user}'");

            MessageBox.Show("Запись скрыта!");

            MainWindow.mainWindow.LoadWaiting();
            MainWindow.mainWindow.frame.Navigate(new Pages.ResultAccept());
        }

        private void buy(object sender, MouseButtonEventArgs e)
        {
            if(status.Content.ToString() == "Отказано" )
            {
                MessageBox.Show("Ваша заявка отклонена!Поробуйте в другой раз.");
                return;
            }

            if(status.Content.ToString() == "Ожидание")
            {
                MessageBox.Show("Администратор пока не рассмотрел вашу заявку.");
                return;
            }

            if (status.Content.ToString() == "Одобрено")
            {
                string query = $"INSERT INTO SaleAuto(data,worker,auto,customer) values('{waiting.data}','{waiting.worker}','{waiting.id_auto}','{waiting.id_customer}')";
                Connection.Select(query);
                //Connection.Ubuntu(query);
                MessageBox.Show("Вы успешно приобрели машину,спасибо за покупку!🤝💵");
                Connection.Select("DELETE FROM Waiting WHERE kod_wait=" + waiting.kod_wait);
                //Connection.Ubuntu("DELETE FROM Waiting WHERE kod_wait=" + waiting.kod_wait);
                MainWindow.mainWindow.LoadWaiting();

               


                MainWindow.mainWindow.LoadSaleAuto();
                MainWindow.mainWindow.frame.Navigate(new Pages.Main());
            }

            
        }
    }
}
