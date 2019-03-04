using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DataBusiness
{
    class Conexion
    {
        #region Variables
        string connetionString = "";
        public string ConnetionString
        { get; set; }
        #endregion
        public SqlConnection con;
        private SqlTransaction tra;

        #region Methods
        public bool OpenConnection()
        {
            try
            {
                con = new SqlConnection(connetionString);
                con.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void CloseConnection()
        {
            try
            {
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void ExecuteQueries(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_);
            cmd.ExecuteNonQuery();
        }
        public SqlDataReader DataReader(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        public object ShowDataInGridView(string Query_)
        {
            SqlDataAdapter dr = new SqlDataAdapter(Query_, connetionString);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            object dataum = ds.Tables[0];
            return dataum;
        }
        public Conexion()
        {
            connetionString = "Data Source=localhost;Initial Catalog=agronegocio_;Integrated Security=True";
            con = new SqlConnection(connetionString);
        }
        public SqlConnection GetConnection()
        {
            return con;
        }
        public SqlTransaction Transaction()
        {
            return tra;
        }
        #endregion
    }
}
