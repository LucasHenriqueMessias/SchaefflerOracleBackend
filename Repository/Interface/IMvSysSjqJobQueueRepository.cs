using oracle_backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace oracle_backend.Repository.Interface
{
    public interface IMvSysSjqJobQueueRepository
    {
        Task<List<MvSysSjqJobQueue>> APIJobQueues();
        Task<MvSysSjqJobQueue> UpdateQueue(MvSysSjqJobQueue q);
        Task<bool> DeleteQueue(string SjqProcedureName);
        Task<MvSysSjqJobQueue> SearchByProcedureName(string SjqProcedureName);
        Task<MvSysSjqJobQueue> AddQueue(MvSysSjqJobQueue q);
    }
}
