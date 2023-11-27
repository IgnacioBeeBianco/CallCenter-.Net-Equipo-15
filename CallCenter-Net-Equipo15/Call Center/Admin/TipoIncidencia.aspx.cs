using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Call_Center.ABML
{
    public partial class TipoIncidencia : System.Web.UI.Page
    {
        TipoIncidenciaDAO tipoIncidenciaDAO = new TipoIncidenciaDAO();
        protected bool hasError = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Usuario"] != null && Session["Cuenta"] != null)
                {
                    if (!IsPostBack)
                    {
                        rptPrioridades.DataSource = tipoIncidenciaDAO.List().Where(incidence => incidence.Estado);
                        rptPrioridades.DataBind();
                    }
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
                int id = int.Parse(((LinkButton)sender).CommandArgument);
                tipoIncidenciaDAO.Delete(id);
                Response.Redirect("TipoIncidencia.aspx",false);
            }
            catch(Exception)
            {
                hasError = true;
            }
            
        }

        protected void abrirModal(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = sender as LinkButton;
                modalPrioridad.Style["display"] = "block";

                switch (btn.Attributes["action"])
                {
                    case "create":
                        lblTitle.Text = "Crear";
                        break;

                    case "modify":
                        int id = int.Parse(((LinkButton)sender).CommandArgument);
                        Dominio.TipoIncidencia tipoIncidencia = tipoIncidenciaDAO.getTipoIncidencia(id);
                        txbPrioNombre.Text = tipoIncidencia.Nombre;
                        txbPrioDesc.Text = tipoIncidencia.Descripcion;

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
                    Dominio.TipoIncidencia tipoIncidencia = new Dominio.TipoIncidencia();
                    tipoIncidencia.Nombre = txbPrioNombre.Text;
                    tipoIncidencia.Descripcion = txbPrioDesc.Text;
                    //Validaciones
                    if (txbPrioNombre.Text == "" || txbPrioNombre.Text == null)
                    {
                        alertPrio.Style["display"] = "block";
                        lblPrioErrores.Text = "La prioridad debe tener nombre...";
                        return;
                    }
                    if (tipoIncidenciaDAO.getTipoIncidencia(txbPrioNombre.Text).Nombre != null)
                    {
                        alertPrio.Style["display"] = "block";
                        lblPrioErrores.Text = "Prioridad ya creada...";
                        return;
                    }
                    if (txbPrioDesc.Text == null)
                    {
                        txbPrioDesc.Text = "";
                    }
                    tipoIncidenciaDAO.Create(tipoIncidencia);
                }
                else
                {
                    int id = tipoIncidenciaDAO.getTipoIncidencia(lblNombre.Text).id;
                    Dominio.TipoIncidencia newValue = new Dominio.TipoIncidencia();
                    newValue.Nombre = txbPrioNombre.Text;
                    newValue.Descripcion = txbPrioDesc.Text;
                    //Validamos antes de efectuar ningun cambio
                    if (txbPrioNombre.Text == "" || txbPrioNombre.Text == null)
                    {
                        alertPrio.Style["display"] = "block";
                        lblPrioErrores.Text = "No hay una prioridad buscada";
                        return;
                    }
                    if (tipoIncidenciaDAO.getTipoIncidencia(txbPrioNombre.Text).Nombre != null && tipoIncidenciaDAO.getTipoIncidencia(lblNombre.Text).id != tipoIncidenciaDAO.getTipoIncidencia(txbPrioNombre.Text).id)
                    {
                        alertPrio.Style["display"] = "block";
                        lblPrioErrores.Text = "TipoIncidencia ya creada...";
                        return;
                    }
                    if (txbPrioDesc.Text == null)
                    {
                        txbPrioDesc.Text = "";
                    }
                    tipoIncidenciaDAO.Update(newValue, id);
                }
                Response.Redirect("TipoIncidencia.aspx",false);

            }
            catch (Exception)
            {
                hasError = true;
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