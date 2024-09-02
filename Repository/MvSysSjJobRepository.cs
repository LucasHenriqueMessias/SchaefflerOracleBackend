using Microsoft.EntityFrameworkCore;
using oracle_backend.Models;
using oracle_backend.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace oracle_backend.Repository
{
    public class MvSysSjJobRepository : IMvSysSjJobRepository
    {
        private readonly ModelContext _context;

        public MvSysSjJobRepository(ModelContext context)
        {
            _context = context;
        }

        public async Task<MvSysSjJob> AddJob(MvSysSjJob Sjob)
        {
            _context.MvSysSjJobs.Add(Sjob);
            await _context.SaveChangesAsync();
            return Sjob;
        }

        public async Task<List<MvSysSjJob>> APISjJob()
        {
            var retorno = await _context.MvSysSjJobs.ToListAsync();
            return retorno;
        }


        public async Task<MvSysSjJob> SearchJob(string ProcedureName)
        {
            var job = await _context.MvSysSjJobs.FindAsync(ProcedureName) ?? throw new Exception("Procedure Name não encontrado");
            return job;
        }

        public async Task<MvSysSjJob> UpdateJob(MvSysSjJob job)
        {
            _context.Entry(job).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return job;
        }

       public async Task<MvSysSjJob> DeleteJob(MvSysSjJob job)
        {
            _context.Entry(job).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return job;
        }
    }
}
