using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Call_Center.ABML
{
    public partial class Cuenta : System.Web.UI.Page
    {
        private CuentaDAO cuentaDAO = new CuentaDAO();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void abrirModal(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            modalUsuarios.Style["display"] = "block";

            switch (btn.Attributes["action"])
            {
                
                case "modify":
                    int id = int.Parse(((Button)sender).CommandArgument);
                    TxbEmail.Text = cuentaDAO.GetCuenta(id).Email;
                    lblTitle.Text = "Modificando la cuenta ";
                    lblNombre.Text = TxbEmail.Text;
                    break;

                default:

                    break;
            }
        }

        protected void submitModal(object sender, EventArgs e)
        {
            if (lblTitle.Text == "Modificando la cuenta ")
            {
                Dominio.Cuenta cuenta = new Dominio.Cuenta
                {
                    Email = TxbEmail.Text,
                    Password = TxbPassword.Text,
                };
                cuentaDAO.Update(cuenta);

            

            }
           

            Response.Redirect("Usuario.aspx");
        }

        protected void cancelarModal(object sender, EventArgs e)
        {

            modalUsuarios.Style["display"] = "none";
            TxbEmail.Text = "";
            alertPrio.Style["display"] = "none";

        }
    }
}