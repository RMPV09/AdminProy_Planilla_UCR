using System;

namespace Domain.AgreementTypes.Entities
{
    public class AgreementType
    {
        public String TypeAgreement { get; set; }
        public int MountPerHour { get; set; }

        public AgreementType(string TypeAgreement, int MountPerHour)
        {
            this.TypeAgreement = TypeAgreement;
            this.MountPerHour = MountPerHour;

        }
    }
}
