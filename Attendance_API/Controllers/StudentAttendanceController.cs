using Attendance_API.Models;
using Attendance_API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Attendance_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAttendanceController : ControllerBase
    {
        StudentAttendanceRepository repo = new StudentAttendanceRepository();
        
        [HttpPost]
        public int InsertStudentAttendanceController(StudentClassAttendanceModel studentAttendance)
        {
            int count = repo.Insert_Student_Class_Attendance(studentAttendance);
            return count;
        }
    }
}
