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
        }

        protected void rptColumnas_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string nombre = DataBinder.Eval(e.Item.DataItem, "nombre").ToString();
                IncidenciaDAO incidenciaDAO = new IncidenciaDAO();
                List<Incidencia> incidencias = incidenciaDAO.ListByEstado(nombre);
                Repeater rptIncidencias = (Repeater)e.Item.FindControl("rptIncidencias");
                rptIncidencias.DataSource = incidencias;
                rptIncidencias.DataBind();
            }
        }
    }
}