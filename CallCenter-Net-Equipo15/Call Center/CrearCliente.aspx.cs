using DAO;
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
                EmailService emailService = new EmailService();

                cuenta.Email = EmailInput.Value;
                cuenta.Password = PasswordInput.Value;
                int id = cuentaDAO.crearNuevaCuentaCliente(cuenta);

                emailService.armarCorreo(cuenta.Email, "Bienvenid@ al Call Center Grupo 15", "A partir de ahora podras ver los estados de las incidencias que realices");
                emailService.enviarEmail();
                Response.Redirect("Login.aspx", false);

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            } 
        }
    }
}