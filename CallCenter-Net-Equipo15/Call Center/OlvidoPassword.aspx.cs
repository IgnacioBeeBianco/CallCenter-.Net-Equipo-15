using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Call_Center
{
    public partial class OlvidoPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void CamPassButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearCliente.aspx");
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {

        }
    }
}