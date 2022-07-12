
 using Microsoft.AspNetCore.Mvc;
using prenotazioni_postazioni_api.Services;
using prenotazione_postazioni_libs.Models;
using prenotazione_postazioni_libs.Dto;
using prenotazioni_postazioni_api.Exceptions;

namespace prenotazioni_postazioni_api.Controllers
{

    [ApiController]
    [Route("/api/ruoli")]
    public class RuoloController : ControllerBase
    {
        private RuoloService _ruoloService = new RuoloService();
        /// <summary>
        /// Restituisce il ruolo di un utente mediante l'id dell'utente
        /// </summary>
        /// <param name="idUtente">L'id dell'utente per trovare il ruolo associato ad esso</param>
        /// <returns>L'utente trovato con 200, 404 altrimenti</returns>
        [HttpGet]
        [Route("getRuoloUtente")]
        public IActionResult GetRuoloUtenteById(int idRuolo)
        {
            try
            {
                Ruolo ruolo = _ruoloService.GetRuoloById(idRuolo);
                return Ok(ruolo);
            }
            catch (PrenotazionePostazioniApiException ex)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Serve a ottenere il Ruolo di un utente tramite l'id dell'utente
        /// </summary>
        /// <param name="idUtente"></param>
        /// <returns>Il ruolo e stato 200 in caso di ricerca effettuata con successo, 404 altrimenti</returns>
        //[HttpGet]
        //[Route("getRuoloByIdUtente")]
        //public IActionResult GetRuoloUtenteByIdUtente(int idUtente)
        //{
        //    try
        //    {
        //        Ruolo ruolo = _ruoloService.GetRuoloByIdUtente(idUtente);
        //        return Ok(ruolo);
        //    }catch(PrenotazionePostazioniApiException ex)
        //    {
        //        return NotFound();
        //    }
        //}


        //da aggiornare la cors policy, oppure implementare un sistema di accesso

        /// <summary>
        /// Aggiorna il ruolo di un utente dall'admin
        /// </summary>
        /// <param name="utenteAdminDto">L'utente che gli verra aggiornato il ruolo</param>
        /// <returns>Ok, Not Authorized altrimenti</returns>

        //[HttpPost]
        //[Route("updateRuoloUtenteByUtenteId")]
        //public IActionResult UpdateRuoloUtenteByAdminUtenteId([FromBody] UtenteDto utenteDto)
        //{
        //    bool ok = _ruoloService.UpdateRuoloUtenteByAdminUtenteId(utenteDto);
        //    if (ok)
        //    {
        //        return Ok();
        //    }
        //    else
        //    {
        //        return Content("Unauthorized");
        //    }
        //}
    }
}
