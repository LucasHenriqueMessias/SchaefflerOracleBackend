using Microsoft.EntityFrameworkCore;
using oracle_backend.Models;
using oracle_backend.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;

namespace oracle_backend.Repository
{
    public class MvSysSjpJobParameterRepository : IMvSysSjpJobParameterRepository
    {
        private readonly ModelContext _parameters;
        public MvSysSjpJobParameterRepository(ModelContext dbContext)
        {
            _parameters = dbContext;
        }
        public async Task<bool> DeleteParam(string SjpProcedureName, string sjpParameterName)
        {
            MvSysSjpJobParameter parameter = await GetParam(SjpProcedureName, sjpParameterName) ?? throw new Exception("Procedure name para exclusão não encontrado");
            _parameters.MvSysSjpJobParameters.Remove(parameter);
            return true;
        }

        public async Task<IEnumerable<MvSysSjpJobParameter>> FilterParam(string SjpProcedureName)
        {
            IEnumerable<MvSysSjpJobParameter> param;
            if(!string.IsNullOrEmpty(SjpProcedureName))
            {
                param = await _parameters.MvSysSjpJobParameters.Where(n => n.SjpProcedureName.Contains(SjpProcedureName)).ToListAsync();
            }
            else
            {
                param = await ListParam();
            }
            return param;
        }

        public async Task<MvSysSjpJobParameter> GetParam(string SjpProcedureName, string sjpParameterName)
        {
            var param = await _parameters.MvSysSjpJobParameters.Where(e => e.SjpParameterName == sjpParameterName && e.SjpProcedureName == SjpProcedureName).FirstOrDefaultAsync() ?? throw new Exception("Procedure buscada não encontrada (GetParam)");
            return param;

        }

        public async Task<List<MvSysSjpJobParameter>> ListParam()
        {
            var retorno = await _parameters.MvSysSjpJobParameters.ToListAsync();
            await _parameters.SaveChangesAsync();
            return retorno;
        }

        public async Task<MvSysSjpJobParameter> PostParam(MvSysSjpJobParameter param)
        {
            _parameters.MvSysSjpJobParameters.Add(param);
            await _parameters.SaveChangesAsync();
            return param;
        }

        public async Task<MvSysSjpJobParameter> PutParam(MvSysSjpJobParameter param)
        {
            _parameters.Entry(param).State = EntityState.Modified;
            await _parameters.SaveChangesAsync();
            return param;
        }
    }
}
