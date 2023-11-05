using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace Call_Center.ABML
{
    public partial class Prioridad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PrioridadDAO prioridadDAO = new PrioridadDAO();

            

            rptPrioridades.DataSource = prioridadDAO.List();
            rptPrioridades.DataBind();

        }

        protected void btnQuitar(object sender, EventArgs e)
        {

        }

        protected void abrirModal(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            modalPrioridad.Style["display"] = "block";

            switch (btn.Attributes["action"])
            {
                case "create":
                    lblTitle.Text = "Crear nueva prioridad";
                    break;

                case "modify":
                    lblTitle.Text = "Modificar a";
                    break;

                default:

                    break;
            }
        }

        protected void submitModal(object sender, EventArgs e)
        {

        }
    }
}