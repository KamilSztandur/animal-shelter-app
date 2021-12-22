namespace AnimalShelter.Infrastructure.DTO
{
    class MedicalProcedureDTO
    {
        int Id { set; get; }
        int DoctorId { set; get; }
        int AnimalId { set; get; }
        string ProcedureName { set; get; }
        bool WasSuccess { set; get; }
    }
}
