using FitnessApi.Models;

namespace FitnessApi.ViewModels.AthletesViewModels
{
    public class AthleteIndexViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
