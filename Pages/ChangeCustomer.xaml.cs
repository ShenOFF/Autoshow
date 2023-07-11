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
using System.Xml.Linq;

namespace AutoShow.Pages
{
    /// <summary>
    /// Логика взаимодействия для ChangeCustomer.xaml
    /// </summary>
    public partial class ChangeCustomer : Page
    {
        
        Classes.Customer customer;


        public ChangeCustomer(Classes.Customer customer)
        {
            InitializeComponent();
            this.customer = customer;
            tb_addres.Text = customer.addres;
            tb_sur_name.Text = customer.Sur_name;
            tb_name.Text = customer.Name;
            tb_Last_name.Text = customer.Last_name;
            tb_passport.Text = customer.passport_date;
            tb_city.Text = customer.City;
            tb_gender.Text = customer.gender;
            tb_years_old.Text = customer.Years_old.ToString();

        }

        private void Click_Reg_Exit(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.Customer());
        }

        private void Click_Main_Accept(object sender, RoutedEventArgs e)
        {
            //Проверка на введение марки
            if (!MainWindow.mainWindow.ItsOnlyFIO(tb_sur_name.Text) || tb_sur_name.Text == " ")
            {
                MessageBox.Show("Вы не правильно написали фамилию.Перепроверьте!");
                return;
            }

            //Проверка на введение страны
            if (!MainWindow.mainWindow.ItsOnlyFIO(tb_name.Text) || tb_name.Text == " ")
            {
                MessageBox.Show("Вы не правильно указали имя.Перепроверьте!");
                return;
            }

            //Проверка на введение завода
            if (!MainWindow.mainWindow.ItsOnlyFIO(tb_Last_name.Text) || tb_Last_name.Text == " ")
            {
                MessageBox.Show("Вы не правильно указали отчество.Перепроверьте!");
                return;
            }

            //if (MainWindow.mainWindow.ItsNumber(tb_passport.Text))
            //{
            //string[] mas2 = tb_passport.Text.Split('-');
            //if (mas2.Length == 3)
            //{
            //    if (mas2[0].Length == mas2[1].Length & mas2[0].Length == 2 & Int32.TryParse(mas2[0], out _) & mas2[2].Length == 6 & Int32.TryParse(mas2[2], out _))
            //    {

            //    }
            //    else
            //    {
            //        MessageBox.Show("Пасспор введен не правильно!");
            //        return;
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Пасспорт введен не верно)");
            //    return;
            //}

            //}
            //else
            //{
            //    MessageBox.Show("Ошибка ввода!");
            //}

            string[] check = tb_passport.Text.Split('-');
            if (check[0] == null || check[0].Length != 2)
            {
                MessageBox.Show("Ошибка в первых двух цыфрах!");
                return;
            }
            try
            {
                if (check[1] == null || check[1].Length != 2)
                {
                    MessageBox.Show("Ошибка во вторых двух цыфрах!");
                    return;
                }
                if (check[2] == null || check[2].Length != 6)
                {
                    MessageBox.Show("Ошибка в третьей части пасспорта!");
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Установите дефис!");
                return;
            }
            for (int i = 0; i < tb_passport.Text.Length; i++)
            {
                if (!MainWindow.mainWindow.ItsNumber(tb_passport.Text) || tb_passport.Text == " ")
                {
                    MessageBox.Show("Указанно вами ФИО содержит цифры.Перепроверьте!");
                    return;
                }
            }

            //Проверка на введение адреса
            if (tb_addres.Text == " ")
            {
                MessageBox.Show("Вы не правильно указали адрес.Перепроверьте!");
                return;
            }

            //Проверка на введение адреса
            if (!MainWindow.mainWindow.ItsOnlyFIO(tb_city.Text) || tb_city.Text == " ")
            {
                MessageBox.Show("Вы не правильно указали город.Перепроверьте!");
                return;
            }

            //Проверка на введение адреса
            if (!MainWindow.mainWindow.ItsNumber(tb_years_old.Text) || tb_years_old.Text == " " || tb_years_old.Text.Length != 2)
            {
                MessageBox.Show("Вы не правильно указали год рождения.Перепроверьте!");
                return;
            }

            //Проверка на введение адреса
            if (tb_gender.Text == " " /*|| tb_gender.Text!="M" || tb_gender.Text!="Ж"*/)
            {
                MessageBox.Show("Вы не правильно указали пол.Перепроверьте!");
                return;
            }

            string query = $"UPDATE Customer SET Sur_name='{tb_sur_name.Text}',Name='{tb_name.Text}',Last_name='{tb_Last_name.Text}',passport_date='{tb_passport.Text}',addres='{tb_addres.Text}',City='{tb_city.Text}',Years_old='{tb_years_old.Text}',gender='{tb_gender.Text}' where kod_customer={customer.kod_customer}";
            Connection.Select(query);
            //Connection.Ubuntu(query);

            MessageBox.Show("Вы успешно изменили покупателя!");
            MainWindow.mainWindow.LoadCustomer();
            MainWindow.mainWindow.frame.Navigate(new Pages.Customer());
        }
    }
}
