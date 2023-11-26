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
            try
            {
                if (Session["Usuario"] != null && Session["Cuenta"] != null)
                {
                    usuario = (Usuario)Session["Usuario"];
                    cuenta = (Cuenta)Session["Cuenta"];
                    if (!IsPostBack)
                    {
                        BindData();
                    }
                }
                else
                {
                    Response.Redirect("~/Login.aspx", false);
                }

            }
            catch(Exception)
            {
                Response.Redirect("Error.aspx");
            }
        }

        private void BindData()
        {
            try
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
            catch (Exception)
            {
                Response.Redirect("Error.aspx");
            }
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

                }catch(Exception)
                {
                    Response.Redirect("Error.aspx");
                }
            }
        }

        protected void optionsTicket(object sender, EventArgs e)
        {
            try
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
            catch (Exception)
            {
                Response.Redirect("Error.aspx");
            }
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
                Incidencia incidencia = new Incidencia();
                IncidenciaDAO incidenciaDAO = new IncidenciaDAO();
                incidencia = incidenciaDAO.getIncidencia(id);
                incidenciaNegocio.UpdateEstado(idEstado, id);

                Usuario cliente = new Usuario();
                UsuarioDAO usuarioDAO = new UsuarioDAO();
                cliente = usuarioDAO.GetUsuario(incidencia.Creador.Id);
                EmailService emailService = new EmailService();
                string asuntoCliente = "Se cambio el estado de " + id;
                string mensajeCliente = "Hola " + cliente.Apellido + " " + cliente.Nombre + ". La incidencia " + id
                    + " ha sido modificada, del estado " + incidencia.Estado.Nombre + " al estado " + btn.Text;
                emailService.armarCorreo(cliente.CuentaId.Email, asuntoCliente, mensajeCliente);
                emailService.enviarEmail();

                Usuario asignado = usuarioDAO.GetUsuario(incidencia.Asignado.Id);
                string asuntoAsignado = "Se cambio el estado de " + id;
                string mensajeAsignado = "Hola " +  asignado.Apellido + " " + asignado.Nombre + ". La incidencia " + id
                    + " ha sido modificada, del estado " + incidencia.Estado.Nombre + " al estado " + btn.Text;
                emailService.armarCorreo(asignado.CuentaId.Email, asuntoAsignado, mensajeAsignado);
                emailService.enviarEmail();
                Response.Redirect("IncidenciaPanel.aspx");


                
            }
            catch(Exception)
            {
                Response.Redirect("Error.aspx");
            }
        }

        protected void BtnResolveTicket_Click(object sender, EventArgs e)
        {
            //Enviar mail
        }

        protected void BtnSeeMore_Click(object sender, EventArgs e)
        {
            IncidenciaDAO incidenciaDAO = new IncidenciaDAO();
            Incidencia incidencia = incidenciaDAO.getIncidencia(int.Parse(lblId.Text));

            
            Response.Redirect($"CrearIncidencia.aspx?id={incidencia.Id}");
        }

    }
}