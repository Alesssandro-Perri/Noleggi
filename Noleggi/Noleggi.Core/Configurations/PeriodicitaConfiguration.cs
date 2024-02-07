using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Noleggi.Core.Models;

namespace Noleggi.Core.Configurations
{
    public class PeriodicitaConfiguration : IEntityTypeConfiguration<Periodicita>
    {
        public void Configure(EntityTypeBuilder<Periodicita> builder)
        {
            builder.Property(m => m.Durata).IsRequired();
            builder.HasData(
                new Periodicita
                {
                    Id = 1,
                    Durata = "Giornaliera",
                    Giorno = 1
                },
                new Periodicita
                {
                    Id = 2,
                    Durata = "Settimanale",
                    Giorno = 7
                },
                new Periodicita
                {
                    Id = 3,
                    Durata = "Mensile",
                    Giorno = 30
                },
                new Periodicita
                {
                    Id = 4,
                    Durata = "Annuale",
                    Giorno = 360
                }
            );
        }
    }
}
