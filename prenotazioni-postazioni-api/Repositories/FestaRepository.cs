﻿using prenotazione_postazioni_libs.Models;
using Newtonsoft.Json;
using prenotazioni_postazioni_api.Repositories.Database;

namespace prenotazioni_postazioni_api.Repositories
{
    public class FestaRepository
    {
        private readonly ILogger<FestaRepository> logger;

        public FestaRepository(ILogger<FestaRepository> logger)
        {
            this.logger = logger;
        }



        /// <summary>
        /// query al db, restituisce tutte le festa in una data
        /// </summary>
        /// <param name="date">la data</param>
        /// <returns>Lista di Feste</returns>
        internal Festa FindByDate(DateTime date)
        {
            string query = $"SELECT * FROM Feste WHERE giorno = '{date.ToString("yyyy-MM-dd hh:mm:ss:fff")}';";
            return DatabaseManager<Festa>.GetInstance().MakeQueryOneResult(query);
        }
        /// <summary>
        /// query al db, restituisce tutte le festa
        /// </summary>
        /// <returns>Lista di festa</returns>
        internal List<Festa> FindAll()
        {
            string query = $"SELECT * FROM Feste";
            return DatabaseManager<List<Festa>>.GetInstance().MakeQueryMoreResults(query);
        }

        /// <summary>
        /// query al db, salva una festa al database
        /// </summary>
        /// <param name="festa">la festa da salvare</param>
        internal void Save(Festa festa)
        {
            string query = $"INSERT INTO Festa (giorno, descrizione) VALUES ('{festa.Date.ToString("yyyy-MM-dd hh:mm:ss:fff")}', '{festa.Desc})';";
            DatabaseManager<object>.GetInstance().MakeQueryNoResult(query);
        }
    }
}
