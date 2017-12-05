using System;
using System.Collections.Generic;
using System.Text;

namespace Test_Task_Systems.DataAccess.Entities
{
    public interface IInsurer
    {
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}
