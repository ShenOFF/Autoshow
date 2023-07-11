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
    /// Логика взаимодействия для Worker.xaml
    /// </summary>
    public partial class Worker : Page
    {
        public static Pages.Worker worker;
        public Worker()
        {
            InitializeComponent();
            worker = this;
            LoadDataWorker();
        }

        private void Click_Reg_Exit(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.Main());
        }

        public void LoadDataWorker()
        {
            //Вывод данных о пользователях
            listView_workers.Items.Clear();
            var a = MainWindow.mainWindow.workers/*.FindAll(x=>x.role=="User")*/;
            for (int i = 0; i < a.Count; i++)
            {
                listView_workers.Items.Add(a[i]);
            }


        }

       

        private void Click_Main_add(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.AddWorker(MainWindow.mainWindow));
        }

        private void Click_Main_change(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.ChangeWorker(MainWindow.mainWindow.workers[listView_workers.SelectedIndex]));
        }

        private void Click_Main_delete(object sender, RoutedEventArgs e)
        {
            try
            {
                Connection.Select("DELETE FROM Worker WHERE kod_worker=" + MainWindow.mainWindow.workers[listView_workers.SelectedIndex].kod_worker);
                //Connection.Ubuntu("DELETE FROM Worker WHERE kod_worker = " + MainWindow.mainWindow.workers[listView_workers.SelectedIndex].kod_worker);
                MainWindow.mainWindow.LoadWorker();
                MessageBox.Show("Вы успешно удалили работника!");
            }
            catch
            {
                MessageBox.Show("Данная запись связана с другой табицей!");
            }
            
        }

        private void Click_Main_search(object sender, RoutedEventArgs e)
        {
            new WIndows.SearchWorker().Show();
        }
    }
}
