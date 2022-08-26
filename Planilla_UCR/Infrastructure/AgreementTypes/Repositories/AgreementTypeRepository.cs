using Domain.Core.Repositories;
using Domain.AgreementTypes.Entities;
using Domain.AgreementTypes.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;


using System.Linq;

namespace Infrastructure.AgreementTypes.Repositories
{
    internal class AgreementTypeRepository : IAgreementTypeRepository
    {
        private readonly AgreementTypeDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public AgreementTypeRepository(AgreementTypeDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }

        public async Task CreateAgreementTypeAsync(AgreementType agreement)

        {
            _dbContext.AgreementTypes.Add(agreement);
            await _dbContext.SaveEntitiesAsync();
        }

        public async Task<IEnumerable<AgreementType?>> GetAllAgreementTypes()
        {
            var agreementTypeList = await _dbContext.AgreementTypes.FromSqlRaw("EXEC GetAllAgreementTypes").ToListAsync();
            return agreementTypeList;
        }

        public async Task<IEnumerable<AgreementType>>? checkAgreementType(string agreementType, int mountPerHour) 
        {
            SqlParameter myAgreementType = new SqlParameter("@AgreementType", agreementType);
            SqlParameter myMountPerHour = new SqlParameter("@MountPerHour", mountPerHour);
            var agreementTypeList = await _dbContext.AgreementTypes.FromSqlRaw("EXEC checkAgreementType {0}, {1}",
                myAgreementType, myMountPerHour).ToListAsync();
            return agreementTypeList;
        }

    }
}
