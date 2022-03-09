namespace FitnessApi.Models { 
    public class TrainingPlan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<TrainingDay> TrainingDays { get; set; }

        //tracking
        public DateTime CreationDate { get; set; }
        //public string ModifiedDate { get; set; }
        //public User CreatedBy { get; set; }
        //public User ModifiedBy { get; set; }

        public TrainingPlan(string name, string description)
        {
            Name = name;
            Description = description;
            TrainingDays = new List<TrainingDay>();

            this.CreationDate = DateTime.Now;
        }

        public TrainingPlan(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
            TrainingDays = new List<TrainingDay>();

            this.CreationDate = DateTime.Now;
        }

    }
}
