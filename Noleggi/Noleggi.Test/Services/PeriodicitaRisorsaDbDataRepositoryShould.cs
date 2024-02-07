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
    public class PeriodicitaRisorsaDbDataRepositoryShould
    {
        private IPeriodicitaRisorsaRepository repoPR;
        private IRisorsaRepository repoRisorsa;
        private IPeriodicitaRepository repoPeriodicita;

        private void _0_FeedDB()
        {
            if (!repoRisorsa.Get().Any())
            {
                var x = new Risorsa
                {
                    Id = 1,
                    Nome = "MacBook",
                    Categoria = "Informatica"
                };
                repoRisorsa.Insert(x);

                x = new Risorsa
                {
                    Id = 2,
                    Nome = "Iphone 15",
                    Categoria = "Informatica"
                };
                repoRisorsa.Insert(x);

            }
            if (!repoPR.Get().Any())
            {
                var y = new PeriodicitaRisorsa
                {
                    Id = 1,
                    RisorsaId = 1,
                    PeriodicitaId = 1,
                    Costo = 1
                };
                repoPR.Insert(y);
                var x = repoPR.Get();
                y = new PeriodicitaRisorsa
                {
                    Id = 2,
                    RisorsaId = 1,
                    PeriodicitaId = 2,
                    Costo = 10
                };
                repoPR.Insert(y);
            }
        }

        public PeriodicitaRisorsaDbDataRepositoryShould()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("WO" + Guid.NewGuid()).Options;
            AppDbContext dbContext = new AppDbContext(optionsBuilder);
            repoPR = new PeriodicitaRisorsaDbDataRepository(dbContext);
            repoRisorsa = new RisorsaDbDataRepository(dbContext);
            _0_FeedDB();
        }

        [Fact]
        public async Task _1a_GetAsync_ReturnsCountOf2()
        {
            // Assign
            // Act
            //var actual = repoPR.GetAsync().Result;
            var actual = repoPR.Get();
            // Assert
            Assert.Equal(2, actual.Count());
            Assert.Contains(actual, p=> p.Id == 1 && p.RisorsaId == 1 && p.PeriodicitaId == 1 && p.Costo == 1); 
            Assert.Contains(actual, p=> p.Id == 2 && p.RisorsaId == 1 && p.PeriodicitaId == 2 && p.Costo == 10); 
        }

        [Fact]
        public async Task _1b_GetAsync_ReturnsCountOf2()
        {
            // Assign
            // Act
            //var actual = await repoRisorsa.GetAsync();
            var actual = repoRisorsa.Get();
            // Assert
            Assert.Equal(2, actual.Count());
            Assert.Contains(actual, p=> p.Id == 1 && p.Nome == "MacBook" && p.Categoria == "Informatica"); 
            Assert.Contains(actual, p=> p.Id == 2 && p.Nome == "Iphone 15" && p.Categoria == "Informatica"); 
        }

        [Fact]
        public async Task _2_GetRisorsaAsync_ReturnsCountOf1()
        {
            // Act

            var y = new PeriodicitaRisorsa
            {
                Id = 2,
                RisorsaId = 2,
                PeriodicitaId = 3,
                Costo = 100
            };
            repoPR.Insert(y);

            var actual = await repoPR.GetRisorsaAsync(y.RisorsaId);
            // Assert
            Assert.Equal(y, actual.First());
        }

        [Fact]
        public async Task _3_InsertRisorsaAsync_ReturnsCountOf3()
        {
            // Assign
            // Act
            var x = new Risorsa
            {
                Id = 4,
                Nome = "Friggitrice",
                Categoria = "Elettrodomestici"
            };
            repoRisorsa.Insert(x);

            var y = new PeriodicitaRisorsa
            {
                Id = 1,
                RisorsaId = 4,
                PeriodicitaId = 3,
                Costo = 100
            };
            repoPR.Insert(y);
            repoPR.InsertRisorsaAsync(x.Id, repoPeriodicita);

            var expected = x.Id;
            var actual = y.RisorsaId;
            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
