using PsMonitorList.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PsMonitorList.Services
{
    class CreazioneGrigliaIngresso
    {
        public async static Task<Grid> GrigliaIngresso(List<RecordBean> lista)
        {
            List<string> dataPresaInCarico = new List<string>();
            List<string> oraPresaInCarico = new List<string>();
            int row = 0;
            int colonna = 0;
            var grigliaPresaInCarico = new Grid
            {
                HorizontalOptions = LayoutOptions.Center
            };
            foreach (var i in lista)
            {
                dataPresaInCarico.Add(i.datapresaincarico);
                oraPresaInCarico.Add(i.orapresaincarico);
            }
        
            colonna = 0;
            grigliaPresaInCarico.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
            grigliaPresaInCarico.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
            for (int j = 0; j<lista.Count; j++)
            {
                var labelDataPresaInCarico = new Label
                {
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Start,
                    Text = dataPresaInCarico[j]
                };
                var labelOraPresaInCarico = new Label
                {

                    HorizontalOptions = LayoutOptions.Center,

                    VerticalOptions = LayoutOptions.Start,

                    Text = oraPresaInCarico[j]
                };
            var stackLayoutData = new StackLayout
                {
                     Orientation = StackOrientation.Vertical,
                     HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                    };

                stackLayoutData.Children.Add(labelDataPresaInCarico);
                stackLayoutData.Children.Add(labelOraPresaInCarico);
                grigliaPresaInCarico.Children.Add(stackLayoutData, colonna, row);
                row++;
            }
            colonna = 0;
            return grigliaPresaInCarico;
        }
        
    }
}

    
