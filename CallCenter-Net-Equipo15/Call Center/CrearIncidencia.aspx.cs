using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;
using Dominio;
using Negocio;

namespace Call_Center
{
    public partial class CrearIncidencia : System.Web.UI.Page
    {
        TipoIncidenciaDAO tipoIncidenciaDAO = new TipoIncidenciaDAO();
        PrioridadDAO prioridadDAO = new PrioridadDAO();
        EstadoDAO estadoDAO = new EstadoDAO();
        UsuarioDAO usuarioDAO = new UsuarioDAO();
        IncidenciaDAO incidenciaDAO = new IncidenciaDAO();
        IncidenciaNegocio IncidenciaNegocio = new IncidenciaNegocio();
        Incidencia Incidencia = new Incidencia();
        protected bool hasError = false;

        private void LoadData(Incidencia incidencia)
        {
            OwnerId.Text = incidencia.Asignado.Id.ToString();
            Owner.Text = incidencia.Asignado.Nombre;
            DropDownCreador.SelectedValue = incidencia.Creador.Nombre;
            txtbFechaCreacion.Text = incidencia.FechaCreacion.ToString();
            txtbFechaCambio.Text = incidencia.FechaCierre.ToString();
            LblEstado.Text = incidencia.Estado.Nombre.ToString();
            DropDownPrio.SelectedValue = incidencia.Prioridad.ToString();
            ddlTipoIncidencia.SelectedValue = incidencia.TipoIncidencia.ToString();
            IncidenciaId.Value = incidencia.Id.ToString();
            problematica.Value = incidencia.problematica.ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            hasError = false;
            if (!IsPostBack)
            {
                LoadCombos(); 
                DropDownEstados.Enabled = false;
                if (IsEditingTicket())
                {
                    if (int.TryParse(Request.QueryString["id"], out int incidenciaId))
                    {
                        DropDownCreador.Enabled = false;
                        Incidencia = IncidenciaNegocio.List(incidenciaId);
                        LoadData(Incidencia);
                        if (IsAdmin())
                        {
                            DropDownAsignado.Enabled = true;
                        }
                        else
                        {
                            DropDownAsignado.Enabled = false;
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
                    LoadDataToCreateTicket();
                    BtnCloseTicket.Style["display"] = "none";
                    BtnResolveTicket.Style["display"] = "none";
                    DropDownAsignado.Enabled = false;
                }
                
            }
        }
        private void LoadCombos()
        {
            cargarDatosDDLTipoIncidencia();
            cargarDatosDDLPrioridad();
            cargarDatosDDLEstado();
            cargarDatosDDLUsuarios();
            cargarDatosDDLUsuariosCreador();
        }
        
        protected bool IsEditingTicket()
        {
            return Request.QueryString["id"] != null;
        }

        private bool IsAdmin()
        {
            return (Session["Cuenta"] as Cuenta).Rol.Nombre == "Administrador";
        }

        private void LoadDataToCreateTicket()
        {
            Owner.Text = (Session["Usuario"] as Usuario).Nombre;
            OwnerId.Text = (Session["Usuario"] as Usuario).Id.ToString();
            Estado estado = estadoDAO.getEstado("Abierto");
            HdfEstado.Value = estado.Id.ToString();
            LblEstado.Text = estado.Nombre;
            IncidenciaId.Value = "0";
            cargarFechaHoraTxtBox();
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
            DropDownCreador.DataSource = usuarioDAO.GetUsuariosClientes();
            DropDownCreador.DataTextField = "Nombre";
            DropDownCreador.DataValueField = "Nombre";
            DropDownCreador.DataBind();
            
        }

        private void cargarFechaHoraTxtBox()
        {
            DateTime fechaActual = DateTime.Now;

            txtbFechaCreacion.Text = fechaActual.ToString("yyyy-MM-dd HH:mm:ss");
            txtbFechaCambio.Text = fechaActual.ToString("yyyy-MM-dd HH:mm:ss");
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                Incidencia.Id = long.Parse(IncidenciaId.Value.ToString());
                Incidencia.Creador.Id = usuarioDAO.getUsuarioId(DropDownCreador.SelectedValue);
                Incidencia.Asignado.Id = int.Parse(OwnerId.Text);
                DateTime fechaCreacion;
                DateTime.TryParseExact(txtbFechaCreacion.Text, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaCreacion);
                Incidencia.FechaCreacion = fechaCreacion;
                DateTime fechaUltimoCambio;
                DateTime.TryParseExact(txtbFechaCambio.Text, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaUltimoCambio);
                Incidencia.FechaCierre = fechaUltimoCambio;

                Incidencia.Estado.Id = estadoDAO.getEstadoId(DropDownEstados.SelectedValue);
                Incidencia.Prioridad.Id = prioridadDAO.getPrioridadId(DropDownPrio.SelectedValue);
                Incidencia.TipoIncidencia.id = tipoIncidenciaDAO.getTipoIncidenciaId(ddlTipoIncidencia.SelectedValue);

                Incidencia.ComentarioCierre = null;
                Incidencia.problematica = problematica.InnerText;

                if(Incidencia.Id == 0)
                {
                    incidenciaDAO.Create(Incidencia);
                    Response.Redirect("Home.aspx", false);
                }
                else
                {
                    Incidencia.FechaCierre = DateTime.Now;
                    Incidencia.Estado.Id = estadoDAO.getEstadoId("En Análisis");
                    incidenciaDAO.Update(Incidencia);
                    Response.Redirect($"CrearIncidencia.aspx?id={IncidenciaId.Value}");
                }

            }
            catch (Exception)
            {
                hasError = true;
            }
            
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
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
                if(comentario.Texto == "" || comentario.Texto ==  null)
                {
                    throw new Exception("No puede ser nulo el comentario");
                }
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
                Incidencia.Id = long.Parse(IncidenciaId.Value);
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

        protected void BtnResolveTicket_Click(object sender, EventArgs e)
        {
            Response.Redirect($"Survey.aspx?ticketId={IncidenciaId.Value}");
        }

        protected void BtnCloseTicket_Click(object sender, EventArgs e)
        {
            Response.Redirect($"CloseComment.aspx?ticketId={IncidenciaId.Value}");
        }

        protected void BtnDeleteComment_Click(object sender, EventArgs e)
        {
            int commentId = int.Parse(((LinkButton)sender).CommandArgument);
            try
            {
                IncidenciaNegocio.DeleteComment(commentId);
            }catch(Exception)
            {
                hasError = true;
            }
        }
    }
}