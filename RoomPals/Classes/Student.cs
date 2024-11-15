using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomPals.Classes
{
    public class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Major { get; set; }
        public string Sex { get; set; }
        public string City { get; set; }
        public string NightOrDay { get; set; }
        public string DogOrCat { get; set; }
        public string PartyOrBook { get; set; }
        public string ActiveOrPassive { get; set; }
        public string MainLanguage { get; set; }
        public string SecondLanguage { get; set; }

        // New properties for login
        public string Username { get; set; }
        public string Password { get; set; }

        // Constructor to initialize the student object
        public Student(string name, string surname, int age, string major, string sex, string city,
                      string nightOrDay, string dogOrCat, string partyOrBook, string activeOrPassive,
                      string mainLanguage, string secondLanguage, string username, string password)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Major = major;
            Sex = sex;
            City = city;
            NightOrDay = nightOrDay;
            DogOrCat = dogOrCat;
            PartyOrBook = partyOrBook;
            ActiveOrPassive = activeOrPassive;
            MainLanguage = mainLanguage;
            SecondLanguage = secondLanguage;
            Username = username;
            Password = password;
        }

        // Method to authenticate user
        public bool Authenticate(string username, string password)
        {
            return Username == username && Password == password;
        }

        public override string ToString()
        {
            return $"{Name} {Surname}, Age: {Age}, Major: {Major}, Sex: {Sex}, City: {City}, Preferences: {NightOrDay}, {DogOrCat}, {PartyOrBook}, Activity: {ActiveOrPassive}, Languages: {MainLanguage}, {SecondLanguage}";
        }
    }
}
