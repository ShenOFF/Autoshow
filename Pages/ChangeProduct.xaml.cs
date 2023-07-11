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
    /// Логика взаимодействия для ChangeProduct.xaml
    /// </summary>
    public partial class ChangeProduct : Page
    {
        MainWindow mainWindow;
        Classes.Auto auto;
        public int marka_i;
        public ChangeProduct(Classes.Auto auto)
        {
            InitializeComponent();
            this.auto = auto;
            LoadCBMarka();
            tb_name.Text = auto.auto_name;
            tb_color.Text = auto.color;
            cb_marka.Text = auto.marka;
            tb_category.Text=auto.category;
            tb_year.Text = auto.year_create.ToString();
            tb_price.Text = auto.price.ToString();

        }

        private void Click_Reg_Exit(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.Main());
        }

        private void Click_Main_Accept(object sender, RoutedEventArgs e)
        {
            //Проверка на введеное название
            if (tb_name.Text == " ")
            {
                MessageBox.Show("Вы не правильно написали название.Перепроверьте!");
                return;
            }

            //Проверка на введеное цены на товар
            if (!MainWindow.mainWindow.ItsNumber(tb_price.Text) || tb_price.Text == " ")
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
            if (!MainWindow.mainWindow.ItsOnlyFIO(tb_color.Text) || tb_color.Text == " ")
            {
                MessageBox.Show("Вы не правильно указали цвет.Перепроверьте!");
                return;
            }

            //Проверка даты
            if (!MainWindow.mainWindow.ItsNumber(tb_year.Text) || tb_year.Text == " ")
            {
                MessageBox.Show("Вы не правильно указали цену.Перепроверьте!");
                return;
            }

            //Проверка на категорию
            if (!MainWindow.mainWindow.ItsOnlyFIO(tb_category.Text) || tb_category.Text == " ")
            {
                MessageBox.Show("Вы не правильно написали категорию.Перепроверьте!");
                return;
            }

            marka_i = MainWindow.mainWindow.marks[cb_marka.SelectedIndex].kod_marki;

            Connection.Select($"UPDATE Auto SET auto_name='{tb_name.Text}',marka='{marka_i}',year_create='{tb_year.Text}',color='{tb_color.Text}',category='{tb_category.Text}',price='{tb_price.Text}' WHERE kod_auto={auto.kod_auto}");
            //Connection.Ubuntu($"UPDATE Auto SET auto_name='{tb_name.Text}',marka='{marka_i}',year_create='{tb_year.Text}',color='{tb_color.Text}',category='{tb_category.Text}',price='{tb_price.Text}' WHERE kod_auto={auto.kod_auto}");

            MessageBox.Show("Товар успешно добавлен!");

            MainWindow.mainWindow.LoadAuto();
            MainWindow.mainWindow.frame.Navigate(new Pages.Main());
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
    }
}
