using Microsoft.EntityFrameworkCore;
using oracle_backend.Models;
using oracle_backend.Repository.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oracle_backend.Repository
{
    public class TbSysSelExchangeLogRepository : ITbSysSelExchangeLog
    {
        private readonly ModelContext _context;

        public TbSysSelExchangeLogRepository(ModelContext context)
        {
            _context = context;
        }

        public async Task<List<TbSysSelExchangeLog>> GetSysSelExchangeLogAsync(int Skip, int Take)
        {
            Take++;
            Take *= 105;
            var retorno = await _context.TbSysSelExchangeLogs.OrderByDescending(b => b.SelId).Take(Take).ToListAsync();
            return retorno;
        }

        public async Task<List<TbSysSelExchangeLog>> ListarExchangeLog()
        {
            var retorno = await _context.TbSysSelExchangeLogs.ToListAsync();
            return retorno;
        }
    }
}
