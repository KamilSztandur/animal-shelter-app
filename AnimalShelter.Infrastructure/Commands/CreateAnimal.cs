using AnimalShelter.Core.Domain;
using System;

namespace AnimalShelter.Infrastructure.Commands
{
    public class CreateAnimal
    {
        int BoxId { set; get; }
        int MainDoctorId { set; get; }
        string Name { set; get; }
        string isReadyForAdoption { set; get; }

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
