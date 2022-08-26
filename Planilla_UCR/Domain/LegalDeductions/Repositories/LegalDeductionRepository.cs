using Domain.LegalDeductions.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.LegalDeductions.Repositories
{
    public interface ILegalDeductionRepository
    {
       Task<IEnumerable<LegalDeduction>> GetAllAsync();
    }
}
