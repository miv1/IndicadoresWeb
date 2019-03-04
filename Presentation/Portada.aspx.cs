using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation
{
    public partial class Portada : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdmin_Click(object sender, EventArgs e)
        {
            Server.Transfer("frmAdmin.aspx");
        }

        protected void btnUser_Click(object sender, EventArgs e)
        {
            Server.Transfer("frmUser.aspx");
        }
    }
}