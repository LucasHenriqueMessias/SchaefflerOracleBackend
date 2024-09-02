using Microsoft.EntityFrameworkCore;
using oracle_backend.Models;
using oracle_backend.Repository.Interface;
using System.Threading.Tasks;

namespace oracle_backend.Repository
{
    public class TbSysSefExchangeFileRepository : ITbSysSefExchangeFile
    {
        private readonly ModelContext _dbContext;
        public TbSysSefExchangeFileRepository(ModelContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TbSysSefExchangeFile> Add(TbSysSefExchangeFile exchangeFile)
        {
            _dbContext.TbSysSefExchangeFiles.Add(exchangeFile);
            await _dbContext.SaveChangesAsync();
            return exchangeFile;
        }

        
    }
}
