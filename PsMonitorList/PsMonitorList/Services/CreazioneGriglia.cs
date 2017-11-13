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


        public async Task<List<Grid>> creazioneGriglia(List<RecordBean> lista)
        {
            string codiceColore, cognomi, nomi, eta, codici, sesso;
            Color colore = Color.Gray;
            int riga = 1;

            List<RecordBean> Appoggio = new List<RecordBean>();
            foreach (var i in lista)
            {
                
                codiceColore = i.colore;
                Appoggio.Add(i);

                switch (codiceColore)
                {
                    case "Verde":
                        colore = Color.LimeGreen;
                        break;
                    case "Rosso":
                        colore = Color.Red;
                        break;
                    case "Bianco":
                        colore = Color.White;
                        break;
                    case "Giallo":
                        colore = Color.Yellow;
                        break;
                }
                if (Appoggio.Count == 5)
                {
                    Grid grigliaPrincipale = new Grid();
                    grigliaPrincipale.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                    grigliaPrincipale.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });

                    var lblNominativi = new Label
                    {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        HorizontalTextAlignment = TextAlignment.Center,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        FontAttributes = FontAttributes.Bold,
                        BackgroundColor = Color.Chocolate,
                        Text = "Nominativi"

                    };
                    var lblNominativi1 = new Label
                    {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        HorizontalTextAlignment = TextAlignment.Center,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        FontAttributes = FontAttributes.Bold,
                        BackgroundColor = Color.Chocolate,
                        Text = "Stato"
                    };
                    var lblNominativi2 = new Label
                    {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        HorizontalTextAlignment = TextAlignment.Center,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        FontAttributes = FontAttributes.Bold,
                        BackgroundColor = Color.Chocolate,
                        Text = "Ingresso"
                    };
                    var lblNominativi3 = new Label
                    {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        HorizontalTextAlignment = TextAlignment.Center,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        FontAttributes = FontAttributes.Bold,
                        BackgroundColor = Color.Chocolate,
                        Text = "In visita"
                    };
                    var lblNominativi4 = new Label
                    {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        HorizontalTextAlignment = TextAlignment.Center,

                        FontAttributes = FontAttributes.Bold,
                        BackgroundColor = Color.Chocolate,
                        Text = "Attesa referti"
                    };
                    var lblNominativi5 = new Label
                    {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        HorizontalTextAlignment = TextAlignment.Center,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        FontAttributes = FontAttributes.Bold,
                        BackgroundColor = Color.Chocolate,
                        Text = "Attesa Dim."
                    };

                    grigliaPrincipale.Children.Add(lblNominativi, 0, 0);
                    grigliaPrincipale.Children.Add(lblNominativi1, 1, 0);
                    grigliaPrincipale.Children.Add(lblNominativi2, 2, 0);
                    grigliaPrincipale.Children.Add(lblNominativi3, 3, 0);
                    grigliaPrincipale.Children.Add(lblNominativi4, 4, 0);
                    grigliaPrincipale.Children.Add(lblNominativi5, 5, 0);
                    for (int j = 0; j < Appoggio.Count; j++)
                    {
                        var labelCodiciNominativi = new Label
                        {
                            HorizontalOptions = LayoutOptions.Center,
                            VerticalOptions = LayoutOptions.CenterAndExpand,
                            VerticalTextAlignment= TextAlignment.Center,
                            HorizontalTextAlignment= TextAlignment.Center,
                            FontAttributes = FontAttributes.Bold,
                            Text = Appoggio[j].cartella,
                            BackgroundColor = colore,
                            TextColor = Color.Black,
                            WidthRequest=60,
                            HeightRequest= 40
                        };
                        var labelNomiCognomiEta = new Label
                        {
                            HorizontalOptions = LayoutOptions.Center,
                            VerticalOptions = LayoutOptions.Center,
                            FontAttributes = FontAttributes.Bold,
                            Text = Appoggio[j].cognome.Substring(0, 1) + "." + " " + Appoggio[j].nome.Substring(0, 1) + "." + " età: " + Appoggio[j].eta + "\n" + "sesso: " + Appoggio[j].sesso,
                            TextColor = Color.Black
                        };
                        var labelStato = new Label
                        {
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            HorizontalTextAlignment = TextAlignment.Center,
                            VerticalTextAlignment = TextAlignment.Center,
                            VerticalOptions = LayoutOptions.FillAndExpand,
                            FontAttributes = FontAttributes.Bold,
                            Text = Appoggio[j].salaprimotriage + "\n" + Appoggio[j].stato,
                            TextColor= Color.Black,
                            BackgroundColor= Color.LightGray

                        };
                        var labelIngresso = new Label
                        {
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            HorizontalTextAlignment = TextAlignment.Center,
                            VerticalTextAlignment= TextAlignment.Center,
                            VerticalOptions = LayoutOptions.FillAndExpand,
                            FontAttributes = FontAttributes.Bold,
                            Text = Appoggio[j].datapresaincarico + "\n" + Appoggio[j].orapresaincarico,
                            TextColor = Color.Black,
                            BackgroundColor= Color.LightGray
                        };
                        var labelInVisita = new Label
                        {
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            HorizontalTextAlignment = TextAlignment.Center,
                            VerticalTextAlignment = TextAlignment.Center,
                            VerticalOptions = LayoutOptions.FillAndExpand,
                            FontAttributes = FontAttributes.Bold,
                            Text = Appoggio[j].dataprimarichiesta + "\n" + Appoggio[j].oraprimarichiesta,
                            TextColor = Color.Black,
                            BackgroundColor = Color.LightGray
                        };
                        var stackNominativi = new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            VerticalOptions = LayoutOptions.Fill,
                            HorizontalOptions = LayoutOptions.Fill,
                            Margin=5
                        };
                        var stackNominativiOrizzontale = new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            VerticalOptions = LayoutOptions.FillAndExpand,
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            Padding=5,
                        };
                        var stackNominativiGrande = new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            VerticalOptions = LayoutOptions.FillAndExpand,
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            Padding = 5,
                            BackgroundColor= Color.LightGray
                        };
                        stackNominativi.Children.Add(labelCodiciNominativi);
                        stackNominativiOrizzontale.Children.Add(labelNomiCognomiEta);
                        stackNominativi.Children.Add(stackNominativiOrizzontale);
                        stackNominativiGrande.Children.Add(stackNominativi);
                        grigliaPrincipale.Children.Add(stackNominativiGrande, 0, riga);
                        grigliaPrincipale.Children.Add(labelStato, 1, riga);
                        grigliaPrincipale.Children.Add(labelIngresso, 2, riga);
                        grigliaPrincipale.Children.Add(labelInVisita, 3, riga);
                        riga++;
                    }
                    Appoggio.Clear();

                    riga = 1;
                    listaProva.Add(grigliaPrincipale);
                }
                }
                if (Appoggio.Count < 5 && Appoggio.Count != 0)
                {
                    Grid grigliaPrincipale = new Grid();
                    grigliaPrincipale.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                    grigliaPrincipale.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });

                    var lblNominativi = new Label
                    {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        HorizontalTextAlignment = TextAlignment.Center,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        FontAttributes = FontAttributes.Bold,
                        BackgroundColor = Color.Chocolate,
                        Text = "Nominativi"

                    };
                    var lblNominativi1 = new Label
                    {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        HorizontalTextAlignment = TextAlignment.Center,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        FontAttributes = FontAttributes.Bold,
                        BackgroundColor = Color.Chocolate,
                        Text = "Stato"
                    };
                    var lblNominativi2 = new Label
                    {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        HorizontalTextAlignment = TextAlignment.Center,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        FontAttributes = FontAttributes.Bold,
                        BackgroundColor = Color.Chocolate,
                        Text = "Ingresso"
                    };
                    var lblNominativi3 = new Label
                    {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        HorizontalTextAlignment = TextAlignment.Center,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        FontAttributes = FontAttributes.Bold,
                        BackgroundColor = Color.Chocolate,
                        Text = "In visita"
                    };
                    var lblNominativi4 = new Label
                    {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        HorizontalTextAlignment = TextAlignment.Center,

                        FontAttributes = FontAttributes.Bold,
                        BackgroundColor = Color.Chocolate,
                        Text = "Attesa referti"
                    };
                    var lblNominativi5 = new Label
                    {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        HorizontalTextAlignment = TextAlignment.Center,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        FontAttributes = FontAttributes.Bold,
                        BackgroundColor = Color.Chocolate,
                        Text = "Attesa Dim."
                    };

                    grigliaPrincipale.Children.Add(lblNominativi, 0, 0);
                    grigliaPrincipale.Children.Add(lblNominativi1, 1, 0);
                    grigliaPrincipale.Children.Add(lblNominativi2, 2, 0);
                    grigliaPrincipale.Children.Add(lblNominativi3, 3, 0);
                    grigliaPrincipale.Children.Add(lblNominativi4, 4, 0);
                    grigliaPrincipale.Children.Add(lblNominativi5, 5, 0);
                for (int j = 0; j < Appoggio.Count; j++)
                {
                    var labelCodiciNominativi = new Label
                    {
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        VerticalTextAlignment = TextAlignment.Center,
                        HorizontalTextAlignment = TextAlignment.Center,
                        FontAttributes = FontAttributes.Bold,
                        Text = Appoggio[j].cartella,
                        BackgroundColor = colore,
                        TextColor = Color.Black,
                        WidthRequest = 60,
                        HeightRequest = 40
                    };
                    var labelNomiCognomiEta = new Label
                    {
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                        FontAttributes = FontAttributes.Bold,
                        Text = Appoggio[j].cognome.Substring(0, 1) + "." + " " + Appoggio[j].nome.Substring(0, 1) + "." + " età: " + Appoggio[j].eta + "\n" + "sesso: " + Appoggio[j].sesso,
                        TextColor = Color.Black
                    };
                    var labelStato = new Label
                    {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        HorizontalTextAlignment = TextAlignment.Center,
                        VerticalTextAlignment = TextAlignment.Center,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        FontAttributes = FontAttributes.Bold,
                        Text = Appoggio[j].salaprimotriage + "\n" + Appoggio[j].stato,
                        TextColor = Color.Black,
                        BackgroundColor = Color.LightGray

                    };
                    var labelIngresso = new Label
                    {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        HorizontalTextAlignment = TextAlignment.Center,
                        VerticalTextAlignment = TextAlignment.Center,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        FontAttributes = FontAttributes.Bold,
                        Text = Appoggio[j].datapresaincarico + "\n" + Appoggio[j].orapresaincarico,
                        TextColor = Color.Black,
                        BackgroundColor = Color.LightGray
                    };

                    var labelInVisita = new Label
                    {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        HorizontalTextAlignment = TextAlignment.Center,
                        VerticalTextAlignment = TextAlignment.Center,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        FontAttributes = FontAttributes.Bold,
                        Text = Appoggio[j].dataprimarichiesta + "\n" + Appoggio[j].oraprimarichiesta,
                        TextColor = Color.Black,
                        BackgroundColor = Color.LightGray
                    };
                    var stackNominativi = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        VerticalOptions = LayoutOptions.Fill,
                        HorizontalOptions = LayoutOptions.Fill,
                        Margin = 5
                    };
                    var stackNominativiOrizzontale = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Padding = 5,
                    };
                    var stackNominativiGrande = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Padding = 5,
                        BackgroundColor = Color.LightGray
                    };
                    stackNominativi.Children.Add(labelCodiciNominativi);
                    stackNominativiOrizzontale.Children.Add(labelNomiCognomiEta);
                    stackNominativi.Children.Add(stackNominativiOrizzontale);
                    stackNominativiGrande.Children.Add(stackNominativi);
                    grigliaPrincipale.Children.Add(stackNominativiGrande, 0, riga);
                    grigliaPrincipale.Children.Add(labelStato, 1, riga);
                    grigliaPrincipale.Children.Add(labelIngresso, 2, riga);
                    grigliaPrincipale.Children.Add(labelInVisita, 3, riga);
                    riga++;

                }

                Appoggio.Clear();
                    riga = 1;
                    listaProva.Add(grigliaPrincipale);
                }

            return listaProva;
        }
    }
}
    