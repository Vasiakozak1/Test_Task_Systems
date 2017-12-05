using System;
using System.Collections.Generic;
using System.Text;

namespace Test_Task_Systems.DataAccess.Entities
{
    public interface IInsurancePolicy
    {
        int InsurerId { get; set; }
        int Number { get; set; }
        bool IsActive();
        string AgentName { get; set; }
    }
}
