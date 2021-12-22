using AnimalShelter.Core.Domain;
using System;

namespace AnimalShelter.Infrastructure.Commands
{
    public class CreateAnimal
    {
        public int BoxId { set; get; }
        public int MainDoctorId { set; get; }
        public string Name { set; get; }
        public string isReadyForAdoption { set; get; }

        public Animal ToAnimal()
        {
            Animal animal = new Animal()
            {
                Name = this.Name,
                MainDoctorId = this.MainDoctorId,
                BoxId = this.BoxId,
                isReadyForAdoption = Boolean.Parse(this.isReadyForAdoption)
            };

            return animal;
        }
    }
}
