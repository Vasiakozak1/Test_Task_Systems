using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
namespace Test_Task_Systems.DataProviders
{
    public class ConnectionService : IConnectionService
    {
        private ConnectionStringSettingsCollection _connStrings;
        private string _currentConnStr;
        public ConnectionService()
        {
            this._connStrings = ConfigurationManager.ConnectionStrings;
        }

        public ICollection<string> GetAvailableDatabases()
        {
            IList<string> databasesNames = new List<string>();
            for (int i = 0; i < _connStrings.Count; i++) 
            {
                databasesNames.Add(_connStrings[i].Name);
            }
            return databasesNames;
        }


        public string GetConnectionString()
        {
            return this._currentConnStr;
        }

        public void SetCurrentDatabase(string databaseName)
        {
            for (int i = 0; i < _connStrings.Count; i++)
            {
                if (_connStrings[i].Name == databaseName)
                {
                    this._currentConnStr = _connStrings[i].ConnectionString;
                    return;
                }
            }
        }
    }
}