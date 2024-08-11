using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using WellsFargo_BusinessEntities.Entities;

namespace WellsFargo_BusinessEntities.Interfaces
{
    public interface IPerformanceRepository
    {
        Task<bool> UpdateAccount(int primaryKey, int accountId);

        Task<bool> DeleteAccount(int accountId);

        Task<int> CheckAccount(int accountId);


        Task<bool> SaveAccount(PgAccount pgAccount);
        Task<List<PgAccount>> GetAccounts();
    }
}
