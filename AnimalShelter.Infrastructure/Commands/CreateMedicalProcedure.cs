using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalShelter.Infrastructure.Commands
{
    public class CreateMedicalProcedure
    {
        int DoctorId { set; get; }
        int AnimalId { set; get; }
        string ProcedureName { set; get; }
        string WasSuccess { set; get; }
        string date { set; get; }
    }
}
