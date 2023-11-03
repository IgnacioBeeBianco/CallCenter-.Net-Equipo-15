using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;
namespace Call_Center
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/Login.aspx"); //Aca nos encargamos de implementar que si no logeo vaya al login
            }

            TipoIncidenciaDAO tipoIncidenciaDAO = new TipoIncidenciaDAO();
            
        }
    }
}