using oracle_backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace oracle_backend.Repository.Interface
{
    public interface IMvSysSvxValueExceptionRepository
    {
        Task<List<MvSysSvxValueException>> ValueExceptionAPI(int Skip, int Take);
        Task<MvSysSvxValueException> AddValueException(MvSysSvxValueException e);
        Task<MvSysSvxValueException> UpdateValueException(MvSysSvxValueException e);
        Task<bool> DeleteValueException(int SvxException);
        Task<MvSysSvxValueException> SearchByValue(int SvxException);
    }
}
