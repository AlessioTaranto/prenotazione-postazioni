﻿using prenotazione_postazioni_libs.Dto;
using prenotazione_postazioni_libs.Models;
using Newtonsoft.Json;
using prenotazioni_postazioni_api.Exceptions;
using prenotazioni_postazioni_api.Repositories.Database;
using prenotazioni_postazioni_api.Utilities;
using log4net;

namespace prenotazioni_postazioni_api.Repositories
{
    public class ImpostazioneRepository
    {
        private readonly ILog logger = LogManager.GetLogger(typeof(ImpostazioneRepository));

        public ImpostazioneRepository()
        {
        }

        /// <summary>
        /// Query al db per restituire il campo Impostazione Emergenza
        /// </summary>
        /// <returns>Lo stato dell'Impostazione Emergenza</returns>
        public Impostazioni FindImpostazioneEmergenza()
        {
            string query = "SELECT * FROM Impostazioni;";
            return DatabaseManager<Impostazioni>.GetInstance().MakeQueryOneResult(query);
        }

        /// <summary>
        /// Query al db per aggiornare lo stato di Impostazione Emergenza
        /// </summary>
        /// <param name="userValue">valore aggiornato, sostituendo lo stato di Impostazione Emergenza vecchia presente nel Database</param>
        /// <returns>Lo stato di Impostazione Emergenza nuova</returns>
        public void UpdateImpostazioneEmergenza(bool userValue)
        {
            string query = "UPDATE Impostazioni SET modEmergenza = 1 ^ modEmergenza;";
            DatabaseManager<object>.GetInstance().MakeQueryNoResult(query);
        }
    }
}
