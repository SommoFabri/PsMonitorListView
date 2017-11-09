using PsMonitorList.ServiceComparator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsMonitorList.Model
{

    class ElencoPasientiBO
    {
        public List<RecordBean> lista = new List<RecordBean>();

        public RecordBean addBean(RecordBean recordBean)
        {
            if (recordBean.nome == string.Empty){
                recordBean.nome = "---";
            }
            if (recordBean.cognome == string.Empty)
            {
                recordBean.cognome = "---";
            }
            if (recordBean.colore == string.Empty)
            {
                recordBean.colore = "---";
            }
            if (recordBean.dataaccettazione == string.Empty)
            {
                recordBean.dataaccettazione = "---";
            }
            if (recordBean.datadimissione == string.Empty)
            {
                recordBean.datadimissione = "---";
            }
            if (recordBean.datainvioinobi == string.Empty)
            {
                recordBean.datainvioinobi = "---";
            }
            if (recordBean.datapresaincarico == string.Empty)
            {
                recordBean.datapresaincarico = "---";
            }
            if (recordBean.dataprimarichiesta == string.Empty)
            {
                recordBean.dataprimarichiesta = "---";
            }
            if (recordBean.eta == string.Empty)
            {
                recordBean.eta = "---";
            }
            if (recordBean.minutidimissione == string.Empty)
            {
                recordBean.minutidimissione = "---";
            }
            if (recordBean.minutiincaricorichiesta == string.Empty)
            {
                recordBean.minutiincaricorichiesta = "---";
            }
            if (recordBean.minutipresaincarico == string.Empty)
            {
                recordBean.minutipresaincarico = "---";
            }
            if (recordBean.modalitadimissione == string.Empty)
            {
                recordBean.modalitadimissione = "---";
            }
            if (recordBean.cartella == string.Empty)
            {
                recordBean.cartella = "---";
            }
            if (recordBean.oraaccettazione == string.Empty)
            {
                recordBean.oraaccettazione = "---";
            }
            if (recordBean.oradimissione == string.Empty)
            {
                recordBean.oradimissione = "---";
            }
            if (recordBean.orainvioinobi == string.Empty)
            {
                    recordBean.orainvioinobi = "---";
            }
            if (recordBean.orapresaincarico == string.Empty)
            {
                recordBean.orapresaincarico = "---";
            }
            if (recordBean.oraprimarichiesta == string.Empty)
            {
                recordBean.oraprimarichiesta = "---";
            }
            if (recordBean.salaprimotriage == string.Empty)
            {
                recordBean.salaprimotriage = "---";
            }
            if (recordBean.stato == string.Empty)
            {
                recordBean.stato = "---";
            }
            if (recordBean.salaprimotriage == string.Empty)
            {
                recordBean.salaprimotriage = "---";
            }
            if (recordBean.sesso == string.Empty)
            {
                recordBean.sesso = "---";
            }
            lista.Add(recordBean);
            return recordBean;
        }
        public List<RecordBean> getListaAssistitiDaVisualizzare(List<RecordBean> list)
        {
            lista = list;
            List<RecordBean> listaAssistitiDaVisualizzare = new List<RecordBean>();
            DateTime c = DateTime.Now;
            c.AddMinutes(-15);
            DateTime dataLimite = c;
            foreach (var recordBean in lista)
            {
                //  DateTime oraFormat = DateTime.Now("dd-MM-yyyy HH:mm"); 
                DateTime oraDimissione;
                if (recordBean.stato.Equals("Dimesso"))
                {
                    try
                    {
                        oraDimissione = DateTime.ParseExact(recordBean.datadimissione + " " + recordBean.oradimissione, "dd-MM-yyyy HH:mm", System.Globalization.CultureInfo.CurrentCulture);
                    }
                    catch (Exception e)
                    {
                        oraDimissione = DateTime.Now;
                    }
                    if (dataLimite.CompareTo(oraDimissione) < 0)
                    {
                        listaAssistitiDaVisualizzare.Add(recordBean);
                    }
                }
                else if (recordBean.stato.Equals("In Osservazione OBI"))
                {
                    try
                    {
                        oraDimissione = DateTime.ParseExact(recordBean.datainvioinobi + " " + recordBean.orainvioinobi, "dd-MM-yyyy HH:mm", System.Globalization.CultureInfo.CurrentCulture);
                    }
                    catch (Exception e)
                    {
                        oraDimissione = DateTime.Now;
                    }
                    if (dataLimite.CompareTo(oraDimissione) < 0)
                    {
                        listaAssistitiDaVisualizzare.Add(recordBean);
                    }
                }
                else
                {
                    listaAssistitiDaVisualizzare.Add(recordBean);
                }
            }
            return listaAssistitiDaVisualizzare;
        }
       // public void addBean(/*JSONObject jsonRecordBean*/)
       /* {
            
        }*/
        public String getMediaVisita(String colore)
        {
            String returnValue = "";
            List<RecordBean> listaFiltrati = new List<RecordBean>();
            DateTime c = DateTime.Now;
            c.AddHours(-2);
            DateTime dataLimite = c;
            float numeroPazientiMedia = 0.0f;
            float tempoMedio = 0.0f;
            foreach (RecordBean recordBean in lista)
            {
                if (recordBean.colore.Equals(colore) && !recordBean.stato.Equals("Accettato"))
                {
                    //System.out.println(recordBean.getCartella() + " - " + recordBean.getColore() + " - " + recordBean.getStato());
                    if (!recordBean.datapresaincarico.Equals(""))
                    {
                        listaFiltrati.Add(recordBean);
                    }
                }
            }
            listaFiltrati.Sort(new DataPresaInCaricoComparator());
            foreach (RecordBean recordBean in listaFiltrati)
            {
                DateTime dataAccetazione = DateTime.Now;
                DateTime dataPresaInCarico = DateTime.Now;

                try
                {
                    
                    dataAccetazione = DateTime.ParseExact(recordBean.dataaccettazione + " " + recordBean.oraaccettazione + ":00", "dd-MM-yyyy HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture);

                    dataPresaInCarico = DateTime.ParseExact(recordBean.datapresaincarico + " " + recordBean.orapresaincarico + ":00", "dd-MM-yyyy HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture);

                }
                catch (Exception e)
                {
                    //e.printStackTrace();
                }
                if (dataLimite.CompareTo(dataPresaInCarico) < 0)
                {
                    numeroPazientiMedia++;
                    var i = Convert.ToDouble(dataPresaInCarico - dataAccetazione);
                    tempoMedio += ((float)(i)) / (60 * 60 * 1000);

                }


            }

            float mediaAttesa = (tempoMedio / numeroPazientiMedia);
            long oreAttesa = (long)mediaAttesa;
            long minutiAttesa = (long)(60 * (mediaAttesa - oreAttesa));
            oreAttesa = (oreAttesa < 0) ? 0 : oreAttesa;
            minutiAttesa = (minutiAttesa < 0) ? 0 : minutiAttesa;
            //        System.out.println("Media: " + mediaAttesa);
            //        System.out.println("Media: " + oreAttesa);
            //        System.out.println("Media: " + minutiAttesa);
            //        System.out.println("Media: " + Math.floor(mediaAttesa));
            //        System.out.println("Media: " + Math.ceil(mediaAttesa));
            returnValue = String.Format("%02d", oreAttesa) + "h " + String.Format("%02d", minutiAttesa) + "min";

            return returnValue;
        }
    }


    }
