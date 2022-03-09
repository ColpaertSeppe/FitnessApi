namespace FitnessApi.Models
{
    public class Coach : User
    {
        public string Biography { get; set; }
        public List<Athlete> Athletes { get; set;}

        public Coach(string firstName, string lastName, string email, DateTime dateOfBirth, string biography) : base(firstName, lastName, email, dateOfBirth)
        {
            this.Biography = biography;
            this.Athletes = new();
        }

        public Coach(int id, string firstName, string lastName, string email, DateTime dateOfBirth, string biography) : base(id, firstName, lastName, email, dateOfBirth)
        {
            this.Biography = biography;
            this.Athletes = new();
        }

    }
}
