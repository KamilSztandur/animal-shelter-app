namespace AnimalShelter.Infrastructure.DTO
{
    public class AnimalDTO
    {
        int Id { set; get; }
        int BoxId { set; get; }
        int MainDoctorId { set; get; }
        string Name { set; get; }
        bool isReadyForAdoption { set; get; }
    }
}
