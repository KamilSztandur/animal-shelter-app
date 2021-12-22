using System;

namespace AnimalShelter.Core.Domain
{
    public class MedicalProcedure
    {
        public int Id { set; get; }
        public int DoctorId { set; get; }
        public int AnimalId { set; get; }
        public string ProcedureName { set; get; }
        public bool WasSuccess { set; get; }
        public DateTime date { set; get; }
    }
}
