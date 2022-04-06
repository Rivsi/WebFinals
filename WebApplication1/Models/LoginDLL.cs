using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Interpro_Business_Logic;
using databaseAccess;
using System.ComponentModel.DataAnnotations;

namespace Register
{
    public class LoginDLL
    {
        [Required (ErrorMessage = "Required")]
        public string password { get; set; }
        [Required (ErrorMessage ="Required")]
        public string username { get; set; }
        [EmailAddress (ErrorMessage ="Entry must be in email format")]
        public string email { get; set; }

        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Invalid entry")]
        public string firstName { get; set; }

        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage ="Invalid entry")]
        public string lastName { get; set; }

        private databaseClass dbAccess = new databaseClass();

        public void Add()
        {
            dbAccess.openConnection();
            dbAccess.setSql("INSERT INTO Registration (username, password,email, firstName, lastName) VALUES(@a,@b,@c,@d,@e)");
            dbAccess.parametersAddFunction("@a",username);
            dbAccess.parametersAddFunction("@b", password);
            dbAccess.parametersAddFunction("@c", email);
            dbAccess.parametersAddFunction("@d", firstName);
            dbAccess.parametersAddFunction("@e", lastName);
            dbAccess.executeQuery();
            dbAccess.closeConnection();
        }


        public bool Log()
        {
            string instruct = "SELECT * FROM Registration WHERE username='" + username + "' AND password='" + password + "'";
            dbAccess.openConnection();
            dbAccess.setSql(instruct);
            SqlDataReader dr = dbAccess.obtainReader();
            if (dr.Read() == true)
            {
                return true;
            }
            else
            {
                return false;
            }
       
            dbAccess.closeConnection();
        }



        public void Edit()
        {
            dbAccess.openConnection();
            dbAccess.setSql("UPDATE Registration SET password=@p WHERE username=@username");
            dbAccess.parametersAddFunction("@p", password);
            dbAccess.parametersAddFunction("@username", username);

            dbAccess.executeQuery();
            dbAccess.closeConnection();
        }


       
    }
}
