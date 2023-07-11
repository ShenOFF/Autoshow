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
    /// Логика взаимодействия для ChangeMarks.xaml
    /// </summary>
    public partial class ChangeMarks : Page
    {
        
        Classes.Marka marka;
        public ChangeMarks( Classes.Marka marka)
        {
            InitializeComponent();
            this.marka = marka;
            tb_addres.Text = marka.addres;
            tb_name_mark.Text = marka.marka_name;
            tb_country_create.Text = marka.country_create;
            tb_zavod_create.Text=marka.zavod_create;
            
        }

        private void Click_Main_Accept(object sender, RoutedEventArgs e)
        {
            //Проверка на введение марки
            if (!MainWindow.mainWindow.ItsOnlyFIO(tb_name_mark.Text) || tb_name_mark.Text == " ")
            {
                MessageBox.Show("Вы не правильно написали название.Перепроверьте!");
                return;
            }

            //Проверка на введение страны
            if (!MainWindow.mainWindow.ItsOnlyFIO(tb_country_create.Text) || tb_country_create.Text == " ")
            {
                MessageBox.Show("Вы не правильно указали цену.Перепроверьте!");
                return;
            }

            //Проверка на введение завода
            if (!MainWindow.mainWindow.ItsOnlyFIO(tb_zavod_create.Text) || tb_zavod_create.Text == " ")
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


            string query = $"UPDATE MarkaAuto SET mark_name='{tb_name_mark.Text}',country_create='{tb_country_create.Text}',zavod_create='{tb_zavod_create.Text}',addres='{tb_addres.Text}' where kod_marki={marka.kod_marki}";
            Connection.Select(query);
            //Connection.Ubuntu(query);

            MessageBox.Show("Марка успешно добавлена!");

            MainWindow.mainWindow.LoadMark();
            MainWindow.mainWindow.frame.Navigate(new Pages.Marks());
        }

        private void Click_Reg_Exit(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.Main());
        }
    }
}
