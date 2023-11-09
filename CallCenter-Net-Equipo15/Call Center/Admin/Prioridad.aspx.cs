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
        PrioridadDAO prioridadDAO = new PrioridadDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            PrioridadDAO prioridadDAO = new PrioridadDAO();

            
            //Aca cargamos el repeater
            rptPrioridades.DataSource = prioridadDAO.List();
            rptPrioridades.DataBind();

        }

        protected void btnQuitar(object sender, EventArgs e)
        {
            //Obtenemos el id que esta puesto como argumento del boton de delete y borramos
            long id = long.Parse(((Button)sender).CommandArgument);
            prioridadDAO.Delete(id);
            Response.Redirect("Prioridad.aspx");
        }

        protected void abrirModal(object sender, EventArgs e)
        {
            //Logica que abre el modal y le carga datos segun si es crear o modificar"
            Button btn = sender as Button;
            modalPrioridad.Style["display"] = "block";

            switch (btn.Attributes["action"])
            {
                case "create":
                    lblTitle.Text = "Crear";
                    break;

                case "modify":
                    long id = long.Parse(((Button)sender).CommandArgument);
                    txbPrioNombre.Text = prioridadDAO.getPrioridad(id).Nombre;
                    lblTitle.Text = "Modificar a ";
                    lblNombre.Text = txbPrioNombre.Text;
                    break;

                default:

                    break;
            }
        }

        protected void submitModal(object sender, EventArgs e)
        {
            //Verificamos si es crear o modificar, y ejecutamos las acciones respectivas
            if (lblTitle.Text == "Crear")
            {
                Dominio.Prioridad prioridad = new Dominio.Prioridad();
                prioridad.Nombre = txbPrioNombre.Text;
                //Validaciones
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
                prioridadDAO.Create(prioridad);
            }
            else
            {
                long id = prioridadDAO.getPrioridad(lblNombre.Text).Id;
                string newValue = txbPrioNombre.Text;
                //Validamos antes de efectuar ningun cambio
                if (txbPrioNombre.Text == "" || txbPrioNombre.Text == null)
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
                prioridadDAO.Update(newValue, id);
            }

            Response.Redirect("Prioridad.aspx");
        }

        protected void cancelarModal(object sender, EventArgs e)
        {
            //Limpiamos el modal
            modalPrioridad.Style["display"] = "none";
            txbPrioNombre.Text = "";
            alertPrio.Style["display"] = "none";


        }

        protected void Volver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminPanel.aspx");
        }
    }
}