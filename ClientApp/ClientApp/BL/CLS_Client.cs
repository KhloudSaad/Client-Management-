using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace ClientApp.BL
{
    class CLS_Client
    {
        public DataTable GetAllFields()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            //open conn with DB through method open "which in DAL "
            DAL.Open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("GetAllFields", null);
            DAL.Close();
            return dt;

        }
        
        public DataTable GetAllStatus()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            //open conn with DB through method open "which in DAL "
            DAL.Open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("GetAllStatus", null);
            DAL.Close();
            return dt;

        }
        /*public DataTable GetStatus(String status)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@status", SqlDbType.Bit);
            param[0].Value = @status;

            //open conn with DB through method open "which in DAL "
            DAL.Open();
            dt = DAL.SelectData("GetStatus", param);
            DAL.Close();
            return dt;
        }*/
        public DataTable SearchID_Client(String Client_Name)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@Client_Name", SqlDbType.NVarChar, 200);
            param[0].Value = Client_Name;

            //open conn with DB through method open "which in DAL "
            DAL.Open();
            dt = DAL.SelectData("SearchID_Client", param);
            DAL.Close();
            return dt;
        }

            public void Add_Client( String Client_Name, String Client_Number, int Client_FieldID ,int Client_StatusID)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[4];
           

            param[0] = new SqlParameter("@Client_Name", SqlDbType.NVarChar, 200);
            param[0].Value = Client_Name;

            param[1] = new SqlParameter("@Client_Number", SqlDbType.NVarChar, 200);
            param[1].Value = Client_Number;

            param[2] = new SqlParameter("@Client_FieldID", SqlDbType.Int);
            param[2].Value = Client_FieldID;

            param[3] = new SqlParameter("@Client_StatusID", SqlDbType.Int);
            param[3].Value = Client_StatusID;

            DAL.ExecuteCommand("Add_Client", param);
            DAL.Close();
        }

        public DataTable GetAllClients()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            //open conn with DB through method open "which in DAL "
            DAL.Open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("GetAllClients", null);
            DAL.Close();
            return dt;

        }
        public void DeleteClient(int ID)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[0].Value = ID;



            DAL.ExecuteCommand("DeleteClient", param);
            DAL.Close();
        }
        public void UpdateClient(int id, String Client_Name, String Client_Number,
                                     int Client_FieldID,int Client_StatusID)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            param[1] = new SqlParameter("@Client_Name", SqlDbType.NVarChar, 200);
            param[1].Value = Client_Name;

            param[2] = new SqlParameter("@Client_Number", SqlDbType.NVarChar, 200);
            param[2].Value = Client_Number;

            param[3] = new SqlParameter("@Client_FieldID", SqlDbType.Int);
            param[3].Value = Client_FieldID;

            param[4] = new SqlParameter("@Client_StatusID", SqlDbType.Int);
            param[4].Value = Client_StatusID;
            DAL.ExecuteCommand("UpdateClient", param);
            DAL.Close();
        }
    }
    }
