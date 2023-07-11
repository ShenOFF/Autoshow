using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoShow.Classes
{
    public class Marka
    {
        public Marka()
        {
        }

        public Marka(int kod_marki, string marka_name, string country_create, string zavod_create,string addres)
        {
            this.kod_marki = kod_marki;
            this.marka_name = marka_name;
            this.country_create = country_create;
            this.zavod_create = zavod_create;
            this.addres = addres;
        }
        public int kod_marki { get; set; }
        public string marka_name { get; set; }
        public string country_create { get; set; }
        public string zavod_create { get; set; }
        public string addres { get; set; }
    }
}
