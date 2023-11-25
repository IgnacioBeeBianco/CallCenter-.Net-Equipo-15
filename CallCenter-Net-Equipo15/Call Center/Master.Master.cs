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
        protected Usuario Usuario { get; set; }
        protected Cuenta Cuenta { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    setearImagenSegunRol();
                }

                if (!IsLogged())
                {
                    Response.Redirect("Login.aspx",false);
                    return;
                }
                else
                {
                    Usuario = (Usuario)Session["Usuario"];
                    Cuenta = (Cuenta)Session["Cuenta"];
                    Username.Text = (Usuario.Nombre + " " + Usuario.Apellido);
                }
                
                if (!IsAdmin())
                {
                    adminDashboard.Style["display"] = "none";
                }
                if (IsClient())
                {
                    incidenciaDashboard.Style["display"] = "none";
                    incidenciaCrear.Style["display"] = "none";
                }
            }
            catch (Exception)
            {
                Response.Redirect("Error.aspx");
            }

        }

        private bool IsAdmin()
        {
            return Cuenta.Rol.Nombre == "Administrador";
        }

        private bool IsClient()
        {
            return Cuenta.Rol.Nombre == "Cliente";
        }

        private bool IsLogged()
        {
            return Session["Usuario"] != null;
        }

        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Remove("Usuario");
                Session.Remove("Cuenta");

                Response.Redirect("~/Login.aspx", false);
            }
            catch (Exception)
            {
                Response.Redirect("Error.aspx");
            }
        }

        public string setearImagenSegunRol()
        {
            return image1.ImageUrl = setearURLImagenSegunRol();
        }

        private string setearURLImagenSegunRol()
        {
            try
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
            catch (Exception)
            {
                Response.Redirect("Error.aspx");
                return "~/Images/default.png";
            }
        }

        protected void ImageUser_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/UsuarioPanel.aspx", false);
            }
            catch (Exception)
            {
                Response.Redirect("Error.aspx");
            }
        }
    }
}