using DAO;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Call_Center.ABML
{
    public partial class Estado : System.Web.UI.Page
    {
        EstadoDAO estadoDAO = new EstadoDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null && Session["Cuenta"] != null)
            {
                EstadoDAO estadoDAO = new EstadoDAO();

                //Aca cargamos el repeater
                rptEstado.DataSource = estadoDAO.List().Where(entity => entity.estado);
                rptEstado.DataBind();
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
                

        }

        protected void btnQuitar(object sender, EventArgs e)
        {
            //Obtenemos el id que esta puesto como argumento del boton de delete y borramos
            int id = int.Parse(((Button)sender).CommandArgument);
            estadoDAO.Delete(id);
            Response.Redirect("Estado.aspx");
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
                    lblTitle.Text = "Modificar a ";
                    txbEstadoNombre.Text = estadoDAO.getEstado(id).Nombre;
                    txbNivelEstado.Text = estadoDAO.getEstado(id).nivelEstado.ToString();
                    lblNombre.Text = txbEstadoNombre.Text;
                    break;

                default:

                    break;
            }
        }

        protected void submitModal(object sender, EventArgs e)
        {
            int nivelEstadoTemp;
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
                if (!int.TryParse(txbNivelEstado.Text, out nivelEstadoTemp))
                {
                    alertEstado.Style["display"] = "block";
                    lblEstadoErrores.Text = "El valor del nivel de estado no es un número válido...";
                    return;
                }
                if (txbNivelEstado.Text == "" || txbNivelEstado.Text == null)
                {
                    alertEstado.Style["display"] = "block";
                    lblEstadoErrores.Text = "Debe ingresar un valor...";
                    return;
                }
                if (estado.nivelEstado < 1 || estado.nivelEstado > 10)
                {
                    alertEstado.Style["display"] = "block";
                    lblEstadoErrores.Text = "El nivel de estado debe estar entre 1 y 10...";
                    return;
                }
                estado.nivelEstado = nivelEstadoTemp;
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
                if (!int.TryParse(txbNivelEstado.Text, out nivelEstadoTemp))
                {
                    alertEstado.Style["display"] = "block";
                    lblEstadoErrores.Text = "El valor del nivel de estado no es un número válido...";
                    return;
                }
                if (txbNivelEstado.Text == "" || txbNivelEstado.Text == null)
                {
                    alertEstado.Style["display"] = "block";
                    lblEstadoErrores.Text = "Debe ingresar un valor...";
                    return;
                }
                if (nivelEstado < 1 || nivelEstado > 10)
                {
                    alertEstado.Style["display"] = "block";
                    lblEstadoErrores.Text = "El nivel de estado debe estar entre 1 y 10...";
                    return;
                }
                nivelEstado = nivelEstadoTemp;
                estadoDAO.Update(nombre, nivelEstado, id);
            }
            Response.Redirect("Estado.aspx");
        }

        protected void cancelarModal(object sender, EventArgs e)
        {
            //Limpiamos el modal
            modalEstado.Style["display"] = "none";
            txbEstadoNombre.Text = "";
            txbNivelEstado.Text = "";
            lblTitle.Text = "";
            lblNombre.Text = "";
            lblNivelEstado.Text = "";
            alertEstado.Style["display"] = "none";
        }
    }
}
