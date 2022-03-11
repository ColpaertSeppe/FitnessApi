using FitnessApi.DTOs;

namespace FitnessApi.Models { 
    public class TrainingDay
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime TrainingDate { get; set; }

        public TrainingDay() { }
        public TrainingDay(TrainingDayDTO day) 
        { 
            this.Id = day.Id;
            this.Name = day.Name;
            this.Description = day.Description;
            this.TrainingDate = day.TrainingDate;

        }
    }
}
