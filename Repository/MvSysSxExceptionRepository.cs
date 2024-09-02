using Microsoft.EntityFrameworkCore;
using oracle_backend.Models;
using oracle_backend.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace oracle_backend.Repository
{
    public class MvSysSxExceptionRepository : IMvSysSxExceptionRepository
    {
        private readonly ModelContext _Context;

        public MvSysSxExceptionRepository(ModelContext context)
        {
            _Context = context;
        }

        public async Task<List<MvSysSxException>> ExceptionAPI()
        {
            var retorno = await _Context.MvSysSxExceptions.ToListAsync();
            return retorno;
        }

        public async Task<MvSysSxException> SearchByException(string sxCompany)
        {
            var exception = await _Context.MvSysSxExceptions.FindAsync(sxCompany) ?? throw new Exception("Sx Company não encontrado");
            return exception;
        }

        public async Task<MvSysSxException> AddException(MvSysSxException Exception)
        {
            _Context.MvSysSxExceptions.Add(Exception);
            await _Context.SaveChangesAsync();
            return Exception;
        }
        public async Task<MvSysSxException> UpdateByException(MvSysSxException Exception)
        {
           _Context.Entry(Exception).State = EntityState.Modified;
           await _Context.SaveChangesAsync();
           return Exception;
        }
        public async Task<bool> DeleteByException(string sxCompany)
        {
            MvSysSxException exception = await SearchByException(sxCompany) ?? throw new Exception("company da excessão não encontrada");
            _Context.MvSysSxExceptions.Remove(exception);
            await _Context.SaveChangesAsync();
            return true;
        }
    }
}
