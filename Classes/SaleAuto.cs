using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoShow.Classes
{
    public class SaleAuto
    {

        public SaleAuto()
        {
        }

        public SaleAuto(int kod_sale, string data, int worker,int auto,int customer)
        {
            this.kod_sale = kod_sale;
            this.data = data;
            this.worker = worker;
            this.auto = auto;
            this.customer = customer;
        }
        public int kod_sale { get; set; }
        public string data { get; set; }
        public int worker { get; set; }
        public int auto { get; set; }
        public int customer { get; set; }

    }
}
