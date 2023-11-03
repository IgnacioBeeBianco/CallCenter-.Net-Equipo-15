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
            cuenta.Email = EmailInput.Value; 
            cuenta.Password = PasswordInput.Value;
            

            CuentaNegocio cuentaNegocio = new CuentaNegocio();

            if (cuentaNegocio.Login(cuenta))
            {
                Session.Add("Cuenta", cuenta);
                Response.Redirect("Home.aspx");
            }
            else
            {
                Session.Add("NoAccountFound", true);
            };

        }
    }
}