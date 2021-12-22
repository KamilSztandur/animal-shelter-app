using AnimalShelter.Core.Domain;

namespace AnimalShelter.Infrastructure.Commands
{
    public class CreateDoctor
    {
        public string Name { set; get; }
        public string SecondName { set; get; }

        public Doctor ToDoctor()
        {
            Doctor doctor = new Doctor()
            {
                Name = this.Name,
                SecondName = this.SecondName
            };

            return doctor;
        }
    }
}
