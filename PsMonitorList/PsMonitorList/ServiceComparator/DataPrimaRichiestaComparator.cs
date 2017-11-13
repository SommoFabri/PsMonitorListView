using PsMonitorList.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using PsMonitorList.Model;
using System.Collections;

namespace PsMonitorList.ServiceComparator
{
    class DataPrimaRichiestaComparator : IComparer<RecordBean>
    {
        public int Compare(RecordBean o1, RecordBean o2)
        {
            DateTime dataPrimaRichiesta1;
            DateTime dataPrimaRichiesta2;
            try
            {
                dataPrimaRichiesta1 = DateTime.ParseExact(o1.dataaccettazione + " " + o1.oraaccettazione + ":00", "dd-MM-yyyy HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture);
                dataPrimaRichiesta2 = DateTime.ParseExact(o2.dataaccettazione + " " + o2.oraaccettazione + ":00", "dd-MM-yyyy HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture);
            }
            catch (Exception e)
            {
                dataPrimaRichiesta1 = new DateTime();
                dataPrimaRichiesta2 = new DateTime();
            }
            int returnValue = dataPrimaRichiesta2.CompareTo(dataPrimaRichiesta1);
            //        System.out.println(dataAccettazione1);
            //        System.out.println(dataAccettazione2);
            //        System.out.println(returnValue);
            return returnValue;
        }
    }
}
