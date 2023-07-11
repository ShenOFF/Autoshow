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

namespace AutoShow.WIndows
{
    /// <summary>
    /// Логика взаимодействия для SearchWorker.xaml
    /// </summary>
    public partial class SearchWorker : Window
    {
        public SearchWorker()
        {
            InitializeComponent();
        }

        private void Click_Main_Accept(object sender, RoutedEventArgs e)
        {
            var data = MainWindow.mainWindow.workers;
            data = data.Where(x => x.Sur_Name.Contains(tb_surname.Text) & x.Last_Name.Contains(tb_middle.Text) & x.Name.Contains(tb_name.Text)
              & x.zp.ToString().Contains(tb_zp.Text) & x.exp.ToString().Contains(tb_stage.Text)).ToList();
            Worker.worker.listView_workers.Items.Clear();

            for (int i = 0; i < data.Count; i++)
            {
                Worker.worker.listView_workers.Items.Add(data[i]);
            }
        }

        private void Click_Reg_Exit(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.Worker());
        }
    }
}
