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
                HorizontalOptions = LayoutOptions.Center
            };
            foreach (var i in lista)
            {
                cognomi.Add(i.cognome);
                nomi.Add(i.nome);
                eta.Add(i.eta);
                
            }
            grigliaNominativi.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            grigliaNominativi.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
            for (int j = 0; j < 5; j++)
            {

                var labelCognome = new Label
                {
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    Text = cognomi[j].Substring(0,1)+"."+" "+nomi[j].Substring(0, 1) + "." +" età: "+eta[j],
                    TextColor = Color.Black
                };
                grigliaNominativi.Children.Add(labelCognome, colonna, row);
                row++;

            }
            colonna = 0;
            return grigliaNominativi;
        }
      
    }
}
