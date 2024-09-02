using oracle_backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace oracle_backend.Repository.Interface
{
    public interface IMvSysSjJobRepository
    {
        Task<List<MvSysSjJob>> APISjJob();
        Task<MvSysSjJob> AddJob(MvSysSjJob job);
        Task<MvSysSjJob> UpdateJob(MvSysSjJob job);
        Task<MvSysSjJob> DeleteJob(MvSysSjJob job);
        Task<MvSysSjJob> SearchJob(string ProcedureName);
    }
}
