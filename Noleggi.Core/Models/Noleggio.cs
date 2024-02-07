using System.ComponentModel.DataAnnotations;

namespace Noleggi.Core.Models
{
    public class Noleggio : BaseEntity
    {
        public virtual Cliente Cliente { get; set; }
        [Required]
        public int ClienteId { get; set; }

        public virtual Risorsa Risorsa { get; set; }
        [Required]
        public int RisorsaId { get; set; }


        public virtual Periodicita Periodicita { get; set; }
        [Required]
        public int PeriodicitaId { get; set; }


        public double CostoTeorico { get; set; }
        public double CostoEffettivo { get; set; }
        public double CostoTotale { get; set; }


        public DateTime DataRitiro { get; set; }
        public DateTime DataFineNoleggio { get; set; }
        public DateTime DataConsegnaEffettiva { get; set; }

        public string NomeNoleggio { get; set; }

        public Noleggio() 
        {
            DataRitiro = DateTime.Now;
            NomeNoleggio = String.Empty;
            DataConsegnaEffettiva = DataFineNoleggio;
        }
    }
}
