using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Task_Systems.DataAccess.Entities
{
    public class InsurancePolicyViewModel
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string AgentName { get; set; }
        public bool IsActive { get; set; }
    }
}
