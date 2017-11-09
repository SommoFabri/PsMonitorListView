using PsMonitorList.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PsMonitorList.Services
{
    class CreazioneGriglia
    {
        public  List<Grid> listaProva = new List<Grid>();
        public async Task<List<Grid>> CreaGriglia(Grid grigliaPrincipale,List<RecordBean> lista)
        {
            int riga = 0, colonna = 0;
           
            grigliaPrincipale.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            grigliaPrincipale.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });

            Grid grigliaCodiciNominativi = await CreazioneGrigliaCodiceNominativi.GrigliaCodiceNominativi(lista);
            Grid grigliaNominativi = await CreazioneGrigliaNominativi.GrigliaNominativi(lista);

            var lblNominativi = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                Text = "Nominativi"
            };
            var lblNominativi1 = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                Text = "Stato"
            };
            var lblNominativi2 = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                Text = "Ingresso"
            };
            var lblNominativi3 = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                Text = "In visita"
            };
            var lblNominativi4 = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                Text = "Attesa referti"
            };
            var lblNominativi5 = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                Text = "Attesa Dim."
            };

            grigliaPrincipale.Children.Add(lblNominativi, 0, 0);
            grigliaPrincipale.Children.Add(lblNominativi1, 1, 0);
            grigliaPrincipale.Children.Add(lblNominativi2, 2, 0);
            grigliaPrincipale.Children.Add(lblNominativi3, 3, 0);
            grigliaPrincipale.Children.Add(lblNominativi4, 4, 0);
            grigliaPrincipale.Children.Add(lblNominativi5, 5, 0);
            var stackNominativi = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions= LayoutOptions.Center,
                VerticalOptions= LayoutOptions.Center,
                Padding=5
                
            };
            var stackNominativiOrizzonatale = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,

            };
            stackNominativi.Children.Add(grigliaCodiciNominativi);
            stackNominativiOrizzonatale.Children.Add(grigliaNominativi);
            stackNominativi.Children.Add(stackNominativiOrizzonatale);
            grigliaPrincipale.Children.Add(stackNominativi, 0, 1);
            listaProva.Add(grigliaPrincipale);
            listaProva.Add(grigliaCodiciNominativi);
            return listaProva;
        }
 
    }


    /* 

 public class AutoSlide : ContentPage
     {
         List<Image> imageList;
         int Count = 0;
         short Counter = 0;
         int SlidePosition = 0;
         public AutoSlide()
         {
             imageList = new List<Image>();
             imageList.Add(new Image { Source = ImageSource.FromResource("AutoSlider.Images.1024x1024[1].png") });
             imageList.Add(new Image { Source = ImageSource.FromResource("AutoSlider.Images.1024x1024[1].png") });
             imageList.Add(new Image { Source = ImageSource.FromResource("AutoSlider.Images.1024x1024[1].png") });


             Grid g = new Grid
             {
                 RowDefinitions = {
                     new RowDefinition { Height = new GridLength(1, GridUnitType.Star)},
                     new RowDefinition { Height = new GridLength(30, GridUnitType.Absolute)},
                 }
             };
             CarouselView cv = new CarouselView { ItemsSource = imageList, ItemTemplate = GetDataTemplate() };
             g.Children.Add(cv, 0, 0);


             StackLayout indicators = new StackLayout { Orientation = StackOrientation.Horizontal, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center };

             foreach (Image item in imageList)
             {
                 Button circularButton = new Button { WidthRequest = 8, HeightRequest = 8, BorderRadius = 4, BackgroundColor = Color.FromHex("DDDDDD"), ClassId = Counter.ToString() };
                 indicators.Children.Add(circularButton);
                 Counter++;
             }

             cv.PropertyChanged += (sender, e) =>
             {
                 foreach (var button in indicators.Children)
                 {
                     button.BackgroundColor = Color.FromHex("DDDDDD");
                     View btn = indicators.Children.FirstOrDefault(f => f.ClassId == cv.Position.ToString());
                     btn.BackgroundColor = Color.FromHex("000000");
                 }
             };

             g.Children.Add(indicators, 0, 1); 


             Content = g;

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
     }


     */


}
