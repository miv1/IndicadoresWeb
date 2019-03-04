namespace Presentation
{
    using iTextSharp.text.pdf;
    using iTextSharp.text.pdf.parser;
    using Logic;
    using System;
    using System.Data;
    using System.Text;

    public partial class frmAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           LoadFile();
        }

        private void LoadFileXmls()
        {   
            fulData.Dispose();
                           string filename = System.IO.Path.GetFileName(fulData.FileName);
                fulData.SaveAs(Server.MapPath("~/") + filename);
                DataSet ds = LogicAccess.GetIndicador(Server.MapPath("~/" + fulData.FileName));
                ddlFolha.Items.Clear();
                foreach (DataTable dt in ds.Tables)
                {
                    ddlFolha.Items.Add(dt.TableName);
                }
            lblEscolher.Visible = true;
            ddlFolha.Visible = true;
                hdnfldFile.Value = fulData.FileName;
            
        }

        private DataTable LoadFilePdf()
        { DataTable dtShowIndicador = LogicAccess.GetTableIndicador();
               
            if (fulData.HasFile)
            {
                try
                {
                    fulData.Dispose();
                    string extension = System.IO.Path.GetExtension(fulData.FileName);
                    if (extension == ".pdf")
                    {
                        ddlFolha.Visible = false;
                        lblEscolher.Visible = false;
                        string filename = System.IO.Path.GetFileName(fulData.FileName);
                        fulData.SaveAs(Server.MapPath("~/") + filename);
                        PdfReader reader = new PdfReader(Server.MapPath("~/" + fulData.FileName));
                        int intPageNum = reader.NumberOfPages;
                        string[] words;
                        string line;
                        string year = string.Empty;
                        int sw = 0;
                        string fff = string.Empty;
                        for (int i = 1; i <= intPageNum; i++)
                        {
                           string text = PdfTextExtractor.GetTextFromPage(reader, i, new LocationTextExtractionStrategy());
                            words = text.Split('\n');
                            for (int j = 0, len = words.Length; j < len; j++)
                            {
                                line = Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(words[j]));
                                if (intPageNum == 44)
                                    fff = "fsd";
                                if (words[j] == "(ton)" && words[j - 1] == "EVOLUÇÃO  DA  PRODUÇÃO ")
                                {
                                    string[] dataYear = words[j + 1].Split(' ');
                                    year = dataYear[dataYear.Length - 1];
                                    if (year.Length == 4)
                                        year = Convert.ToInt32(year) - 1 + "/" + year;
                                    sw = 1;
                                }
                                if (words[j] == "(ha)" && words[j - 1] == "EVOLUÇÃO  DAS  ÁREAS  DE  PLANTIO")
                                {
                                    string[] dataYear = words[j + 2].Split(' ');
                                    year = dataYear[dataYear.Length - 1];
                                    year = "20" + year.Substring(0, 2) + "/20" + year.Substring(year.Length - 2);
                                    sw = 2;
                                }
                                if (sw == 1)
                                {
                                    if ((words[j] == "Soja" && words[j + 1].Length > 15) || (words[j] == "Milho" && words[j + 1].Length > 15) || (words[j] == "Trigo" && words[j + 1].Length > 15))
                                        dtShowIndicador.Rows.Add(LogicAccess.SplitData(words[j + 1], true), words[j], year, "Producao", "Castrolanda");
                                }
                                if (sw == 2)
                                {
                                    if ((words[j] == "Soja" && words[j + 1].Length > 15) || (words[j] == "Trigo" && words[j + 1].Length > 15))
                                        dtShowIndicador.Rows.Add(LogicAccess.SplitData(words[j + 1], true), words[j], year, "Area Plantada", "Castrolanda");
                                    if (words[j].StartsWith("Milho") && words[j].Length > 30)
                                        dtShowIndicador.Rows.Add(LogicAccess.SplitData(words[j], true), LogicAccess.SplitData(words[j], false), year, "Area Plantada", "Castrolanda");
                                }
                            }
                            sw = 0;
                        }
                    }
                    else
                        lblStatus.Text = "Selecione arquivos de Excel ou pdf.";
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "Um erro foi achado no arquivo" + ex.Message;
                }
                gvwResultado.DataSource = dtShowIndicador;
                gvwResultado.Visible = true;
                gvwResultado.DataBind();
                gvwResultadoXmlx.Visible = false;
                gvwResultado.Visible = true;
            }
            return dtShowIndicador;
        }
        void LoadFile()
        {
            if (fulData.HasFile)
            {
                string extension = System.IO.Path.GetExtension(fulData.FileName);
                switch (extension)
                {
                    case ".xlsx":
                    case "xls":
                        LoadFileXmls();
                        break;
                    case ".pdf":
                        LoadFilePdf();
                        break;
                    default:
                        lblStatus.Text = "Selecione arquivos de Excel ou pdf.";
                        break;
                }
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if(System.IO.Path.GetExtension(fulData.FileName) == ".xlsx")
            { 
            int columns = gvwResultado.Columns.Count;
            int propriedadeId = 0;
            for (int cfila = 0; cfila < gvwResultado.Rows.Count - 1; cfila++)
            {
                for (int i = 1; i < columns; i++)
                {
                    if (gvwResultado.Rows[cfila].Cells[i].Text != "&nbsp;")
                    {
                        int safraId = LogicAccess.GetIdSafrabyNome(gvwResultado.Rows[cfila].Cells[0].Text);
                        int quantidade = Convert.ToInt32(gvwResultado.Rows[cfila].Cells[i].Text);
                        switch (i)
                        {
                            case 1:
                                propriedadeId = LogicAccess.GetPropriedadebyNome("produtividade");
                                break;
                            case 2:
                                propriedadeId = LogicAccess.GetPropriedadebyNome("Area Plantada");
                                break;
                            case 3:
                                propriedadeId = LogicAccess.GetPropriedadebyNome("Producao");
                                break;
                        }
                        int produto = LogicAccess.GetProdutobyNome(ddlFolha.SelectedItem.ToString());
                        if (safraId != 0 && produto != 0 && propriedadeId != 0)
                            LogicAccess.SaveIndicador(quantidade, produto, safraId, propriedadeId, 1);
                    }
                }
            }
            }
            lblStatus.Text = "Arquivo salvado";
            lblStatus.Visible = true;
        }

        protected void ddlFolha_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvwResultado.Visible = false;
            gvwResultadoXmlx.Visible = true;
        gvwResultadoXmlx.DataSource = LogicAccess.GetIndicador(Server.MapPath("~/") + hdnfldFile.Value).Tables[ddlFolha.SelectedItem.ToString()];
            gvwResultadoXmlx.Visible = true;
                gvwResultadoXmlx.DataBind();
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Server.Transfer("Portada.aspx");
        }
    }
}
