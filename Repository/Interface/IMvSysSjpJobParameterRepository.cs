using oracle_backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace oracle_backend.Repository.Interface
{
    public interface IMvSysSjpJobParameterRepository
    {
        Task<List<MvSysSjpJobParameter>> ListParam();
        Task<IEnumerable<MvSysSjpJobParameter>> FilterParam(string SjpProcedureName);
        Task<MvSysSjpJobParameter> GetParam(string SjpProcedureName, string sjpParameterName);
        Task<MvSysSjpJobParameter> PostParam(MvSysSjpJobParameter param);
        Task<MvSysSjpJobParameter> PutParam(MvSysSjpJobParameter param);
        Task<bool> DeleteParam(string SjpProcedureName, string sjpParameterName);
    }
}
