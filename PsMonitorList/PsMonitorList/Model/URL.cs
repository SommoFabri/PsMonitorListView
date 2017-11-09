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
            DateTime c = DateTime.Now;
           // c=c.AddDays();
            string s = c.Day.ToString();
            string URLConnessione= "http://192.168.160.24:3004/whaccettatips?dataingresso=2017-11-0" + s +"&oraingresso=01:59:59";
            return URLConnessione;

        }
    }
}
