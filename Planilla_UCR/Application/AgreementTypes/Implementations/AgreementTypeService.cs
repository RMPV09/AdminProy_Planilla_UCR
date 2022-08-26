using Domain.AgreementTypes.Repositories;
using Domain.AgreementTypes.Entities;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Application.AgreementTypes.Implementations
{
    internal class AgreementTypeService : IAgreementTypeService
    {
        private readonly IAgreementTypeRepository _agreementTypeRepository;

        public AgreementTypeService(IAgreementTypeRepository agreementTypeRepository)
        {
            _agreementTypeRepository = agreementTypeRepository;
        }

        public async Task CreateAgreementTypeAsync(AgreementType agreement)
        {
            await _agreementTypeRepository.CreateAgreementTypeAsync(agreement);
        }

        public async Task<IEnumerable<AgreementType>>? GetAllAgreementTypes()
        {
            return await _agreementTypeRepository.GetAllAgreementTypes();
        }

        public async Task<IEnumerable<AgreementType>>? checkAgreementType(string agreementType, int mountPerHour)
        {
            return await _agreementTypeRepository.checkAgreementType(agreementType, mountPerHour);
        }
    }
}
