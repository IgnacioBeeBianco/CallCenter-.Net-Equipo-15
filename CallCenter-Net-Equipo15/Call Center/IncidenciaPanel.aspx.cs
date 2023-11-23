using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using System.Configuration;
using System.Data.SqlClient;

namespace Call_Center
{
    public partial class IncidenciaPanel : System.Web.UI.Page
    {

        Usuario usuario = new Usuario();
        Cuenta cuenta = new Cuenta();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/Login.aspx"); //Aca nos encargamos de implementar que si no logeo vaya al login
            }
            usuario = (Usuario) Session["Usuario"];
            cuenta = (Cuenta) Session["Cuenta"];
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            EstadoDAO estadoDAO = new EstadoDAO();
            List<Estado> Estados = estadoDAO.List().Where(estado => estado.estado).ToList();
            rptColumnas.DataSource = Estados;
            rptColumnas.DataBind();


            UsuarioDAO usuarioDAO = new UsuarioDAO();
            List<Usuario> Usuarios = new List<Usuario>();
            if (cuenta.Rol.Nombre == "Administrador")
            {
                Usuarios = usuarioDAO.GetUsuariosClientes();
            }
            else
            {
                Usuarios = usuarioDAO.GetUsuariosClientesConIncidencias(cuenta.Id);
            }
            rptAsignados.DataSource = Usuarios;
            rptAsignados.DataBind();
        }

        protected void rptColumnas_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                try
                {
                    string nombre = DataBinder.Eval(e.Item.DataItem, "nombre").ToString();
                    int idCreador = Request.QueryString["requested"]!= null ? int.Parse(Request.QueryString["requested"]) : -1;
                    IncidenciaDAO incidenciaDAO = new IncidenciaDAO();
                    List<Incidencia> incidencias = new List<Incidencia>();
                    if(cuenta.Rol.Nombre == "Administrador")
                    {
                        incidencias = idCreador == -1 ? incidenciaDAO.ListByEstado(nombre) : incidenciaDAO.ListByEstadoxCliente(nombre, idCreador);
                    }
                    else
                    {
                        incidencias = idCreador == -1 ? incidenciaDAO.ListByEstado(nombre, usuario.Id) : incidenciaDAO.ListByEstadoxCliente(nombre, idCreador, usuario.Id);
                    }
                    Repeater rptIncidencias = (Repeater)e.Item.FindControl("rptIncidencias");
                    rptIncidencias.DataSource = incidencias;
                    rptIncidencias.DataBind();

                }catch(Exception ex)
                {
                    throw ex;
                }
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
            lblProblematica.Text = "Incidencia:" + incidencia.problematica;
            lblEstado.Text = "Estado: " + incidencia.Estado.Nombre.ToString();
            lblOwner.Text = "Asignado: " + incidencia.Asignado.Nombre;
            lblIssuer.Text = "Creador: " + incidencia.Creador.Nombre;

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

        protected void BtnResolveTicket_Click(object sender, EventArgs e)
        {

        }

        protected void BtnSeeMore_Click(object sender, EventArgs e)
        {
            IncidenciaDAO incidenciaDAO = new IncidenciaDAO();
            Incidencia incidencia = incidenciaDAO.getIncidencia(int.Parse(lblId.Text));

            
            Response.Redirect($"CrearIncidencia.aspx?id={incidencia.Id}");
        }

    }
}