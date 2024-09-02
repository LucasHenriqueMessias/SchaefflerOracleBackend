using oracle_backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace oracle_backend.Repository.Interface
{
    public interface IMvSysSemEmailGroupMember
    {
        Task<List<MvSysSemEmailGroupMember>> Select(string semGroupName);
        Task<MvSysSemEmailGroupMember> Post(MvSysSemEmailGroupMember semMember);
    }
}
