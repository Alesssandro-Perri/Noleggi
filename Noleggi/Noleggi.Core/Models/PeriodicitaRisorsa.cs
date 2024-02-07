using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noleggi.Core.Models
{
    public class PeriodicitaRisorsa : BaseEntity
    {
        #region =01=== costanti & statici ======================
        #endregion

        #region =02=== membri & proprietà ======================
        public virtual Periodicita Periodicita { get; set; }
        [Required]
        public int PeriodicitaId { get; set; }

        public virtual Risorsa Risorsa { get; set; }
        [Required]
        public int RisorsaId { get; set; }

        public double Costo { get; set; }
        #endregion

        #region =03=== costruttori =============================
        public PeriodicitaRisorsa()
        {
            Costo = 0;
        }
        #endregion

        #region =04=== metodi private e aiuto ==================
        #endregion

        #region =05=== metodi public ===========================
        public override string ToString()
        {
            return "P id: " + PeriodicitaId.ToString() + " - R id: " + RisorsaId.ToString() + " - Costo: " + Costo.ToString();
        }
        #endregion
    }
}
