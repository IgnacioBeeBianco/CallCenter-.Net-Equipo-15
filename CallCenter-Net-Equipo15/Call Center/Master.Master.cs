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
            string currentPageName = System.IO.Path.GetFileNameWithoutExtension(Request.Url.LocalPath);
            PageNameLabel.InnerText = currentPageName;
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/Login.aspx"); //Aca nos encargamos de implementar que si no logeo vaya al login
            }
            Usuario usuario = new Usuario();
            usuario = (Usuario)Session["Usuario"];
            Cuenta cuenta = new Cuenta();
            cuenta = (Cuenta)Session["Cuenta"];

            Username.Text = (usuario.Nombre + " " + usuario.Apellido);

            if( cuenta.Rol.Nombre != "Administrador")
            {
                adminDashboard.Style["display"] = "none";
            }
        }

        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            Session.Remove("Usuario");
            Session.Remove("Cuenta");

            Response.Redirect("Login.aspx");
        }
    }
}