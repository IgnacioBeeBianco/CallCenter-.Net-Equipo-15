using DAO;
using Dominio;
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
        CuentaDAO cuentaDAO = new CuentaDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Remove("NoAccountFound");
        }
        protected void CamPassButton_Click(object sender, EventArgs e)
        {
            try
            {
                string email = EmailInput.Value;
                string newPassword = PasswordInput.Value;

                Cuenta cuenta = new Cuenta();
                cuenta.Email = email;
                cuenta.Password = newPassword;

                if (cuentaDAO.getCuentaMail(cuenta))
                {
                    cuentaDAO.UpdatePassword(cuenta);

                    Response.Redirect("Login.aspx", false);

                }
                else
                {
                    Session.Add("NoAccountFound", true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Session.Remove("NoAccountFound");
            Response.Redirect("Login.aspx", false);
        }
    }
}