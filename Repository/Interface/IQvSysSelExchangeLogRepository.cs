using oracle_backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace oracle_backend.Repository.Interface
{
    public interface IQvSysSelExchangeLogRepository
    {
        Task<List<QvSysSelExchangeLog>> ListarExchangeLog();
        Task<QvSysSelExchangeLog> AddExchangeLog(QvSysSelExchangeLog ExchangeLog);
        Task<QvSysSelExchangeLog> UpdateExchangeLog(QvSysSelExchangeLog exchangeLog);
        Task<QvSysSelExchangeLog> SearchExchangeLog(long SelId);
        Task<bool> DeleteExchangeLog(long SelId);
    }
}
