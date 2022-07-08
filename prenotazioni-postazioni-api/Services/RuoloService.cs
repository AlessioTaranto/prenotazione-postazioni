using prenotazione_postazioni_libs.Dto;
using prenotazioni_postazioni_api.Repositories;
using prenotazione_postazioni_libs.Models;
using prenotazioni_postazioni_api.Exceptions;

namespace prenotazioni_postazioni_api.Services
{
    public class RuoloService
    {
        private RuoloRepository _ruoloRepository = new RuoloRepository();


        /// <summary>
        /// Restituisce il Ruolo associato all'utente mediante il suo id
        /// </summary>
        /// <param name="idUtente">L'id dell'utente</param>
        /// <returns>Ruolo trovato, null altrimenti</returns>
        /// <exception cref="PrenotazionePostazioniApiException"></exception>
        public Ruolo GetRuoloByUtenteId(int idUtente)
        {
            Ruolo ruolo = _ruoloRepository.FindByUtenteId(idUtente);
            if (ruolo == null) throw new PrenotazionePostazioniApiException("Ruolo utente non trovato");
            else return ruolo;
        }

        public bool UpdateRuoloUtenteByAdminUtenteId(UtenteDto utenteDto)
        {
            
        }
    }
}
