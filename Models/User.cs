﻿namespace FitnessApi.Models
{
    public class User : Trackable
    {
        public int Id { get; set; } 
        public string FirstName { get; set; }    
        public string LastName { get; set; }  
        public string Email { get; set; }   
        public DateTime DateOfBirth{ get; set; }
        public double Weight { get; set; }
        public int Height { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }

        //tracking
        //public DateTime CreationDate { get; set; }
        //public string ModifiedDate { get; set; }
        //public User CreatedBy { get; set; }
        //public User ModifiedBy { get; set; }

        public User()
        {

        }
        public User(string firstName, string lastName, string email, DateTime dateOfBirth)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.DateOfBirth = dateOfBirth;

            this.
            //this.CreationDate = DateTime.Now;
        }

        public User(int id, string firstName, string lastName, string email, DateTime dateOfBirth)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.DateOfBirth = dateOfBirth;

            //this.CreationDate = DateTime.Now;
        }
    }
}
