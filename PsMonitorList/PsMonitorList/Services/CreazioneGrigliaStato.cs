using PsMonitorList.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PsMonitorList.Services
{
    class CreazioneGrigliaStato
    {
        public async static Task<Grid> GrigliaStato(List<RecordBean> lista)
        {
            List<string> dataAccettazione = new List<string>();
            List<string> oraAccettazione = new List<string>();
            int row = 0;
            int colonna = 0;
            var grigliaStato = new Grid
            {
                HorizontalOptions = LayoutOptions.Center
            };
            foreach (var i in lista)
            {
                dataAccettazione.Add(i.dataaccettazione);
                oraAccettazione.Add(i.oraaccettazione);
            }
            colonna = 0;
            grigliaStato.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            grigliaStato.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
            for (int j = 0; j < lista.Count; j++)
            {
                var labelStatoData = new Label
                {
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Start,
                    Text = dataAccettazione[j]
                };
                var labelStatoOra = new Label
                {
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Start,
                    Text = oraAccettazione[j]
                };
                var stackLayoutData = new StackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                };
                stackLayoutData.Children.Add(labelStatoData);
                stackLayoutData.Children.Add(labelStatoOra);
                grigliaStato.Children.Add(stackLayoutData, colonna, row);
                row++;
            }
            colonna = 0;
            return grigliaStato;
        }
        
    }
}
