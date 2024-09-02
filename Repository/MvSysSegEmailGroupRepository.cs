using Microsoft.EntityFrameworkCore;
using oracle_backend.Models;
using oracle_backend.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace oracle_backend.Repository
{
    public class MvSysSegEmailGroupRepository : IMvSysSegEmailGroupRepository
    {
        private readonly ModelContext _dbContext;
        public MvSysSegEmailGroupRepository(ModelContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MvSysSegEmailGroup> AddEmail(MvSysSegEmailGroup emailGroup)
        {
            _dbContext.MvSysSegEmailGroups.Add(emailGroup);
            await _dbContext.SaveChangesAsync();
            return emailGroup;
        }

        public async Task<bool> DeleteEmail(string segGroupName)
        {
            MvSysSegEmailGroup GroupName = await SearchByGroupEmail(segGroupName) ?? throw new Exception("Nome do grupo para exclusão não encontrada");
            _dbContext.MvSysSegEmailGroups.Remove(GroupName);
            await _dbContext.SaveChangesAsync() ;
            return true;
        }

        public async Task<List<MvSysSegEmailGroup>> ListarEmails()
        {
            var retorno = await _dbContext.MvSysSegEmailGroups.ToListAsync();
            return retorno;
        }

        public async Task<MvSysSegEmailGroup> SearchByGroupEmail(string segGroupName)
        {
            var GroupEmail = await _dbContext.MvSysSegEmailGroups.FindAsync(segGroupName) ?? throw new Exception("Group Name não encontrado");
            return GroupEmail;
        }

        public async Task<MvSysSegEmailGroup> UpdateEmail(MvSysSegEmailGroup EmailGroup)
        {
            _dbContext.Entry(EmailGroup).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return EmailGroup;
        }
    }
}
