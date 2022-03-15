using FitnessApi.DTOs;

namespace FitnessApi.Models
{
    public class Coach : User
    {
        public string Biography { get; set; }
        public IList<Athlete> Athletes { get; set;}

        public Coach()
        {

        }
        public Coach(CoachDTO coach)
        {
            this.Id = coach.Id;
            this.FirstName = coach.FirstName;
            this.LastName = coach.LastName;
            this.Email = coach.Email;
            this.DateOfBirth = coach.DateOfBirth;

            this.Weight = coach.Weight;
            this.Height = coach.Height;

            this.Biography = coach.Biography;

            this.Athletes = new List<Athlete>();

            this.ModifiedOn = coach.ModifiedOn;
            this.ModifiedBy = coach.ModifiedBy;
            this.CreatedBy = coach.CreatedBy;
            this.CreatedOn = coach.CreatedOn;
        }
    }
}
