using DAO;
using Dominio;
using Negocio;
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

                Usuario cliente = new Usuario();
                UsuarioDAO usuarioDAO = new UsuarioDAO();
                cliente = usuarioDAO.GetUsuario(Incidencia.Creador.Id);
                EmailService emailService = new EmailService();
                string asuntoCliente = "Se cambio el estado de " + Incidencia.Id;
                string mensajeCliente = "Hola " + cliente.Apellido + " " + cliente.Nombre + ". La incidencia " + Incidencia.Id
                    + " ha sido modificada, del estado " + Incidencia.Estado.Nombre + " al estado Resuelto. " +
                    "Con el siguiente comentario " + Incidencia.Encuesta.Comentario +
                    " su calificación fue de " + Incidencia.Encuesta.Calificacion.ToString() + "/5";
                emailService.armarCorreo(cliente.CuentaId.Email, asuntoCliente, mensajeCliente);
                emailService.enviarEmail();

                Usuario asignado = usuarioDAO.GetUsuario(Incidencia.Asignado.Id);
                string asuntoAsignado = "Se cambio el estado de " + Incidencia.Id;
                string mensajeAsignado = "Hola " + cliente.Apellido + " " + cliente.Nombre + ". La incidencia " + Incidencia.Id
                    + " ha sido modificada, del estado " + Incidencia.Estado.Nombre + " al estado Resuelto. " +
                    "Con el siguiente comentario " + Incidencia.Encuesta.Comentario + 
                    " su calificación fue de " + Incidencia.Encuesta.Calificacion.ToString() + "/5";
                emailService.armarCorreo(asignado.CuentaId.Email, asuntoAsignado, mensajeAsignado);
                emailService.enviarEmail();

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