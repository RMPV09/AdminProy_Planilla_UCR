using Domain.AgreementTypes.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.AgreementTypes.Repositories
{
    public interface IAgreementTypeRepository
    {
        Task CreateAgreementTypeAsync(AgreementType agreement);

        Task<IEnumerable<AgreementType>>? GetAllAgreementTypes();
        Task<IEnumerable<AgreementType>>? checkAgreementType(string agreementType, int mountPerHour);
    }
}
