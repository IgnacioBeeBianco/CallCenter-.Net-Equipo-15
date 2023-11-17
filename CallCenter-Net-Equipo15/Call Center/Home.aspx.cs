using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;
namespace Call_Center
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IncidenciaDAO incidenciaDAO = new IncidenciaDAO();
            int id=0;
            if (!IsPostBack)
            {
                id = getIDsesion();
                rptIncidencias.DataSource = incidenciaDAO.ListByUsuarioId(id);
                rptIncidencias.DataBind();
                CargarIncidencias(id);
            }
            if (Session["Usuario"] != null && Session["Cuenta"] != null)
            {

                h1NomApe.InnerText = (Session["Usuario"] as Dominio.Usuario).Nombre + " " + (Session["Usuario"] as Dominio.Usuario).Apellido;
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
            IncidenciaDAO incidenciaDAO = new IncidenciaDAO();

            inciTotales.Text = incidenciaDAO.incidenciasTotales(id).ToString();
            inciPen.Text = incidenciaDAO.incidenciasPendiente(id).ToString();
            inciUrg.Text = incidenciaDAO.incidenciasUrgente(id).ToString();
            inciFin.Text = incidenciaDAO.incidenciasResuelto(id).ToString();
            inciClose.Text = incidenciaDAO.incidenciasCerrada(id).ToString();
        }
    }
}