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
    /// Логика взаимодействия для ChangeWorker.xaml
    /// </summary>
    public partial class ChangeWorker : Page
    {
        Classes.Worker worker;
        public ChangeWorker(Classes.Worker worker)
        {
            InitializeComponent();
            this.worker = worker;
            tb_middle.Text = worker.Last_Name;
            tb_name.Text = worker.Name;
            tb_stage.Text = worker.exp.ToString();
            tb_zp.Text = worker.zp.ToString();
            tb_surname.Text = worker.Sur_Name;
        }

        private void Click_Reg_Exit(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.Worker());
        }

        private void Click_Main_Accept(object sender, RoutedEventArgs e)
        {
            //Проверка на введение марки
            if (!MainWindow.mainWindow.ItsOnlyFIO(tb_middle.Text) || tb_middle.Text == " ")
            {
                MessageBox.Show("Вы не правильно написали название.Перепроверьте!");
                return;
            }

            //Проверка на введение страны
            if (!MainWindow.mainWindow.ItsOnlyFIO(tb_name.Text) || tb_name.Text == " ")
            {
                MessageBox.Show("Вы не правильно указали цену.Перепроверьте!");
                return;
            }

            //Проверка на введение завода
            if (!MainWindow.mainWindow.ItsOnlyFIO(tb_surname.Text) || tb_surname.Text == " ")
            {
                MessageBox.Show("Вы не правильно указали цену.Перепроверьте!");
                return;
            }

            //Проверка на введение адреса
            if (!MainWindow.mainWindow.ItsNumber(tb_stage.Text) || tb_stage.Text == " ")
            {
                MessageBox.Show("Вы не правильно указали цену.Перепроверьте!");
                return;
            }

            //Проверка на введение адреса
            if (!MainWindow.mainWindow.ItsNumber(tb_zp.Text) || tb_zp.Text == " ")
            {
                MessageBox.Show("Вы не правильно указали цену.Перепроверьте!");
                return;
            }

            Connection.Select($"UPDATE Worker SET Sur_Name='{tb_surname.Text}',Name='{tb_name.Text}',Last_Name='{tb_middle.Text}',exp='{tb_stage.Text}',zp='{tb_zp.Text}' WHERE kod_worker={worker.kod_worker}");
            //Connection.Ubuntu($"UPDATE Worker SET Sur_Name='{tb_surname.Text}',Name='{tb_name.Text}',Last_Name='{tb_middle.Text}',exp='{tb_stage.Text}',zp='{tb_zp.Text}' WHERE kod_worker={worker.kod_worker}");
            MessageBox.Show("Работник успешно изменили работника!");

            MainWindow.mainWindow.LoadWorker();
            MainWindow.mainWindow.frame.Navigate(new Pages.Main());
        }
    }
}
