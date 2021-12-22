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

        public MedicalProcedure ToMedicalProcedure()
        {
            MedicalProcedure medicalProcedure = new MedicalProcedure()
            {
                DoctorId = this.DoctorId,
                AnimalId = this.AnimalId,
                ProcedureName = this.ProcedureName,
                WasSuccess = Boolean.Parse(this.WasSuccess),
                date = DateTime.Parse(date)
            };

            return medicalProcedure;
        }
    }
}
