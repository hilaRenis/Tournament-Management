using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class Player
    {
        public int Id { get; private set; }

        [Required]
        public string Name { get; private set; }

        public int NationalityId { get; private set; }

        [Required]
        public string Nationality { get; private set; }

        [Required]
        public DateTime DateOfBirth { get; private set; }

        public Team Team { get; private set; }

        public Player() { }

        public Player(int id) 
        {
            Id = id;
        }

        public Player(int id, string name, int nationalityId, string nationality, DateTime dateOfBirth, Team team)
        {
            Id= id;
            SetName(name);
            NationalityId = nationalityId;
            SetNationality(nationality);
            SetAge(dateOfBirth);
            SetTeam(team);
        }

        public Player(int id, string name, int nationalityId, DateTime dateOfBirth, Team team)
        {
            Id = id;
            SetName(name);
            NationalityId = nationalityId;
            SetAge(dateOfBirth);
            SetTeam(team);
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Player name is required");
            Name = name.Trim();
        }

        public void SetNationality(string nationality)
        {
            if (string.IsNullOrWhiteSpace(nationality))
                throw new ArgumentException("Nationality is required");
            Nationality = nationality.Trim();
        }

        public void SetAge(DateTime dateOfBirth)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - dateOfBirth.Year;
            if (dateOfBirth > today.AddYears(-age))
                age--;

            if (age < 17 || age > 99)
                throw new ArgumentException("Age must be between 17 and 99 years old.");

            DateOfBirth = dateOfBirth;
        }

        public void SetTeam(Team team)
        {
            if (team == null)
                throw new ArgumentException("Team is required");
            Team = team;
        }
    }
}
