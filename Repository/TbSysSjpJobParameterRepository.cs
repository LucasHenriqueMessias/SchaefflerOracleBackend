using Microsoft.EntityFrameworkCore;
using oracle_backend.Models;
using oracle_backend.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oracle_backend.Repository
{
    
    public class TbSysSjpJobParameterRepository : ITbSysSjpJobParameters
    {
        private readonly ModelContext _context;
        public TbSysSjpJobParameterRepository(ModelContext context)
        {
            _context = context;
        }
        public async Task<TbSysSjpJobParameter> Delete(TbSysSjpJobParameter parameter)
        {
            _context.TbSysSjpJobParameters.Remove(parameter);
            await _context.SaveChangesAsync();
            return parameter;
        }

        public async Task<List<TbSysSjpJobParameter>> GetList()
        {
            var retorno = await _context.TbSysSjpJobParameters.ToListAsync();
            return retorno;
        }

        public async Task<TbSysSjpJobParameter> Post(TbSysSjpJobParameter parameter)
        {
            _context.TbSysSjpJobParameters.Add(parameter);
            await _context.SaveChangesAsync();
            return parameter;
        }

        public async Task<TbSysSjpJobParameter> Put(TbSysSjpJobParameter parameter)
        {
            _context.Entry(parameter).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return parameter;
        }

        public async Task<TbSysSjpJobParameter> Select(string SjpProcedureName, string SjpParameterName)
        {
            var retorno = await _context.TbSysSjpJobParameters.Where(e => e.SjpProcedureName == SjpProcedureName && e.SjpParameterName == SjpParameterName).FirstOrDefaultAsync() ?? throw new Exception("Procedure não encontrado TbSysSjpJobRepository");
            return retorno;
        }
        public async Task<List<TbSysSjpJobParameter>> SelectList(string SjpProcedureName)
        {
            var retorno = await _context.TbSysSjpJobParameters.Where(e => e.SjpProcedureName == SjpProcedureName).ToListAsync() ?? throw new Exception("Procedure não encontrado TbSysSjpJobRepository");
            return retorno;
        }
    }
}
