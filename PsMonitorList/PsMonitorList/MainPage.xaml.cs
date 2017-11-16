using PsMonitorList.Costants;
using PsMonitorList.Model;
using PsMonitorList.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PsMonitorList.ServiceComparator;

namespace PsMonitorList
{
    public partial class MainPage : ContentPage
    {
        public List<Grid> MainPageGrid = new List<Grid>();

        public MainPage()
        {
            InitializeComponent();
            riempimento();

        }
        public async void riempimento()
        {
            
            int SlidePosition = 0;
        List<RecordBean> lista = await RisultatoConnessione();
            if(lista!=null)
            {
                CaricamentoPagina.IsVisible = false;
                CaricamentoPagina.IsRunning = false;
                List<RecordBean> prova = new List<RecordBean>();
                ElencoPasientiBO p = new ElencoPasientiBO();
                ElencoPasientiMedia media = new ElencoPasientiMedia();

                Colori colori = new Colori();
                foreach (var i in lista)
                {
                    var a = p.addBean(i);
                    prova.Add(a);
                }
                prova = p.getListaAssistitiDaVisualizzare(prova);
                lista = media.ListaConMedia(prova, lista);
                CreazioneGriglia crea = new CreazioneGriglia();
                MainPageGrid = await crea.creazioneGriglia(lista);
                Carousel.ItemsSource = MainPageGrid;
                Carousel.ItemTemplate = GetDataTemplate();
                Carousel.IsEnabled = false;


                Device.StartTimer(TimeSpan.FromSeconds(15), () =>
                {
                    SlidePosition++;
                    if (SlidePosition == MainPageGrid.Count)
                    {
                        SlidePosition = 0;
                        Carousel.Position = SlidePosition;
                        riempimento();
                        return false;
                    }

                    Carousel.Position = SlidePosition;
                    return true;
                });
            }
            else
            {
                Device.StartTimer(TimeSpan.FromSeconds(15), () =>
                {
                        riempimento();
                    CaricamentoPagina.IsRunning = true;
                    CaricamentoPagina.IsVisible = true;
                        return false;
                  
                });
            }
       
       
        }
        
        public DataTemplate GetDataTemplate()
        {
            int count = 0;
            return new DataTemplate(() =>
            {
                Grid g = MainPageGrid[count];
                count++;
                return g;
            });
        }
        async  Task<List<RecordBean>> RisultatoConnessione()
        {
            List<RecordBean> listaUno = new List<RecordBean>();
            List<RecordBean> listaDue = new List<RecordBean>();
            try
            {
                Connessioni<RecordBean> connessioni = new Connessioni<RecordBean>();
                URL urllone = new URL();
                string URL = urllone.creastringa();
                listaUno = await connessioni.GetJson(URL);
            }
            catch (Exception e)
            {

                listaUno = null;
                
            }

           
            return listaUno;

        }

     

    }
}
