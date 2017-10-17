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
        public async void riempimento()
        {
            List<RecordBean> lista = await RisultatoConnessione();
            CreazioneGriglia.CreaGriglia(GrigliaNominativi,lista);

        }
        private async static Task<List<RecordBean>> RisultatoConnessione()
        {

            Connessioni<RecordBean> connessioni = new Connessioni<RecordBean>();

            var listaUno = await connessioni.GetJson(URL.URLConnessione);
            return listaUno;

        }
    }
}
