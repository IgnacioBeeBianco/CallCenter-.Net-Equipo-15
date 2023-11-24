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
        Incidencia incidencia = new Incidencia();
        protected bool hasError = false;

        private void LoadData(Incidencia incidencia)
        {
            OwnerId.Text = incidencia.Asignado.Id.ToString();
            Owner.Text = incidencia.Asignado.Nombre;
            DropDownCreador.SelectedValue = incidencia.Creador.Nombre;
            txtbFechaCreacion.Text = incidencia.FechaCreacion.ToString();
            txtbFechaCambio.Text = incidencia.FechaCierre.ToString();
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
                DropDownEstados.Enabled = false;
                if (Request.QueryString["id"] != null)
                {
                    if (int.TryParse(Request.QueryString["id"], out int incidenciaId))
                    {
                        Incidencia = incidenciaDAO.getIncidencia(incidenciaId);
                        Incidencia.Comentarios = ComentarioIncidenciaDAO.GetComentarios(incidenciaId);
                        LoadData(Incidencia);
                        if ((Session["Cuenta"] as Cuenta).Rol.Nombre == "Administrador")
                        {
                            DropDownCreador.Enabled = true;
                        }
                        else
                        {
                            DropDownCreador.Enabled = false;
                        }
                        RptComments.DataSource = Incidencia.Comentarios;
                        RptComments.DataBind();
                        
                    }
                    else
                    {
                        Response.Redirect("IncidenciaPanel.aspx");
                    }
                }
                else
                {
                    Owner.Text = (Session["Usuario"] as Usuario).Nombre;
                    cargarFechaHoraTxtBox();
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
            DropDownAsignado.DataValueField = "Id";
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
                Incidencia.Id = long.Parse(IncidenciaId.Value.ToString());
                Incidencia.Creador.Id = usuarioDAO.getUsuarioId(DropDownCreador.SelectedValue);
                Incidencia.Asignado.Id = int.Parse(OwnerId.Text);
                Incidencia.FechaCreacion = DateTime.Parse(txtbFechaCreacion.Text, CultureInfo.InvariantCulture);
                Incidencia.FechaCierre = DateTime.Parse(txtbFechaCambio.Text, CultureInfo.InvariantCulture);

                Incidencia.Estado.Id = estadoDAO.getEstadoId(DropDownEstados.SelectedValue);
                Incidencia.Prioridad.Id = prioridadDAO.getPrioridadId(DropDownPrio.SelectedValue);
                Incidencia.TipoIncidencia.id = tipoIncidenciaDAO.getTipoIncidenciaId(ddlTipoIncidencia.SelectedValue);

                Incidencia.ComentarioCierre = null;
                Incidencia.problematica = problematica.InnerText;

                if(Incidencia.Id == 0)
                {
                    incidenciaDAO.Create(Incidencia);
                    Response.Redirect("CrearIncidencia.aspx");
                }
                else
                {
                    Incidencia.FechaCierre = DateTime.Now;
                    Incidencia.Estado.Id = estadoDAO.getEstadoId("En Análisis");
                    incidenciaDAO.Update(Incidencia);
                    Response.Redirect($"CrearIncidencia.aspx?id={IncidenciaId.Value}");
                }

            }
            catch (Exception ex)
            {
                hasError = true;
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

        protected void DropDownAsignado_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListItem selectedItem = DropDownAsignado.SelectedItem;

            if(selectedItem != null)
            {
                Owner.Text = selectedItem.Text;
                OwnerId.Text = selectedItem.Value;
                try
                {
                    incidenciaDAO.ModifyOwner(int.Parse(OwnerId.Text), Incidencia.Id);
                    Estado estado = estadoDAO.getEstado("Asignado");
                    incidenciaDAO.ModifyState(estado.Id, Incidencia.Id);
                }
                catch (Exception)
                {
                    hasError = true;

                }
            }
        }
    }
}