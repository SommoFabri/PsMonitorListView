using PsMonitorList.Costants;
using PsMonitorList.Model;
using PsMonitorList.ServiceComparator;
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
        public List<Grid> MainPageGrid = new List<Grid>();


        List<RecordBean> lista = new List<RecordBean>();
        public MainPage()
        {
            InitializeComponent();
            riempimento();
        }
        public async void riempimento()
        {
            int SlidePosition=0;
            List<RecordBean> lista = await RisultatoConnessione();
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
            lista = media.ListaConMedia(prova);


            //CarouselView carousel = new CarouselView();
            /*CreazioneGriglia.CreaGriglia(GrigliaNominativi, lista);*/
            CreazioneGriglia crea = new CreazioneGriglia();
            MainPageGrid = await crea.CreaGriglia(GrigliaNominativi, lista);
            Carousel.ItemsSource = MainPageGrid;
            Carousel.ItemTemplate = GetDataTemplate();
            //Content= carousel;
            Device.StartTimer(TimeSpan.FromSeconds(20), () =>
            {
                SlidePosition++;
                if (SlidePosition == MainPageGrid.Count) SlidePosition = 0;
                Carousel.Position = SlidePosition;
                return true;
            });


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
        async static Task<List<RecordBean>> RisultatoConnessione()
        {

            Connessioni<RecordBean> connessioni = new Connessioni<RecordBean>();
            URL urllone = new URL();
            string URL = urllone.creastringa();
            var listaUno = await connessioni.GetJson(URL);
            return listaUno;

        }

        /*
        public AutoSlide()
        {
            imageList = new List<Image>();
            imageList.Add(new Image { Source = ImageSource.FromResource("AutoSlider.Images.1024x1024[1].png") });
            imageList.Add(new Image { Source = ImageSource.FromResource("AutoSlider.Images.1024x1024[1].png") });
            imageList.Add(new Image { Source = ImageSource.FromResource("AutoSlider.Images.1024x1024[1].png") });

            CarouselView cv = new CarouselView { ItemsSource = imageList, ItemTemplate = GetDataTemplate() };

            Content = cv;

            Device.StartTimer(TimeSpan.FromSeconds(2), () =>
            {
                SlidePosition++;
                if (SlidePosition == imageList.Count) SlidePosition = 0;
                cv.Position = SlidePosition;
                return true;
            });

        }

        public DataTemplate GetDataTemplate()
        {
            return new DataTemplate(() =>
            {
                Image v = imageList[Count];
                Count++;
                return v;
            });
        }
        */


    }
}
