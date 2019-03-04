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
            FillSafraHasta();
            FillCooperativas();
           // RepeteData();
            }
           
        }
        void FillSafra()
        {
            ddlSafra.DataSource = LogicAccess.GetSafra();
            ddlSafra.DataTextField = "Descrição";
            ddlSafra.DataValueField = "Id";
            ddlSafra.DataBind();
        }
        void FillSafraHasta()
        {
            ddlHasta.DataSource = LogicAccess.GetSafra();
            ddlHasta.DataTextField = "Descrição";
            ddlHasta.DataValueField = "Id";
            ddlHasta.DataBind();
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
            List<MyList> myList = new List<MyList>();
            DataTable dt = LogicAccess.GetTableIndicador();
            foreach (ListItem listItem in chbSelectAll.Items)
            {
                if (listItem.Selected)
                {
                    myList = LogicAccess.GetIndicador(Convert.ToInt32(ddlSafra.SelectedValue), Convert.ToInt32(ddlHasta.SelectedValue), Convert.ToInt32(ddlProduto.SelectedValue), Convert.ToInt32(listItem.Value));
                    foreach (var li in myList)
                    {
                        DataRow dr = dt.NewRow();
                        dr["Cooperativa"] = li.cooperativa;
                        dr["Produto"] = li.produto;
                        dr["Descrição"] = li.propriedade;
                        dr["Quantidade"] = li.quantidade;
                        dr["Safra"] = li.safra;
                        dt.Rows.Add(dr);
                    }
                }
            } 
          rptIndicadores.DataSource = dt;
                rptIndicadores.DataBind(); rptIndicadores.Visible = true;
            //if (rptIndicadores.Items.Count > 0)
            //        {
 
            //        }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            RepeteData();
        }

        protected void rbdSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            //if(rbdSelectAll.Checked)
            //{
            //    rdbFrisia. = true;
            //}
        }
        protected void FillCooperativas()
        {
            chbSelectAll.DataSource= LogicAccess.GetCooperativa();
            chbSelectAll.DataTextField = "Nome";
            chbSelectAll.DataValueField = "Id";
            chbSelectAll.DataBind();
        }

        protected void ckbSelecionarTudo_CheckedChanged(object sender, EventArgs e)
        {
                foreach (ListItem it in chbSelectAll.Items)
                {
                    it.Selected = ckbSelecionarTudo.Checked;
                }           
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Server.Transfer("Portada.aspx");
        }
    }
}