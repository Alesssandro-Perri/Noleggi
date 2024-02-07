using Noleggi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noleggi.Core.Services
{
    public class PeriodicitaDbDataRepository : DbDataRepository<AppDbContext, Periodicita>, IPeriodicitaRepository
    {
        public PeriodicitaDbDataRepository(AppDbContext ctx) : base(ctx)
        {
        }
    }
}
