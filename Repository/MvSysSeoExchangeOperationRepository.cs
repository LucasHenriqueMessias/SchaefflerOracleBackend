using Microsoft.EntityFrameworkCore;
using oracle_backend.Models;
using oracle_backend.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace oracle_backend.Repository
{
    public class MvSysSeoExchangeOperationRepository : IMvSysSeoExchangeOperationRepository
    {
        private readonly ModelContext _dbContext;
        public MvSysSeoExchangeOperationRepository(ModelContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MvSysSeoExchangeOperation> AddExchangeOperation(MvSysSeoExchangeOperation exchangeOperation)
        {
            _dbContext.MvSysSeoExchangeOperations.Add(exchangeOperation);
            await _dbContext.SaveChangesAsync();
            return exchangeOperation;
        }

        public async Task<bool> DeleteExchangeOperation(MvSysSeoExchangeOperation exchangeOperation)
        {
            _dbContext.MvSysSeoExchangeOperations.Remove(exchangeOperation);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<MvSysSeoExchangeOperation>> ListarExchangeOperation()
        {
            var retorno = await _dbContext.MvSysSeoExchangeOperations.ToListAsync();
            return retorno;
        }

        public async Task<MvSysSeoExchangeOperation> SearchExchangeOperation(string seoCompany, string SeoSourceHost, string SeoSourceFtpUser, string SeoDestHost, string SeoDestFtpUser, string SeoOperation)
        {
            var exchangeOperation = await _dbContext.MvSysSeoExchangeOperations.FirstOrDefaultAsync(e =>
                                                                                                    e.SeoCompany == seoCompany && 
                                                                                                    e.SeoSourceHost == SeoSourceHost && 
                                                                                                    e.SeoSourceFtpUser == SeoSourceFtpUser && 
                                                                                                    e.SeoDestHost == SeoDestHost && 
                                                                                                    e.SeoDestFtpUser == SeoDestFtpUser && 
                                                                                                    e.SeoOperation == SeoOperation  
                                                                                                    ) ?? throw new Exception("Seo Operation não encontrado");
            return exchangeOperation;
        }

        public async Task<MvSysSeoExchangeOperation> UpdateExchangeOperation(MvSysSeoExchangeOperation exchangeOperation)
        {
            _dbContext.Entry(exchangeOperation).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return exchangeOperation;
        }
    }
}
