using Microsoft.EntityFrameworkCore;
using oracle_backend.Models;
using oracle_backend.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace oracle_backend.Repository
{
    public class MvSysSjqJobQueueRepository : IMvSysSjqJobQueueRepository
    {
        private readonly ModelContext _context;

        public MvSysSjqJobQueueRepository(ModelContext context)
        {
            _context = context;
        }

        public async Task<MvSysSjqJobQueue> AddQueue(MvSysSjqJobQueue q)
        {
            _context.MvSysSjqJobQueues.Add(q);
            await _context.SaveChangesAsync();
            return q;
        }

        public async Task<List<MvSysSjqJobQueue>> APIJobQueues()
        {
            var retorno = await _context.MvSysSjqJobQueues.ToListAsync();
            return retorno;
        }

        public async Task<bool> DeleteQueue(string SjqProcedureName)
        {
            MvSysSjqJobQueue ProcName = await SearchByProcedureName(SjqProcedureName) ?? throw new Exception("Nome da Procedure não encontrada para excluir");
            _context.MvSysSjqJobQueues.Remove(ProcName);
            await _context.SaveChangesAsync() ;
            return true;
        }

        public async Task<MvSysSjqJobQueue> SearchByProcedureName(string SjqProcedureName)
        {
            var q = await _context.MvSysSjqJobQueues.FindAsync(SjqProcedureName) ?? throw new Exception("Sjq Procedure Name não encontrado");
            return q;
        }

        public async Task<MvSysSjqJobQueue> UpdateQueue(MvSysSjqJobQueue q)
        {
            _context.Entry(q).State = EntityState.Modified; 
            await _context.SaveChangesAsync();
            return q;
        }
    }
}
