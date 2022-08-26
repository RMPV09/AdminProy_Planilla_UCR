using System;

namespace Domain.AgreementTypes.DTOs
{
    public class AgreementTypeDTO
    {
        public String TypeAgreement { get; set; }
        public int MountPerHour { get; set; }

        public AgreementTypeDTO(string TypeAgreement, int MountPerHour)
        {
            this.TypeAgreement = TypeAgreement;
            this.MountPerHour = MountPerHour;
            
        }
    }
}