using AnimalShelter.Core.Domain;

namespace AnimalShelter.Infrastructure.Commands
{
    public class CreateDoctor
    {
        public string Name { set; get; }
        public string SecondName { set; get; }
    }
}
