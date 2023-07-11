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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Click_Log_Page(object sender, RoutedEventArgs e)
        {
            //Проверка на введение марки
            if (tb_login.Text == " ")
            {
                MessageBox.Show("Вы не правильно написали логин.Перепроверьте!");
                return;
            }

            if(tb_password.Text == " ")
            {
                MessageBox.Show("Вы не правильно указали пароль.Перепроверьте!");
                return;
            }

            //Проверка на введение завода
            if (tb_password_repet.Text != tb_password.Text )
            {
                MessageBox.Show("Вы не правильно указали пароль в подтверждении.Перепроверьте!");
                return;
            }

            try
            {
                Connection.Select($"CREATE LOGIN [{tb_login.Text}] with PASSWORD = '{tb_password.Text}'");

                Connection.Select($"USE praktic if not exists (SELECT * FROM sys.database_principals where name = N'{tb_login.Text}') begin  create user[{tb_login.Text}] for login [{tb_login.Text}] exec sp_addrolemember N'db_datareader', N'{tb_login.Text}' exec sp_addrolemember N'db_datawriter', N'{tb_login.Text}' end; ");




                //Connection.Ubuntu($"CREATE LOGIN [{tb_login.Text}] with PASSWORD = '{tb_password.Text}'");
                //Connection.Ubuntu($"USE praktic if not exists (SELECT * FROM sys.database_principals where name = N'{tb_login.Text}') begin  create user[{tb_login.Text}] for login [{tb_login.Text}] exec sp_addrolemember N'db_datareader', N'{tb_login.Text}' exec sp_addrolemember N'db_datawriter', N'{tb_login.Text}' end; ");
                MessageBox.Show("Вы успешно зарегистрировались!");
                MainWindow.mainWindow.frame.Navigate(new Pages.Login(MainWindow.mainWindow));
            }
            catch
            {
                MessageBox.Show("Ошибка регистрации!");
                return;
            }
            
        }

        private void Click_Reg_Accept(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.Login(MainWindow.mainWindow));
        }
    }
}
