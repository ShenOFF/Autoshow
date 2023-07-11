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
    /// Логика взаимодействия для AddCustomer.xaml
    /// </summary>
    public partial class AddCustomer : Page
    {
        
        public AddCustomer()
        {
            InitializeComponent();
            if (Classes.data.role=="User")
            {
                btn_cancel.Visibility = Visibility.Hidden;
                tb_login.Visibility=Visibility.Hidden;
                lb_login.Visibility=Visibility.Hidden;
            }
            if (Classes.data.role == "Admin")
            {
                btn_accept_user.Visibility = Visibility.Hidden;
            }
        }

        private void Click_Reg_Exit(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.Main());
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
            if (tb_gender.SelectedItem==null )
            {
                MessageBox.Show("Вы не правильно указали пол.Перепроверьте!");
                return;
            }
            //else if(tb_gender.Text!="М" || tb_gender.Text != "Ж")
            //{
            //    MessageBox.Show("Пол должен выглядит так, М или Ж!");
            //    return ;
            //}


            for (int i = 0; i < MainWindow.mainWindow.customers.Count; i++)
            {
                var cus = MainWindow.mainWindow.customers[i];
                if (tb_name.Text == cus.Name && tb_passport.Text == cus.passport_date)
                {
                    MessageBox.Show("Введенные данные уже существуют в БД!");
                    return;
                }
            }
        

            string query = $"INSERT INTO Customer(Sur_name,Name,Last_name,passport_date,addres,City,Years_old,gender,login_user) values('{tb_sur_name.Text}','{tb_name.Text}','{tb_Last_name.Text}','{tb_passport.Text}','{tb_addres.Text}','{tb_city.Text}','{tb_years_old.Text}','{tb_gender.Text}','{tb_login.Text}')";
            Connection.Select(query);
            //Connection.Ubuntu(query);

            MessageBox.Show("Вы успешно добавили покупателя!");
            MainWindow.mainWindow.LoadCustomer();
            MainWindow.mainWindow.frame.Navigate(new Pages.Customer());
        }

        private void Click_Main_Accept_user(object sender, RoutedEventArgs e)
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
            if (tb_gender.SelectedItem == null /*|| tb_gender.Text!="M" || tb_gender.Text!="Ж"*/)
            {
                MessageBox.Show("Вы не правильно указали пол.Перепроверьте!");
                return;
            }
            


            for(int i = 0; i < MainWindow.mainWindow.customers.Count; i++)
            {
                var cus = MainWindow.mainWindow.customers[i];
                if (tb_name.Text == cus.Name && tb_passport.Text == cus.passport_date)
                {
                    MessageBox.Show("Введенные данные уже существуют в БД!");
                    return;
                }
            }


            string query = $"INSERT INTO WaitCustomer(Sur_name,Name,Last_name,passport_date,addres,City,Years_old,gender,login_user) values('{tb_sur_name.Text}','{tb_name.Text}','{tb_Last_name.Text}','{tb_passport.Text}','{tb_addres.Text}','{tb_city.Text}','{tb_years_old.Text}','{tb_gender.Text}','{Classes.data.name}')";
            Connection.Select(query);
            //Connection.Ubuntu(query);

            MessageBox.Show("Вы успешно отправили заявку на добавление,ожидайте!");
            MainWindow.mainWindow.LoadWaitCustomer();
            MainWindow.mainWindow.frame.Navigate(new Pages.Customer());
        }
    }
}
