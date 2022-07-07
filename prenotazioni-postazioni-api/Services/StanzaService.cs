using prenotazione_postazioni_libs.Dto;
using prenotazioni_postazioni_api.Repositories;
using prenotazione_postazioni_libs.Models;

namespace prenotazioni_postazioni_api.Services
{
    public class StanzaService
    {
        private StanzaRepository _stanzaRepository = new StanzaRepository();
        
        /// <summary>
        /// restituisce tutte le stanze presenti nel database
        /// </summary>
        /// <returns>una lista di stanza</returns>
        internal List<Stanza> GetAllStanze()
        {
            return _stanzaRepository.FindAll();
        }

        /// <summary>
        /// restituisce una stanza mediante il suo id associato
        /// </summary>
        /// <param name="id">L'id della stanza</param>
        /// <returns>Stanza trovata, null altrimenti</returns>
        internal Stanza GetStanzaByid(int id)
        {
            return _stanzaRepository.FindById(id);
        }

        /// <summary>
        /// restituisce una stanza mediante il suo nome associato
        /// </summary>
        /// <param name="stanzaName">il nome della stanza da trovare</param>
        /// <returns>stanza trovata, null altrimenti</returns>
        internal Stanza GetStanzaByName(string stanzaName)
        {
            return _stanzaRepository.FindByName(stanzaName);
        }

        /// <summary>
        /// Salva una stanza nel database
        /// </summary>
        /// <param name="stanzaDto">la stanza da salvare</param>
        internal void Save(StanzaDto stanzaDto)
        {
            //TODO da implemenetare
        }
    }
}
