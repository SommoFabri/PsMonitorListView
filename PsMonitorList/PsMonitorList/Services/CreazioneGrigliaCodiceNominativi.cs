using PsMonitorList.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PsMonitorList.Services
{
    class CreazioneGrigliaCodiceNominativi
    {
        public async static Task<Grid> GrigliaCodiceNominativi( List<RecordBean> lista)
        {
            List<string> codiceNominativi = new List<string>();
            List<string> codiceColore = new List<string>();
            Color colore= Color.Yellow;
            int row = 0;
            int colonna = 0;
            string immagine = "rettangoloA.png";

            var grigliaCodiceNominativi = new Grid
            {
                HorizontalOptions=LayoutOptions.Center
            };
            foreach (var i in lista)
            {
                codiceNominativi.Add(i.cartella);
                codiceColore.Add(i.colore);
            }
            colonna = 0;
            grigliaCodiceNominativi.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            grigliaCodiceNominativi.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
            for (int j = 0; j < 5; j++)
            {
              switch (codiceColore[j])
                {
                    case "Verde":
                        colore = Color.Green;
                        break;
                    case "Rosso":
                        colore = Color.Red;
                        break;
                    case "Bianco":
                        colore = Color.Red;
                        break;
                    case "Giallo":
                        colore = Color.Yellow;
                        break;
                }
                var image = new Image
                {
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    BackgroundColor = colore,
                    Source=immagine,
                    Aspect=Aspect.Fill
                };
                var labelcodiceNominativo = new Label
                {
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions= LayoutOptions.Center,
                    BackgroundColor=colore,
                    Text = codiceNominativi[j],
                    TextColor = Color.Black
                };
               
                // grigliaCodiceNominativi.Children.Add(image, colonna, row);
                grigliaCodiceNominativi.Children.Add(labelcodiceNominativo, colonna, row);
                row++;
            }
            colonna = 0;
            return grigliaCodiceNominativi;
        }

  
    }
}
