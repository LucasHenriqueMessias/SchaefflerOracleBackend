using oracle_backend.Models;
using System.Threading.Tasks;

namespace oracle_backend.Repository.Interface
{
    public interface ITbSysSefExchangeFile
    {
        Task<TbSysSefExchangeFile> Add(TbSysSefExchangeFile exchangeFile);
    }
}
