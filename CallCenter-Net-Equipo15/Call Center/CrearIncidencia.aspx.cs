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
        Incidencia Incidencia = new Incidencia();
        ComentarioIncidenciaDAO ComentarioIncidenciaDAO = new ComentarioIncidenciaDAO();
        protected bool hasError = false;

        private void LoadData(Incidencia incidencia)
        {
            OwnerId.Text = incidencia.Asignado.Id.ToString();
            Owner.Text = incidencia.Asignado.Nombre;
            DropDownCreador.SelectedValue = incidencia.Creador.Nombre;
            txtbFechaCreacion.Text = incidencia.FechaCreacion.ToString();
            DropDownEstados.SelectedValue = incidencia.Estado.ToString();
            DropDownPrio.SelectedValue = incidencia.Prioridad.ToString();
            ddlTipoIncidencia.SelectedValue = incidencia.TipoIncidencia.ToString();
            IncidenciaId.Value = incidencia.Id.ToString();
            problematica.Value = incidencia.problematica.ToString();
        }

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
                Owner.Text = (Session["Usuario"] as Usuario).Nombre;
                DropDownEstados.Enabled = false;
                if (Request.QueryString["id"] != null)
                {
                    if (int.TryParse(Request.QueryString["id"], out int incidenciaId))
                    {
                        Incidencia = incidenciaDAO.getIncidencia(incidenciaId);
                        Incidencia.Comentarios = ComentarioIncidenciaDAO.GetComentarios(incidenciaId);
                        LoadData(Incidencia);
                        DropDownCreador.Enabled = false;
                        RptComments.DataSource = Incidencia.Comentarios;
                        RptComments.DataBind();
                        
                    }
                    else
                    {
                        Response.Redirect("IncidenciaPanel.aspx");
                    }
                }
            }
        }

        protected string EnableAddCommentButton()
        {
            if (int.TryParse(Request.QueryString["id"], out int incidenciaId))
            {
                return "disabled = true";
            }

            return ""; // Botón habilitado por defecto
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
                //incidencia.Asignado.Id = usuarioDAO.getUsuarioId(DropDownAsignado.SelectedValue);
                incidencia.Asignado.Id = (Session["Usuario"] as Usuario).Id;
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
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void BtnAddComment_Click(object sender, EventArgs e)
        {

        }

        protected void BtnSaveComment_Click(object sender, EventArgs e)
        {
            IncidenciaDAO incidenciaDAO = new IncidenciaDAO();

            Comentario comentario = new Comentario();
            comentario.Fecha = DateTime.Now;
            comentario.Usuario = new Usuario();
            comentario.Usuario.Id = (Session["Usuario"] as Usuario).Id;
            comentario.IncidenciaId = long.Parse(IncidenciaId.Value);
            comentario.Texto = CommentTextArea.Text;
            try
            {
                incidenciaDAO.AddComment(comentario);
                EstadoDAO estadoDAO = new EstadoDAO();
                Estado estado = estadoDAO.getEstado("En Análisis");
                incidenciaDAO.ModifyState(estado.Id, int.Parse(IncidenciaId.Value));
                Response.Redirect($"CrearIncidencia.aspx?id={IncidenciaId.Value}");
            }
            catch (Exception)
            {
                hasError = true;
            }

        }
    }
}