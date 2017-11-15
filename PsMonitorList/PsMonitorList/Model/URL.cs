using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsMonitorList.Model
{
    public class URL
    {
        
       // public static string URLConnessione = "http://192.168.160.24:3004/whaccettatips?dataingresso=2017-07-20&oraingresso=10:00";
        public string  creastringa()
        {
            DateTime c = DateTime.Today;
            c = c.AddDays(-1);

            string ora = "23:59";

            string day = c.Day.ToString();

            string month = c.Month.ToString();

            string anno = c.Year.ToString();

            string URLConnessione= "http://192.168.160.24:3004/whaccettatips?dataingresso=" + anno + "-" + month + "-" + day +"&oraingresso=" + ora;
            return URLConnessione;
        }
    }
}
