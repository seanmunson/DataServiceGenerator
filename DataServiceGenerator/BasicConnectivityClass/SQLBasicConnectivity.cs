using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataServiceGenerator.BasicConnectivityClass
{
    class SQLBasicConnectivity:Object,IBasicConnectivity
    {
        SqlConnection oDbConn;

        public SQLBasicConnectivity()
        {
            SqlConnection oDbConn;
        }
        public void Connect(string connectstring)
        {
             if (oDbConn!=null)
                {
                    oDbConn.Dispose();
                    oDbConn = null;
                }
             oDbConn = new SqlConnection(connectstring);
                oDbConn.Open();
        }
        private void Close()
        {
            oDbConn.Dispose();
        }   
#region IBasicConnectivity Members

    void nonQuery(string SQLCommandText)
    {
        SqlCommand C = new SqlCommand(SQLCommandText, oDbConn);
        C.ExecuteNonQuery();
    }

    object  QueryScalar(string SQLCommandText)
    {
                object l;
                SqlCommand C = new SqlCommand(SQLCommandText, oDbConn);
                l=C.ExecuteScalar().ToString();
                return l;
    }

    System.Data.DataTable QueryDataTable(string SQLCommand)
    {
 	            DataTable Dt = new DataTable();
                SqlDataAdapter Da = new SqlDataAdapter(SQLCommand, oDbConn);
                Da.Fill(Dt);
                Da.Dispose();
                return Dt;
    }

#endregion

    #region IBasicConnectivity Members

    void IBasicConnectivity.nonQuery(string SQLCommand)
    {
        throw new NotImplementedException();
    }

    long IBasicConnectivity.QueryScalar(string SQLCommand)
    {
        throw new NotImplementedException();
    }

    DataTable IBasicConnectivity.QueryDataTable(string SQLCommand)
    {
        throw new NotImplementedException();
    }

    #endregion
    }
}
