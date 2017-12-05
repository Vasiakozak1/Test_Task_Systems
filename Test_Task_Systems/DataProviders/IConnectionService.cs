using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Task_Systems.DataProviders
{
    public interface IConnectionService
    {
        string GetConnectionString();
        void SetCurrentDatabase(string databaseName);
        ICollection<string> GetAvailableDatabases();
    }
}
