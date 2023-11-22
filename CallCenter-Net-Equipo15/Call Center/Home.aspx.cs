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
        UsuarioDAO usuarioDAO = new UsuarioDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                
                int id = getIDsesion();

                if (Session["Usuario"] != null && Session["Cuenta"] != null)
                {
                    Dominio.Cuenta cuenta = Session["Cuenta"] as Dominio.Cuenta;
                    string rolUsuario = cuenta.Rol.Nombre;

                    h1NomApe.InnerText = (Session["Usuario"] as Dominio.Usuario).Nombre + " " + (Session["Usuario"] as Dominio.Usuario).Apellido;

                    ScriptManager.RegisterStartupScript(this, GetType(), "ConfigurarRolUsuario", $"var rolUsuario = '{rolUsuario}';", true);

                    if (!IsPostBack)
                    {
                        if (rolUsuario == "Cliente")
                        {
                            Session["listaIncidencias"] = incidenciaDAO.ListByUsuarioId(id);
                            
                            rptIncidencias.DataSource = Session["listaIncidencias"];
                            rptIncidencias.DataBind();

                            mostrarObjetosCliente();
                        }
                        else if (rolUsuario == "Telefonista")
                        {
                            Session["listaIncidencias"] = incidenciaDAO.ListByUsuarioId(id);
                            rptIncidencias.DataSource = Session["listaIncidencias"];
                            rptIncidencias.DataBind();

                            Session["listaUsuario"] = usuarioDAO.GetUsuariosClientes();
                            rptUsuarios.DataSource = Session["listaUsuario"];
                            rptUsuarios.DataBind();

                            CargarIncidencias(id);
                            mostrarObjetos();
                        }
                        else if (rolUsuario == "Supervisor" || rolUsuario == "Administrador")
                        {
                            Session["listaIncidencias"] = incidenciaDAO.List();
                            rptIncidencias.DataSource = Session["listaIncidencias"];
                            rptIncidencias.DataBind();
                            

                            Session["listaUsuario"] = usuarioDAO.GetUsuariosClientes();
                            rptUsuarios.DataSource = Session["listaUsuario"];
                            rptUsuarios.DataBind();

                            CargarIncidencias(id);
                            mostrarObjetos();
                        }
                    }
                }
            }
            catch (Exception)
            {
                MostrarMensajeError("Se ha producido un error. Por favor, inténtalo de nuevo más tarde.");
            }
        }

        private void MostrarMensajeError(string mensaje)
        {
            lblMensajeError.Text = mensaje;
            lblMensajeError.Visible = true;
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
            List<Incidencia> listaIncidencias = Session["listaIncidencias"] as List<Incidencia>;

            if (listaIncidencias != null)
            {
                inciTotales.Text = listaIncidencias.Count.ToString();
                inciUrg.Text = listaIncidencias.Count(x => x.Prioridad.Nombre == "Urgente").ToString();
                inciPen.Text = listaIncidencias.Count(x => x.Estado.Nombre != "Cerrado" && x.Estado.Nombre != "Resuelto").ToString();
                inciFin.Text = listaIncidencias.Count(x => x.Estado.Nombre == "Resuelto").ToString();
                inciClose.Text = listaIncidencias.Count(x => x.Estado.Nombre == "Cerrado").ToString();
            }
        }

        protected void mostrarObjetos()
        {
            cantInci.Visible = true;
            filtroIDusu.Visible = true;
            filtro.Visible = true;
            usuDatos.Visible = true;
            txbFiltraDNI.Visible = true;
            lblFiltro.Visible = true;
            crearIncidencia.Visible = true;
            lblEstado.Visible = true;
            filtroEstado.Visible = true;
            lblPrioridad.Visible = true;
            filtroPrioridad.Visible = true;
            lblTipoInci.Visible = true;
            filtroTipoInci.Visible = true;
            liBusqueda.Visible = true;
            lblInciID.Visible = true;
            filtroInciID.Visible = true;
        }

        protected void mostrarObjetosCliente()
        {
            lblEstado.Visible = true;
            filtroEstado.Visible = true;
            lblTipoInci.Visible = true;
            filtroTipoInci.Visible = true;
            lblInciID.Visible = true;
            filtroInciID.Visible = true;
        }

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            List<Incidencia> listaInci = (List<Incidencia>)Session["listaIncidencias"];
            int id = getIDsesion();
            if (string.IsNullOrWhiteSpace(filtro.Text))
            {
                rptIncidencias.DataSource = listaInci;
                rptIncidencias.DataBind();
                CargarIncidencias(id);
                lblMenError.Visible = false;
                return;
            }

            if (int.TryParse(filtro.Text, out int idFiltrado))
            {
                List<Incidencia> listaFiltrada = listaInci.Where(x => x.Creador.Id == idFiltrado).ToList();

                if (listaFiltrada.Count == 0 && !string.IsNullOrWhiteSpace(filtro.Text))
                {
                    mostrarMensajeErrorVarios("No se encontro ID usuario proporcionado.");
                    return;
                }
                else
                {
                    rptIncidencias.DataSource = listaFiltrada;
                    rptIncidencias.DataBind();
                    CargarIncidencias(id);
                    lblMenError.Visible = false;
                }
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
            List<Incidencia> listaInci = (List<Incidencia>)Session["listaIncidencias"];
            int id = getIDsesion();
            string DNIFiltrado = txbFiltraDNI.Text.Trim();

            if (string.IsNullOrWhiteSpace(DNIFiltrado))
            {
                lblMensajeErrorDNI.Visible = false;

                rptUsuarios.DataSource = listaUsu;
                rptUsuarios.DataBind();

                rptIncidencias.DataSource = listaInci;
                rptIncidencias.DataBind();

                CargarIncidencias(id);
                return;
            }
            else
            {

                List<Usuario> listaFiltrada = listaUsu.Where(x => x.DNI == DNIFiltrado).ToList();

                if (listaFiltrada.Count == 0 && !string.IsNullOrWhiteSpace(DNIFiltrado))
                {
                    mostrarMensajeErrorDNI("No se encontraron usuarios con el DNI proporcionado.");
                    return;
                }
                else
                {
                    int idUsuarioFiltrado = listaFiltrada.FirstOrDefault()?.Id ?? -1;

                    List<Incidencia> listaIncidenciasFiltrada = listaInci.Where(x => x.Creador.Id == idUsuarioFiltrado).ToList();
                    rptUsuarios.DataSource = listaFiltrada;
                    rptUsuarios.DataBind();

                    rptIncidencias.DataSource = listaIncidenciasFiltrada;
                    rptIncidencias.DataBind();

                    CargarIncidencias(id);

                    lblMensajeErrorDNI.Visible = false;
                } 
            }
        }

        protected void crearIncidencia_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearIncidencia.aspx");
        }

        protected void filtroEstado_TextChanged(object sender, EventArgs e)
        {
            List<Incidencia> listaInci = (List<Incidencia>)Session["listaIncidencias"];
            int id = getIDsesion();
            if (string.IsNullOrWhiteSpace(filtroEstado.Text))
            {
                lblMenError.Visible = false;
                rptIncidencias.DataSource = listaInci;
                rptIncidencias.DataBind();
                CargarIncidencias(id);
                return;
            }
            else
            {
                List<Incidencia> listaFiltrada = listaInci.Where(x => x.Estado.Nombre == filtroEstado.Text).ToList();
                
                if (listaFiltrada.Count == 0 && !string.IsNullOrWhiteSpace(filtroEstado.Text))
                {
                    mostrarMensajeErrorVarios("No se encontro el Estado proporcionado.");
                    return;
                }
                else
                {
                    rptIncidencias.DataSource = listaFiltrada;
                    rptIncidencias.DataBind();
                    CargarIncidencias(id);
                    lblMenError.Visible = false;
                }
            }
        }

        protected void filtroPrioridad_TextChanged(object sender, EventArgs e)
        {
            List<Incidencia> listaInci = (List<Incidencia>)Session["listaIncidencias"];
            int id = getIDsesion();
            if (string.IsNullOrWhiteSpace(filtroPrioridad.Text))
            {
                lblMenError.Visible = false;
                rptIncidencias.DataSource = listaInci;
                rptIncidencias.DataBind();
                CargarIncidencias(id);
                return;
            }
            else
            {
                List<Incidencia> listaFiltrada = listaInci.Where(x => x.Prioridad.Nombre == filtroPrioridad.Text).ToList();
                
                if (listaFiltrada.Count == 0 && !string.IsNullOrWhiteSpace(filtroPrioridad.Text))
                {
                    mostrarMensajeErrorVarios("No se encontro la Prioridad proporcionada.");
                    return;
                }
                else
                {
                    rptIncidencias.DataSource = listaFiltrada;
                    rptIncidencias.DataBind();
                    CargarIncidencias(id);
                    lblMenError.Visible = false;
                }
            }
        }

        protected void filtroTipoPrio_TextChanged(object sender, EventArgs e)
        {
            List<Incidencia> listaInci = (List<Incidencia>)Session["listaIncidencias"];
            int id = getIDsesion();
            if (string.IsNullOrWhiteSpace(filtroTipoInci.Text))
            {
                rptIncidencias.DataSource = listaInci;
                rptIncidencias.DataBind();
                CargarIncidencias(id);
                lblMenError.Visible = false;
                return;
            }
            else
            {
                List<Incidencia> listaFiltrada = listaInci.Where(x => x.TipoIncidencia.Nombre == filtroTipoInci.Text).ToList();
                
                if (listaFiltrada.Count == 0 && !string.IsNullOrWhiteSpace(filtroTipoInci.Text))
                {
                    mostrarMensajeErrorVarios("No se encontro el Tipo de incidencia proporcionado.");
                    return;
                }
                else
                {
                    rptIncidencias.DataSource = listaFiltrada;
                    rptIncidencias.DataBind();
                    CargarIncidencias(id);
                    lblMenError.Visible = false;
                }
                
            }
        }

        private void mostrarMensajeErrorDNI(string mensaje)
        {
            lblMensajeErrorDNI.Text = mensaje;
            lblMensajeErrorDNI.Visible = true;
        }

        private void mostrarMensajeErrorVarios(string mensaje)
        {
            lblMenError.Text = mensaje;
            lblMenError.Visible = true;
        }

        protected void filtroInciID_TextChanged(object sender, EventArgs e)
        {
            List<Incidencia> listaInci = (List<Incidencia>)Session["listaIncidencias"];
            int id = getIDsesion();
            if (string.IsNullOrWhiteSpace(filtroInciID.Text))
            {
                rptIncidencias.DataSource = listaInci;
                rptIncidencias.DataBind();
                CargarIncidencias(id);
                lblMenError.Visible = false;
                return;
            }

            if (int.TryParse(filtroInciID.Text, out int idFiltrado))
            {
                List<Incidencia> listaFiltrada = listaInci.Where(x => x.Id == idFiltrado).ToList();

                if (listaFiltrada.Count == 0 && !string.IsNullOrWhiteSpace(filtroInciID.Text))
                {
                    mostrarMensajeErrorVarios("No se encontro ID incidencia proporcionado.");
                    return;
                }
                else
                {
                    rptIncidencias.DataSource = listaFiltrada;
                    rptIncidencias.DataBind();
                    CargarIncidencias(id);
                    lblMenError.Visible = false;
                }
            }
            else
            {
                rptIncidencias.DataSource = listaInci;
                rptIncidencias.DataBind();
                CargarIncidencias(id);
            }
        }
    }
}