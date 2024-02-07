using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noleggi.Core.Models
{
    public class Cliente : BaseEntity
    {
        #region =01=== costanti & statici ======================
        #endregion

        #region =02=== membri & proprietà ======================
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Indirizzo { get; set; }
        public DateTime DataNascita { get; set; }
        public string Email { get; set; }
        public string Numero { get; set; }
        public virtual List<Noleggio> Noleggi { get; set; }
        #endregion

        #region =03=== costruttori =============================
        public Cliente()
        {
            Nome = string.Empty;
            Cognome = string.Empty;
            Indirizzo = string.Empty;
            Email = string.Empty;
            Numero = string.Empty;
        }
        #endregion

        #region =04=== metodi private e aiuto ==================
        #endregion

        #region =05=== metodi public ===========================
        #endregion
    }
}
