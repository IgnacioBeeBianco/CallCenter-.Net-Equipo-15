using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace Call_Center
{
    public partial class UsuarioPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Cuenta"]  != null)
            {
                lblRol.Text = (Session["Cuenta"] as Dominio.Cuenta).Rol.Nombre;
            }
            if (Session["Usuario"] != null)
            {
                lblNombre.Text = (Session["Usuario"] as Dominio.Usuario).Nombre;
                lblApellido.Text = (Session["Usuario"] as Dominio.Usuario).Apellido;
                lblDNI.Text = (Session["Usuario"] as Dominio.Usuario).DNI;
                lblDomicilio.Text = (Session["Usuario"] as Dominio.Usuario).Domicilio;
                lblTelefono.Text = (Session["Usuario"] as Dominio.Usuario).Telefono;
                lblGenero.Text = (Session["Usuario"] as Dominio.Usuario).Genero.ToString();

            }
            else
            {
                Response.Redirect("Login.aspx", false);
            }
        }
    }
}