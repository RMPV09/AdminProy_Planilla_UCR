using Domain.LegalDeductions.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.LegalDeductions
{
    public interface ILegalDeductionService
    {
        Task<IEnumerable<LegalDeduction>> GetAllAsync();
    }
}