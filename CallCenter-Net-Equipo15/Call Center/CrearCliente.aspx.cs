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
    public partial class CrearCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegistrarseButton_Click(object sender, EventArgs e)
        {
            try
            {
                Cuenta cuenta = new Cuenta();
                CuentaDAO cuentaDAO = new CuentaDAO();
                cuenta.Email = EmailInput.Value;
                cuenta.Password = PasswordInput.Value;
                int id = cuentaDAO.crearNuevaCuentaCliente(cuenta);
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            } 
        }
    }
}