using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellsFargo_BusinessEntities.Interfaces
{
    public interface IConnectionFactory
    {
        IDbConnection GetMidLandConnection();

        IDbConnection GetKarvyaConnection();


    }
}
