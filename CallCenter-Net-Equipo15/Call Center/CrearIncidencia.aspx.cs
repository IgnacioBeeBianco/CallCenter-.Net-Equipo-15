using System;
using System.Collections.Generic;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<TipoIncidencia> tipoIncidencias = new List<TipoIncidencia>();
                tipoIncidencias = tipoIncidenciaDAO.List();
                
                foreach(var tipoIncidencia in tipoIncidencias)
                {
                    ddlTipoIncidencia.Items.Add(tipoIncidencia.Nombre);
                }

                DropDownPrio.DataSource = prioridadDAO.List();
                DropDownPrio.DataTextField = "Nombre";
                DropDownPrio.DataValueField = "Id";
                DropDownPrio.DataBind();

                DropDownEstados.DataSource = estadoDAO.List();
                DropDownEstados.DataTextField = "Nombre";
                DropDownEstados.DataValueField= "Id";
                DropDownEstados.DataBind();

            }
        }
    }
}