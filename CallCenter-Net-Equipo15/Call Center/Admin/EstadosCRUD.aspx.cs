using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Call_Center.Admin
{
    public partial class EstadosCRUD : System.Web.UI.Page
    {
        EstadoDAO estadoDAO = new EstadoDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            EstadoDAO estadoDAO = new EstadoDAO();


            //Aca cargamos el repeater
            rptEstado.DataSource = estadoDAO.List().Where(entity => entity.estado);
            rptEstado.DataBind();

        }

        protected void btnQuitar(object sender, EventArgs e)
        {
            //Obtenemos el id que esta puesto como argumento del boton de delete y borramos
            int id = int.Parse(((Button)sender).CommandArgument);
            estadoDAO.Delete(id);
            Response.Redirect("EstadosCRUD.aspx");
        }

        protected void abrirModal(object sender, EventArgs e)
        {
            //Logica que abre el modal y le carga datos segun si es crear o modificar"
            LinkButton btn = sender as LinkButton;
            modalEstado.Style["display"] = "block";

            switch (btn.Attributes["action"])
            {
                case "create":
                    lblTitle.Text = "Crear";
                    break;

                case "modify":
                    int id = int.Parse(((LinkButton)sender).CommandArgument);
                    txbEstadoNombre.Text = estadoDAO.getEstado(id).Nombre;
                    txbNivelEstado.Text = estadoDAO.getEstado(id).nivelEstado.ToString();
                    lblTitle.Text = "Modificar a ";
                    lblNombre.Text = txbEstadoNombre.Text;
                    lblNivelEstado.Text = txbNivelEstado.Text;
                    break;

                default:

                    break;
            }
        }

        protected void submitModal(object sender, EventArgs e)
        {
            //Verificamos si es crear o modificar, y ejecutamos las acciones respectivas
            if (lblTitle.Text == "Crear")
            {
                Dominio.Estado estado = new Dominio.Estado();
                estado.Nombre = txbEstadoNombre.Text;
                estado.nivelEstado = int.Parse(txbNivelEstado.Text);
                //Validaciones
                if (txbEstadoNombre.Text == "" || txbEstadoNombre.Text == null)
                {
                    alertEstado.Style["display"] = "block";
                    lblEstadoErrores.Text = "El Estado debe tener nombre...";
                    return;
                }
                if (estadoDAO.getEstado(txbEstadoNombre.Text).Nombre != null)
                {
                    alertEstado.Style["display"] = "block";
                    lblEstadoErrores.Text = "Estado ya creado...";
                    return;
                }
                estadoDAO.Create(estado);
            }
            else
            {
                int id = estadoDAO.getEstado(lblNombre.Text).Id;
                string nombre = txbEstadoNombre.Text;
                int nivelEstado = int.Parse(txbNivelEstado.Text);
                //Validamos antes de efectuar ningun cambio
                if (txbEstadoNombre.Text == "" || txbEstadoNombre.Text == null)
                {
                    alertEstado.Style["display"] = "block";
                    lblEstadoErrores.Text = "No hay un estado buscado";
                    return;
                }
                if (!nombre.Equals(lblNombre.Text, StringComparison.OrdinalIgnoreCase))
                {
                    if (estadoDAO.getEstado(txbEstadoNombre.Text).Nombre != null)
                    {
                        alertEstado.Style["display"] = "block";
                        lblEstadoErrores.Text = "Estado ya creado...";
                        return;
                    }
                }
                estadoDAO.Update(nombre, nivelEstado, id);
            }

            Response.Redirect("EstadosCRUD.aspx");
        }

        protected void cancelarModal(object sender, EventArgs e)
        {
            //Limpiamos el modal
            modalEstado.Style["display"] = "none";
            txbEstadoNombre.Text = "";
            alertEstado.Style["display"] = "none";
        }
    }
}