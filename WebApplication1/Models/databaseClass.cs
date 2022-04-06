using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interpro_Business_Logic;
using Microsoft.Data.SqlClient;

namespace databaseAccess
{
    class databaseClass
    {
        private const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Riv_VivaciousPhantom\InteproFinals.mdf;Integrated Security=True;Connect Timeout=30";
        SqlConnection cn = new SqlConnection(ConnectionString);
        SqlCommand cm;

        public void openConnection()
        {
            if (cn.State == System.Data.ConnectionState.Closed)
            {
                cn.Open();
            }
        }

        public void closeConnection()
        {
            if (cn.State == System.Data.ConnectionState.Open)
            {
                cn.Close();
            }
        }


        public void setSql(string commandText)
        {
            cm = new SqlCommand();
            cm.Connection = cn;
            cm.CommandText = commandText;
        }

        public void parametersAddFunction(string parameterName, object parameterValue)
        {
          
          
                cm.Parameters.AddWithValue(parameterName, parameterValue);
            

        }

        public void parametersClearFunction()
        {
            cm.Parameters.Clear();
        }

        public void executeQuery()
        {
            cm.ExecuteNonQuery();
        }

        public DataTable RetrieveTable()
        {
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cm;
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            return dataTable;
        }
        public SqlDataReader obtainReader()
        {
            return cm.ExecuteReader();
        }

    }
}
