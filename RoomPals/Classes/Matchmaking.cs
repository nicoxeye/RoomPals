using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RoomPals.Classes
{
    public class Matchmaking
    {
        List<Student> allStudents = StudentPersistence.LoadStudents();
        public static List<(Student, int)> FindMatches(Student loggedInUser, List<Student> allStudents)
        {
            if (allStudents == null || loggedInUser == null)
            {
                throw new ArgumentNullException("allStudents or loggedInUser is null.");
            }

            var matches = new List<(Student, int)>();

            foreach (var student in allStudents)
            {
                if (student.Username != loggedInUser.Username) // Avoid matching with oneself
                {
                    int score = CalculateCompatibilityScore(loggedInUser, student);
                    matches.Add((student, score));
                }
            }

            // Sort matches by compatibility score in descending order
            matches = matches.OrderByDescending(m => m.Item2).ToList();

            return matches;
        }

        public static int CalculateCompatibilityScore(Student user, Student other)
        {
            int score = 0;

            if (user.city == other.city) score += 20; // Match in the same city
            if (user.NightOrDay == other.NightOrDay) score += 20; // Same time preference
            if (user.DogOrCat == other.DogOrCat) score += 10; // Same pet preference
            if (user.PartyOrBook == other.PartyOrBook) score += 15; // Same social preference
            if (user.ActiveOrPassive == other.ActiveOrPassive) score += 5; // Similar activity level
            if (user.MainLanguage == other.MainLanguage) score += 15; // Same main language
            if (user.SecondLanguage == other.SecondLanguage) score += 15; // Same secondary language

            return score;
        }

        
    }
}
