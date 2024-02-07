using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noleggi.Core.Models
{
    public class Periodicita : BaseEntity
    {
        #region =01=== costanti & statici ======================
        #endregion

        #region =02=== membri & proprietà ======================
        public string Durata { get; set; }
        public int Giorno { get; set; }
        public virtual List<PeriodicitaRisorsa> PeriodicitaRisorse { get; set; }
        public virtual List<Noleggio> Noleggi { get; set; }
        #endregion

        #region =03=== costruttori =============================
        public Periodicita()
        {
            Durata = string.Empty;
            Giorno = 0;
        }
        #endregion

        #region =04=== metodi private e aiuto ==================
        #endregion

        #region =05=== metodi public ===========================
        #endregion
    }
}
