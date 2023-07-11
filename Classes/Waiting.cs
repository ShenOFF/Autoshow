using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoShow.Classes
{
    public class Waiting
    {
        public Waiting()
        {
        }

        public Waiting(int kod_wait, string data, string worker, string auto, string customer,string login_user, string status, string hidden,int id_customer,int id_auto)
        {
            this.kod_wait = kod_wait;
            this.data = data;
            this.worker = worker;
            this.auto = auto;
            this.customer = customer;
            this.login_user = login_user;
            this.status = status;
            this.hidden = hidden;
            this.id_customer = id_customer;
            this.id_auto = id_auto;
        }
        public int kod_wait { get; set; }
        public string data { get; set; }
        public string worker { get; set; }
        public string auto { get; set; }
        public string customer { get; set; }
        public string login_user { get; set; }
        public string status { get; set; }
        public string hidden { get; set; }
        public int id_customer { get; set; }
        public int id_auto { get; set; }
    }
}
