using Microsoft.EntityFrameworkCore;
using oracle_backend.Models;
using oracle_backend.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace oracle_backend.Repository
{
    public class QvSysSelExchangeLogRepository : IQvSysSelExchangeLogRepository
    {
        private readonly ModelContext _dbContext;
        public QvSysSelExchangeLogRepository(ModelContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<QvSysSelExchangeLog> AddExchangeLog(QvSysSelExchangeLog ExchangeLog)
        {
            _dbContext.QvSysSelExchangeLogs.Add(ExchangeLog);
            await _dbContext.SaveChangesAsync();
            return ExchangeLog;
        }

        public async Task<bool> DeleteExchangeLog(long SelId)
        {
            QvSysSelExchangeLog exchangeLog = await SearchExchangeLog(SelId) ?? throw new Exception("ID não encontrado para exclusão do Exchange Log");
            _dbContext.QvSysSelExchangeLogs.Remove(exchangeLog);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<QvSysSelExchangeLog>> ListarExchangeLog()
        {
            var retorno = await _dbContext.QvSysSelExchangeLogs.ToListAsync();
            return retorno;
        }

        public async Task<QvSysSelExchangeLog> SearchExchangeLog(long SelId)
        {
            var log = await _dbContext.QvSysSelExchangeLogs.FindAsync(SelId) ?? throw new Exception("Sel Id não encontrado");
            return log;
        }

        public async Task<QvSysSelExchangeLog> UpdateExchangeLog(QvSysSelExchangeLog exchangeLog)
        {
            _dbContext.Entry(exchangeLog).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return exchangeLog;
        }
    }
}
