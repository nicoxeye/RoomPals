using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;

namespace RoomPals.Classes
{
    public static class StudentPersistence
    {
        private static string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Database", "students.json");

        // Save all students to file
        public static void SaveStudents(List<Student> students)
        {
            string json = JsonSerializer.Serialize(students);
            File.WriteAllText(filePath, json);
        }

        // Load all students from file
        public static List<Student> LoadStudents()
        {
            if (!File.Exists(filePath))
            {
                return new List<Student>();
            }

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Student>>(json) ?? new List<Student>();
        }

        public static void AddStudent(Student newStudent)
        {
            // Load the existing students from the file
            List<Student> students = LoadStudents();

            // Add the new student to the list
            students.Add(newStudent);

            // Save the updated list back to the file
            SaveStudents(students);
        }
    }
}
