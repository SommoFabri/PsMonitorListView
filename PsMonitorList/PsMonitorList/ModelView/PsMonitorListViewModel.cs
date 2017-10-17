using PsMonitorList.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsMonitorList.ModelView
{
    class PsMonitorListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        List<RecordBean> lista = new List<RecordBean>();

    }
}
