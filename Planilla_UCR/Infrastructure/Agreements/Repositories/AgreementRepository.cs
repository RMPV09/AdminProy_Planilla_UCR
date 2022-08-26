using Domain.Core.Repositories;
using Domain.Agreements.Entities;
using Domain.Agreements.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;


using System.Linq;

namespace Infrastructure.Agreements.Repositories
{
    internal class AgreementRepository : IAgreementRepository
    {
        private readonly AgreementDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public AgreementRepository(AgreementDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }

        public async Task CreateAgreementAsync(Agreement agreement)

        {
            _dbContext.Agreements.Add(agreement);
            await _dbContext.SaveEntitiesAsync();
        }

        public async Task<Agreement?> GetContractee(Agreement agreement)
        {
            IList<Agreement> agreementList = await _dbContext.Agreements.Where
                (e => e.EmployeeEmail == agreement.EmployeeEmail && e.EmployerEmail == agreement.EmployerEmail
                && e.ProjectName == agreement.ProjectName && e.IsEnabled == 1).ToListAsync();
            Agreement myAgreement = null;
            if (agreementList.Length() > 0)
            {
                myAgreement = agreementList.First();
            }
            return myAgreement;
        }

        public async Task<IEnumerable<Agreement?>> GetAllAgreementsByProjectAndEmployer(string projectName, string employerEmail) 
        {
            SqlParameter myProjectName = new SqlParameter("@Project", projectName);
            SqlParameter myEmployerEmail = new SqlParameter("@EmployerEmail", employerEmail);

            var agreementList = await _dbContext.Agreements.FromSqlRaw("EXEC GetAllAgreementsByProjectAndEmployer {0},{1}",
                myProjectName, myEmployerEmail).ToListAsync();
            return agreementList;

        }

        public async Task<IEnumerable<Agreement>> GetEmployeeAgreements(string employeeEmail)
        {
            IList<Agreement> agreementList = await _dbContext.Agreements.Where
                (e => e.EmployeeEmail == employeeEmail && e.IsEnabled == 1).ToListAsync();
            return agreementList;
        }

        public async Task<IEnumerable<Agreement>> GetEmployerAgreements(string employerEmail)
        {
            IList<Agreement> agreementList = await _dbContext.Agreements.Where
                (e => e.EmployerEmail == employerEmail && e.IsEnabled == 1).ToListAsync();
            return agreementList;
        }

        public async Task<Agreement?> GetFirstProjectAgreement(Agreement searchAgreement)
        {
            IEnumerable<Agreement> agreements = await _dbContext.Agreements.Where(e => e.EmployerEmail == searchAgreement.EmployerEmail && e.ProjectName == searchAgreement.ProjectName).OrderBy(a => a.ContractStartDate).ToListAsync();
            Agreement firstAgreement = agreements.FirstOrDefault();
            return firstAgreement;
        }

        public async Task<IList<Agreement>> GetProjectAgreements(string projectName, string employerEmail) 
        {
            IList<Agreement> agreementList = await _dbContext.Agreements.Where
               (e => e.EmployerEmail == employerEmail && e.ProjectName == projectName
               && e.IsEnabled == 1).ToListAsync();
            return agreementList;
        }

        public async Task DesactivateAgreement(string employeeEmail, string employerEmail, string projectName, string justification)
        {
            System.FormattableString query = $"EXECUTE DesactivateAgreement @EmployeeEmail = {employeeEmail},@EmployerEmail = {employerEmail}, @ProjectName = {projectName}, @Justification = {justification}";
            _dbContext.Database.ExecuteSqlInterpolated(query);
        }

        public async Task<IEnumerable<Agreement?>> CheckAgreementTypeOfContractee(Agreement agreement)
        {
            SqlParameter myEmployeeEmail = new SqlParameter("@EmployeeEmail", agreement.EmployeeEmail);
            SqlParameter myEmployerEmail = new SqlParameter("@EmployerEmail", agreement.EmployerEmail);
            SqlParameter myProjectName = new SqlParameter("@ProjectName", agreement.ProjectName);
            SqlParameter myContractType = new SqlParameter("@ContractType", agreement.ContractType);

            var agreementsSalary = await _dbContext.Agreements.FromSqlRaw("EXEC CheckAgreementTypeOfContractee {0},{1},{2},{3}",
                myEmployeeEmail, myEmployerEmail, myProjectName, myContractType).ToListAsync();
            return agreementsSalary;
        }

        public async Task<IEnumerable<Agreement?>> CheckIfAgreementIsDesactivated(Agreement agreement)
        {
            SqlParameter myEmployeeEmail = new SqlParameter("@EmployeeEmail", agreement.EmployeeEmail);
            SqlParameter myEmployerEmail = new SqlParameter("@EmployerEmail", agreement.EmployerEmail);
            SqlParameter myProjectName = new SqlParameter("@ProjectName", agreement.ProjectName);
            var agreementList = await _dbContext.Agreements.FromSqlRaw("EXEC CheckIfAgreementIsDesactivated {0},{1},{2}",
                myEmployeeEmail, myEmployerEmail, myProjectName).ToListAsync();
            return agreementList;
        }

        public async Task UpdateAgreementStatus(Agreement agreement)
        {
            string myEmployeeEmail = agreement.EmployeeEmail;
            string myEmployerEmail = agreement.EmployerEmail;
            string myProjectName =  agreement.ProjectName;
            DateTime? myContractStartDate = agreement.ContractStartDate;
            DateTime? myContractFinishDate = agreement.ContractFinishDate;
            string myContractType = agreement.ContractType;
            int myMountPerHour = agreement.MountPerHour;

            System.FormattableString query = ($@"EXECUTE UpdateAgreementStatus @EmployeeEmail = {myEmployeeEmail},
            @EmployerEmail = {myEmployerEmail}, @ProjectName = {myProjectName}, @ContractStartDate = {myContractStartDate},
            @ContractFinishDate = {myContractFinishDate}, @ContractType = {myContractType}, @MountPerHour = {myMountPerHour}");
            _dbContext.Database.ExecuteSqlInterpolated(query);
        }

        public async Task<IEnumerable<Agreement?>> GetErasableAgreeements(string employeeAgreements)
        {
            SqlParameter myEmployeeEmail = new SqlParameter("@EmployeeEmail", employeeAgreements);
            var agreementList = await _dbContext.Agreements.FromSqlRaw("EXEC GetErasableAgreeements {0}",
                myEmployeeEmail).ToListAsync();
            return agreementList;
        }
       
    }
}
