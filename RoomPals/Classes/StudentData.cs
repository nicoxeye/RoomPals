using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomPals.Classes
{
    public static class StudentData
    {
        public static List<Student> Students { get; private set; } = StudentPersistence.LoadStudents();

        public static void AddStudent(Student student)
        {
            Students.Add(student);
            StudentPersistence.SaveStudents(Students);
        }

        /*public static List<Student> Students = new List<Student>
        {
            new Student("Nikola", "Jamrozy", 19, "IT", "night", "dog", "book", "active", "pl", "esp", "nicoxeye", "nicoxeye@op.pl", "Randompassword1", "myslowice"),
            new Student("Jola", "Majcher", 19, "IT", "night", "dog", "party", "active", "pl", "eng", "yola", "yola@op.pl", "Randompassword1", "chorzow"),
            new Student("Weronika", "Miozga", 20, "IT", "night", "dog", "party", "active", "pl", "eng", "jellix", "jellix@op.pl", "Randompassword1", "katowice"),
            new Student("Julia", "Pawlik", 20, "IT", "night", "cat", "party", "active", "pl", "eng", "judzia", "judzia@op.pl", "Randompassword1", "katowice"),
            new Student("Jakub", "Jamrozy", 25, "Logistics", "night", "cat", "party", "active", "pl", "none", "jamrox", "jamrox@op.pl","Randompassword1", "myslowice")
        }; */

        public static void UpdateStudent(Student updatedStudent)
        {
            // find a student by username
            var studentIndex = Students.FindIndex(s => s.Username == updatedStudent.Username);

            if (studentIndex >= 0)
            {
                // update student data
                Students[studentIndex] = updatedStudent;

                // save whole list to json
                StudentPersistence.SaveStudents(Students);
            }
            else
            {
                throw new Exception("Student not found in the database.");
            }
        }
    }
}
