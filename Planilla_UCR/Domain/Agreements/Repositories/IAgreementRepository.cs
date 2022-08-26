using Domain.Agreements.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Agreements.Repositories
{
    public interface IAgreementRepository
    {
        Task CreateAgreementAsync(Agreement agreement);
        Task<Agreement?> GetContractee(Agreement agreement);
        Task<Agreement?> GetFirstProjectAgreement(Agreement searchAgreement);
        Task<IList<Agreement>> GetProjectAgreements(string projectName, string employerEmail);
        Task<IEnumerable<Agreement>> GetEmployeeAgreements(string employeeEmail);
        Task<IEnumerable<Agreement>> GetEmployerAgreements(string employerEmail);
        Task<IEnumerable<Agreement?>> GetAllAgreementsByProjectAndEmployer(string projectName, string employerEmail);
        Task DesactivateAgreement(string employeeEmail, string employerEmail, string projectName, string justification);
        Task<IEnumerable<Agreement>>? CheckAgreementTypeOfContractee(Agreement agreement);
        Task<IEnumerable<Agreement>>? CheckIfAgreementIsDesactivated(Agreement agreement);
        Task UpdateAgreementStatus(Agreement agreement);
        Task<IEnumerable<Agreement>>? GetErasableAgreeements(string employeeEmail);
    }
}
