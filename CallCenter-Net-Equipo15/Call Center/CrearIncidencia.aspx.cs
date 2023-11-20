using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;
using Dominio;

namespace Call_Center
{
    public partial class CrearIncidencia : System.Web.UI.Page
    {
        TipoIncidenciaDAO tipoIncidenciaDAO = new TipoIncidenciaDAO();
        PrioridadDAO prioridadDAO = new PrioridadDAO();
        EstadoDAO estadoDAO = new EstadoDAO();
        UsuarioDAO usuarioDAO = new UsuarioDAO();
        IncidenciaDAO incidenciaDAO = new IncidenciaDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarDatosDDLTipoIncidencia();
                cargarDatosDDLPrioridad();
                cargarDatosDDLEstado();
                cargarDatosDDLUsuarios();
                cargarDatosDDLUsuariosCreador();
                cargarFechaHoraTxtBox();
            }
        }

        private void cargarDatosDDLTipoIncidencia()
        {
            ddlTipoIncidencia.DataSource = tipoIncidenciaDAO.List();
            ddlTipoIncidencia.DataTextField = "Nombre";
            ddlTipoIncidencia.DataValueField = "Nombre";
            ddlTipoIncidencia.DataBind();
        }

        private void cargarDatosDDLPrioridad()
        {
            DropDownPrio.DataSource = prioridadDAO.List();
            DropDownPrio.DataTextField = "Nombre";
            DropDownPrio.DataValueField = "Nombre";
            DropDownPrio.DataBind();
        }

        private void cargarDatosDDLEstado()
        {
            DropDownEstados.DataSource = estadoDAO.List();
            DropDownEstados.DataTextField = "Nombre";
            DropDownEstados.DataValueField = "Nombre";
            DropDownEstados.DataBind();
        }

        private void cargarDatosDDLUsuarios()
        {
            DropDownAsignado.DataSource = usuarioDAO.GetUsuariosDistintosClientes();
            DropDownAsignado.DataTextField = "Nombre";
            DropDownAsignado.DataValueField = "Nombre";
            DropDownAsignado.DataBind();
        }

        private void cargarDatosDDLUsuariosCreador()
        {
            DropDownCreador.DataSource = usuarioDAO.GetUsuarios();
            DropDownCreador.DataTextField = "Nombre";
            DropDownCreador.DataValueField = "Nombre";
            DropDownCreador.DataBind();
        }

        private void cargarFechaHoraTxtBox()
        {
            DateTime fechaActual = DateTime.Now;

            txtbFechaCreacion.Text = fechaActual.ToString("dd/MM/yyyy HH:mm:ss");
            txtbFechaCambio.Text = fechaActual.ToString("dd/MM/yyyy HH:mm:ss");
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                Incidencia incidencia = new Incidencia();

                incidencia.Creador.Id = usuarioDAO.getUsuarioId(DropDownCreador.SelectedValue);
                incidencia.Asignado.Id = usuarioDAO.getUsuarioId(DropDownAsignado.SelectedValue);
                incidencia.FechaCreacion = DateTime.ParseExact(txtbFechaCreacion.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                incidencia.FechaCierre = DateTime.ParseExact(txtbFechaCambio.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

                incidencia.Estado.Id = estadoDAO.getEstadoId(DropDownEstados.SelectedValue);
                incidencia.Prioridad.Id = prioridadDAO.getPrioridadId(DropDownPrio.SelectedValue);
                incidencia.TipoIncidencia.id = tipoIncidenciaDAO.getTipoIncidenciaId(ddlTipoIncidencia.SelectedValue);

                incidencia.ComentarioCierre = "";
                incidencia.problematica = problematica.InnerText;

                incidenciaDAO.Create(incidencia);

                Response.Redirect("Home.aspx");
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}