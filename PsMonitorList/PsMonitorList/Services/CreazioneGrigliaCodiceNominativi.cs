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
        public async static Task<Grid> GrigliaCodiceNominativi(List<RecordBean> lista)
        {
            List<string> codiceNominativi = new List<string>();
            int row = 0;
            int colonna = 0;
            string cognome = "";
            string immagine = "rettangoloA.png";

            var grigliaCodiceNominativi = new Grid
            {
                HorizontalOptions=LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            foreach (var i in lista)
            {
                codiceNominativi.Add(i.cartella);

            }
            colonna = 0;

            for (int j = 0; j < 5; j++)
            {
                grigliaCodiceNominativi.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            }

            grigliaCodiceNominativi.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            for (int j = 0; j < 5; j++)
            {
                var labelcodiceNominativo = new Label
                {
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    Text = codiceNominativi[j],
                    TextColor = Color.Black
                };
            
                var stack = new StackLayout
                {
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                };
                row++;

                stack.Children.Add(labelcodiceNominativo);
                grigliaCodiceNominativi.Children.Add(stack, colonna, row);

               
            }
            return grigliaCodiceNominativi;
        }

       
    }
}
