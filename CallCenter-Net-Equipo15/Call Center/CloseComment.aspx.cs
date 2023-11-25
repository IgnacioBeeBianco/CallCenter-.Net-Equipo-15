using DAO;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Call_Center
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        private Incidencia Incidencia { get; set; }
        private IncidenciaDAO IncidenciaDAO = new IncidenciaDAO();
        protected bool hasError = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (int.TryParse(Request.QueryString["ticketId"], out int incidenciaId))
            {
                Incidencia = IncidenciaDAO.getIncidencia(incidenciaId);
            }
        }

        protected void BtnCloseTicket_Click(object sender, EventArgs e)
        {
            try
            {
                EstadoDAO estadoDAO = new EstadoDAO();
                Estado estado = estadoDAO.getEstado("Cerrado");
                Incidencia.Estado = estado;
                Incidencia.ComentarioCierre = TxbCloseComment.Text;
                IncidenciaDAO.Update(Incidencia);
                Response.Redirect("Home.aspx");
            }catch (Exception)
            {
                hasError = true;
            }
        }

        protected void BtnGoBack_Click(object sender, EventArgs e)
        {
            Response.Redirect($"CrearIncidencia.aspx?ticketId={Incidencia.Id}");
        }
    }
}