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
            string codiceColore;
            Color colore = Color.Gray;
            Color color = new Color();
            color = Color.LightGray;
            int riga = 1;

            List<RecordBean> Appoggio = new List<RecordBean>();
            foreach (var i in lista)
            {
                Appoggio.Add(i);

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
                        codiceColore = Appoggio[j].colore;

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
                        var imageArrowIngresso = new Image
                        {
                            Source = "freccia.png",
                            HorizontalOptions= LayoutOptions.End,
                            HeightRequest= 30,
                            WidthRequest= 20
                        };
                        var imageArrowVisita = new Image
                        {
                            Source = "freccia.png",
                            HorizontalOptions = LayoutOptions.End,
                            HeightRequest = 30,
                            WidthRequest = 20
                        };
                        var imageArrowAttesa = new Image
                        {
                            Source = "freccia.png",
                            HorizontalOptions = LayoutOptions.End,
                            HeightRequest = 30,
                            WidthRequest = 20
                        };
                        var imageSessoUomo = new Image
                        {
                            Source= "male48.png"
                        };
                        var imageSessoDonna = new Image
                        {
                            Source ="female48.png"
                        }; 
                        var labelCodiciNominativi = new Label
                        {
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            VerticalOptions = LayoutOptions.FillAndExpand,
                            VerticalTextAlignment= TextAlignment.Center,
                            HorizontalTextAlignment= TextAlignment.Center,
                            FontAttributes = FontAttributes.Bold,
                            Text = Appoggio[j].cartella,
                            BackgroundColor = colore,
                            TextColor = Color.Black,
                            WidthRequest=80,
                            HeightRequest= 40
                        };
                        var labelNomiCognomiEta = new Label
                        {
                            HorizontalOptions = LayoutOptions.Center,
                            VerticalOptions = LayoutOptions.Center,
                            FontAttributes = FontAttributes.Bold,
                            Text = Appoggio[j].cognome.Substring(0, 1) + "." + " " + Appoggio[j].nome.Substring(0, 1) + "." + " età: " + Appoggio[j].eta ,
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
                        if (Appoggio[j].stato.Equals("Accettato") || Appoggio[j].stato.Equals("In Triage"))
                        {
                            color = Color.Orange;
                        }
                        else
                            color = Color.LightGray;

                        var labelIngresso = new Label
                        {
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            HorizontalTextAlignment = TextAlignment.Center,
                            VerticalTextAlignment = TextAlignment.Center,
                            VerticalOptions = LayoutOptions.FillAndExpand,
                            FontAttributes = FontAttributes.Bold,
                            Text = Appoggio[j].dataaccettazione + "\n" + Appoggio[j].oraaccettazione,
                            TextColor = Color.Black,
                            BackgroundColor = color
                        };
                        if (Appoggio[j].stato.Equals("In Visita"))
                        {
                            color = Color.Orange;
                        }
                        else
                            color = Color.LightGray;

                        var labelInVisita = new Label
                        {
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            HorizontalTextAlignment = TextAlignment.Center,
                            VerticalTextAlignment = TextAlignment.Center,
                            VerticalOptions = LayoutOptions.FillAndExpand,
                            FontAttributes = FontAttributes.Bold,
                            Text = Appoggio[j].datapresaincarico + "\n" + Appoggio[j].orapresaincarico,
                            TextColor = Color.Black,
                            BackgroundColor = color
                        };
                        if (Appoggio[j].stato.Equals("In Attesa Referto"))
                        {
                            color = Color.Orange;
                        }
                        else
                            color = Color.LightGray;

                        var labelInAttesa = new Label
                        {
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            HorizontalTextAlignment = TextAlignment.Center,
                            VerticalTextAlignment = TextAlignment.Center,
                            VerticalOptions = LayoutOptions.FillAndExpand,
                            FontAttributes = FontAttributes.Bold,
                            Text = Appoggio[j].dataprimarichiesta + "\n" + Appoggio[j].oraprimarichiesta,
                            TextColor = Color.Black,
                            BackgroundColor = color
                        };

                        if (Appoggio[j].stato.Equals("In Osservazione OBI") || Appoggio[j].stato.Equals("Dimesso"))
                        {
                            color = Color.Orange;
                        }
                        else
                            color = Color.LightGray;

                        var labelDimissioni = new Label
                        {
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            HorizontalTextAlignment = TextAlignment.Center,
                            VerticalTextAlignment = TextAlignment.Center,
                            VerticalOptions = LayoutOptions.FillAndExpand,
                            FontAttributes = FontAttributes.Bold,
                            Text = Appoggio[j].datadimissione + "\n" + Appoggio[j].oradimissione,
                            TextColor = Color.Black,
                            BackgroundColor = color
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
                        if (Appoggio[j].sesso == "M")
                        {
                            stackNominativiGrande.Children.Add(imageSessoUomo);
                        }
                        else if(Appoggio[j].sesso=="F")
                        {
                            stackNominativiGrande.Children.Add(imageSessoDonna);
                        }

                        var stackIngresso = new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            VerticalOptions = LayoutOptions.Fill,
                            HorizontalOptions = LayoutOptions.Fill,
                            Margin = 5
                        };
                        var stackIngressoOrizzontale = new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            VerticalOptions = LayoutOptions.FillAndExpand,
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            Padding = 5,
                        };
                        var stackIngressoGrande = new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            VerticalOptions = LayoutOptions.FillAndExpand,
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            Padding = 5,
                            BackgroundColor = Color.LightGray
                        };
                        stackIngresso.Children.Add(labelIngresso);
                        stackIngressoOrizzontale.Children.Add(imageArrowIngresso);
                        stackIngresso.Children.Add(stackIngressoOrizzontale);
                        stackIngressoGrande.Children.Add(stackIngresso);

                        var stackInVisita = new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            VerticalOptions = LayoutOptions.Fill,
                            HorizontalOptions = LayoutOptions.Fill,
                            Margin = 5
                        };
                        var stackInVisitaOrizzontale = new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            VerticalOptions = LayoutOptions.FillAndExpand,
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            Padding = 5,
                        };
                        var stackInVisitaGrande = new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            VerticalOptions = LayoutOptions.FillAndExpand,
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            Padding = 5,
                            BackgroundColor = Color.LightGray
                        };
                        stackInVisita.Children.Add(labelInVisita);
                        stackInVisitaOrizzontale.Children.Add(imageArrowVisita);
                        stackInVisita.Children.Add(stackInVisitaOrizzontale);
                        stackInVisitaGrande.Children.Add(stackInVisita);

                        var stackInAttesa = new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            VerticalOptions = LayoutOptions.Fill,
                            HorizontalOptions = LayoutOptions.Fill,
                            Margin = 5
                        };
                        var stackInAttesaOrizzontale = new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            VerticalOptions = LayoutOptions.FillAndExpand,
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            Padding = 5,
                        };
                        var stackInAttesaGrande = new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            VerticalOptions = LayoutOptions.FillAndExpand,
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            Padding = 5,
                            BackgroundColor = Color.LightGray
                        };
                        stackInAttesa.Children.Add(labelInAttesa);
                        stackInAttesaOrizzontale.Children.Add(imageArrowAttesa);
                        stackInAttesa.Children.Add(stackInAttesaOrizzontale);
                        stackInAttesaGrande.Children.Add(stackInAttesa);

                        var stackDimissioni = new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            VerticalOptions = LayoutOptions.FillAndExpand,
                            HorizontalOptions = LayoutOptions.CenterAndExpand,
                            Margin = 5
                        };
                        var stackDimissioniOrizzontale = new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            VerticalOptions = LayoutOptions.FillAndExpand,
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            Padding = 5,
                        };
                        var stackDimissioniGrande = new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            VerticalOptions = LayoutOptions.FillAndExpand,
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            Padding = 5,
                            BackgroundColor = Color.LightGray
                        };
                        stackDimissioni.Children.Add(labelDimissioni);
                        //stackDimissioniOrizzontale.Children.Add( );
                       // stackDimissioni.Children.Add(stackDimissioniOrizzontale);
                        stackDimissioniGrande.Children.Add(stackDimissioni);

                        grigliaPrincipale.Children.Add(stackNominativiGrande, 0, riga);
                        grigliaPrincipale.Children.Add(labelStato, 1, riga);
                        grigliaPrincipale.Children.Add(stackIngressoGrande, 2, riga);
                        grigliaPrincipale.Children.Add(stackInVisitaGrande, 3, riga);
                        grigliaPrincipale.Children.Add(stackInAttesaGrande, 4, riga);
                        grigliaPrincipale.Children.Add(stackDimissioniGrande, 5, riga);
                        grigliaPrincipale.Children.Add(imageArrowIngresso, 2, riga);
                        grigliaPrincipale.Children.Add(imageArrowVisita, 3, riga);
                        grigliaPrincipale.Children.Add(imageArrowAttesa, 4, riga);
                      
                        grigliaPrincipale.ColumnSpacing = 2;
                        grigliaPrincipale.RowSpacing = 2;
                        riga++;
                        }
                    Appoggio.Clear();

                    riga = 1;
                    listaProva.Add(grigliaPrincipale);
                }
                }
                if (Appoggio.Count < 5 && Appoggio.Count != 0)
                {

                    ElencoPasientiBO p = new ElencoPasientiBO();
                    RecordBean g = new RecordBean();
                    g = p.aggiungiCampiVuoti();
                    while ( Appoggio.Count != 5)
                    {
                    Appoggio.Add(g);
                    }
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

                    codiceColore = Appoggio[j].colore;

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
                    var imageArrowIngresso = new Image
                    {
                        Source = "freccia.png",
                        HorizontalOptions = LayoutOptions.End,
                        HeightRequest = 30,
                        WidthRequest = 20
                    };
                    var imageArrowVisita = new Image
                    {
                        Source = "freccia.png",
                        HorizontalOptions = LayoutOptions.End,
                        HeightRequest = 30,
                        WidthRequest = 20
                    };
                    var imageArrowAttesa = new Image
                    {
                        Source = "freccia.png",
                        HorizontalOptions = LayoutOptions.End,
                        HeightRequest = 30,
                        WidthRequest = 20
                    };
                    var imageSessoUomo = new Image
                    {
                        Source = "male48.png"
                    };
                    var imageSessoDonna = new Image
                    {
                        Source = "female48.png"
                    };
                    var labelCodiciNominativi = new Label
                    {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        VerticalTextAlignment = TextAlignment.Center,
                        HorizontalTextAlignment = TextAlignment.Center,
                        FontAttributes = FontAttributes.Bold,
                        Text = Appoggio[j].cartella,
                        BackgroundColor = colore,
                        TextColor = Color.Black,
                        WidthRequest = 80,
                        HeightRequest = 40
                    };
                    var labelNomiCognomiEta = new Label
                    {
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                        FontAttributes = FontAttributes.Bold,
                        Text = Appoggio[j].cognome.Substring(0, 1) + "." + " " + Appoggio[j].nome.Substring(0, 1) + "." + " età: " + Appoggio[j].eta,
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
                    if (Appoggio[j].stato.Equals("Accettato") || Appoggio[j].stato.Equals("In Triage"))
                    {
                        color = Color.Orange;
                    }
                    else
                        color = Color.LightGray;

                    var labelIngresso = new Label
                    {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        HorizontalTextAlignment = TextAlignment.Center,
                        VerticalTextAlignment = TextAlignment.Center,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        FontAttributes = FontAttributes.Bold,
                        Text = Appoggio[j].dataaccettazione + "\n" + Appoggio[j].oraaccettazione,
                        TextColor = Color.Black,
                        BackgroundColor = color
                    };
                    if (Appoggio[j].stato.Equals("In Visita"))
                    {
                        color = Color.Orange;
                    }
                    else
                        color = Color.LightGray;

                    var labelInVisita = new Label
                    {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        HorizontalTextAlignment = TextAlignment.Center,
                        VerticalTextAlignment = TextAlignment.Center,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        FontAttributes = FontAttributes.Bold,
                        Text = Appoggio[j].datapresaincarico + "\n" + Appoggio[j].orapresaincarico,
                        TextColor = Color.Black,
                        BackgroundColor = color
                    };
                    if (Appoggio[j].stato.Equals("In Attesa Referto"))
                    {
                        color = Color.Orange;
                    }
                    else
                        color = Color.LightGray;

                    var labelInAttesa = new Label
                    {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        HorizontalTextAlignment = TextAlignment.Center,
                        VerticalTextAlignment = TextAlignment.Center,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        FontAttributes = FontAttributes.Bold,
                        Text = Appoggio[j].dataprimarichiesta + "\n" + Appoggio[j].oraprimarichiesta,
                        TextColor = Color.Black,
                        BackgroundColor = color
                    };

                    if (Appoggio[j].stato.Equals("In Osservazione OBI") || Appoggio[j].stato.Equals("Dimesso"))
                    {
                        color = Color.Orange;
                    }
                    else
                        color = Color.LightGray;

                    var labelDimissioni = new Label
                    {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        HorizontalTextAlignment = TextAlignment.Center,
                        VerticalTextAlignment = TextAlignment.Center,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        FontAttributes = FontAttributes.Bold,
                        Text = Appoggio[j].datadimissione + "\n" + Appoggio[j].oradimissione,
                        TextColor = Color.Black,
                        BackgroundColor = color
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
                    if (Appoggio[j].sesso == "M")
                    {
                        stackNominativiGrande.Children.Add(imageSessoUomo);
                    }
                    else if (Appoggio[j].sesso == "F")
                    {
                        stackNominativiGrande.Children.Add(imageSessoDonna);
                    }

                    var stackIngresso = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        VerticalOptions = LayoutOptions.Fill,
                        HorizontalOptions = LayoutOptions.Fill,
                        Margin = 5
                    };
                    var stackIngressoOrizzontale = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Padding = 5,
                    };
                    var stackIngressoGrande = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Padding = 5,
                        BackgroundColor = Color.LightGray
                    };
                    stackIngresso.Children.Add(labelIngresso);
                    stackIngressoOrizzontale.Children.Add(imageArrowIngresso);
                    stackIngresso.Children.Add(stackIngressoOrizzontale);
                    stackIngressoGrande.Children.Add(stackIngresso);

                    var stackInVisita = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        VerticalOptions = LayoutOptions.Fill,
                        HorizontalOptions = LayoutOptions.Fill,
                        Margin = 5
                    };
                    var stackInVisitaOrizzontale = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Padding = 5,
                    };
                    var stackInVisitaGrande = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Padding = 5,
                        BackgroundColor = Color.LightGray
                    };
                    stackInVisita.Children.Add(labelInVisita);
                    stackInVisitaOrizzontale.Children.Add(imageArrowVisita);
                    stackInVisita.Children.Add(stackInVisitaOrizzontale);
                    stackInVisitaGrande.Children.Add(stackInVisita);

                    var stackInAttesa = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        VerticalOptions = LayoutOptions.Fill,
                        HorizontalOptions = LayoutOptions.Fill,
                        Margin = 5
                    };
                    var stackInAttesaOrizzontale = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Padding = 5,
                    };
                    var stackInAttesaGrande = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Padding = 5,
                        BackgroundColor = Color.LightGray
                    };
                    stackInAttesa.Children.Add(labelInAttesa);
                    stackInAttesaOrizzontale.Children.Add(imageArrowAttesa);
                    stackInAttesa.Children.Add(stackInAttesaOrizzontale);
                    stackInAttesaGrande.Children.Add(stackInAttesa);

                    var stackDimissioni = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        Margin = 5
                    };
                    var stackDimissioniOrizzontale = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Padding = 5,
                    };
                    var stackDimissioniGrande = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Padding = 5,
                        BackgroundColor = Color.LightGray
                    };
                    stackDimissioni.Children.Add(labelDimissioni);
                    //stackDimissioniOrizzontale.Children.Add( );
                    // stackDimissioni.Children.Add(stackDimissioniOrizzontale);
                    stackDimissioniGrande.Children.Add(stackDimissioni);

                    grigliaPrincipale.Children.Add(stackNominativiGrande, 0, riga);
                    grigliaPrincipale.Children.Add(labelStato, 1, riga);
                    grigliaPrincipale.Children.Add(stackIngressoGrande, 2, riga);
                    grigliaPrincipale.Children.Add(stackInVisitaGrande, 3, riga);
                    grigliaPrincipale.Children.Add(stackInAttesaGrande, 4, riga);
                    grigliaPrincipale.Children.Add(stackDimissioniGrande, 5, riga);
                    grigliaPrincipale.Children.Add(imageArrowIngresso, 2, riga);
                    grigliaPrincipale.Children.Add(imageArrowVisita, 3, riga);
                    grigliaPrincipale.Children.Add(imageArrowAttesa, 4, riga);

                    grigliaPrincipale.ColumnSpacing = 2;
                    grigliaPrincipale.RowSpacing = 2;
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
    