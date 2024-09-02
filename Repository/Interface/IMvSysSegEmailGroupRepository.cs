using oracle_backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace oracle_backend.Repository.Interface
{
    public interface IMvSysSegEmailGroupRepository
    {
        Task<List<MvSysSegEmailGroup>> ListarEmails();
        Task<MvSysSegEmailGroup> AddEmail(MvSysSegEmailGroup emailGroup);
        Task<MvSysSegEmailGroup> UpdateEmail(MvSysSegEmailGroup EmailGroup);
        Task<bool> DeleteEmail( string segGroupName );
        Task<MvSysSegEmailGroup> SearchByGroupEmail( string segGroupName );
    }
}
