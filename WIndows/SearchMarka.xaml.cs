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
    /// Логика взаимодействия для SearchMarka.xaml
    /// </summary>
    public partial class SearchMarka : Window
    {
        public SearchMarka()
        {
            InitializeComponent();
        }

        private void Click_Main_Accept(object sender, RoutedEventArgs e)
        {
            var data = MainWindow.mainWindow.marks;
            data = data.Where(x => x.marka_name.Contains(tb_name_mark.Text) & x.zavod_create.Contains(tb_zavod_create.Text) & x.country_create.Contains(tb_country_create.Text)
              & x.addres.ToString().Contains(tb_addres.Text)).ToList();
            Marks.marks.accepted_wait.Children.Clear();

            foreach (var item in data)
            {
                Marks.marks.accepted_wait.Children.Add(new View.MarksElement(item));
            }
        }
    }
}
