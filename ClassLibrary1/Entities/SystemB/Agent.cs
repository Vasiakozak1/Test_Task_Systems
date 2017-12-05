﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Task_Systems.DataAccess.Entities.SystemB
{
    public class Agent
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<InsurancePolicy> InsurancePolicies { get; set; }
    }
}
