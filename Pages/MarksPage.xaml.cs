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
    /// Логика взаимодействия для Marks.xaml
    /// </summary>
    public partial class Marks : Page
    {
        public static Marks marks;
        public Marks()
        {
            InitializeComponent();
            marks=this;
            AllResultMarksLook(MainWindow.mainWindow.marks);


        }

        private void Click_Reg_Exit(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.Main());
        }

        public void AllResultMarksLook(List<Classes.Marka> markss)
        {

            markss = MainWindow.mainWindow.marks/*.FindAll(x => x.login_user.ToString().Contains(Classes.data.name.ToString()) && x.hidden.ToString().Contains("1"))*/;
            accepted_wait.Children.Clear();
            foreach (var item in markss)
            {
                accepted_wait.Children.Add(new MarksElement(item));
            }
        }

        private void Click_Search(object sender, RoutedEventArgs e)
        {
            new Windows.SearchMarka().Show();
        }
    }
}
