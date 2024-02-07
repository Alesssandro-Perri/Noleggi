using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noleggi.Core.Models
{
    public class Risorsa : BaseEntity
    {
        #region =01=== costanti & statici ======================
        #endregion

        #region =02=== membri & proprietà ======================
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public string Stato { get; set; }
        public virtual List<Noleggio> Noleggi { get; set; }
        public virtual List<PeriodicitaRisorsa> PeriodicitaRisorse { get; set; }
        #endregion

        #region =03=== costruttori =============================
        public Risorsa()
        {
            Nome = string.Empty;
            Categoria = string.Empty;
            Stato = "Disponibile";
        }
        #endregion

        #region =04=== metodi private e aiuto ==================
        #endregion

        #region =05=== metodi public ===========================
        #endregion
    }
}
