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

        protected void optionsTicket(object sender, EventArgs e)
        {
            IncidenciaDAO incidenciaDAO = new IncidenciaDAO();
            Button btn = sender as Button;
            modal.Style["display"] = "block";
            moverAOpts.Style["display"] = "none";
            int id = int.Parse(((Button)sender).CommandArgument);
            Incidencia incidencia = incidenciaDAO.getIncidencia(id);

            lblId.Text = incidencia.Id.ToString();
            lblProblematica.Text = incidencia.problematica;
            lblEstado.Text = incidencia.Estado.Nombre.ToString();

            EstadoDAO estadoDAO = new EstadoDAO();
            rptMoverA.DataSource = estadoDAO.List();
            rptMoverA.DataBind();
        }

        protected void cancelarModal(object sender, EventArgs e)
        {
            //Limpiamos el modal
            modal.Style["display"] = "none";
            alert.Style["display"] = "none";
            moverAOpts.Style["display"] = "none";
        }

        protected void btnMoverA_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int id = int.Parse(lblId.Text);
            moverAOpts.Style["display"] = "flex";


        }

        protected void cerrarMoverA(object sender, EventArgs e)
        {
            moverAOpts.Style["display"] = "none";
        }
    }
}