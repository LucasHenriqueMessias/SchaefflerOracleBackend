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
    public class MvSysSemEmailGroupMemberRepository : IMvSysSemEmailGroupMember
    {
        private readonly ModelContext _context;

        public MvSysSemEmailGroupMemberRepository(ModelContext context)
        {
            _context = context;
        }

        public async Task<MvSysSemEmailGroupMember> Post(MvSysSemEmailGroupMember semMember)
        {
            _context.MvSysSemEmailGroupMembers.Add(semMember);
            await _context.SaveChangesAsync();
            return semMember;
        }

        public async Task<List<MvSysSemEmailGroupMember>> Select(string SemGroupName)
        {
            var retorno = await _context.MvSysSemEmailGroupMembers.Where(e => e.SemGroupName == SemGroupName).ToListAsync();
            return retorno;
        }
    }
}
