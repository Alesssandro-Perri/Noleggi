using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Noleggi.Core.Models;

namespace Noleggi.Core.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.Property(m => m.Nome).IsRequired();
            builder.Property(m => m.Cognome).IsRequired();
            builder.Property(m => m.Indirizzo).IsRequired();
            builder.Property(m => m.Email).IsRequired();
            builder.Property(m => m.Numero).IsRequired();

            builder.HasData(
                new Cliente
                {
                    Id = 1,
                    Nome = "Alessandro",
                    Cognome = "Perri",
                    Indirizzo = "Via Boschina 2, Bedano",
                    DataNascita = DateTime.ParseExact("2005-06-01", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                    Email = "alessandro.perri@samtrevano.ch",
                    Numero = "+41765545772",
                },
                new Cliente
                {
                    Id = 2,
                    Nome = "Diego",
                    Cognome = "Muniz",
                    Indirizzo = "Via stazione, Quartino",
                    DataNascita = DateTime.ParseExact("2004-11-18", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                    Email = "diego.muniz@samtrevano.ch",
                    Numero = "+41765349425",
                },
                new Cliente
                {
                    Id = 3,
                    Nome = "Alex",
                    Cognome = "Ierardi",
                    Indirizzo = "Via montagne, Biasca",
                    DataNascita = DateTime.ParseExact("2005-02-02", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                    Email = "alex.ierardi@samtrevano.ch",
                    Numero = "+41794321432",
                },
                new Cliente
                {
                    Id = 4,
                    Nome = "Christian",
                    Cognome = "Monga",
                    Indirizzo = "Via gerra, Bedano",
                    DataNascita = DateTime.ParseExact("2005-12-23", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                    Email = "christian.monga@samtrevano.ch",
                    Numero = "+41791234567",
                },
                new Cliente
                {
                    Id = 5,
                    Nome = "Edoardo",
                    Cognome = "Ratti",
                    Indirizzo = "Via cinquale, Caslano",
                    DataNascita = DateTime.ParseExact("2005-08-13", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                    Email = "edoardo.ratti@samtrevano.ch",
                    Numero = "+41795432100",
                }

            );
        }
    }
}
