namespace Logic
{
    using DataBusiness;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class LogicAccess
    {
        internal clsABC abc = new clsABC();

        public static DataTable getIndicadores(int idSafra, int idProduto, int idCooperativa)
        {
            clsABC abc = new clsABC();
            return abc.GetIndicador(idSafra, idProduto, idCooperativa);
        }
        public static DataSet GetIndicador(string name)
        {
            clsABC abc = new clsABC();
            return abc.GetIndicador(name);
        }
        public static DataTable GetCooperativa()
        {
            clsABC abc = new clsABC();
            return abc.GetCooperativa();
        }
        public static Cooperativa GetCooperativa(int id)
        {
            clsABC abc = new clsABC();
            return abc.GetCooperativobyId(id);
        }
        public static DataTable GetSafra()
        {
            clsABC abc = new clsABC();
            return abc.GetSafra();
        }

        public static DataTable GetProduto()
        {
            clsABC cls = new clsABC();
            return cls.GetProduto();
        }

        public static Produto GetProdutobyId(int id)
        {
            clsABC abc = new clsABC();
            return abc.GetProdutobyId(id);
        }

        public static int GetProdutobyNome(string nome)
        {
            clsABC abc = new clsABC();
            return abc.GetProduto(nome).Id;
        }

        public static Safra GetSafrabyId(int id)
        {
            clsABC abc = new clsABC();
            return abc.GetSafrabyId(id);
        }

        public static int GetIdSafrabyNome(string nome)
        {
            clsABC abc = new clsABC();
            return abc.GetIdSafrabyNome(nome);
        }

        public static Propriedade GetPropriedadebyId(int id)
        {
            clsABC abc = new clsABC();
            return abc.GetPropriedadebyId(id);
        }
        public static Safra GetSafrabyNome(string nome)
        {
            clsABC abc = new clsABC();
            return abc.GetSafrabyNome(nome);
        }
        public static Cooperativa GetCooperativabyName(string name)
        {
            clsABC abc = new clsABC();
            return abc.GetCooperativobyNome(name);
        }

        public static int GetPropriedadebyNome(string nome)
        {
            clsABC abc = new clsABC();
            return abc.GetPropriedadeByNome(nome);
        }

        public static bool SaveIndicador(decimal valor, int idProduto, int idSafra, int idvetor, int idCooperativa)
        {
            clsABC abc = new clsABC();
            return (abc.SaveIndicador(valor, idProduto, idSafra, idvetor, idCooperativa));
        }
        public static List<MyList> GetIndicador(int idSafraStart, int idSafraEnd, int idProduto, int idCooperativa)
        {
            List<MyList> datalist = new List<MyList>();
            for (int i = idSafraStart; i < idSafraEnd + 1; i++)
            {
                DataTable dtIndicador = getIndicadores(i, idProduto, idCooperativa);
                foreach (DataRow rw in dtIndicador.Rows)
                {
                    datalist.Add(
                        new MyList
                        {

                            safra = GetSafrabyId(Convert.ToInt32(rw["IdSafra"])).Descrição, //LogicAccess.GetSafrabyId(Convert.ToInt32(row["IdSafra"])).Descrição, GetProdutobyId(Convert.ToInt32(row["IdProduto"])).Nome, GetPropriedadebyId(Convert.ToInt32(row["IdVetor"])).Nome, row["Quantidade"].ToString()}
                            produto = GetProdutobyId(Convert.ToInt32(rw["IdProduto"])).Nome,
                            propriedade = GetPropriedadebyId(Convert.ToInt32(rw["IdVetor"])).Nome,
                            quantidade = rw["Quantidade"].ToString(),
                            cooperativa = GetCooperativa(Convert.ToInt32(rw["idCooperativa"])).Nome
                        });
                }
            }
            return datalist;
        }
     public static string SplitData(string word, bool place)
        {
            string[] wordSplited = word.Split(' ');
            string words = string.Empty;
            if (place == true)            
 words= wordSplited[wordSplited.Length - 1];
            else
                words= wordSplited[0];
            return words;
          //  return SaveIndicador(Convert.ToDecimal(quanityProd), GetProdutobyNome(produto), GetSafrabyNome(safra).Id, GetPropriedadebyNome(propriedade), GetCooperativabyName(cooperativa).Id);
        }
        public static DataTable GetTableIndicador()//(int quantity, string produto, string safra, string descricao, string cooperativa)
    {
            DataTable dt = new DataTable("Indicadors");
        try
        {
            DataColumn dc = dt.Columns.Add("Quantidade", typeof(decimal));
            dt.Columns.Add("Produto", typeof(String));
            dt.Columns.Add("Safra", typeof(String));
            dt.Columns.Add("Descrição", typeof(String));
            dt.Columns.Add("Cooperativa", typeof(String));
        }
        catch (Exception)
        {
            throw;
        }
        return dt;
    }
    }
   

    public class MyList
    {
        public string safra { get; set; }

        public string produto { get; set; }

        public string propriedade { get; set; }

        public string quantidade { get; set; }
        public string cooperativa { get; set; }
    }
}
