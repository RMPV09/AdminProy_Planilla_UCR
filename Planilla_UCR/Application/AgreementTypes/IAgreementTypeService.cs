using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.AgreementTypes.Entities;

namespace Application.AgreementTypes
{
    public interface IAgreementTypeService
    {
        Task CreateAgreementTypeAsync(AgreementType agreement);
        Task<IEnumerable<AgreementType>>? GetAllAgreementTypes();
        Task<IEnumerable<AgreementType>>? checkAgreementType(string agreementType, int mountPerHour);

    }
}
