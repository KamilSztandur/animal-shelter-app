using AnimalShelter.Core.Domain;
using System;

namespace AnimalShelter.Infrastructure.Commands
{
    public class CreateAnimal
    {
        public int BoxId { set; get; }
        public int MainDoctorId { set; get; }
        public string Name { set; get; }
        public string IsReadyForAdoption { set; get; }
    }
}
