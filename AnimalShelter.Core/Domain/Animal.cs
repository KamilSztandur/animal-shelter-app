using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Core.Domain
{
    public class Animal
    {
        int Id { set; get; }
        int BoxId { set; get; }
        int MainDoctorId { set; get; }
        string Name { set; get; }
        bool isReadyForAdoption { set; get; }
    }
}
