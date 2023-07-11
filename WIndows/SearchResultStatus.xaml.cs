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
    /// Логика взаимодействия для SearchResultStatus.xaml
    /// </summary>
    public partial class SearchResultStatus : Window
    {
        public SearchResultStatus()
        {
            InitializeComponent();
        }

        private void Click_Main_Accept(object sender, RoutedEventArgs e)
        {
            var data = MainWindow.mainWindow.waitings;
            data = data.Where(x => x.customer.Contains(tb_customer.Text) & x.auto.Contains(tb_car.Text)).ToList();
            ResultAccept.resultAccept.accepted_wait.Children.Clear();


            foreach (var item in data)
            {
                ResultAccept.resultAccept.accepted_wait.Children.Add(new View.StatusOrder(item));
            }
        }
    }
}
