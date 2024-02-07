using Microsoft.EntityFrameworkCore;
using Noleggi.Core.Models;
using Noleggi.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noleggi.Test.Services
{
    public class ClienteDbDataRepositoryShould
    {
        private IClienteRepository repoCliente;

        private void _0_FeedDB()
        {
            //Inserisco i dati unicamente se è vuota
            if (!repoCliente.Get().Any())
            {
                var x = new Cliente()
                {
                    Id = 1,
                    Nome = "Alessandro",
                    Cognome = "Perri",
                    Indirizzo = "Via Boschina 2, Bedano",
                    DataNascita = DateTime.ParseExact("2005-06-01", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                    Email = "alessandro.perri@samtrevano.ch",
                    Numero = "+41765545772",
                };
                repoCliente.Insert(x);
            }
        }

        public ClienteDbDataRepositoryShould()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("WO" + Guid.NewGuid()).Options;
            AppDbContext dbContext = new AppDbContext(optionsBuilder);
            repoCliente = new ClienteDbDataRepository(dbContext);
            _0_FeedDB();
        }

        [Fact]
        public void _1_Get_ReturnsCountOf1()
        {
            // Assign
            // Act
            int expected = 1;
            int actual = repoCliente.Get().Count();
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void _2_Delete_ReturnsCountOf0()
        {
            // Assign
            // Act
            var wo = repoCliente.Get().First();
            repoCliente.Delete(wo);

            int expected = 0;
            int actual = repoCliente.Get().Count();
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void _3_Insert_ReturnsCountOf2()
        {
            // Assign
            // Act
            var wo = new Cliente()
            {
                Id = 2,
                Nome = "Alessandro",
                Cognome = "Curiale",
                Indirizzo = "Via prova 2, Bioggio",
                DataNascita = DateTime.ParseExact("2004-03-03", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                Email = "alessandro.curiale@samtrevano.ch",
                Numero = "+41795678910",
            };
            repoCliente.Insert(wo);

            int expected = 2;
            int actual = repoCliente.Get().Count();
            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
