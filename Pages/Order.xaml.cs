using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace AutoShow.Pages
{
    /// <summary>
    /// Логика взаимодействия для Order.xaml
    /// </summary>
    public partial class Order : Page
    {
        public int kod_customer;
        Classes.Auto auto;
        public Order(Classes.Auto auto)
        {
            InitializeComponent();
            this.auto = auto;
            LoadCBCustomer();
            
            auto_buy.Content = auto.auto_name;
            data_buy.Content = System.DateTime.Now.ToShortDateString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Сейчас вам нужно заполнить поля данныемыЮполсе чаго ваша заявка на покупку машины будет отправленна работнику автосалона. После рассмотрения будет принято решение о продаже автомобиля. Для понимания одобрили заявку или нет смотрите странцу заказа,если там ничего нет, то завка отклонена. Заявка рассматривается в течении 1 рабочего дня. Удачного дня!");
        }

        private void Click_Reg_Exit(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.Main());
        }
        public string kod_cust;
        private void Click_Main_Accept(object sender, RoutedEventArgs e)
        {
            ////Проверка на введение марки
            //if (!MainWindow.mainWindow.ItsOnlyFIO(tb_sur_name.Text) || tb_sur_name.Text == " ")
            //{
            //    MessageBox.Show("Вы не правильно написали фамилию.Перепроверьте!");
            //    return;
            //}

            ////Проверка на введение страны
            //if (!MainWindow.mainWindow.ItsOnlyFIO(tb_name.Text) || tb_name.Text == " ")
            //{
            //    MessageBox.Show("Вы не правильно указали имя.Перепроверьте!");
            //    return;
            //}

            ////Проверка на введение завода
            //if (!MainWindow.mainWindow.ItsOnlyFIO(tb_Last_name.Text) || tb_Last_name.Text == " ")
            //{
            //    MessageBox.Show("Вы не правильно указали отчество.Перепроверьте!");
            //    return;
            //}

            ////Проверка на введение адреса
            //if (tb_addres.Text == " ")
            //{
            //    MessageBox.Show("Вы не правильно указали адрес.Перепроверьте!");
            //    return;
            //}

            ////Проверка на введение адреса
            //if (!MainWindow.mainWindow.ItsOnlyFIO(tb_city.Text) || tb_city.Text == " ")
            //{
            //    MessageBox.Show("Вы не правильно указали город.Перепроверьте!");
            //    return;
            //}

            ////Проверка на введение адреса
            //if (!MainWindow.mainWindow.ItsNumber(tb_years_old.Text) || tb_years_old.Text == " " || tb_years_old.Text.Length != 2)
            //{
            //    MessageBox.Show("Вы не правильно указали год рождения.Перепроверьте!");
            //    return;
            //}

            ////Проверка на введение адреса
            //if (tb_gender.Text == " " /*|| tb_gender.Text!="M" || tb_gender.Text!="Ж"*/)
            //{
            //    MessageBox.Show("Вы не правильно указали пол.Перепроверьте!");
            //    return;
            //}

            ////запрос на добавление клиента(покупателя-Customer)
            //string query_customer = $"INSERT INTO Customer(Sur_name,Name,Last_name,passport_date,addres,City,Years_old,gender) values('{tb_sur_name.Text}','{tb_name.Text}','{tb_Last_name.Text}','{tb_passport.Text}','{tb_addres.Text}','{tb_city.Text}','{tb_years_old.Text}','{tb_gender.Text}')";
            //Connection.Select(query_customer);
            //MainWindow.mainWindow.LoadCustomer();

            //DataTable kod_c = Connection.Select($"SELECT kod_customer FROM Customer where passport_date={}");
            //for (int i = 0; i < kod_c.Rows.Count; i++)
            //{
            //    kod_cust = Convert.ToString(kod_c.Rows[i][0]);
            //}
            //string insert_kod_customer = kod_cust;


            
            //запрос на добаление заказа в waiting(ожидание одобрения от работника(адмнина))
            kod_customer = MainWindow.mainWindow.customers[cb_customer_buy.SelectedIndex].kod_customer;
            string query_wait = $"INSERT INTO Waiting(data,auto,customer,login_user,hidden,id_customer,id_auto) values('{data_buy.Content}','{auto.auto_name}','{cb_customer_buy.Text.Substring(0)}','{Classes.data.name}','1','{kod_customer}','{auto.kod_auto}')";
            
            Connection.Select(query_wait);
            //Connection.Ubuntu(query_wait);
            MessageBox.Show("Ваша заявка отправленная на одобрение администратора!");
            MainWindow.mainWindow.LoadWaiting();

        }
        public void LoadCBCustomer()
        {
            DataTable hotel_query = Connection.Select("SELECT * FROM Customer");
            for (int i = 0; i < hotel_query.Rows.Count; i++)
            {
                string customer_id = Convert.ToString(hotel_query.Rows[i][1]+" " + Convert.ToString(hotel_query.Rows[i][2]) + " " + Convert.ToString(hotel_query.Rows[i][3])+ "," + Convert.ToString(hotel_query.Rows[i][6]) + "," + Convert.ToString(hotel_query.Rows[i][5]));


                cb_customer_buy.Items.Add(customer_id);
                
            }
            
        }
    }
}
