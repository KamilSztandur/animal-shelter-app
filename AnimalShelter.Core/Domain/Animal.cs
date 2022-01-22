namespace AnimalShelter.Core.Domain
{
    public class Animal
    {
        public int Id { set; get; }
        public ShelterBox Box { set; get; }
        public int MainDoctorId { set; get; }
        public string Name { set; get; }
        public bool IsReadyForAdoption { set; get; }
    }
}
