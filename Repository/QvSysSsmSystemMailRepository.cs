using Microsoft.EntityFrameworkCore;
using oracle_backend.Models;
using oracle_backend.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oracle_backend.Repository
{
    public class QvSysSsmSystemMailRepository : IQvSysSsmSystemMailRepository
    {
        private readonly ModelContext _context;

        public QvSysSsmSystemMailRepository(ModelContext context)
        {
            _context = context;
        }

        public async Task<QvSysSsmSystemMail> AddEmailSistema(QvSysSsmSystemMail Mail)
        {
            _context.QvSysSsmSystemMails.Add(Mail);
            await _context.SaveChangesAsync();
            return Mail;
        }

        public async Task<bool> DeleteEmailSistema(DateTime SsmSentDatetime)
        {
            QvSysSsmSystemMail Mail = await SearchEmailSistema(SsmSentDatetime) ?? throw new Exception("Email para exclusão não encontrado (DeleteEmailSistema)");
            _context.QvSysSsmSystemMails.Remove(Mail);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<QvSysSsmSystemMail>> ListarEmailSistema(int Skip, int Take)
        {
            Take++;
            Take *= 21;
            var retorno = await _context.QvSysSsmSystemMails.Take(Take).ToListAsync();
            return retorno;
        }

        public async Task<QvSysSsmSystemMail> SearchEmailSistema(DateTime SsmSentDatetime)
        {
            var systemMail = await _context.QvSysSsmSystemMails.FindAsync(SsmSentDatetime) ?? throw new Exception("Ssm Sent Datetime não encontrado");
            return systemMail;
        }

        public async Task<QvSysSsmSystemMail> UpdateEmailSistema(QvSysSsmSystemMail Mail)
        {
            _context.Entry(Mail).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Mail;
        }
    }
}
