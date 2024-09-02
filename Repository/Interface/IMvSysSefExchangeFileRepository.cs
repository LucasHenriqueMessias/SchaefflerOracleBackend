using oracle_backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace oracle_backend.Repository.Interface
{
    public interface IMvSysSefExchangeFileRepository
    {
        Task<List<MvSysSefExchangeFile>> ListarExchangeFile();
        Task<MvSysSefExchangeFile> AddExchangeFile(MvSysSefExchangeFile exchangeFile);
        Task<MvSysSefExchangeFile> UpdateExchangeFile(MvSysSefExchangeFile exchangeFile);
        Task<MvSysSefExchangeFile> DeleteExchangeFile(MvSysSefExchangeFile exchangeFile);
        Task<MvSysSefExchangeFile> SearchExchangeFile(int SefID);
    }
}
