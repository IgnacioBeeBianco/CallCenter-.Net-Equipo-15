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
           /* if (!IsPostBack)
            {
                setearImagenSegunRol();
            }
            
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/Login.aspx"); //Aca nos encargamos de implementar que si no logeo vaya al login
            }
            Usuario usuario = new Usuario();
            usuario = (Usuario)Session["Usuario"];
            Cuenta cuenta = new Cuenta();
            cuenta = (Cuenta)Session["Cuenta"];

            Username.Text = (usuario.Nombre + " " + usuario.Apellido);
            //UserRol.Text = cuenta.Rol.Nombre;


            if ( cuenta.Rol.Nombre != "Administrador")
            {
                adminDashboard.Style["display"] = "none";
            }*/
            
        }

        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            Session.Remove("Usuario");
            Session.Remove("Cuenta");

            Response.Redirect("~/Login.aspx");
        }

        public string setearImagenSegunRol()
        {
            return image1.ImageUrl = setearURLImagenSegunRol();
        }

        private string setearURLImagenSegunRol()
        {
            if (Session["Cuenta"] != null)
            {
                string userRol = (Session["Cuenta"] as Dominio.Cuenta).Rol.Nombre;

                switch (userRol)
                {
                    case "Administrador":
                        return "~/Images/admin.png";

                    case "Cliente":
                        return "~/Images/businessman.png";

                    case "Telefonista":
                        return "~/Images/customer-service.png";

                    case "Supervisor":
                        return "~/Images/supervisor.png";

                    default:
                        return "~/Images/client.png";

                }
            }
            else
            {
                return "~/Images/default.png";
            }
        }

        protected void ImageUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UsuarioPanel.aspx");
        }
    }
}