﻿namespace prenotazione_postazioni_mvc.Models
{
    public class ImpostazioniViewModel
    {

        public CapienzaImpostazioniViewModel CapienzaViewModel { get; set; }
        public FestivitaImpostazioniViewModel FestivitaViewModel { get; set; }
        public PresenzeImpostazioniViewModel PresenzeViewModel { get; set; }

        public ImpostazioniViewModel(CapienzaImpostazioniViewModel capienzaViewModel, FestivitaImpostazioniViewModel festivitaViewModel, PresenzeImpostazioniViewModel presenzeViewModel)
        {
            CapienzaViewModel = capienzaViewModel;
            FestivitaViewModel = festivitaViewModel;
            PresenzeViewModel = presenzeViewModel;
        }
    }
}
