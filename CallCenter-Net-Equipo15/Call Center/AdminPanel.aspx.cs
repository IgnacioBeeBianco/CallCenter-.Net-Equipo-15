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
                    break;

                default:

                    break;
            }

        }

        protected void submitModal(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            try
            {
                switch (btn.Attributes["table"])
                {
                    case "Prioridad":
                        PrioridadDAO prioridadDAO = new PrioridadDAO();
                        Prioridad prioridad = new Prioridad();
                        switch (btn.Attributes["action"])
                        {
                            case "create":
                                prioridad.Nombre = txbPrioNombre.Text;
                                //Validar y mostrar alert
                                prioridadDAO.Create(prioridad);

                                break;

                            case "modify":
                                prioridad.Nombre = txbPrioNombre.Text;
                                prioridadDAO.Update(prioridad);
                                break;

                            case "delete":
                                prioridad = prioridadDAO.getPrioridad(txbPrioNombre.Text);
                                prioridadDAO.Delete(prioridad.Id);
                                break;

                            default:

                                break;
                        }
                        
                        modalPrioridad.Style["display"] = "none";

                        break;

                    default:

                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

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

        protected void realizarBusqueda(object sender, EventArgs e)
        {
            Button btn = sender as Button;


            switch (btn.Attributes["table"])
            {

                case "Prioridad":

                    modalPrioridad.Style["display"] = "block";
                    PrioridadDAO prioridadDAO = new PrioridadDAO();
                    Prioridad prioridad = new Prioridad();
                    prioridad = prioridadDAO.getPrioridad(txbSearhPrio.Text);
                    txbPrioNombre.Text = prioridad.Nombre;
                    txbSearhPrio.Text = null;

                    break;

                default:

                    break;
            }
        }

    }
}