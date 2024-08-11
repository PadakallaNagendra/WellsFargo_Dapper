using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WellsFargo.Utilis;
using WellsFargo_BusinessEntities.Entities;
using WellsFargo_BusinessEntities.Interfaces;

namespace WellsFargo_Dapper_RepositoryLayer
{
    public class PerformanceRepository : IPerformanceRepository
    {

        public async Task<List<PgGuarantee>> GetGuaranteeList()
        {
            Log.Information($"GetGuaranteeList Info ProcedureName:{PerformanceGuaranteeProcedures.QueryGuarantee}");
            List<PgGuarantee> result;
            using (IDbConnection conn = _factory.ResourceNetSqlConnection())
            {
                var queryResult = await conn.QueryAsync<PgGuarantee>(PerformanceGuaranteeProcedures.QueryGuarantee, CommandType.StoredProcedure);
                result = queryResult.ToList();
                Log.Information($"GetGuaranteeList result record count:{result.Count}");
                return result;
            }
        }

    }
}
