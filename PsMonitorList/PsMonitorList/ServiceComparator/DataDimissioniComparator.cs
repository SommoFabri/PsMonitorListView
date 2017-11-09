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
    class DataDimissioniComparator : IComparer<RecordBean>
    {
        public int Compare(RecordBean o1, RecordBean o2)
        {
            DateTime dataDimissioni1;
            DateTime dataDimissioni2;
            try
            {
                dataDimissioni1 = DateTime.ParseExact(o1.dataaccettazione + " " + o1.oraaccettazione + ":00", "dd-MM-yyyy HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture);
                dataDimissioni2 = DateTime.ParseExact(o2.dataaccettazione + " " + o2.oraaccettazione + ":00", "dd-MM-yyyy HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture);
            }
            catch (Exception e)
            {
                dataDimissioni1 = new DateTime();
                dataDimissioni2 = new DateTime();
            }
            int returnValue = dataDimissioni2.CompareTo(dataDimissioni1);
            //        System.out.println(dataAccettazione1);
            //        System.out.println(dataAccettazione2);
            //        System.out.println(returnValue);
            return returnValue;
        }
    }
}
