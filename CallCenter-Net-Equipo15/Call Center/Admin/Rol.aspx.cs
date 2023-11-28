using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Call_Center.ABML
{
    public partial class Rol : System.Web.UI.Page
    {
        RolDAO rolDAO = new RolDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Usuario"] != null && Session["Cuenta"] != null)
                {
                    RolDAO rolDAO = new RolDAO();

                    //Aca cargamos el repeater
                    rptRol.DataSource = rolDAO.List().Where(rol => rol.Estado);
                    rptRol.DataBind();
                }
                else
                {
                    Response.Redirect("~/Login.aspx",false);
                }
            }
            catch(Exception)
            {
                Response.Redirect("~/Error.aspx");
            }

        }

        protected void btnQuitar(object sender, EventArgs e)
        {
            try
            {
                //Obtenemos el id que esta puesto como argumento del boton de delete y borramos
                int id = int.Parse(((LinkButton)sender).CommandArgument);
                if (rolDAO.Delete(id))
                {
                    Response.Redirect("Rol.aspx", false);
                }
                else 
                {
                    alertDelete.Style["display"] = "block";
                    lblErrorDelete.Text = "El Rol esta en uso en una incidencia...";
                    return;
                }
            }
            catch (Exception)
            {
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void abrirModal(object sender, EventArgs e)
        {
            try
            {
                //Logica que abre el modal y le carga datos segun si es crear o modificar"
                LinkButton btn = sender as LinkButton;
                modalRol.Style["display"] = "block";

                switch (btn.Attributes["action"])
                {
                    case "create":
                        lblTitle.Text = "Crear";
                        break;

                    case "modify":
                        int id = int.Parse(((LinkButton)sender).CommandArgument);
                        Dominio.Rol rol = rolDAO.getRol(id);
                        Session.Add("RolModificado", rol);
                        txbRolNombre.Text = rol.Nombre;
                        lblTitle.Text = "Modificar a ";
                        lblNombre.Text = txbRolNombre.Text;
                        break;

                    default:

                        break;
                }
            }
            catch (Exception)
            {
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void submitModal(object sender, EventArgs e)
        {
            try
            {
                //Verificamos si es crear o modificar, y ejecutamos las acciones respectivas
                if (lblTitle.Text == "Crear")
                {
                    Dominio.Rol rol = new Dominio.Rol();
                    rol.Nombre = txbRolNombre.Text;
                    //Validaciones
                    if (txbRolNombre.Text == "" || txbRolNombre.Text == null)
                    {
                        alertRol.Style["display"] = "block";
                        lblRolErrores.Text = "El Rol debe tener nombre...";
                        return;
                    }
                    if (rolDAO.getRol(txbRolNombre.Text).Nombre != null)
                    {
                        alertRol.Style["display"] = "block";
                        lblRolErrores.Text = "Rol ya creado...";
                        return;
                    }
                    rolDAO.Create(rol);
                }
                else
                {
                    Dominio.Rol rol = Session["RolModificado"] as Dominio.Rol;
                    string nombre = txbRolNombre.Text;
                    //Validamos antes de efectuar ningun cambio
                    if (txbRolNombre.Text == "" || txbRolNombre.Text == null)
                    {
                        alertRol.Style["display"] = "block";
                        lblRolErrores.Text = "No hay un rol buscado";
                        return;
                    }
                    if (rolDAO.getRol(txbRolNombre.Text).Nombre != null)
                    {
                        alertRol.Style["display"] = "block";
                        lblRolErrores.Text = "Rol ya creado...";
                        return;
                    }
                    rolDAO.Update(nombre, rol.Id);
                }

                Response.Redirect("Rol.aspx", false);
            }
            catch(Exception)
            {
                Response.Redirect("~/Error.aspx");
            }
        }

        protected void cancelarModal(object sender, EventArgs e)
        {
            //Limpiamos el modal
            modalRol.Style["display"] = "none";
            txbRolNombre.Text = "";
            alertRol.Style["display"] = "none";
        }
    }
}