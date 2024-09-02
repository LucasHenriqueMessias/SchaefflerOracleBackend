using oracle_backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace oracle_backend.Repository.Interface
{
    public interface ITbSysSemEmailGroupMember
    {
        Task<List<TbSysSemEmailGroupMember>> GetList();
        Task<TbSysSemEmailGroupMember> Post(TbSysSemEmailGroupMember member);
        Task<TbSysSemEmailGroupMember> Put(TbSysSemEmailGroupMember member);
        Task<TbSysSemEmailGroupMember> Delete(TbSysSemEmailGroupMember member);
        Task<List<TbSysSemEmailGroupMember>> Select(string semCompany, string semGroupName);
        Task<TbSysSemEmailGroupMember> SelectByMember(string semCompany, string semGroupName, string semGroupMember);

    }
}
