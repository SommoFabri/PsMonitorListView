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
    class DataPresaInCaricoComparator : IComparer<RecordBean>
    {
        public int Compare(RecordBean o1, RecordBean o2)
        {
            DateTime dataPresaInCarico1;
            DateTime dataPresaInCarico2;
            int returnValue = -1;
            try
            {
                dataPresaInCarico1 = DateTime.ParseExact(o1.dataaccettazione + " " + o1.oraaccettazione + ":00", "dd-MM-yyyy HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture);
                dataPresaInCarico2 = DateTime.ParseExact(o2.dataaccettazione + " " + o2.oraaccettazione + ":00", "dd-MM-yyyy HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture);
                returnValue = dataPresaInCarico2.CompareTo(dataPresaInCarico1);
            }
            catch (Exception e)
            {
                returnValue = 0;
            }
            return returnValue;
        }
    }
}
