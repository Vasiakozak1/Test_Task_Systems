using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Task_Systems.DataAccess.ViewModels
{
    public class InsurancePolicyViewModel
    {
        public Guid Guid { get; set; }
        public int Number { get; set; }
        public string AgentName { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTill { get; set; }
        public InsurerViewModel Insurer { get; set; }
        public ICollection<BeneficiaryViewModel> Beneficiaries { get; set; }
    }
}
