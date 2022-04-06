using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using databaseAccess;
using Microsoft.Data.SqlClient;

namespace Interpro_Business_Logic
{
    public class StudentDLL
    {
        //student content
        public int id{get;set;}

        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Invalid entry")]
        [MaxLength(50, ErrorMessage ="Cannot exceed than 50 Characters")]
        public string firstName { get; set; }

        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Invalid entry")]
        [MaxLength(50, ErrorMessage = "Cannot exceed than 50 Characters")]
        public string lastName { get; set; }
        
        

        private databaseClass dbAccess = new databaseClass();
        public void Add()
        {
            dbAccess.openConnection();
            dbAccess.setSql("INSERT INTO Students (firstName, lastName) VALUES(@fn, @ln)");
            dbAccess.parametersAddFunction("@fn", firstName);
            dbAccess.parametersAddFunction("@ln", lastName);
            dbAccess.executeQuery();
            dbAccess.closeConnection();
        }

        public List<StudentDLL> GetAll()
        {
            List<StudentDLL> list = new List<StudentDLL>();
            dbAccess.openConnection();
            dbAccess.setSql("SELECT * FROM Students");
            SqlDataReader dr = dbAccess.obtainReader();

            while (dr.Read() == true)
            {
                StudentDLL students = new StudentDLL();
                students.id = (int)dr["id"];
                students.firstName = dr["firstName"].ToString();
                students.lastName= dr["lastName"].ToString();
               
                list.Add(students);
            }

            dr.Close();
            dbAccess.closeConnection();
            return list;
        }
        
        public void Edit()
        {
            dbAccess.openConnection();
            dbAccess.setSql("UPDATE Students SET firstName =@fn, lastName=@ln WHERE id=@sid");
            dbAccess.parametersAddFunction("@fn",firstName);
            dbAccess.parametersAddFunction("@ln", lastName);
            dbAccess.parametersAddFunction("@sid", id);
            dbAccess.executeQuery();            
            dbAccess.closeConnection();
        }
        public StudentDLL Get(int id)
        {
            StudentDLL students = new StudentDLL();
            dbAccess.openConnection();
            dbAccess.setSql("SELECT * FROM Students WHERE id = @sid");
            dbAccess.parametersAddFunction("@sid", id);
            SqlDataReader dr = dbAccess.obtainReader();

            if (dr.Read() == true)
            {
                students.id= (int)dr[0];
                students.firstName = dr[1].ToString();
                students.lastName = dr[2].ToString();
              

            }
            dr.Close();
            dbAccess.closeConnection();
            return students;
        }
        public void Delete()
        {
            dbAccess.openConnection();
            dbAccess.setSql("DELETE Students WHERE ID = @sid");
            dbAccess.parametersAddFunction("@sid", id);
            dbAccess.executeQuery();
            dbAccess.closeConnection();
        }
       

    }
}