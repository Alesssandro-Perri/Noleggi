using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Noleggi.Core.Models;

namespace Noleggi.Core.Configurations
{
    public class PeriodicitaRisorsaConfiguration : IEntityTypeConfiguration<PeriodicitaRisorsa>
    {
        public void Configure(EntityTypeBuilder<PeriodicitaRisorsa> builder)
        {
            builder.HasKey(rcc => new { rcc.RisorsaId, rcc.PeriodicitaId });
            builder.HasData(
               new PeriodicitaRisorsa
               {
                   Id = 1,
                   RisorsaId = 1,
                   PeriodicitaId = 1,
                   Costo = 1
               },
               new PeriodicitaRisorsa
               {
                   Id = 2,
                   RisorsaId = 1,
                   PeriodicitaId = 2,
                   Costo = 10
               },
               new PeriodicitaRisorsa
               {
                   Id = 3,
                   RisorsaId = 1,
                   PeriodicitaId = 3,
                   Costo = 100
               },
               new PeriodicitaRisorsa
               {
                   Id = 4,
                   RisorsaId = 1,
                   PeriodicitaId = 4,
                   Costo = 1000
               },
               new PeriodicitaRisorsa
               {
                   Id = 5,
                   RisorsaId = 2,
                   PeriodicitaId = 1,
                   Costo = 2
               },
               new PeriodicitaRisorsa
               {
                   Id = 6,
                   RisorsaId = 2,
                   PeriodicitaId = 2,
                   Costo = 20
               }
               );
        }
    }
}
