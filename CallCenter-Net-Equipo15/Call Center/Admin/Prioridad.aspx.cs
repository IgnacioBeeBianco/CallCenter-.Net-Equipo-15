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
            try
            {
                if (Session["Usuario"] != null && Session["Cuenta"] != null)
                {
                    PrioridadDAO prioridadDAO = new PrioridadDAO();

                    //Aca cargamos el repeater
                    rptPrioridades.DataSource = prioridadDAO.List().Where(prio => prio.Estado);
                    rptPrioridades.DataBind();
                }
                else
                {
                    Response.Redirect("~/Login.aspx", false);
                }
            }
            catch(Exception)
            {
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void btnQuitar(object sender, EventArgs e)
        {
            try
            {
                //Obtenemos el id que esta puesto como argumento del boton de delete y borramos
                int id = int.Parse(((LinkButton)sender).CommandArgument);
                if (prioridadDAO.Delete(id))
                {
                    Response.Redirect("Prioridad.aspx", false);
                }
                else
                {
                    alertDelete.Style["display"] = "block";
                    lblErrorDelete.Text = "La Prioridad esta en uso en una incidencia...";
                    return;
                }
                
            }
            catch (Exception)
            {
                Response.Redirect("~/Error.aspx");
            }
            
            
        }

        protected void abrirModal(object sender, EventArgs e)
        {
            try
            {
                //Logica que abre el modal y le carga datos segun si es crear o modificar"
                LinkButton btn = sender as LinkButton;
                modalPrioridad.Style["display"] = "block";

                switch (btn.Attributes["action"])
                {
                    case "create":
                        lblTitle.Text = "Crear";
                        break;

                    case "modify":
                        int id = int.Parse(((LinkButton)sender).CommandArgument);
                        txbPrioNombre.Text = prioridadDAO.getPrioridad(id).Nombre;
                        txbNivelPrioridad.Text = prioridadDAO.getPrioridad(id).nivelPrioridad.ToString();
                        lblTitle.Text = "Modificar a ";
                        lblNombre.Text = txbPrioNombre.Text;
                        break;

                    default:

                        break;
                }
            }
            catch(Exception)
            {
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void submitModal(object sender, EventArgs e)
        {
            try
            {
                //Verificamos si es crear o modificar, y ejecutamos las acciones respectivas
                if (lblTitle.Text == "Crear")
                {
                    Dominio.Prioridad prioridad = new Dominio.Prioridad();
                    prioridad.Nombre = txbPrioNombre.Text;
                    prioridad.nivelPrioridad = int.Parse(txbNivelPrioridad.Text);
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
                    if (prioridad.nivelPrioridad < 1 || prioridad.nivelPrioridad > 10)
                    {
                        alertPrio.Style["display"] = "block";
                        lblPrioErrores.Text = "El nivel de prioridad debe estar entre 1 y 10...";
                        return;
                    }
                    prioridadDAO.Create(prioridad);
                }
                else
                {
                    int id = prioridadDAO.getPrioridad(lblNombre.Text).Id;
                    Dominio.Prioridad prioridad = new Dominio.Prioridad();
                    prioridad.Nombre = txbPrioNombre.Text;
                    prioridad.nivelPrioridad = int.Parse(txbNivelPrioridad.Text);
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
                    if (prioridad.nivelPrioridad < 1 || prioridad.nivelPrioridad > 10)
                    {
                        alertPrio.Style["display"] = "block";
                        lblPrioErrores.Text = "El nivel de prioridad debe estar entre 1 y 10...";
                        return;
                    }
                    prioridadDAO.Update(prioridad, id);
                }
                Response.Redirect("Prioridad.aspx",false);
            }
            catch (Exception)
            {
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void cancelarModal(object sender, EventArgs e)
        {
            //Limpiamos el modal
            modalPrioridad.Style["display"] = "none";
            txbPrioNombre.Text = "";
            alertPrio.Style["display"] = "none";
        }
    }
}