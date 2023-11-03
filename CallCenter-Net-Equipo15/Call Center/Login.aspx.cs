using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Call_Center
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            Cuenta cuenta = new Cuenta();
            EmailInput.Value = cuenta.Email;
            PasswordInput.Value = cuenta.Password;

            CuentaNegocio cuentaNegocio = new CuentaNegocio();

            if (cuentaNegocio.Login(cuenta))
            {
                Response.Redirect("Home.aspx");
            };

        }
    }
}