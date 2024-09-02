using oracle_backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace oracle_backend.Repository.Interface
{
    public interface IMvSysSeoExchangeOperationRepository
    {
        Task<List<MvSysSeoExchangeOperation>> ListarExchangeOperation();
        Task<MvSysSeoExchangeOperation> AddExchangeOperation(MvSysSeoExchangeOperation exchangeOperation);
        Task<MvSysSeoExchangeOperation> UpdateExchangeOperation(MvSysSeoExchangeOperation exchangeOperation);
        Task<bool> DeleteExchangeOperation(MvSysSeoExchangeOperation exchangeOperation);
        Task<MvSysSeoExchangeOperation> SearchExchangeOperation(string seoCompany, string SeoSourceHost, string SeoSourceFtpUser, string SeoDestHost, string SeoDestFtpUser, string SeoOperation);

    }
}
