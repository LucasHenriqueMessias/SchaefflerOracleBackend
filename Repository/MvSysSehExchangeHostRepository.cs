using Microsoft.EntityFrameworkCore;
using oracle_backend.Models;
using oracle_backend.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace oracle_backend.Repository
{
    public class MvSysSehExchangeHostRepository : IMvSysSehExchangeHostRepository
    {
        private readonly ModelContext _dbContext;
        public MvSysSehExchangeHostRepository(ModelContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MvSysSehExchangeHost> AddExchangeHost(MvSysSehExchangeHost exchangeHost)
        {
            _dbContext.MvSysSehExchangeHosts.Add(exchangeHost);
            await _dbContext.SaveChangesAsync();
            return exchangeHost;
        }

        public async Task<bool> DeleteExchangeHost(MvSysSehExchangeHost exchangeHost)
        {
            _dbContext.MvSysSehExchangeHosts.Remove(exchangeHost);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<MvSysSehExchangeHost>> ListarExchangeHost()
        {
            var retorno = await _dbContext.MvSysSehExchangeHosts.ToListAsync();
            return retorno;
        }

        public async Task<MvSysSehExchangeHost> SearchExchangeHost(string sehCompany, string sehHost, string sehUsername)
        {
            var exchangeHost = await _dbContext.MvSysSehExchangeHosts.FirstOrDefaultAsync(e => e.SehCompany == sehCompany && 
                                                                                          e.SehHost == sehHost && 
                                                                                          e.SehUsername == sehUsername
                                                                                          ) ?? throw new Exception("Seh Company não encontrado");
            return exchangeHost;
        }

        public async Task<MvSysSehExchangeHost> UpdateExchangeHost(MvSysSehExchangeHost exchangeHost)
        {
            _dbContext.Entry(exchangeHost).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return exchangeHost;
        }
    }
}
