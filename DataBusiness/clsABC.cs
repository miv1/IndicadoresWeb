namespace DataBusiness
{
    using ExcelDataReader;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;


    public class clsABC
    {
        internal Connexion connection = new Connexion();

        #region Safra
 public void SaveSafra(string descricao, string data)
        {
            //ABM
            try
            {
                if (connection.OpenConnection())
                {
                    SqlCommand cmd = new SqlCommand("SaveSafra", connection.GetConnection());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@descrição", SqlDbType.VarChar).Value = "dd";
                    cmd.Parameters.Add("@data", SqlDbType.VarChar).Value = "";
                    // dataGridView1.datasource = ClassObject.ShowDataInGridView("Select * From Student")
                    cmd.ExecuteNonQuery();
                    //connection.ExecuteQueries();
                    SqlDataAdapter ada = new SqlDataAdapter(cmd);
                }
            }
            catch (Exception ex)
            { }
        }
   public Safra GetSafrabyId(int id)
        {
            Safra safra = new Safra();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("GetSafrabyId", connection.GetConnection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("Id", SqlDbType.Int).Value = id;
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                ada.Fill(dt);
                safra.Id = Convert.ToInt32(dt.Rows[0]["Id"].ToString());
                safra.Descrição = dt.Rows[0]["Descrição"].ToString();
                safra.Data = dt.Rows[0]["Data"].ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
            return safra;
        }
        public Safra GetSafrabyNome(string nome)
        {
            Safra safra = new Safra();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("GetSafrabyName", connection.GetConnection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("descrição", SqlDbType.VarChar).Value = nome;
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                ada.Fill(dt);
                safra.Id = Convert.ToInt32(dt.Rows[0]["Id"].ToString());
                safra.Descrição = dt.Rows[0]["Descrição"].ToString();
                safra.Data = dt.Rows[0]["Data"].ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
            return safra;
        }
        public DataTable GetSafra()
        {
            //SELECT
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("GetSafra", connection.GetConnection());
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                ada.Fill(dt);
            }
            catch (Exception ex)
            {
                throw;
            }
            return dt;
        }

        public int GetIdSafrabyNome(string safr)
        {
            //SELECT
            int safra = 0;
            DataSet tabla = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("GetSafrabyName", connection.GetConnection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@descrição", SqlDbType.VarChar).Value = safr;
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                ada.Fill(tabla);
                if (tabla.Tables[0].Rows.Count > 0)
                {
                    safra = Convert.ToInt32(tabla.Tables[0].Rows[0][0].ToString());
                }
                else
                    safra = 0;
            }
            catch (Exception)
            {
                throw;
            }
            return safra;
        }


        #endregion
        #region Indicador
    public bool SaveIndicador(decimal valor, int idProducto, int idSafra, int idVetor, int idCooperativa)
        {
            //ABM
            try
            {
                if (connection.OpenConnection())
                {
                    SqlCommand cmd = new SqlCommand("SaveIndicador", connection.GetConnection());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@idProduto", SqlDbType.Int).Value = idProducto;
                    cmd.Parameters.Add("@idSafra", SqlDbType.Int).Value = idSafra;
                    cmd.Parameters.Add("@idVetor", SqlDbType.Int).Value = idVetor;
                    cmd.Parameters.Add("@idCooperativa", SqlDbType.Int).Value = idCooperativa;
                    cmd.Parameters.Add("@quantidade", SqlDbType.Decimal).Value = valor;
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter ada = new SqlDataAdapter(cmd);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

     
        public DataTable GetIndicador(int idSafra, int idProduto, int idCooperativa)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("GetIndicador", connection.GetConnection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@idSafra", SqlDbType.Int).Value = idSafra;
                cmd.Parameters.Add("@idProduto", SqlDbType.Int).Value = idProduto;
                cmd.Parameters.Add("@idCooperativa", SqlDbType.Int).Value = idCooperativa;
                SqlDataAdapter dat = new SqlDataAdapter(cmd);
                dat.Fill(dt);
            }
            catch (Exception ex)
            {
                throw;
            }
            return dt;
        }

        public DataSet GetIndicador(string name)
        {
          FileStream stream;
            try
            {
               stream = File.Open(name, FileMode.Open, FileAccess.Read);
                IExcelDataReader reader;
                reader = ExcelDataReader.ExcelReaderFactory.CreateReader(stream);
                ExcelDataSetConfiguration conf = new ExcelDataSetConfiguration();
                var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = true
                    }
                });
                stream.Close();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
           
           
        }

        #endregion
        #region Cooperativa
  public Cooperativa GetCooperativobyNome(string nombre)
        {
            //SELECT
            DataTable dt = new DataTable();
                Cooperativa cooperativa = new Cooperativa();
            try
            {
                SqlCommand cmd = new SqlCommand("GetCooperativabyName", connection.GetConnection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = nombre;
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                ada.Fill(dt);
                if (dt.Columns.Count > 0)
                {
                    cooperativa.Nome = dt.Rows[0]["Nome"].ToString();
                    cooperativa.Endereço = dt.Rows[0]["Endereço"].ToString();
                    cooperativa.Id = Convert.ToInt32( dt.Rows[0]["Id"]);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return cooperativa;
        }
        public Cooperativa GetCooperativobyId(int id)
        {
            //SELECT
            DataTable dt = new DataTable();
           Cooperativa cooperativa = new Cooperativa();
            try
            {
                SqlCommand cmd = new SqlCommand("GetCooperativabyId", connection.GetConnection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                ada.Fill(dt);
                if (dt.Columns.Count > 0)
                {
                    cooperativa.Nome = dt.Rows[0]["Nome"].ToString();
                    cooperativa.Endereço = dt.Rows[0]["Endereço"].ToString();
                    cooperativa.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return cooperativa;
        }
        public DataTable GetCooperativa()
        {
            DataTable dt= new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("GetCooperativa", connection.GetConnection());
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter dat = new SqlDataAdapter(cmd);
                dat.Fill(dt);
            }
            catch (Exception)
            {
                throw;
            }
            return dt;
        }
      
        #endregion

        public Produto GetProdutobyId(int idproduto)
        {
            //SELECT
            Produto produto = new Produto();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("GetProductbyId", connection.GetConnection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = idproduto;
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                ada.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    produto.Id = Convert.ToInt32(dt.Rows[0]["Id"].ToString());
                    produto.Nome = Convert.ToString(dt.Rows[0]["Nome"].ToString());
                    produto.Descrição = Convert.ToString(dt.Rows[0]["Descrição"].ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }
            return produto;
        }

        public Produto GetProduto(string produton)
        {
            //SELECT
            Produto produto = new Produto();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("GetProductbyName", connection.GetConnection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = produton;
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                ada.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    produto.Id = Convert.ToInt32(dt.Rows[0]["Id"].ToString());
                    produto.Nome = Convert.ToString(dt.Rows[0]["Nome"].ToString());
                    produto.Descrição = Convert.ToString(dt.Rows[0]["Descrição"].ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }
            return produto;
        }

        public DataTable GetProduto()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("GetProduct", connection.GetConnection());
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter dat = new SqlDataAdapter(cmd);
                dat.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

      
        public int GetPropriedadeByNome(string nome)
        {
            //SELECT
            int propriedad = 0;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("GetPropriedadebyName", connection.GetConnection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = nome;
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                ada.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                    propriedad = Convert.ToInt32(ds.Tables[0].Rows[0]["Id"].ToString());
            }
            catch (Exception ex)
            {
                throw;
            }
            return propriedad;
        }

        public Propriedade GetPropriedadebyId(int id)
        {
            //SELECT
            DataSet ds = new DataSet();
            Propriedade propiedade = new DataBusiness.Propriedade();
            try
            {
                SqlCommand cmd = new SqlCommand("GetVetorbyId", connection.GetConnection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                ada.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    propiedade.Nome = ds.Tables[0].Rows[0]["Nome"].ToString();
                    propiedade.Descrição = ds.Tables[0].Rows[0]["Descrição"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return propiedade;
        }

      
    }

}
