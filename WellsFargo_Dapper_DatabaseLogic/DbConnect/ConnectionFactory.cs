using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WellsFargo_BusinessEntities.Interfaces;

namespace WellsFargo_Dapper_DatabaseLogic.DbConnect
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IOptions<ConnectConfiguration> _configs;
        public ConnectionFactory(IOptions<ConnectConfiguration> configs) { 
        _configs= configs;
        }
        public IDbConnection GetKarvyaConnection()
        {
            //var constring = _configs.Value.KarvyaSqlConnectionString;
            IDbConnection _connection=new SqlConnection("Data Source=DESKTOP-1R77HQO;Initial Catalog=WellsFargo.EmployeeManagement;Integrated Security=True");
            return _connection;
        }

        public IDbConnection GetMidLandConnection()
        {
            //var constring = _configs.Value.KarvyaSqlConnectionString;
            IDbConnection _connection = new SqlConnection("Data Source=DESKTOP-1R77HQO;Initial Catalog=WellsFargo.EmployeeManagement;Integrated Security=True");
            return _connection;
        }
    }
}
