using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoShow.Classes
{
    public class Worker
    {
        public Worker()
        {
        }

        public Worker(int kod_worker, string Sur_Name, string Name, string Last_Name, int exp, int zp)
        {
            this.kod_worker = kod_worker;
            this.Sur_Name = Sur_Name;
            this.Name = Name;
            this.Last_Name = Last_Name;
            this.exp = exp;
            this.zp = zp;
        }
        public int kod_worker { get; set; }
        public string Sur_Name { get; set; }
        public string Name { get; set; }
        public string Last_Name { get; set; }
        public int exp { get; set; }
        public int zp { get; set; }
    }
}
