using PsMonitorList.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace PsMonitorList.Services
{
    class CreazioneGrigliaNominativi
    {
        public async static Task<Grid> GrigliaNominativi(List<RecordBean> lista)
        {
            
            List<string> cognomi = new List<string>();
            List<string> nomi = new List<string>();
            List<string> eta = new List<string>();
            int row = 0;
            int colonna = 0;
            string cognome = "";
            string immagine = "rettangoloA.png";
        
            var grigliaNominativi = new Grid
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            foreach (var i in lista)
            {
                cognomi.Add(i.cognome);
                nomi.Add(i.nome);
                eta.Add(i.eta);
                
            }
            colonna = 0;

            for (int j = 0; j < 5; j++)
            {
                grigliaNominativi.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            }

            grigliaNominativi.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            for (int j = 0; j < 5; j++)
            {

                var image = new Image
                {
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    Source = immagine,
                    Aspect=Aspect.Fill
                };

                var labelCognome = new Label
                {
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    Text = cognomi[j].Substring(0,1)+"."+" "+nomi[j].Substring(0, 1) + ".",
                    TextColor = Color.Black
                };
                var labelEta = new Label
                {
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.End,
                    Text = eta[j],
                    TextColor = Color.Black
                };
                var stack = new StackLayout
                {
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                };
                row++;
               
                stack.Children.Add(labelCognome);
                stack.Children.Add(labelEta);
                grigliaNominativi.Children.Add(image,colonna,row);
                grigliaNominativi.Children.Add(stack, colonna, row);

                
            }
            return grigliaNominativi;
        }
      
    }
}
