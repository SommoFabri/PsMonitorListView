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
        public async static void GrigliaNominativi(Grid grigliaNominativi)
        {
            List<RecordBean> lista = new List<RecordBean>();
            List<string> cognomi = new List<string>();
            int row = 0;
            int colonna = 0;
            string cognome = "";
            string immagine = "rettangoloA.png";
            lista = await RisultatoConnessione();

            foreach (var i in lista)
            {
                cognomi.Add(i.cognome);

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
                    Source = immagine
                };

                var labelCognome = new Label
                {
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    Text = cognomi[j],
                    TextColor = Color.Black
                };
                row++;

                grigliaNominativi.Children.Add(image, colonna, row);
                grigliaNominativi.Children.Add(labelCognome, colonna, row);

            }




        }
        public async static Task<List<RecordBean>> RisultatoConnessione()
        {

            Connessioni<RecordBean> connessioni = new Connessioni<RecordBean>();

            var listaUno = await connessioni.GetJson(URL.URLConnessione);
            return listaUno;

        }
    }
}
