using Microsoft.EntityFrameworkCore;
using Noleggi.Core.Models;

namespace Noleggi.Core.Services
{
    public class NoleggioDbDataRepository : DbDataRepository<AppDbContext, Noleggio>, INoleggioRepository
    {
        public NoleggioDbDataRepository(AppDbContext ctx) : base(ctx)
        {
        }
    }
}
