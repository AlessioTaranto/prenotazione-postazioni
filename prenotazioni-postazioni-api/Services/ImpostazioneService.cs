﻿using prenotazioni_postazioni_api.Repositories;
using prenotazione_postazioni_libs.Models;
using prenotazioni_postazioni_api.Exceptions;

namespace prenotazioni_postazioni_api.Services
{
    public class ImpostazioneService
    {
        private ImpostazioneRepository _impostazioneRepository = new ImpostazioneRepository();

        /// <summary>
        /// Restituisce il valore Impostazione Emergenza situato nella tabella Impostazioni nel database.
        /// </summary>
        /// <returns>Valore effettivo dell'impostazione di emergenza. True, o False</returns>
        /// <exception cref="PrenotazionePostazioniApiException"></exception>
        public bool GetImpostazioneEmergenza()
        {
            bool impostazioni= _impostazioneRepository.FindImpostazioneEmergenza();
            if (impostazioni == null) throw new PrenotazionePostazioniApiException("Impostazione di emergenza non trovata");
            else return impostazioni;
        }

        /// <summary>
        /// Aggiorna il campo di Impostazioni Emergenza nel Database con il valore inserito nel primo parametro
        /// </summary>
        /// <param name="userValue">Il valore con cui si aggiornera Impostazioni Emergenza</param>
        /// <returns>Lo stato di Impostazione Emergenza aggiornata</returns>
        public bool ChangeImpostazioniEmergenza()
        {
            if(_impostazioneRepository.FindImpostazioneEmergenza() == true)
            {
                return _impostazioneRepository.UpdateImpostazioneEmergenza(false);
            }
            else
            {
                return _impostazioneRepository.UpdateImpostazioneEmergenza(true);
            }
            
        }
    }
}
