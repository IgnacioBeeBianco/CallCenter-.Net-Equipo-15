using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using DAO;
using Dominio;
namespace Call_Center
{
    public partial class Home : System.Web.UI.Page
    {
        IncidenciaDAO incidenciaDAO = new IncidenciaDAO();
        Usuario usuario = new Usuario();
        UsuarioDAO usuarioDAO = new UsuarioDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            int id=0;
            if (!IsPostBack)
            {
                id = getIDsesion();
                Session.Add("listaIncidencias", incidenciaDAO.ListByUsuarioId(id));
                rptIncidencias.DataSource = Session["listaIncidencias"];
                rptIncidencias.DataBind();
                rptUsuarios.DataSource = usuarioDAO.GetUsuariosClientes();
                rptUsuarios.DataBind();
            }

            if ((Session["Cuenta"] as Dominio.Cuenta).Rol.Nombre != "Cliente")
            {
                CargarIncidencias(id);
                cantInci.Visible = true;
            }

            if (Session["Usuario"] != null && Session["Cuenta"] != null)
            {
                h1NomApe.InnerText = (Session["Usuario"] as Dominio.Usuario).Nombre + " " + (Session["Usuario"] as Dominio.Usuario).Apellido;
                string rolUsuario = (Session["Cuenta"] as Dominio.Cuenta).Rol.Nombre;
                ScriptManager.RegisterStartupScript(this, GetType(), "ConfigurarRolUsuario", $"var rolUsuario = '{rolUsuario}';", true);
            }
        }
        protected int getIDsesion()
        {
            if (Session["Usuario"] != null)
            {
                int id = (Session["Usuario"] as Dominio.Usuario).Id;
                return id;
            }
            else
            {
                return 0;
            }
        }

        protected void CargarIncidencias(int id)
        {
            inciTotales.Text = incidenciaDAO.incidenciasTotales(id).ToString();
            inciPen.Text = incidenciaDAO.incidenciasPendiente(id).ToString();
            inciUrg.Text = incidenciaDAO.incidenciasUrgente(id).ToString();
            inciFin.Text = incidenciaDAO.incidenciasResuelto(id).ToString();
            inciClose.Text = incidenciaDAO.incidenciasCerrada(id).ToString();
        }

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            List<Incidencia> listaInci = (List<Incidencia>)Session["listaIncidencias"];

            if (string.IsNullOrWhiteSpace(filtro.Text))
            {
                rptIncidencias.DataSource = listaInci;
                rptIncidencias.DataBind();
                CargarIncidencias(getIDsesion());
                return;
            }

            if (int.TryParse(filtro.Text, out int idFiltrado))
            {
                List<Incidencia> listaFiltrada = listaInci.Where(x => x.Creador.Id == idFiltrado).ToList();

                rptIncidencias.DataSource = listaFiltrada;
                rptIncidencias.DataBind();
                CargarIncidencias(getIDsesion());
            }
            else
            {
                rptIncidencias.DataSource = listaInci;
                rptIncidencias.DataBind();
                CargarIncidencias(getIDsesion());
            }
        }

    }
}