using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DataBusiness
{
    //Click on "view" -> SQL Server Object Explorer.
    //if the name of your server exists there, right click on it and properties.
    //if the name of the server does not exist, "Add SQL Server".
    // chose DB and click "connect" your database will appear in SQL Server Object Explorer.
    //right click on your DB name and choose "Property".
    //in property options, copy connections string.
   public class Connexion
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
        public Connexion()
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
