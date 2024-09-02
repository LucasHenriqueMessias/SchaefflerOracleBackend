using oracle_backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace oracle_backend.Repository.Interface
{
    public interface IMvSysSehExchangeHostRepository
    {
        Task<List<MvSysSehExchangeHost>> ListarExchangeHost();
        Task<MvSysSehExchangeHost> AddExchangeHost(MvSysSehExchangeHost exchangeHost);
        Task<MvSysSehExchangeHost> UpdateExchangeHost(MvSysSehExchangeHost exchangeHost);
        Task<bool> DeleteExchangeHost(MvSysSehExchangeHost exchangeHost);
        Task<MvSysSehExchangeHost> SearchExchangeHost(string sehCompany, string sehHost, string sehUsername);
    }
}
