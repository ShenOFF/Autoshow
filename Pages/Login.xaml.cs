using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        Classes.Auto auto;
        MainWindow mainWindow;
        public Login(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {

            MainWindow.mainWindow.frame.Navigate(new Pages.Main());
            //var login = tb_login.Text;
            //var password = tb_password.Password;
            //if (MainWindow.mainWindow.UserCheck(tb_login.Text, tb_password.Password))
            //{
            //    SqlConnection connection = new SqlConnection($"server=10.0.130.74;Trusted_Connection=no;database=praktic;user={login};PWD={password}");
            //    connection.Open();
            //    SqlCommand sqlCommand = connection.CreateCommand();
            //    sqlCommand.CommandText = "select IS_SRVROLEMEMBER ('owner')";
            //    SqlDataReader reader = sqlCommand.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        if (reader[0].ToString() == "1")
            //        {
            //            Classes.data.name = Convert.ToString(login);
            //            Classes.data.role = "Admin";
            //            MainWindow.mainWindow.frame.Navigate(new Pages.Main());
            //            return;
            //        }
            //        if (reader[0].ToString() == null)
            //        {
            //            Classes.data.name = Convert.ToString(login);
            //            Classes.data.role = "User";
            //            MainWindow.mainWindow.frame.Navigate(new Pages.Main()); ;
            //        }
            //    }
            //    reader.Close();
            //    sqlCommand.CommandText = "select IS_SRVROLEMEMBER ('reader')";
            //    reader = sqlCommand.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        if (reader[0].ToString() == "1")
            //        {
            //            Classes.data.name = Convert.ToString(login);
            //            Classes.data.role = "Reader";
            //            MainWindow.mainWindow.frame.Navigate(new Pages.Main());
            //        }
            //        else
            //        {
            //            Classes.data.name = Convert.ToString(login);
            //            Classes.data.role = "User";
            //            MainWindow.mainWindow.frame.Navigate(new Pages.Main());
            //        }
            //    }

            //}
            //else
            //{
            //    MessageBox.Show("Логин или пароль введен не правильно!!!");
            //}

            //var login = tb_login.Text;
            //var password = tb_password.Password;
            //SqlConnection connection = new SqlConnection($"server=10.0.130.74;Trusted_Connection=no;database=praktic;user={login};PWD={password}");
            ////SqlConnection connection = new SqlConnection($"server=localhost;Trusted_Connection=yes;database=autoshowkuchin11;user={login};PWD={password}");
            //try
            //{
            //    connection.Open();
            //    //mainWindow.con = $"server=localhost;Trusted_Connection=yes;database=autoshowkuchin11;user={login};PWD={password}";
            //    mainWindow.con = $"server=10.0.130.74;Trusted_Connection=no;database=praktic;user={login};PWD={password}";
            //    Classes.data.name = Convert.ToString(login);
            //    IsOwner(connection);
            //    if (MainWindow.mainWindow.isOwner)
            //    {
            //        MessageBox.Show("Вы зашли под администратором!");
            //        MainWindow.mainWindow.frame.Navigate(new Pages.Main());
            //    }

            //    else
            //        MessageBox.Show("Вы зашли под пользователем!");
            //        MainWindow.mainWindow.frame.Navigate(new Pages.Main());
            //    connection.Close();
            //}
            //catch
            //{
            //    MessageBox.Show("Авторизаци не удалась!");
            //    connection.Close();
            //}
            //finish
            //SqlCommand myCMD = new SqlCommand("Select IS_SRVROLEMEMBER ('admin')");
            //SqlDataReader myReader = myCMD.ExecuteReader();
            //while (myReader.Read())
            //{
            //    if (myReader[0].ToString()== "1")
            //    {
            //        DataTable table = new DataTable();

            //        string query = $"SELECT id_user,name_user,password_user FROM Users where name_user='{login}' and password_user='{password}'";
            //        table = Connection.Select(query);



            //        if (table.Rows.Count == 1)
            //        {
            //            //Classes.data.role = Convert.ToString(table.Rows[0][3]);
            //            //Classes.data.id = Convert.ToInt32(table.Rows[0][0]);
            //            MessageBox.Show("Вы успешно вошли!", "Успешно!", MessageBoxButton.OK);

            //            //mainWindow.OpenPage(new Pages.main(mainWindow, products, baskets, item));
            //            mainWindow.frame.Navigate(new Pages.Main());
            //        }
            //        else
            //        {
            //            MessageBox.Show("Такого аккаунта нету!", "Аккайунт не найден!", MessageBoxButton.OK);
            //        }
            //    }
        }

        //var reader = Connection.Select("Select IS_SRVROLEMEMBER ('admin')");

        //while ()
        //{

        //}



        public void IsOwner(SqlConnection connection)
        {
            DataTable dataTable = new DataTable("dataBase");
            SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "if is_rolemember('db_owner') = 1 begin select 1 end";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);
            try
            {
                if (Convert.ToInt32(dataTable.Rows[0][0]) == 1)
                    MainWindow.mainWindow.isOwner = true;
            }
            catch
            {
                MainWindow.mainWindow.isOwner = false;
            }
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.Registration());
        }
    }


}
