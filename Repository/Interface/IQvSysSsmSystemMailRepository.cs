using oracle_backend.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace oracle_backend.Repository.Interface
{
    public interface IQvSysSsmSystemMailRepository
    {
        Task<List<QvSysSsmSystemMail>> ListarEmailSistema(int Skip, int Take);
        Task<QvSysSsmSystemMail> AddEmailSistema(QvSysSsmSystemMail Mail);
        Task<QvSysSsmSystemMail> UpdateEmailSistema(QvSysSsmSystemMail Mail);
        Task<QvSysSsmSystemMail> SearchEmailSistema(DateTime SsmSentDatetime);
        Task<bool> DeleteEmailSistema(DateTime SsmSentDatetime);
    }
}
