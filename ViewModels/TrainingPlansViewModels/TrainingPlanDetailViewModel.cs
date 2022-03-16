using FitnessApi.ViewModels.TrainingDayViewModels;

namespace FitnessApi.ViewModels.TrainingPlansViewModels
{
    public class TrainingPlanDetailViewModel : TrainingPlanIndexViewModel
    {
        //id, name, description uit index

        public IList<TrainingDayIndexViewModel> TrainingDays { get; set; }
    }
}
