using Noleggi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noleggi.Core.Services
{
    public class RisorsaDbDataRepository : DbDataRepository<AppDbContext, Risorsa>, IRisorsaRepository
    {
        public RisorsaDbDataRepository(AppDbContext ctx) : base(ctx)
        {
        }
        public async override Task<IEnumerable<Risorsa>> GetAsync()
        {
            return (await base.GetAsync()).OrderBy(c => c.Categoria);
        } 
    }
}
