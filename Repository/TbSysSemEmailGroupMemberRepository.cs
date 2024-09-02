using Microsoft.EntityFrameworkCore;
using oracle_backend.Models;
using oracle_backend.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

namespace oracle_backend.Repository
{
    public class TbSysSemEmailGroupMemberRepository : ITbSysSemEmailGroupMember
    {
        private readonly ModelContext _context;
        public TbSysSemEmailGroupMemberRepository(ModelContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<TbSysSemEmailGroupMember> Delete(TbSysSemEmailGroupMember member)
        {
            _context.TbSysSemEmailGroupMembers.Remove(member);
            await _context.SaveChangesAsync();
            return member;
        }

        public async Task<List<TbSysSemEmailGroupMember>> GetList()
        {
            var retorno = await _context.TbSysSemEmailGroupMembers.ToListAsync();
            return retorno;
        }

        public async Task<TbSysSemEmailGroupMember> Post(TbSysSemEmailGroupMember member)
        {
            _context.TbSysSemEmailGroupMembers.Add(member);
            await _context.SaveChangesAsync();
            return member;
        }

        public async Task<TbSysSemEmailGroupMember> Put(TbSysSemEmailGroupMember member)
        {
           _context.Entry(member).State = EntityState.Modified;
           await _context.SaveChangesAsync();
           return member;
        }

        public async Task<List<TbSysSemEmailGroupMember>> Select(string semCompany, string semGroupName)
        {
            var retorno = await _context.TbSysSemEmailGroupMembers.Where(e => e.SemCompany == semCompany && e.SemGroupName == semGroupName).ToListAsync(); 
            return retorno;
        }

        public async Task<TbSysSemEmailGroupMember> SelectByMember(string semCompany, string semGroupName, string semGroupMember)
        {
            var retorno = await _context.TbSysSemEmailGroupMembers.Where(e => e.SemCompany == semCompany && e.SemGroupName == semGroupName && e.SemGroupMember == semGroupMember).FirstOrDefaultAsync() ?? throw new Exception("Membro do grupo não encontrado");
            return retorno;
        }
    }
}
