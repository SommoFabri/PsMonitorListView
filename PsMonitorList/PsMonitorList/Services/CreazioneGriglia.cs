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
      
        public async static void CreaGriglia(Grid grigliaPrincipale,List<RecordBean> lista)
        {
            int riga = 0, colonna = 0;
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
                Grid grigliaCodiciNominativi = await CreazioneGrigliaCodiceNominativi.GrigliaCodiceNominativi(lista);
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
                Grid grigliaNominativi = await CreazioneGrigliaNominativi.GrigliaNominativi(lista);
                grigliaPrincipale.Children.Add(grigliaNominativi, colonna, riga);
            }

        }
 
    }
   
}
