using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logic;
using System.Data.SqlClient;
using System.Data;

namespace IndicadoresWeb
{
    public partial class frmUser : System.Web.UI.Page
    {
      //  DataBusiness.Connexion cnn = new Connexion();
        SqlCommand cmd = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            FillSafra();
            FillProduct();
                RepeteData();
            }
           
        }
        void FillSafra()
        {
            ddlSafra.DataSource = LogicAccess.GetSafra();
            ddlSafra.DataTextField = "Descrição";
            ddlSafra.DataValueField = "Id";
            ddlSafra.DataBind();
        }
        void FillProduct()
        {
            ddlProduto.DataSource = LogicAccess.GetProduto();
            ddlProduto.DataTextField = "Nome";
            ddlProduto.DataValueField = "Id";
            ddlProduto.DataBind();
        }
        void RepeteData()
        {
            //cnn.OpenConnection();
            //DataTable dt = new DataTable();
            //SqlCommand cmd = new SqlCommand("GetIndicador", cnn.GetConnection());
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("idSafra", SqlDbType.Int).Value = 3;
            //cmd.Parameters.Add("idProduto", SqlDbType.Int).Value = 3;
            //SqlDataAdapter da = new SqlDataAdapter (cmd);
            //da.Fill();
          //  rptIndicadores.DataSource = LogicAccess.getIndicadores(Convert.ToInt32(ddlSafra.SelectedValue), Convert.ToInt32(ddlProduto.SelectedValue));
            rptIndicadores.DataSource = LogicAccess.getIndicadores(8, 25);
            rptIndicadores.DataBind();
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
          //  bool cn = cnn.OpenConnection();
            RepeteData();
        }
    }
}