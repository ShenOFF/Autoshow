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
    /// Логика взаимодействия для AddWorker.xaml
    /// </summary>
    public partial class AddWorker : Page
    {
        MainWindow mainWindow;
        public AddWorker(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void Click_Reg_Exit(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.Worker());
        }

        private void Click_Main_Accept(object sender, RoutedEventArgs e)
        {
            //Проверка на введение марки
            if (!mainWindow.ItsOnlyFIO(tb_middle.Text) || tb_middle.Text == " ")
            {
                MessageBox.Show("Вы не правильно написали название.Перепроверьте!");
                return;
            }

            //Проверка на введение страны
            if (!mainWindow.ItsOnlyFIO(tb_name.Text) || tb_name.Text == " ")
            {
                MessageBox.Show("Вы не правильно указали цену.Перепроверьте!");
                return;
            }

            //Проверка на введение завода
            if (!mainWindow.ItsOnlyFIO(tb_surname.Text) || tb_surname.Text == " ")
            {
                MessageBox.Show("Вы не правильно указали цену.Перепроверьте!");
                return;
            }

            //Проверка на введение адреса
            if (!mainWindow.ItsNumber(tb_stage.Text) || tb_stage.Text == " ")
            {
                MessageBox.Show("Вы не правильно указали цену.Перепроверьте!");
                return;
            }

            //Проверка на введение адреса
            if (!mainWindow.ItsNumber(tb_zp.Text) || tb_zp.Text == " ")
            {
                MessageBox.Show("Вы не правильно указали цену.Перепроверьте!");
                return;
            }


            string query = $"INSERT INTO Worker(Sur_Name,Name,Last_Name,exp,zp) values('{tb_surname.Text}','{tb_name.Text}','{tb_middle.Text}','{tb_stage.Text}','{tb_zp.Text}')";
            Connection.Select(query);
            //Connection.Ubuntu(query);

            MessageBox.Show("Работник успешно добавлен!");

            MainWindow.mainWindow.LoadWorker();
            MainWindow.mainWindow.frame.Navigate(new Pages.Main());
        }
    }
}
