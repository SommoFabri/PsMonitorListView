using PsMonitorList.Model;
using PsMonitorList.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PsMonitorList
{
    public partial class MainPage : ContentPage
    {
        List<RecordBean> lista = new List<RecordBean>();
        public MainPage()
        {
            InitializeComponent();
            riempimento();


        }
        public  void riempimento()
        {
            CreazioneGriglia.CreaGriglia(GrigliaNominativi);

        }
    }
}
