using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Noleggi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noleggi.Core.Configurations
{
    public class RisorsaConfiguration : IEntityTypeConfiguration<Risorsa>
    {
        public void Configure(EntityTypeBuilder<Risorsa> builder)
        {
            builder.Property(m => m.Nome).IsRequired();
            builder.Property(m => m.Categoria).IsRequired();
            builder.Property(m => m.Stato).IsRequired();

            builder.HasData(
                new Risorsa
                {
                    Id = 1,
                    Nome = "MacBook",
                    Categoria = "Informatica"
                },
                new Risorsa
                {
                    Id = 2,
                    Nome = "Iphone 15",
                    Categoria = "Informatica"
                },
                new Risorsa
                {
                    Id = 3,
                    Nome = "Aspirapolvere - Dyson",
                    Categoria = "Elettrodomestici"
                },
                new Risorsa
                {
                    Id = 4,
                    Nome = "Friggitrice",
                    Categoria = "Elettrodomestici"
                },
                new Risorsa
                {
                    Id = 5,
                    Nome = "Controller PS5",
                    Categoria = "Gaming"
                }
            );
        }
    }
}
