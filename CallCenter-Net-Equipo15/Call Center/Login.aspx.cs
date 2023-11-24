using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Call_Center
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                Cuenta cuenta = new Cuenta();
                cuenta.Rol = new Rol();
                cuenta.Email = EmailInput.Value;
                cuenta.Password = PasswordInput.Value;


                CuentaNegocio cuentaNegocio = new CuentaNegocio();

                Usuario user = cuentaNegocio.Login(cuenta);

                if (user != null)
                {
                    Session.Add("Usuario", user);
                    Session.Add("Cuenta", cuenta);
                    Response.Redirect("Home.aspx", false);
                }
                else
                {
                    Session.Add("NoAccountFound", true);
                };

            }
            catch (Exception)
            {
                Response.Redirect("Error.aspx");
            }
        }

        protected void RegistrarseButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearCliente.aspx");
        }
    }
}