using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Infrastructure.Commands
{
    public class CreateAnimal
    {
        int BoxId { set; get; }
        int MainDoctorId { set; get; }
        string Name { set; get; }
        string isReadyForAdoption { set; get; }
    }
}
