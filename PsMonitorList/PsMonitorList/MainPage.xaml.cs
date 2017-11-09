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
            List<RecordBean> prova=new List<RecordBean>();
            ElencoPasientiBO p = new ElencoPasientiBO();
            foreach(var i in lista)
            {
                var a = p.addBean(i);
                prova.Add(a);
            }
            prova = p.getListaAssistitiDaVisualizzare(prova);
            
        }
        private async static Task<List<RecordBean>> RisultatoConnessione()
        {

            Connessioni<RecordBean> connessioni = new Connessioni<RecordBean>();
            URL urllone = new URL();
            string URL = urllone.creastringa();
            var listaUno = await connessioni.GetJson(URL);
            return listaUno;

        }
    }
}
