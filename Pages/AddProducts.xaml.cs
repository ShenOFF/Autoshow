using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using static System.Net.Mime.MediaTypeNames;
using AutoShow.Classes;

namespace AutoShow.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddProducts.xaml
    /// </summary>
    public partial class AddProducts : Page
    {
        MainWindow mainWindow;
        public AddProducts(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            LoadCBMarka();
        }

        int marka_i;

        private void Click_Reg_Exit(object sender, RoutedEventArgs e)
        {
            mainWindow.frame.Navigate(new Pages.Main());
        }

        private void Click_Main_Accept(object sender, RoutedEventArgs e)
        {
            //Проверка на введеное название
            if ( tb_name.Text == " ")
            {
                MessageBox.Show("Вы не правильно написали название.Перепроверьте!");
                return;
            }

            //Проверка на введеное цены на товар
            if (!mainWindow.ItsNumber(tb_price.Text) || tb_price.Text == " ")
            {
                MessageBox.Show("Вы не правильно указали цену.Перепроверьте!");
                return;
            }

            //Проверка на марку
            if (cb_marka.Text == " ")
            {
                MessageBox.Show("Вы не правильно указали марку.Перепроверьте!");
                return;
            }

            //Проверка на введеное цвета
            if (!mainWindow.ItsOnlyFIO(tb_color.Text) || tb_color.Text == " ")
            {
                MessageBox.Show("Вы не правильно указали цвет.Перепроверьте!");
                return;
            }

            //Проверка даты
            if (!mainWindow.ItsNumber(tb_year.Text) || tb_year.Text == " ")
            {
                MessageBox.Show("Вы не правильно указали цену.Перепроверьте!");
                return;
            }

            //Проверка на категорию
            if (!mainWindow.ItsOnlyFIO(tb_category.Text) || tb_category.Text == " ")
            {
                MessageBox.Show("Вы не правильно написали категорию.Перепроверьте!");
                return;
            }


            marka_i = MainWindow.mainWindow.marks[cb_marka.SelectedIndex].kod_marki;

            string query = $"INSERT INTO Auto(auto_name,marka,year_create,color,category,price) values('{tb_name.Text}','{marka_i}','{tb_year.Text}','{tb_color.Text}','{tb_category.Text}','{tb_price.Text}')";
            Connection.Select(query);
            //Connection.Ubuntu(query);

            MessageBox.Show("Машина успешно добавлена!");

            mainWindow.LoadAuto();
            MainWindow.mainWindow.frame.Navigate(new Pages.Main());
        }
        public void LoadCBMarka()
        {
            DataTable hotel_query = Connection.Select("SELECT * FROM MarkaAuto");
            for (int i = 0; i < hotel_query.Rows.Count; i++)
            {
                string marka_id= Convert.ToString(hotel_query.Rows[i][0]) + "-" + Convert.ToString(hotel_query.Rows[i][1]); ;

                cb_marka.Items.Add(marka_id);
            }
        }
    }
}
