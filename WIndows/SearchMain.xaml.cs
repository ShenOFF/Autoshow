using AutoShow.Pages;
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
using System.Windows.Shapes;

namespace AutoShow.WIndows
{
    /// <summary>
    /// Логика взаимодействия для SearchMain.xaml
    /// </summary>
    public partial class SearchMain : Window
    {
        public SearchMain()
        {
            InitializeComponent();
            LoadCBMarka();
        }

        private void Click_Main_Accept(object sender, RoutedEventArgs e)
        {
            var data = MainWindow.mainWindow.autos;
            data=data.Where(x => x.auto_name.Contains(tb_name.Text) & x.category.Contains(tb_category.Text) & x.color.Contains(tb_color.Text)
            & x.marka.Contains(cb_marka.SelectedIndex.ToString()) & x.price.ToString().Contains(tb_price.Text) & x.year_create.ToString().Contains(tb_year.Text)).ToList();
            Main.main.parrent.Children.Clear();
            foreach(var item in data)
            {
                Main.main.parrent.Children.Add(new View.CarsProduct(item));
            }
        }

        public void LoadCBMarka()
        {
            DataTable hotel_query = Connection.Select("SELECT * FROM MarkaAuto");
            for (int i = 0; i < hotel_query.Rows.Count; i++)
            {
                string marka_id = Convert.ToString(hotel_query.Rows[i][0]) + "-" + Convert.ToString(hotel_query.Rows[i][1]); ;

                cb_marka.Items.Add(marka_id);
            }
        }

        private void Click_Reg_Exit(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.Main());
        }
    }
}
