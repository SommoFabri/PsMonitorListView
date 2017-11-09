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
        public List<Grid> listaProva = new List<Grid>();
        public async Task<List<Grid>> CreaGriglia(Grid grigliaPrincipale1, List<RecordBean> lista)
        {
            int riga = 0, colonna = 0;
            List<RecordBean> Appoggio = new List<RecordBean>();
            foreach (var i in lista)
            {
                Appoggio.Add(i);
                if (Appoggio.Count == 5)
                {
                    Grid grigliaPrincipale = new Grid();
                    grigliaPrincipale.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                    grigliaPrincipale.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });

                    Grid grigliaCodiciNominativi = await CreazioneGrigliaCodiceNominativi.GrigliaCodiceNominativi(Appoggio);
                    Grid grigliaNominativi = await CreazioneGrigliaNominativi.GrigliaNominativi(Appoggio);

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
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                        Padding = 5

                    };
                    var stackNominativiOrizzonatale = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,

                    };
                    stackNominativi.Children.Add(grigliaCodiciNominativi);
                    stackNominativiOrizzonatale.Children.Add(grigliaNominativi);
                    stackNominativi.Children.Add(stackNominativiOrizzonatale);
                    grigliaPrincipale.Children.Add(stackNominativi, 0, 1);
                    Appoggio.Clear();
                    listaProva.Add(grigliaPrincipale);
                }
            }
            if (Appoggio.Count < 5 && Appoggio.Count!=0)
                     {
                         Grid grigliaPrincipale = new Grid();
                         grigliaPrincipale.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                         grigliaPrincipale.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });

                         Grid grigliaCodiciNominativi = await CreazioneGrigliaCodiceNominativi.GrigliaCodiceNominativi(Appoggio);
                         Grid grigliaNominativi = await CreazioneGrigliaNominativi.GrigliaNominativi(Appoggio);

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
                             HorizontalOptions = LayoutOptions.Center,
                             VerticalOptions = LayoutOptions.Center,
                             Padding = 5

                         };
                         var stackNominativiOrizzonatale = new StackLayout
                         {
                             Orientation = StackOrientation.Horizontal,

                         };
                         stackNominativi.Children.Add(grigliaCodiciNominativi);
                         stackNominativiOrizzonatale.Children.Add(grigliaNominativi);
                         stackNominativi.Children.Add(stackNominativiOrizzonatale);
                         grigliaPrincipale.Children.Add(stackNominativi, 0, 1);
                         listaProva.Add(grigliaPrincipale);}
                return listaProva;
        }
    }
}
