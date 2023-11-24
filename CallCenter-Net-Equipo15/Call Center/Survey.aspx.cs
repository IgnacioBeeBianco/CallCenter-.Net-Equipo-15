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
    public partial class WebForm1 : System.Web.UI.Page
    {
        private Incidencia Incidencia { get; set; }
        private IncidenciaDAO IncidenciaDAO = new IncidenciaDAO();
        private EstadoDAO EstadoDAO = new EstadoDAO();
        public bool hasError = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(int.TryParse(Request.QueryString["ticketId"], out int incidenciaId))
            {
                Incidencia = IncidenciaDAO.getIncidencia(incidenciaId);

            }
        }

        protected void BtnResolveTicket_Click(object sender, EventArgs e)
        {
            try
            {
                Incidencia.Encuesta = new Encuesta();

                Incidencia.Encuesta.Calificacion = int.Parse(TxbCalification.Text);
                Incidencia.Encuesta.Comentario = TxbComments.Text;
                int usuarioId = ((Usuario)Session["Usuario"]).Id;
                IncidenciaDAO.AddSurvey(Incidencia.Encuesta, Incidencia.Id, usuarioId);
                Estado estado = new Estado();
                estado = EstadoDAO.getEstado("Resuelto");
                IncidenciaDAO.ModifyState(estado.Id, Incidencia.Id);

                Response.Redirect("Home.aspx");
            }
            catch (Exception)
            {
                hasError = true;
            }

        }

        protected void BtnGoBack_Click(object sender, EventArgs e)
        {
            Response.Redirect($"CrearIncidencia.aspx?id={Incidencia.Id}");
        }
    }
}