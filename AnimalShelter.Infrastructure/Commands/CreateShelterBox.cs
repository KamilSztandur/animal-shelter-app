using AnimalShelter.Core.Domain;

namespace AnimalShelter.Infrastructure.Commands
{
    public class CreateShelterBox
    {
        public int AnimalId { set; get; }

        public ShelterBox ToMedicalProcedure()
        {
            ShelterBox shelterBox = new ShelterBox()
            {
                AnimalId = this.AnimalId
            };

            return shelterBox;
        }
    }
}
