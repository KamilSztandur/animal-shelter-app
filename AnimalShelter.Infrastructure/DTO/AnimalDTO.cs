namespace AnimalShelter.Infrastructure.DTO
{
    public class AnimalDTO
    {
        public int Id { set; get; }
        public ShelterBoxDTO Box { set; get; }
        public int MainDoctorId { set; get; }
        public string Name { set; get; }
        public bool IsReadyForAdoption { set; get; }
    }
}
