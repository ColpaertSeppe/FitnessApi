using FitnessApi.ViewModels.AthletesViewModels;

namespace FitnessApi.ViewModels.CoahesViewModels
{
    public class CoachDetailViewModel : CoachIndexViewModel
    {
        //id, firstname, lastname, dateofbirht komen uit index

        public string Email { get; set; }
        public int Height { get; set; }
        public double Weight { get; set; }
        public string Biography { get; set; }
        public IList<AthleteIndexViewModel> Athletes { get; set; }
    }
}
