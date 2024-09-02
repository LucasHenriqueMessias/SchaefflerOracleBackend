using Microsoft.EntityFrameworkCore;
using oracle_backend.Models;
using oracle_backend.Repository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace oracle_backend.Repository
{
    public class MvSysSefExchangeFileRepository : IMvSysSefExchangeFileRepository
    {
        private readonly ModelContext _dbContext;
        public MvSysSefExchangeFileRepository(ModelContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<MvSysSefExchangeFile>> ListarExchangeFile()
        {
            var retorno = await _dbContext.MvSysSefExchangeFiles.ToListAsync();
            return retorno;
        }

        public async Task<MvSysSefExchangeFile> AddExchangeFile(MvSysSefExchangeFile ExchangeFile)
        {
            _dbContext.MvSysSefExchangeFiles.Add(ExchangeFile);
            await _dbContext.SaveChangesAsync();
            return ExchangeFile;
        }

        public async Task<MvSysSefExchangeFile> UpdateExchangeFile(MvSysSefExchangeFile exchangeFile)
        {
            _dbContext.Entry(exchangeFile).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return exchangeFile;
        }

        public async Task<MvSysSefExchangeFile> DeleteExchangeFile(MvSysSefExchangeFile exchangeFile)
        {
            _dbContext.Entry(exchangeFile).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
            return exchangeFile;
        }

        public async Task<MvSysSefExchangeFile> SearchExchangeFile(int SefID)
        {
            var exchangefiles = await _dbContext.MvSysSefExchangeFiles.FindAsync(SefID) ?? throw new Exception("Sef ID não encontrado");
            return exchangefiles;

        }


    }
}
