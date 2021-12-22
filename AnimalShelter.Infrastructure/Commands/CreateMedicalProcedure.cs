using AnimalShelter.Core.Domain;
using System;

namespace AnimalShelter.Infrastructure.Commands
{
    public class CreateMedicalProcedure
    {
        int DoctorId { set; get; }
        int AnimalId { set; get; }
        string ProcedureName { set; get; }
        string WasSuccess { set; get; }
        string date { set; get; }

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
