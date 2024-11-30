using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomPals.Classes
{
    public static class StudentData
    {
        public static List<Student> Students = new List<Student>
        {
            new Student("Nikola", "Jamrozy", 19, "IT", "night", "dog", "book", "active", "pl", "esp", "nicoxeye", "nicoxeye@op.pl", "Randompassword1", "myslowice"),
            new Student("Jola", "Majcher", 19, "IT", "night", "dog", "party", "active", "pl", "eng", "yola", "yola@op.pl", "Randompassword1", "chorzow"),
            new Student("Weronika", "Miozga", 20, "IT", "night", "dog", "party", "active", "pl", "eng", "jellix", "jellix@op.pl", "Randompassword1", "katowice"),
            new Student("Julia", "Pawlik", 20, "IT", "night", "cat", "party", "active", "pl", "eng", "judzia", "judzia@op.pl", "Randompassword1", "katowice"),
            new Student("Jakub", "Jamrozy", 25, "Logistics", "night", "cat", "party", "active", "pl", "none", "jamrox", "jamrox@op.pl","Randompassword1", "myslowice")
        };
    }
}
