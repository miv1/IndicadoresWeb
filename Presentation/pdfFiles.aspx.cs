namespace Presentation
{
    using iTextSharp.text.pdf;
    using iTextSharp.text.pdf.parser;
    using System;
    using System.Text;
    using System.Collections.Generic;

    public partial class pdfFiles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReadPdf();
        }

        internal void ReadPdf()
        {
            PdfReader reader = new PdfReader(@"E:\Dissertação\RA2017.pdf");
            int intPageNum = reader.NumberOfPages;
            string[] words;
            string line;
            bool sw = true;
           for (int i = 1; i <= intPageNum; i++)
            {
                string text = PdfTextExtractor.GetTextFromPage(reader, i, new LocationTextExtractionStrategy());
              words = text.Split('\n');
                for (int j = 0, len = words.Length; j < len; j++)
                {
                   
                    line = Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(words[j]));
                    if (words[j] == "(ton)" && words[j - 1] == "EVOLUÇÃO  DA  PRODUÇÃO ")
                    {
                        string[] dataYear = words[j+1].Split(' ');
                        string year = dataYear[dataYear.Length - 1];
                        sw = false;
                    }
                    if (sw == false)
                    {
                        if (words[j] == "Soja" || words[j] == "Milho" || words[j] == "Trigo")
                        {
                            SplitData(words[j + 1], words[j]);
                        }
                    }
                } sw = true;
            }
           
        }
        void SplitData(string quantity, string produto)
        { 
           string []dataYear = quantity.Split(' ');
            string quanityProd =   dataYear[dataYear.Length -1];
        }
    }
}
