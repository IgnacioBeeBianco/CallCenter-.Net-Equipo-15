using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;

namespace Call_Center
{
    public partial class AdminPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }


        protected void mostrarModal(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            switch (btn.Attributes["table"])
            {
                case "Prioridad":

                    modalPrioridad.Style["display"] = "block";
                    PrioridadDAO prioridadDAO = new PrioridadDAO();

                    

                    switch (btn.Attributes["action"])
                    {
                        case "create":

                            break;

                        case "modify":
                        case "delete":
                            Prioridad prioridad = new Prioridad();
                            prioridad = prioridadDAO.getPrioridad(txbBusquedaPrioridad.Text);
                            txbPrioNombre.Text = prioridad.Nombre;
                            txbBusquedaPrioridad.Text = null;
                            break;

                        default:
                            // Acción por defecto si el ID no coincide con ninguno de los casos anteriores
                            break;
                    }

                    break;

                default:

                    break;
            }

        }

        protected void submitModal(object sender, EventArgs e)
        {

        }

        protected void cancelarModal(object sender, EventArgs e)
        {

            Button btn = sender as Button;

            switch (btn.Attributes["table"])
            {
                case "Prioridad":

                    modalPrioridad.Style["display"] = "none";
                    break;

                default:

                    break;
            }

           
        }

    }
}