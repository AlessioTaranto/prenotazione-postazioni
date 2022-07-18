﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prenotazione_postazioni_libs.Models
{
    public class Festa
    {
        public int IdFestivita { get; set; }
        public DateTime Date { get; set; }
        public string? Desc { get; set; }

        public Exception ModelException;
        public bool IsValid { get; set; } = false;

        public Festa()
        {

        }
        public Festa(DateTime date, string? desc)
        {
            this.Date = date;
            this.Desc = desc;
            this.Validate();
        }
        public Festa(int idFestivita, DateTime date, string? desc)
        {
            IdFestivita = idFestivita;
            Date = date;
            Desc = desc;
            this.Validate();
        }
        public Festa(DateTime date)
        {
            this.Date = date;
            this.Validate();
        }


        private void Validate()
        {
            try
            {
                if (this.Date == null)
                    throw new Exception("Date non puo essere null");
                this.IsValid = true;
            }
            catch (Exception ex)
            {
                this.IsValid = false;
                this.ModelException = ex;
            }

        }
    }
}
