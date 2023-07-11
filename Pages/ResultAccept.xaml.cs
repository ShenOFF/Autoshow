using AutoShow.View;
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
    /// Логика взаимодействия для ResultAccept.xaml
    /// </summary>
    public partial class ResultAccept : Page
    {
        public static ResultAccept resultAccept;
        public ResultAccept()
        {
            InitializeComponent();
            resultAccept = this;
            AllResultAcceptLook(MainWindow.mainWindow.waitings);
        }

        private void Click_Reg_Exit(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.Main());
        }

        public void AllResultAcceptLook(List<Classes.Waiting> waitings)
        {

            waitings = MainWindow.mainWindow.waitings.FindAll(x => x.login_user.ToString().Contains(Classes.data.name.ToString()) && x.hidden.ToString().Contains("1"));
            accepted_wait.Children.Clear();
            foreach (var item in waitings)
            {
                accepted_wait.Children.Add(new StatusOrder(item));
            }
        }

        private void Click_Search(object sender, RoutedEventArgs e)
        {
            new Windows.SearchResultStatus().Show();
        }
    }
}
