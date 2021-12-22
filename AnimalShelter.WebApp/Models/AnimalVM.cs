namespace AnimalShelter.WebApp.Models
{
    public class AnimalVM
    {
        public int Id { set; get; }
        public int BoxId { set; get; }
        public int MainDoctorId { set; get; }
        public string Name { set; get; }
        public bool IsReadyForAdoption { set; get; }
    }
}
