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
      
        public async static void CreaGriglia(Grid grigliaPrincipale)
        {
            int riga = 0, colonna = 0;
            List<RecordBean> ListaRisultato = new List<RecordBean>();
            
            
            for(int i=0; i<5;i++)
            {
                grigliaPrincipale.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            }
            for(int i=0; i<2;i++)
            {
                grigliaPrincipale.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                
            }

            for ( riga=0;riga<5;riga++)
            {
                
                var stack_vertical = new StackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    BackgroundColor = Color.LightGray
                };
                Grid grigliaCodiciNominativi = await CreazioneGrigliaCodiceNominativi.GrigliaCodiceNominativi(RisultatoConnessione);
                stack_vertical.Children.Add(grigliaPrincipale);
                grigliaPrincipale.Children.Add(grigliaCodiciNominativi,colonna,riga);
            }
            
            for (riga= 0;riga<5;riga++)
            {
                colonna = 1;
                var stack_verticalDue = new StackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    BackgroundColor = Color.LightGray
                };

                stack_verticalDue.Children.Add(grigliaPrincipale);
                Grid grigliaNominativi = await CreazioneGrigliaNominativi.GrigliaNominativi(RisultatoConnessione);

                grigliaPrincipale.Children.Add(grigliaNominativi, colonna, riga);
            }

        }
        public async Task<List<RecordBean>> RisultatoConnessione()
        {
            List<RecordBean> RisultatoConnessione = new List<RecordBean>();
            Connessioni<RecordBean> connessione = new Connessioni<RecordBean>();
            RisultatoConnessione = await connessione.GetJson(URL.URLConnessione);
            return RisultatoConnessione;
        }
    }
   
}
