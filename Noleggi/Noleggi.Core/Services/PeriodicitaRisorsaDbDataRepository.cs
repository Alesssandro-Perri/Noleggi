using Noleggi.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Noleggi.Core.Services
{
    public class PeriodicitaRisorsaDbDataRepository : DbDataRepository<AppDbContext, PeriodicitaRisorsa>, IPeriodicitaRisorsaRepository
    {
        public PeriodicitaRisorsaDbDataRepository(AppDbContext ctx) : base(ctx)
        {
        }
        public override async Task<IEnumerable<PeriodicitaRisorsa>> GetAsync()
        {
            var v = await base.GetAsync(includes: v => v.Include(x => x.Periodicita)
                                                        .Include(x => x.Risorsa));
            return v;
        }

        public async Task<IEnumerable<PeriodicitaRisorsa>> GetRisorsaAsync(int risorsaId)
        {
            var x = base.Get().Where(pr => pr.RisorsaId == risorsaId);
            var v = await Task.Run(() => base.Get().Where(pr => pr.RisorsaId == risorsaId));

            return v; 
        }

        public async Task InsertRisorsaAsync(int risorsaId, IPeriodicitaRepository p)
        {
            foreach (var item in await p.GetAsync())
            {
                var pr = new PeriodicitaRisorsa();
                pr.PeriodicitaId = item.Id;
                pr.RisorsaId = risorsaId;
                await base.InsertAsync(pr);
            }
        }
        public override Task<PeriodicitaRisorsa> InsertAsync(PeriodicitaRisorsa entity)
        {
            throw new NotImplementedException();
        }
    }
}
