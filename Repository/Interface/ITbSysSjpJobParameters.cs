using oracle_backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace oracle_backend.Repository.Interface
{
    public interface ITbSysSjpJobParameters
    {
        Task<List<TbSysSjpJobParameter>> GetList();
        Task<TbSysSjpJobParameter> Post(TbSysSjpJobParameter parameter);
        Task<TbSysSjpJobParameter> Put(TbSysSjpJobParameter parameter);
        Task<TbSysSjpJobParameter> Delete(TbSysSjpJobParameter parameter);
        Task<TbSysSjpJobParameter> Select(string SjpProcedureName, string SjpParameterName);

        Task<List<TbSysSjpJobParameter>> SelectList(string SjpProcedureName);
    }
}
