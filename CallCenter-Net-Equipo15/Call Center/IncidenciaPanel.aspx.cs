using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Call_Center
{
    public partial class IncidenciaPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            EstadoDAO estadoDAO = new EstadoDAO();
            List<Estado> Estados = estadoDAO.List();
            rptColumnas.DataSource = Estados;
            rptColumnas.DataBind();


            UsuarioDAO usuarioDAO = new UsuarioDAO();
            List<Usuario> Usuarios = usuarioDAO.GetUsuariosClientes();
            rptAsignados.DataSource = Usuarios;
            rptAsignados.DataBind();
        }

        protected void rptColumnas_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string nombre = DataBinder.Eval(e.Item.DataItem, "nombre").ToString();
                int idCreador = Request.QueryString["requested"]!= null ? int.Parse(Request.QueryString["requested"]) : -1;
                IncidenciaDAO incidenciaDAO = new IncidenciaDAO();
                Usuario usuario = new Usuario();
                usuario = (Usuario)Session["Usuario"];
                Cuenta cuenta = new Cuenta();
                cuenta = (Cuenta)Session["Cuenta"];
                List<Incidencia> incidencias = idCreador == -1 ? incidenciaDAO.ListByEstado(nombre, usuario.Id) : incidenciaDAO.ListByEstadoxCliente(nombre, idCreador, usuario.Id);
                Repeater rptIncidencias = (Repeater)e.Item.FindControl("rptIncidencias");
                rptIncidencias.DataSource = incidencias;
                rptIncidencias.DataBind();
            }
        }

        protected void optionsTicket(object sender, EventArgs e)
        {
            IncidenciaDAO incidenciaDAO = new IncidenciaDAO();
            Button btn = sender as Button;
            modal.Style["display"] = "block";
            moverAOpts.Style["display"] = "none";
            int id = int.Parse(((Button)sender).CommandArgument);
            Incidencia incidencia = incidenciaDAO.getIncidencia(id);

            lblId.Text = incidencia.Id.ToString();
            lblProblematica.Text = incidencia.problematica;
            lblEstado.Text = incidencia.Estado.Nombre.ToString();

            IncidenciaNegocio incidenciaNegocio = new IncidenciaNegocio();
            rptMoverA.DataSource = incidenciaNegocio.TraerEstadosMenos(incidencia.Estado.Nombre);
            rptMoverA.DataBind();
        }

        protected void cancelarModal(object sender, EventArgs e)
        {
            //Limpiamos el modal
            modal.Style["display"] = "none";
            alert.Style["display"] = "none";
            moverAOpts.Style["display"] = "none";
        }

        protected void btnMoverA_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int id = int.Parse(lblId.Text);
            moverAOpts.Style["display"] = "flex";


        }

        protected void cerrarMoverA(object sender, EventArgs e)
        {
            moverAOpts.Style["display"] = "none";
        }

        protected void btnCambiarEstado_Click(object sender, EventArgs e)
        {
            try
            {
                IncidenciaNegocio incidenciaNegocio = new IncidenciaNegocio();
                Button btn = sender as Button;
                int id = int.Parse(((Button)sender).CommandArgument);
                int idEstado = int.Parse(btn.Attributes["idEstado"]);
                incidenciaNegocio.UpdateEstado(idEstado, id);
                Response.Redirect("IncidenciaPanel.aspx");

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}