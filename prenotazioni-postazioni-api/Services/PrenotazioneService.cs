
 using prenotazioni_postazioni_api.Repositories;
using prenotazione_postazioni_libs.Models;
using prenotazione_postazioni_libs.Dto;

 namespace prenotazioni_postazioni_api.Services
 {
     public class PrenotazioneService
     {
         private PrenotazioneRepository _prenotazioneRepository = new PrenotazioneRepository();

         /// <summary>
         /// Trova una Prenotazione dal suo ID nel Database
         /// </summary>
         /// <param name="idPrenotazione">ID Prenotazione da trovare</param>
         /// <returns>Prenotazione trovata, altrimenti null</returns>
         internal Prenotazione GetPrenotazioneById(int idPrenotazione)
         {
             return _prenotazioneRepository.FindById(idPrenotazione);
         }


         /// <summary>
         /// Trova una Prenotazione dall'ID stanza nel Database
         /// </summary>
         /// <param name="idStanza">ID della stanza associata alla Prenotazione da trovare</param>
         /// <returns>Prenotazione trovata, altrimenti null</returns>
         internal Prenotazione GetPrenotazioneByStanza(string idStanza)
         {
             return _prenotazioneRepository.FindByStanza(idStanza);
         }

         /// <summary>
         /// Trova tutte le prenotazioni presenti nel Database
         /// </summary>
         /// <returns>Lista di Prenotazioni trovate nel Database</returns>
         internal List<Prenotazione> GetAllPrenotazioni()
         {
             return _prenotazioneRepository.FindAll();
         }

         /// <summary>
         /// Trova una Prenotazione dall'ID dell'utente associata alla prenotazione stessa
         /// </summary>
         /// <param name="idUtente">ID utente associata alla Prenotazione</param>
         /// <returns>Prenotazione trovata, altrimenti null</returns
         internal Prenotazione GetPrenotazioneByUtente(string idUtente)
         {
             return _prenotazioneRepository.FindByUtente(idUtente);
         }

         /// <summary>
         /// Salva una prenotazione al database
         /// </summary>
         /// <param name="prenotazioneDto">La prenotazione da salvare</param>
         public void Save(PrenotazioneDto prenotazioneDto)
         {
             //salva una prenotazione nel database
         }
     }
 }
