using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoShow.Classes
{
    public class Auto
    {
        public Auto()
        {
        }

        public Auto(int kod_auto, string auto_name, string marka,int year_create, string color, string category, int price)
        {
            this.kod_auto = kod_auto;
            this.auto_name = auto_name;
            this.marka = marka;
            this.year_create = year_create;
            this.color = color;
            this.category = category;
            this.price = price;
        }
        public int kod_auto { get; set; }
        public string auto_name { get; set; }
        public string marka { get; set; }
        public int year_create { get; set; }
        public string color { get; set; }
        public string category { get; set; }
        public int price { get; set; }

    }
}
