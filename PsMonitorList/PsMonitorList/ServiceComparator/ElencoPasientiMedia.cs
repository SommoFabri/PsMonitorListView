﻿using PsMonitorList.Costants;
using PsMonitorList.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsMonitorList.ServiceComparator
{
    class ElencoPasientiMedia
    {
        private String mediaAttesaVisitaBianco;
        private String mediaAttesaVisitaVerde;
        private String mediaAttesaVisitaGiallo;
        private String mediaAttesaVisitaRosso;

        private String mediaAttesaRefertiBianco;
        private String mediaAttesaRefertiVerde;
        private String mediaAttesaRefertiGiallo;
        private String mediaAttesaRefertiRosso;

        private String mediaAttesaDimissioniBianco;
        private String mediaAttesaDimissioniVerde;
        private String mediaAttesaDimissioniGiallo;
        private String mediaAttesaDimissioniRosso;
        public List<RecordBean> ListaConMedia (List<RecordBean> lista, List<RecordBean> lista1)
        {
            ElencoPasientiBO p = new ElencoPasientiBO();

            mediaAttesaVisitaBianco = p.getMediaVisita(Colori.BIANCO,lista1);
            mediaAttesaVisitaVerde = p.getMediaVisita(Colori.VERDE, lista1);
            mediaAttesaVisitaGiallo = p.getMediaVisita(Colori.GIALLO, lista1);
            mediaAttesaVisitaRosso = p.getMediaVisita(Colori.ROSSO, lista1);

            mediaAttesaDimissioniBianco = p.getMediaDimissioni(Colori.BIANCO, lista1);
            mediaAttesaDimissioniVerde = p.getMediaDimissioni(Colori.VERDE, lista1);
            mediaAttesaDimissioniGiallo = p.getMediaDimissioni(Colori.GIALLO, lista1);
            mediaAttesaDimissioniRosso = p.getMediaDimissioni(Colori.ROSSO, lista1);

            mediaAttesaRefertiBianco = p.getMediaReferti(Colori.BIANCO, lista1);
            mediaAttesaRefertiVerde = p.getMediaReferti(Colori.VERDE, lista1);
            mediaAttesaRefertiGiallo = p.getMediaReferti(Colori.GIALLO, lista1);
            mediaAttesaRefertiRosso = p.getMediaReferti(Colori.ROSSO, lista1);
            
            foreach (var i in lista)
            {
                // implementare direttamente qui modalita dimissione se pasiente è dimesso
                if (i.stato.Equals("Accettato"))
                {
                    string mediaAttesaVisita= "0h 0min";
                    switch (i.colore)
                    {
                        case "Bianco": mediaAttesaVisita = mediaAttesaVisitaBianco;
                            break;
                        case "Verde":
                            mediaAttesaVisita = mediaAttesaVisitaVerde;
                            break;
                        case "Giallo":
                            mediaAttesaVisita = mediaAttesaVisitaGiallo;
                            break;
                        case "Rosso":
                            mediaAttesaVisita = mediaAttesaVisitaRosso;
                            break;
                    };
                    if ( mediaAttesaVisita.Equals("0h 0min"))
                    {
                        i.datapresaincarico = "";

                        i.orapresaincarico = "";
                    }
                    else
                    {
                        i.datapresaincarico = "Non Prima di";
                        //per commit
                        i.orapresaincarico = mediaAttesaVisita;
                    }

                    i.stato = "In Triage";
                }

                if (i.stato.Equals("Dimesso"))
                {
                    //imgPosizioneDimesso = R.drawable.rettangolo_g;
                    string stato = i.modalitadimissione;
                    stato = "RICOVERO IN REPARTO DI DEGENZA".Equals(stato) ? "Ricoverato" : stato;
                    stato = "DIMISSIONE A DOMICILIO".Equals(stato) ? "Dimesso" : stato;
                    stato = "TRASFERIMENTO AD ALTRO ISTITUTO".Equals(stato) ? "Trasferimento ad Altro Istituto" : stato;
                    stato = "DIMISSIONE A STRUTTURE AMBULATORIALI".Equals(stato) ? "Dimesso" : stato;
                    stato = stato.Contains("ABBANDONA") ? "Abbandona" : stato;
                }

                if (i.stato.Equals("In Visita"))
                {
                    string mediaAttesaReferti = "0h 0min";
                    // imgPosizioneAccettato = R.drawable.rettangolo_g;
                    switch (i.colore)
                    {
                        case "Bianco":
                            mediaAttesaReferti = mediaAttesaRefertiBianco;
                            break;
                        case "Verde":
                            mediaAttesaReferti = mediaAttesaRefertiVerde;
                            break;
                        case "Giallo":
                            mediaAttesaReferti = mediaAttesaRefertiGiallo;
                            break;
                        case "Rosso":
                            mediaAttesaReferti = mediaAttesaRefertiRosso;
                            break;
                    };

                    if (mediaAttesaReferti.Equals("0h 0min"))
                    {
                        i.dataprimarichiesta = "";

                        i.oraprimarichiesta = "";
                    }
                    else
                    {
                        i.dataprimarichiesta = "Non Prima di";
                        i.oraprimarichiesta = mediaAttesaReferti;
                    }
                   // imgPosizioneVisita = R.drawable.rettangolo_g;
                }

                if (i.stato.Equals("In Attesa Referto"))
                {
                    string mediaAttesaDimissione = "0h 0min";

                    switch (i.colore)
                    {
                        case "Bianco":
                            mediaAttesaDimissione = mediaAttesaDimissioniBianco;
                            break;
                        case "Verde":
                            mediaAttesaDimissione = mediaAttesaDimissioniVerde;
                            break;
                        case "Giallo":
                            mediaAttesaDimissione = mediaAttesaDimissioniGiallo;
                            break;
                        case "Rosso":
                            mediaAttesaDimissione = mediaAttesaDimissioniRosso;
                            break;
                    };
                    if (mediaAttesaDimissione.Equals("0h 0min"))
                    {
                       i.datadimissione = "";

                        i.oradimissione = "";
                    }
                    else
                    {
                        i.datadimissione = "Non Prima di";
                        i.oradimissione = mediaAttesaDimissione;
                    }

                    //            oraDimissione = mediaAttesaDimissione;
                   // imgPosizioneReferto = R.drawable.rettangolo_g;
                }

                if (i.stato.Equals("In Osservazione OBI"))
                {
                    //imgPosizioneDimesso = R.drawable.rettangolo_g;
                   i. datadimissione = i.datainvioinobi;
                   i. oradimissione = i.orainvioinobi;
                }
            }

            return lista;
        }

    }
}
