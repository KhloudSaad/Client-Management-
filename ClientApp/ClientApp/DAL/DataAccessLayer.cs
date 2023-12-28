using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ClientApp.DAL
{
    class DataAccessLayer
    {
        SqlConnection sqlConnection;

        // constructor to build conn
        public DataAccessLayer()
        {
            sqlConnection = new SqlConnection(@"Server=.\SQLEXPRESS; Database=TaskClient; Integrated Security = true");
        }
        // open conn
        public void Open()
        {
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
            }
        }
        // close conn
        public void Close()
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }
        //read data from DB
        public DataTable SelectData(string stored_procedure, SqlParameter[] param)
        {

            SqlCommand sqlcmd = new SqlCommand();  //execute proc
            sqlcmd.CommandType = CommandType.StoredProcedure; //type proc
            sqlcmd.CommandText = stored_procedure;
            sqlcmd.Connection = sqlConnection;

            // if there is one parameter or more -- add it/them
            if (param != null)

            {

                for (int i = 0; i < param.Length; i++)

                {
                    sqlcmd.Parameters.Add(param[i]);
                }
            }
            // exceute sqlcmd
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        //method to DML data from DB
        public void ExecuteCommand(string stored_procedure, SqlParameter[] param)
        {

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = stored_procedure;
            sqlcmd.Connection = sqlConnection;

            // if there is one parameter or more -- add it/them
            if (param != null)

            {
                sqlcmd.Parameters.AddRange(param);
            }
            sqlcmd.ExecuteNonQuery();
        }
    }

}
    
