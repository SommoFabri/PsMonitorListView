using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsMonitorList.Model
{
    public class RecordBean
    {
        public string cartella { get; set;}
        public string colore { get; set; }
        public string cognome { get; set; }
        public string nome { get; set; }
        public string sesso { get; set; }
        public string eta { get; set; }
        public string stato { get; set; }
        public string dataaccettazione { get; set; }
        public string oraaccettazione { get; set; }
        public string datapresaincarico { get; set; }
        public string orapresaincarico { get; set; }
        public string dataprimarichiesta { get; set; }
        public string oraprimarichiesta { get; set; }
        public string datainvioinobi { get; set; }
        public string orainvioinobi { get; set; }
        public string datadimissione { get; set; }
        public string oradimissione { get; set; }
        public string minutiincaricorichiesta { get; set; }
        public string minutipresaincarico { get; set; }
        public string minutidimissione { get; set; }
        public string salaprimotriage { get; set; }
        public string modalitadimissione { get; set; }
    }
    
}
/*          "cartella": 25103,
            "colore": "Verde",
            "cognome": "PETRILLO",
            "nome": "GIOVANNI",
            "sesso": "M",
            "eta": 44,
            "stato": "Dimesso",
            "salaprimotriage": "SALA MEDICA",
            "modalitadimissione": "RIFIUTA RICOVERO/VOLONTARIA",
            "dataaccettazione": "20-07-2017",
            "oraaccettazione": "10:07",
            "datapresaincarico": "20-07-2017",
            "orapresaincarico": "10:29",
            "dataprimarichiesta": "20-07-2017",
            "oraprimarichiesta": "15:03",
            "datainvioinobi": "",
            "orainvioinobi": "",
            "datadimissione": "20-07-2017",
            "oradimissione": "20:03",
            "minutiincaricorichiesta": 274,
            "minutipresaincarico": 22,
            "minutidimissione": 574*/
