using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace CurdInWeb.Models
{
    public class StudentDbContext
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public List<Students> GeStudents()
        {
            List<Students> students = new List<Students>();
            SqlConnection con=new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spGetEmployees", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr=cmd.ExecuteReader();
            while (dr.Read()) { 
                Students stu=new Students();
                stu.Id=Convert.ToInt32(dr.GetValue(0).ToString());
                stu.Name=dr.GetValue(1).ToString();
                stu.Department=dr.GetValue(3).ToString();
                stu.Course=dr.GetValue(4).ToString();
                stu.Address=dr.GetValue(5).ToString();
                students.Add(stu);
            }
            con.Close(); 
            return students;  
        }
        public bool AddStudent(Students student)
        {  
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spAddEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.AddWithValue("@name",student.Name);
            cmd.Parameters.AddWithValue("@Department", student.Department);
            cmd.Parameters.AddWithValue("@Course", student.Course);
            cmd.Parameters.AddWithValue("@Address", student.Address);
            con.Open();
            int i=cmd.ExecuteNonQuery();
            con.Close();
            if(i>0)
            {
                return true;
            }
            else 
            { 
                return false; 
            }
        }
   
    }
}