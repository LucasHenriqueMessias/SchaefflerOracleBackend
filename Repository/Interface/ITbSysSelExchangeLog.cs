using oracle_backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace oracle_backend.Repository.Interface
{
    public interface ITbSysSelExchangeLog
    {
        Task<List<TbSysSelExchangeLog>> GetSysSelExchangeLogAsync(int Skip, int Take);
        Task<List<TbSysSelExchangeLog>> ListarExchangeLog();
    }
}
