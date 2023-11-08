using Attendance_API.Models;
using System.Data;
using System.Data.SqlClient;

namespace Attendance_API.Repository
{
    public class StudentAttendanceRepository
    {
        public int Insert_Student_Class_Attendance(StudentClassAttendanceModel studentAttendance)
        {
            using(SqlConnection cn = new SqlConnection(Utility.GetConnection()))
            {
                using(SqlCommand cmd = new SqlCommand("Insert_Student_Class_Attendence", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(studentAttendance.ConductedClassDate).Date);
                    cmd.Parameters.AddWithValue("@time", Convert.ToDateTime(studentAttendance.ConductedTime).TimeOfDay);
                    //cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(studentAttendance.ConductedClassDate));
                    //cmd.Parameters.AddWithValue("@time", Convert.ToDateTime(studentAttendance.ConductedTime)) ;
                    cmd.Parameters.AddWithValue("@trainer_id", Convert.ToInt32(studentAttendance.Trainer_Id));
                    cmd.Parameters.AddWithValue("@subject_id", Convert.ToInt32(studentAttendance.Subject_Id));
                    cmd.Parameters.AddWithValue("@topic_id", Convert.ToInt32(studentAttendance.Topic_Id));
                    DataTable attendedStudentsTable = new DataTable();
                    attendedStudentsTable.Columns.Add("Student_Id", typeof(int));

                    foreach (int studentId in studentAttendance.AttendedStudents)
                    {
                        attendedStudentsTable.Rows.Add(studentId);
                    }

                    SqlParameter attendedStudentsParam = cmd.Parameters.AddWithValue("@attendedStudents", attendedStudentsTable);
                    attendedStudentsParam.SqlDbType = SqlDbType.Structured;
                    attendedStudentsParam.TypeName = "udtStudentClassAttendanceList";

                    try
                    {
                        cn.Open();
                        int count = cmd.ExecuteNonQuery();
                        return count;
                    }
                    catch(SqlException ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if(cn.State == ConnectionState.Open)
                        {
                            cn.Close();
                        }
                    }
                   
                }
            }
        }
    }
}
