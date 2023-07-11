using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace AutoShow
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Classes.Auto> autos = new List<Classes.Auto>();

        public List<Classes.Marka> marks = new List<Classes.Marka>();
        public List<Classes.Worker> workers = new List<Classes.Worker>();
        public List<Classes.Customer> customers = new List<Classes.Customer>();
        public List<Classes.SaleAuto> saleAutos = new List<Classes.SaleAuto>();
        public List<Classes.Waiting> waitings = new List<Classes.Waiting>();
        public List<Classes.WaitCustomer> waitCustomers = new List<Classes.WaitCustomer>();
        public static MainWindow mainWindow;
        public static Classes.Auto auto;
        public static Classes.Worker worker;
        public static Classes.Customer customer;
        //public string con = "server=10.0.130.74;Trusted_Connection=no;database=praktickuchin;user=danilk;PWD=danilk";
        //public string conUbuntu = "server=10.0.130.75;Trusted_Connection=no;database=praktickuchin;user=sa;PWD=Kuchin2004";
        public string con = "server=localhost;Trusted_Connection=yes;database=praktickuchin;user=danilk;PWD=danilk";
        //public string conUbuntu = "server=localhost;Trusted_Connection=yes;database=praktickuchin;user=danilk;PWD=danilk";
        //public string conUbuntu = "server=10.0.130.75;Trusted_Connection=no;database=praktickuchin;user=sa;PWD=Kuchin2004";
        public MainWindow()
        {
            InitializeComponent();
            Classes.data.role = "Admin";
            Classes.data.name = "danilk";
            try
            {

                SqlConnection sqlConnection = new SqlConnection(con);
                sqlConnection.Open();
                //SqlConnection sqlConnection1 = new SqlConnection(conUbuntu);
                //sqlConnection1.Open();
            }
            catch
            {
                if (MessageBox.Show("Ошибка подключения!!!", "Ошибка", MessageBoxButton.OK) == MessageBoxResult.OK)
                {
                    this.Close();
                    return;
                }
            }
            mainWindow = this;
            
            LoadAuto();
            LoadMark();
            LoadWorker();
            LoadCustomer();
            LoadSaleAuto();
            LoadWaiting();
            LoadWaitCustomer();
            frame.Navigate(new Pages.Login(this));
            //frame.Navigate(new Pages.Main());
        }
        public bool isOwner;
        public void LoadAuto()
        {
            autos.Clear();
            DataTable product_query = Connection.Select("SELECT * FROM Auto");
            for (int i = 0; i < product_query.Rows.Count; i++)
            {
                autos.Add(new Classes.Auto()
                {
                    kod_auto = Convert.ToInt32(product_query.Rows[i][0]),
                    auto_name = Convert.ToString(product_query.Rows[i][1]),
                    marka = Convert.ToString(product_query.Rows[i][2]),
                    year_create = Convert.ToInt32(product_query.Rows[i][3]),
                    color = Convert.ToString(product_query.Rows[i][4]),
                    category = Convert.ToString(product_query.Rows[i][5]),
                    price = Convert.ToInt32(product_query.Rows[i][6]),
                });

            }
        }

       

        public void LoadMark()
        {
            marks.Clear();
            DataTable product_query = Connection.Select("SELECT * FROM MarkaAuto");
            for (int i = 0; i < product_query.Rows.Count; i++)
            {
                marks.Add(new Classes.Marka()
                {
                    kod_marki = Convert.ToInt32(product_query.Rows[i][0]),
                    marka_name = Convert.ToString(product_query.Rows[i][1]),
                    country_create = Convert.ToString(product_query.Rows[i][2]),
                    zavod_create = Convert.ToString(product_query.Rows[i][3]),
                    addres = Convert.ToString(product_query.Rows[i][4]),
                });

            }
        }

        public void LoadWorker()
        {
            workers.Clear();
            DataTable product_query = Connection.Select("SELECT * FROM Worker");
            for (int i = 0; i < product_query.Rows.Count; i++)
            {
                workers.Add(new Classes.Worker()
                {
                    kod_worker = Convert.ToInt32(product_query.Rows[i][0]),
                    Sur_Name = Convert.ToString(product_query.Rows[i][1]),
                    Name = Convert.ToString(product_query.Rows[i][2]),
                    Last_Name = Convert.ToString(product_query.Rows[i][3]),
                    exp = Convert.ToInt32(product_query.Rows[i][4]),
                    zp = Convert.ToInt32(product_query.Rows[i][5]),
                });

            }
        }

        public void LoadCustomer()
        {
            customers.Clear();
            DataTable product_query = Connection.Select("SELECT * FROM Customer");
            for (int i = 0; i < product_query.Rows.Count; i++)
            {
                customers.Add(new Classes.Customer()
                {
                    kod_customer = Convert.ToInt32(product_query.Rows[i][0]),
                    Sur_name = Convert.ToString(product_query.Rows[i][1]),
                    Name = Convert.ToString(product_query.Rows[i][2]),
                    Last_name = Convert.ToString(product_query.Rows[i][3]),
                    passport_date = Convert.ToString(product_query.Rows[i][4]),
                    addres = Convert.ToString(product_query.Rows[i][5]),
                    City = Convert.ToString(product_query.Rows[i][6]),
                    Years_old = Convert.ToInt32(product_query.Rows[i][7]),
                    gender = Convert.ToString(product_query.Rows[i][8]),
                    login_user = Convert.ToString(product_query.Rows[i][9]),
                });

            }
        }

        public void LoadSaleAuto()
        {
            saleAutos.Clear();
            DataTable product_query = Connection.Select("SELECT * FROM SaleAuto");
            for (int i = 0; i < product_query.Rows.Count; i++)
            {
                saleAutos.Add(new Classes.SaleAuto()
                {
                    kod_sale = Convert.ToInt32(product_query.Rows[i][0]),
                    data = Convert.ToString(product_query.Rows[i][1]),
                    worker = Convert.ToInt32(product_query.Rows[i][2]),
                    auto = Convert.ToInt32(product_query.Rows[i][3]),
                    customer = Convert.ToInt32(product_query.Rows[i][4]),
                });

            }
        }

        public void LoadWaiting()
        {
            waitings.Clear();
            DataTable product_query = Connection.Select("SELECT * FROM Waiting");
            for (int i = 0; i < product_query.Rows.Count; i++)
            {
                waitings.Add(new Classes.Waiting()
                {
                    kod_wait = Convert.ToInt32(product_query.Rows[i][0]),
                    data = Convert.ToString(product_query.Rows[i][1]),
                    worker = Convert.ToString(product_query.Rows[i][2]),
                    auto = Convert.ToString(product_query.Rows[i][3]),
                    customer = Convert.ToString(product_query.Rows[i][4]),
                    login_user = Convert.ToString(product_query.Rows[i][5]),
                    status= Convert.ToString(product_query.Rows[i][6]),
                    hidden = Convert.ToString(product_query.Rows[i][7]),
                    id_customer= Convert.ToInt32(product_query.Rows[i][8]),
                    id_auto= Convert.ToInt32(product_query.Rows[i][9]),
                });

            }
        }

        public void LoadWaitCustomer()
        {
            waitCustomers.Clear();
            DataTable product_query = Connection.Select("SELECT * FROM WaitCustomer");
            for (int i = 0; i < product_query.Rows.Count; i++)
            {
                waitCustomers.Add(new Classes.WaitCustomer()
                {
                    kod_customer = Convert.ToInt32(product_query.Rows[i][0]),
                    Sur_name = Convert.ToString(product_query.Rows[i][1]),
                    Name = Convert.ToString(product_query.Rows[i][2]),
                    Last_name = Convert.ToString(product_query.Rows[i][3]),
                    passport_date = Convert.ToString(product_query.Rows[i][4]),
                    addres = Convert.ToString(product_query.Rows[i][5]),
                    City = Convert.ToString(product_query.Rows[i][6]),
                    Years_old = Convert.ToInt32(product_query.Rows[i][7]),
                    gender = Convert.ToString(product_query.Rows[i][8]),
                    login_user=Convert.ToString(product_query.Rows[i][9]),
                });

            }
        }

        //Проверка на номер
        public bool ItsNumber(string str)
        {

            bool isflag = false;
            string isnum = "1234567890";
            if (str != "")
            {
                string write = str.ToLower();
                for (int i = 0; i < write.Length; i++)
                {
                    isflag = false;
                    for (int j = 0; j < isnum.Length; j++)
                    {
                        if (write[i] == isnum[j])
                        {
                            isflag = true;
                        }
                    }
                }
            }
            return isflag;
        }
        //Проверка на ФИО
        public bool ItsOnlyFIO(string str)
        {
            bool isflag = false;
            string isfio = "яфйчыцсвумакипетрньогблшюдщжзэхъzaqxswcdevfrbgtnhymjukilop ";
            if (str != "")
            {
                string note = str.ToLower();
                for (int i = 0; i < note.Length; i++)
                {
                    isflag = false;
                    for (int j = 0; j < isfio.Length; j++)
                    {
                        if (note[i] == isfio[j])
                        {
                            isflag = true;
                        }
                    }
                }
            }
            return isflag;
        }

        public bool UserCheck(string login,string password)
        {
            try
            {
                SqlConnection connection = new SqlConnection($"server=10.0.130.74;Trusted_Connection=no;database=praktic;user={login};PWD={password}");
                connection.Open();
            }
            catch
            {
                return false;
            }
            return true;
        }

    }
}
