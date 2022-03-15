using FitnessApi.DTOs;

namespace FitnessApi.Models { 
    public class TrainingDay : Trackable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime TrainingDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }


        public TrainingDay() { }
        public TrainingDay(TrainingDayDTO day) 
        { 
            this.Id = day.Id;
            this.Name = day.Name;
            this.Description = day.Description;
            this.TrainingDate = day.TrainingDate;

            //tracking
            this.CreatedOn = day.CreatedOn;
            this.CreatedBy = day.CreatedBy;
            this.ModifiedOn = day.ModifiedOn;
            this.ModifiedBy = day.ModifiedBy;

        }
    }
}
