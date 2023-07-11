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
    /// Логика взаимодействия для TopList.xaml
    /// </summary>
    public partial class TopList : Page
    {
        public TopList()
        {
            InitializeComponent();
        }

        private void Click_Reg_Exit(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.Main());
        }
    }
}
