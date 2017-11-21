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
        Colori colori = new Colori();
        ElencoPasientiMedia media = new ElencoPasientiMedia();
        ElencoPasientiBO MetodoElencoBO = new ElencoPasientiBO();
        CreazioneGriglia crea = new CreazioneGriglia();

        public  List<Grid> MainPageGrid = new List<Grid>();
        public List<RecordBean> lista = new List<RecordBean>();
        public int Flag = 0;
        private int count = 0;

        public MainPage()
        {
            InitializeComponent();
            riempimento();

        }

        public async void riempimento()
        {
            lista = null;
            lista= await RisultatoConnessione();
            
            if (lista != null)
            {
                List<RecordBean> listaTemp = new List<RecordBean>();
                foreach (var i in lista)
                {
                    var appoggio = MetodoElencoBO.addBean(i);
                    listaTemp.Add(appoggio);
                }
                listaTemp = MetodoElencoBO.getListaAssistitiDaVisualizzare(listaTemp);
                lista = media.ListaConMedia(listaTemp, lista);
                if(Flag == 0)
                visualizza();
            }
            else
            {
                    CaricamentoPagina.IsRunning = true;
                    CaricamentoPagina.IsVisible = true;
                    riempimento();  
            }
        }



        public async void visualizza()
        {
            Flag = 1;
            int time = 15;
            Boolean flagPage = false;
            int SlidePosition;

            if (lista!=null)
            {
                SlidePosition = 0;
                CaricamentoPagina.IsVisible = false;
                CaricamentoPagina.IsRunning = false;

                MainPageGrid = null;
                Carousel.ItemsSource = null;
                MainPageGrid = await crea.creazioneGriglia(lista);
                Carousel.ItemsSource = MainPageGrid;
                Carousel.ItemTemplate = GetDataTemplate();
                Carousel.IsEnabled = false;


                Device.StartTimer(TimeSpan.FromSeconds(time), () =>
                {
                    SlidePosition++;
                    if (SlidePosition == count - 1)
                    {
                        flagPage = true;
                        riempimento();
                        time = 20;
                    }
                    if (SlidePosition == count || count==0)
                    {
                        if (count == 0 && flagPage==false)
                        {
                            SlidePosition = 0;
                            flagPage = true;
                            riempimento();
                            time = 20;
                        }
                        else
                        {
                            SlidePosition = 0;
                            Carousel.Position = SlidePosition;
                            visualizza();
                            return false;
                        }

                    }
                    
                    Carousel.Position = SlidePosition;
                    return true;
                });
            }
            else
            {
                Flag = 0;
                if (Carousel.Position != count || count==0)
                    Carousel.Position++;
                else Carousel.Position = 0;

                riempimento();
            }
            
       
       
        }
        
        public DataTemplate GetDataTemplate()
        {
            count = 0;
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
