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
