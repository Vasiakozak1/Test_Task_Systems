using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
namespace Test_Task_Systems.DataProviders
{
    public class ConnectionService : IConnectionService
    {
        public ICollection<string> GetAvailableDatabases()
        {
            IList<string> databasesNames = new List<string>();
            var connStrings = ConfigurationManager.ConnectionStrings;
            for (int i = 0; i < connStrings.Count; i++) 
            {
                databasesNames.Add(connStrings[i].Name);
            }
            return databasesNames;
        }

        private string _currentConnStr;

        public string GetConnectionString()
        {
            throw new NotImplementedException();
        }

        public void SetCurrentDatabase(string databaseName)
        {
            throw new NotImplementedException();
        }
    }
}