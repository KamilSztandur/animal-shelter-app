using AnimalShelter.Core.Domain;
using System;

namespace AnimalShelter.Infrastructure.Commands
{
    public class CreateMedicalProcedure
    {
        public int DoctorId { set; get; }
        public int AnimalId { set; get; }
        public string ProcedureName { set; get; }
        public string WasSuccess { set; get; }
        public string date { set; get; }
    }
}
