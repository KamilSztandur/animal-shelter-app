using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Core.Domain
{
    public class MedicalProcedure
    {
        int Id { set; get; }
        int DoctorId { set; get; }
        int AnimalId { set; get; }
        string ProcedureName { set; get; }
        bool WasSuccess { set; get; }
    }
}
