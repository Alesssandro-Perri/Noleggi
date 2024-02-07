using Noleggi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noleggi.Core.Services
{
    public class ClienteDbDataRepository : DbDataRepository<AppDbContext, Cliente>, IClienteRepository
    {
        public ClienteDbDataRepository(AppDbContext ctx) : base(ctx)
        {
        }
        public async override Task<IEnumerable<Cliente>> GetAsync()
        {
            return (await base.GetAsync()).OrderBy(c => c.Nome + c.Cognome);
        }
    }
}
