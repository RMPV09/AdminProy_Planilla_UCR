using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.LegalDeductions.Entities;
using Domain.LegalDeductions.Repositories;

namespace Application.LegalDeductions.Implementations
{
    internal class LegalDeductionService : ILegalDeductionService
    {
        private readonly ILegalDeductionRepository _legalDeductionRepository;

        public LegalDeductionService(ILegalDeductionRepository legalDeductionRepository)
        {
            _legalDeductionRepository = legalDeductionRepository;
        }

        public Task<IEnumerable<LegalDeduction>> GetAllAsync()
        {
            return _legalDeductionRepository.GetAllAsync();
        }
    }
}