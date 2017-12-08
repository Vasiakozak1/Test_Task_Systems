using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Task_Systems.DataAccess.ViewModels;
using Test_Task_Systems.DataAccess.Entities;
namespace Test_Task_Systems.Mapper
{
    internal static class Mapper
    {
        public static InsurancePolicyViewModel MapPolicy(this DataAccess.Entities.SystemA.InsurancePolicy insurancePolicy)
        {
            if (insurancePolicy == null)
            {
                return null;
            }
            return new InsurancePolicyViewModel
            {
                Guid = insurancePolicy.InsurerGuid,
                Number = insurancePolicy.Number,
                AgentName = insurancePolicy.AgentName,
                IsActive = insurancePolicy.IsActive,
                Beneficiaries = insurancePolicy.Beneficiaries.Select(ben => MapBeneficiary(ben)).ToList(),
                Insurer = MapInsurer(insurancePolicy.Insurer)
            };

        }
        public static InsurancePolicyViewModel MapPolicy(this DataAccess.Entities.SystemB.InsurancePolicy insurancePolicy)
        {
            if (insurancePolicy == null)
            {
                return null;
            }
            return new InsurancePolicyViewModel
            {
                Guid = insurancePolicy.InsurerGuid,
                Number = insurancePolicy.Number,
                DateFrom = insurancePolicy.DateFrom,
                DateTill = insurancePolicy.DateTill,
                Insurer = MapInsurer(insurancePolicy.Insurer)
            };
        }

        public static InsurancePolicyViewModel MapPolicy(this DataAccess.Entities.SystemC.InsurancePolicy insurancePolicy)
        {
            if (insurancePolicy == null)
            {
                return null;
            }
            return new InsurancePolicyViewModel
            {
                Guid = insurancePolicy.InsurerGuid,
                Number = insurancePolicy.Number,
                DateFrom = insurancePolicy.DateFrom,
                DateTill = insurancePolicy.DateTill,
                Beneficiaries = insurancePolicy.Beneficiaries.Select(ben => MapBeneficiary(ben)).ToList(),
                Insurer = MapInsurer(insurancePolicy.Insurer)
            };
        }

        public static BeneficiaryViewModel MapBeneficiary(this DataAccess.Entities.SystemA.Beneficiary beneficiary)
        {
            if (beneficiary == null)
            {
                return null;
            }
            return new BeneficiaryViewModel
            {
                Guid = beneficiary.Guid,
                Name = beneficiary.Name
            };
        }
        public static BeneficiaryViewModel MapBeneficiary(this DataAccess.Entities.SystemC.Beneficiary beneficiary)
        {
            if (beneficiary == null)
            {
                return null;
            }
            return new BeneficiaryViewModel
            {
                Guid = beneficiary.Guid,
                Name = beneficiary.Name
            };
        }
        public static InsurerViewModel MapInsurer(this DataAccess.Entities.SystemA.Insurer insurer)
        {
            if (insurer == null)
            {
                return null;
            }
            return new InsurerViewModel
            {
                Guid = insurer.InsurancePolicyGuid,
                FirstName = insurer.FirstName,
                LastName = insurer.LastName,
                Phone = insurer.Phone              
            };
        }
        public static InsurerViewModel MapInsurer(this DataAccess.Entities.SystemB.Insurer insurer)
        {
            if (insurer == null)
            {
                return null;
            }
            return new InsurerViewModel
            {
                Guid = insurer.InsurancePolicyGuid,
                FirstName = insurer.FirstName,
                LastName = insurer.LastName,
                Phone = insurer.Phone
            };
        }
        public static InsurerViewModel MapInsurer(this DataAccess.Entities.SystemC.Insurer insurer)
        {
            if (insurer == null)
            {
                return null;
            }
            return new InsurerViewModel
            {
                Guid = insurer.InsurancePolicyGuid,
                FirstName = insurer.FirstName,
                LastName = insurer.LastName
            };
        }
    }
}
