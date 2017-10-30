using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DataServiceGenerator.BasicConnectivityClass
{
    interface IBasicConnectivity
    {
        
         void nonQuery(string SQLCommand);
         long QueryScalar(string SQLCommand);
         DataTable QueryDataTable(string SQLCommand);

    }
}