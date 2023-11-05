using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Call_Center
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Username.Text = ((Usuario)Session["Usuario"]).Nombre + " " + ((Usuario)Session["Usuario"]).Apellido;
        }
    }
}