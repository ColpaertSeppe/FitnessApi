using FitnessApi.Models;
using FitnessApi.ViewModels.TrainingPlansViewModels;

namespace FitnessApi.ViewModels.AthletesViewModels
{
    public class AthleteDetailViewModel : AthleteIndexViewModel
    {
        // id, firstName, lastName, DateOfBirth komen uit index
        public string Email { get; set; }
        public double Weight { get; set; }
        public int Height { get; set; }
        public IList<TrainingPlanIndexViewModel> TrainingPlans { get; set; }
    }
}
