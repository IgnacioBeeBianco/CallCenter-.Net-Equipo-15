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
        protected void Page_Load(object sender, EventArgs e)
        {
            List<TipoIncidencia> tipoIncidencias = new List<TipoIncidencia>();
            tipoIncidencias = tipoIncidenciaDAO.List();
            foreach(var tipoIncidencia in tipoIncidencias)
            {
                ddlTipoIncidencia.Items.Add(tipoIncidencia.Nombre);
            }
        }
    }
}