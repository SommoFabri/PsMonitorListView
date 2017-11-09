using PsMonitorList.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PsMonitorList.Services
{
    class CreazioneGrigliaInVisita
    {
        public async static Task<Grid> GrigliaInVisita(List<RecordBean> lista)
        {
            List<string> dataInVisita = new List<string>();
            List<string> oraInVisita = new List<string>();
            int row = 0;
            int colonna = 0;
            var grigliaInVisita = new Grid
            {
                HorizontalOptions = LayoutOptions.Center
            };
            foreach (var i in lista)
            {
                dataInVisita.Add(i.dataprimarichiesta);
                oraInVisita.Add(i.oraprimarichiesta);
            }

            colonna = 0;
            grigliaInVisita.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            grigliaInVisita.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
            for (int j = 0; j < lista.Count; j++)
            {
                var labelDataInVisita = new Label
                {
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Start,
                    Text = dataInVisita[j]
                };
                var labelOraInVisita = new Label
                {

                    HorizontalOptions = LayoutOptions.Center,

                    VerticalOptions = LayoutOptions.Start,

                    Text = oraInVisita[j]
                };
                var stackLayoutData = new StackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                };

                stackLayoutData.Children.Add(labelDataInVisita);
                stackLayoutData.Children.Add(labelOraInVisita);
                grigliaInVisita.Children.Add(stackLayoutData, colonna, row);
                row++;
            }
            colonna = 0;
            return grigliaInVisita;
        }

    }
}
