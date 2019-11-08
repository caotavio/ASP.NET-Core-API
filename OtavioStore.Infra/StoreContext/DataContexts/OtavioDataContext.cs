using System;
using System.Data;
using OtavioStore.Shared;
using Microsoft.Data.SqlClient;

namespace OtavioStore.Infra.DataContexts
{
    public class OtavioDataContext : IDisposable
    {
        public SqlConnection Connection { get; set; }

        public OtavioDataContext()
        {
            Connection = new SqlConnection(Settings.ConnectionString);
            Connection.Open();
        }

        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }
    }
}