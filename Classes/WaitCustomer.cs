using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoShow.Classes
{
    public class WaitCustomer
    {
        public WaitCustomer()
        {
        }

        public WaitCustomer(int kod_customer, string Sur_name, string Name, string Last_name, string passport_date, string addres, string City, int Years_old, string gender,string login_user)
        {
            this.kod_customer = kod_customer;
            this.Sur_name = Sur_name;
            this.Name = Name;
            this.Last_name = Last_name;
            this.passport_date = passport_date;
            this.addres = addres;
            this.City = City;
            this.Years_old = Years_old;
            this.gender = gender;
            this.login_user = login_user;
        }
        public int kod_customer { get; set; }
        public string Sur_name { get; set; }
        public string Name { get; set; }
        public string Last_name { get; set; }
        public string passport_date { get; set; }
        public string addres { get; set; }
        public string City { get; set; }
        public int Years_old { get; set; }
        public string gender { get; set; }
        public string login_user { get; set; }
    }
}
