using Domain.Core.Repositories;
using Domain.LegalDeductions.Entities;
using Domain.LegalDeductions.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.LegalDeductions.Repositories
{
    internal class LegalDeductionRepository : ILegalDeductionRepository
    {
        private readonly LegalDeductionDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public LegalDeductionRepository(LegalDeductionDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }

        public async Task<IEnumerable<LegalDeduction>> GetAllAsync()
        {
            IEnumerable<LegalDeduction> legalDeductions = await _dbContext.LegalDeductions.Where(e => e.DeductionName == e.DeductionName).ToListAsync();
            bool flag = true;
            return legalDeductions;
        }
    }
}