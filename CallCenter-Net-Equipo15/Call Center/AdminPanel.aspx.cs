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
            switch (btn.Attributes["table"])
            {
                case "Prioridad":
                    PrioridadDAO prioridadDAO = new PrioridadDAO();
                    Prioridad prioridad = new Prioridad();
                    switch (btn.Attributes["action"])
                    {
                        case "create":
                            //Validar y mostrar alert
                            //Validamos que no exista
                            if (txbPrioNombre.Text == "" || txbPrioNombre.Text == null)
                            {
                                alertPrio.Style["display"] = "block";
                                lblPrioErrores.Text = "La prioridad debe tener nombre...";
                                return;
                            }
                            if (prioridadDAO.getPrioridad(txbPrioNombre.Text).Nombre != null)
                            {
                                alertPrio.Style["display"] = "block";
                                lblPrioErrores.Text = "Prioridad ya creada...";
                                return;
                            }
                            else
                            {
                                prioridad.Nombre = txbPrioNombre.Text;
                                prioridadDAO.Create(prioridad);
                                txbSearhPrio.Text = "";
                                txbPrioNombre.Text = "";
                                lblPrioBuscada.Text = "";
                                alertPrio.Style["display"] = "none";

                            }

                            break;

                        case "modify":
                            if (lblPrioBuscada.Text == "" || lblPrioBuscada.Text == null)
                            {
                                alertPrio.Style["display"] = "block";
                                lblPrioErrores.Text = "No hay una prioridad buscada";
                                return;
                            }
                            if (prioridadDAO.getPrioridad(txbPrioNombre.Text).Nombre != null)
                            {
                                alertPrio.Style["display"] = "block";
                                lblPrioErrores.Text = "Prioridad ya creada...";
                                return;
                            }
                            long idM = Int64.Parse(lblPrioBuscada.Attributes["prioId"]);
                            string newValue = txbPrioNombre.Text;
                            prioridadDAO.Update(newValue, idM);
                            txbSearhPrio.Text = "";
                            txbPrioNombre.Text = "";
                            lblPrioBuscada.Text = "";
                            alertPrio.Style["display"] = "none";

                            break;

                        case "delete":
                            if (lblPrioBuscada.Text == "" || lblPrioBuscada.Text == null)
                            {
                                alertPrio.Style["display"] = "block";
                                lblPrioErrores.Text = "No hay una prioridad buscada";
                                return;
                            }
                            prioridad = prioridadDAO.getPrioridad(lblPrioBuscada.Text);
                            long idD = Int64.Parse(lblPrioBuscada.Attributes["prioId"]);
                            prioridadDAO.Delete(idD);
                            txbSearhPrio.Text = "";
                            txbPrioNombre.Text = "";
                            lblPrioBuscada.Text = "";
                            alertPrio.Style["display"] = "none";
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

        protected void cancelarModal(object sender, EventArgs e)
        {

            Button btn = sender as Button;

            switch (btn.Attributes["table"])
            {
                case "Prioridad":

                    modalPrioridad.Style["display"] = "none";
                    txbPrioNombre.Text = "";
                    lblPrioBuscada.Text = "";
                    alertPrio.Style["display"] = "none";
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
                    lblPrioBuscada.Text = "Busqueda: " + prioridad.Nombre;
                    lblPrioBuscada.Attributes["prioId"] = prioridad.Id.ToString();
                    txbPrioNombre.Text = prioridad.Nombre;
                    txbSearhPrio.Text = null;

                    break;

                default:

                    break;
            }
        }

    }
}