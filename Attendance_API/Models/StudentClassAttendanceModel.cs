using Microsoft.OpenApi.Any;
using System.Runtime.Serialization;

namespace Attendance_API.Models
{
    public class StudentClassAttendanceModel
    {
        public int ConductedClass_Id { get; set; }
        public DateTime ConductedClassDate { get; set; }
        public DateTime ConductedTime { get; set; }
        public int Trainer_Id { get; set; }
        public int Subject_Id { get; set; }
        public int Topic_Id { get; set; }
        public List<int>? AttendedStudents { get; set; }
        public int SerialNo { get; set; }
        public int Student_Id { get; set;}


            





    }
}
