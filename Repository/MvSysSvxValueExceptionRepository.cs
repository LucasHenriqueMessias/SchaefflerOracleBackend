using Microsoft.EntityFrameworkCore;
using oracle_backend.Models;
using oracle_backend.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oracle_backend.Repository
{
    public class MvSysSvxValueExceptionRepository : IMvSysSvxValueExceptionRepository
    {
        private readonly ModelContext _context;

        public MvSysSvxValueExceptionRepository(ModelContext context)
        {
            _context = context;
        }

        public async Task<MvSysSvxValueException> AddValueException(MvSysSvxValueException e)
        {
            _context.MvSysSvxValueExceptions.Add(e);
            await _context.SaveChangesAsync();
            return e;
        }

        public async Task<bool> DeleteValueException(int SvxException)
        {
            MvSysSvxValueException Value = await SearchByValue(SvxException) ?? throw new Exception("Company não encontrada");
            _context.MvSysSvxValueExceptions.Remove(Value);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<MvSysSvxValueException> SearchByValue(int SvxException)
        {
            var exception = await _context.MvSysSvxValueExceptions.FindAsync(SvxException) ?? throw new Exception("svx Company não encontrado");
            return exception;
        }

        public async Task<MvSysSvxValueException> UpdateValueException(MvSysSvxValueException e)
        {
            _context.Entry(e).State = EntityState.Modified;
            await _context.SaveChangesAsync();  
            return e;
        }

        public async Task<List<MvSysSvxValueException>> ValueExceptionAPI(int Skip, int Take)
        {
            Take++;
            Take *= 21;
            var retorno = await _context.MvSysSvxValueExceptions.OrderByDescending(b => b.SvxDatetimeCreated).Take(Take).ToListAsync();
            return retorno;
        }
    }

}
