using System;

namespace AnimalShelter.WebApp.Models
{
    public class MedicalProcedureVM
    {
        public int Id { set; get; }
        public int DoctorId { set; get; }
        public int AnimalId { set; get; }
        public string ProcedureName { set; get; }
        public bool WasSuccess { set; get; }
        public DateTime Date { set; get; }
    }
}
