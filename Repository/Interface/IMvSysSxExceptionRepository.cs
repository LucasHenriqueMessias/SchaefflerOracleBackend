using oracle_backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace oracle_backend.Repository.Interface
{
    public interface IMvSysSxExceptionRepository
    {
        Task<List<MvSysSxException>> ExceptionAPI(); 
        Task<MvSysSxException> SearchByException(string sxCompany );
        Task<MvSysSxException> AddException(MvSysSxException Exception);
        Task<MvSysSxException> UpdateByException(MvSysSxException Exception);
        Task<bool> DeleteByException(string sxCompany);
    }
}
