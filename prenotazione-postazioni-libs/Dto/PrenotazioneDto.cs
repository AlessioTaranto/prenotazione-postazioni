
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prenotazione_postazioni_libs.Dto
{
    public class PrenotazioneDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int IdStanza { get; set; }
        public int IdUtente { get; set; }

        public PrenotazioneDto(DateTime startDate, DateTime endDate, int idStanza, int idUtente)
        {
            StartDate = startDate;
            EndDate = endDate;
            IdStanza = idStanza;
            IdUtente = idUtente;
        }

        public PrenotazioneDto()
        {
        }
    }
}
