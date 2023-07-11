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
    /// Логика взаимодействия для AddMarks.xaml
    /// </summary>
    public partial class AddMarks : Page
    {
        MainWindow mainWindow;
        public AddMarks(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void Click_Reg_Exit(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.Main());
        }

        private void Click_Main_Accept(object sender, RoutedEventArgs e)
        {
            //Проверка на введение марки
            if (!mainWindow.ItsOnlyFIO(tb_name_mark.Text) || tb_name_mark.Text == " ")
            {
                MessageBox.Show("Вы не правильно написали название.Перепроверьте!");
                return;
            }

            //Проверка на введение страны
            if (!mainWindow.ItsOnlyFIO(tb_country_create.Text) || tb_country_create.Text == " ")
            {
                MessageBox.Show("Вы не правильно указали цену.Перепроверьте!");
                return;
            }

            //Проверка на введение завода
            if (!mainWindow.ItsOnlyFIO(tb_zavod_create.Text) || tb_zavod_create.Text == " ")
            {
                MessageBox.Show("Вы не правильно указали цену.Перепроверьте!");
                return;
            }

            //Проверка на введение адреса
            if (tb_addres.Text == " ")
            {
                MessageBox.Show("Вы не правильно указали цену.Перепроверьте!");
                return;
            }


            string query = $"INSERT INTO MarkaAuto(mark_name,country_create,zavod_create,addres) values('{tb_name_mark.Text}','{tb_country_create.Text}','{tb_zavod_create.Text}','{tb_addres.Text}')";
            Connection.Select(query);
            //Connection.Ubuntu(query);

            MessageBox.Show("Марка успешно добавлена!");

            mainWindow.LoadMark();
            MainWindow.mainWindow.frame.Navigate(new Pages.Main());
        }
    }
}
