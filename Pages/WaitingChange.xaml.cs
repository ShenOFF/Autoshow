using AutoShow.Classes;
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
    /// Логика взаимодействия для WaitingChange.xaml
    /// </summary>
    public partial class WaitingChange : Page
    {
        public int id_worker;
        Classes.Waiting waiting;
        public WaitingChange(Classes.Waiting waiting)
        {
            InitializeComponent();
            this.waiting = waiting;
            tb_status.Text = waiting.status;
            LoadCBWorker();
        }

        private void Click_Log_Page(object sender, RoutedEventArgs e)
        {
            id_worker = MainWindow.mainWindow.workers[cb_worker_accept.SelectedIndex].kod_worker;
            Connection.Select($"UPDATE Waiting SET status='{tb_status.Text}',worker='{id_worker}' where kod_wait={waiting.kod_wait}");
            //Connection.Ubuntu($"UPDATE Waiting SET status='{tb_status.Text}',worker='{id_worker}' where kod_wait={waiting.kod_wait}");
            MainWindow.mainWindow.LoadWaiting();
            MessageBox.Show("Запись изменина");
            MainWindow.mainWindow.frame.Navigate(new Pages.WaitAccept());
        }

        private void Click_Reg_Accept(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.WaitAccept());
        }

        public void LoadCBWorker()
        {
            DataTable hotel_query = Connection.Select("SELECT * FROM Worker");
            for (int i = 0; i < hotel_query.Rows.Count; i++)
            {
                string worker_id = Convert.ToString(hotel_query.Rows[i][0]) + "-" + Convert.ToString(hotel_query.Rows[i][1]); ;

                cb_worker_accept.Items.Add(worker_id);
            }
        }
    }
}
