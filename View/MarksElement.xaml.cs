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

namespace AutoShow.View
{
    /// <summary>
    /// Логика взаимодействия для Marks.xaml
    /// </summary>
    public partial class MarksElement : UserControl
    {
        Classes.Marka marka;
        public MarksElement(Classes.Marka marka)
        {
            InitializeComponent();
            this.marka = marka;

            name_marka.Content = marka.marka_name;
            zavod.Content = marka.zavod_create;
            country.Content = marka.country_create;
            addreas.Content = marka.addres;

        }

        private void delete(object sender, MouseButtonEventArgs e)
        {
            string query = $"DELETE FROM MarkaAuto where kod_marki = {marka.kod_marki}";
            Connection.Select(query);
            //Connection.Ubuntu(query);
            MainWindow.mainWindow.LoadMark();
            MainWindow.mainWindow.frame.Navigate(new Pages.Marks());
        }

        private void change(object sender, MouseButtonEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Pages.ChangeMarks(marka));
        }
    }
}
