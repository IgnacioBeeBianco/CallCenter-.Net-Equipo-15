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
            
            int id = 0;
            if (!IsPostBack)
            {
                id = getIDsesion();
                Session.Add("listaIncidencias", incidenciaDAO.ListByUsuarioId(id));
                Session.Add("listaUsuario", usuarioDAO.GetUsuariosClientes());
                rptIncidencias.DataSource = Session["listaIncidencias"];
                rptIncidencias.DataBind();
                rptUsuarios.DataSource = Session["listaUsuario"];
                rptUsuarios.DataBind();
            }

            if (Session["Usuario"] != null && Session["Cuenta"] != null && (Session["Cuenta"] as Dominio.Cuenta).Rol.Nombre != "Cliente")
            {
                CargarIncidencias(id);
                cantInci.Visible = true;
                filtroIDusu.Visible = true;
                filtro.Visible = true;
                usuDatos.Visible = true;
                txbFiltraDNI.Visible = true;
                lblFiltro.Visible = true;
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
            int id=getIDsesion();
            if (string.IsNullOrWhiteSpace(filtro.Text))
            {
                rptIncidencias.DataSource = listaInci;
                rptIncidencias.DataBind();
                CargarIncidencias(id);
                return;
            }

            if (int.TryParse(filtro.Text, out int idFiltrado))
            {
                List<Incidencia> listaFiltrada = listaInci.Where(x => x.Creador.Id == idFiltrado).ToList();

                rptIncidencias.DataSource = listaFiltrada;
                rptIncidencias.DataBind();
                CargarIncidencias(id);
            }
            else
            {
                rptIncidencias.DataSource = listaInci;
                rptIncidencias.DataBind();
                CargarIncidencias(id);
            }
        }

        protected void txbFiltraDNI_TextChanged(object sender, EventArgs e)
        {
            List<Usuario> listaUsu = (List<Usuario>)Session["listaUsuario"];
            int id = getIDsesion();
            string DNIFiltrado = txbFiltraDNI.Text.Trim();

            if (string.IsNullOrWhiteSpace(DNIFiltrado))
            {
                rptUsuarios.DataSource = listaUsu;
                rptUsuarios.DataBind();
                CargarIncidencias(id);
                return;
            }
            else
            {
                List<Usuario> listaFiltrada = listaUsu.Where(x => x.DNI == DNIFiltrado).ToList();

                rptUsuarios.DataSource = listaFiltrada;
                rptUsuarios.DataBind();
                CargarIncidencias(id);
            }
        }

        

        private int ObtenerRecuentoPorEstado(string estado)
        {
            // Lógica para obtener el recuento de incidencias por estado.
            // Puedes usar tu lógica y acceder a la base de datos aquí.
            // Por ahora, vamos a devolver un valor aleatorio.
            Random random = new Random();
            return random.Next(1, 20);
        }

    }
}