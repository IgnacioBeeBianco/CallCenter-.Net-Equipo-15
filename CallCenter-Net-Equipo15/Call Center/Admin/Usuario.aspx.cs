using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Call_Center.ABML
{
    public partial class Usuario : System.Web.UI.Page
    {
        UsuarioDAO usuarioDAO = new UsuarioDAO(); 
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack) { 

                rptUsuarios.DataSource = usuarioDAO.GetUsuarios();
                rptUsuarios.DataBind();
            }
        }

        protected void btnQuitar(object sender, EventArgs e)
        {
            int id = int.Parse(((Button)sender).CommandArgument);
            usuarioDAO.Delete(id);
            Response.Redirect("Usuario.aspx");
        }

        protected void abrirModal(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            modalUsuarios.Style["display"] = "block";

            switch (btn.Attributes["action"])
            {
                case "create":
                    lblTitle.Text = "Crear";
                    break;

                case "modify":
                    int id = int.Parse(((Button)sender).CommandArgument);
                    txbUsuarioNombre.Text = usuarioDAO.GetUsuario(id).Nombre;
                    lblTitle.Text = "Modificar a ";
                    lblNombre.Text = txbUsuarioNombre.Text;
                    break;

                default:

                    break;
            }
        }

        protected void submitModal(object sender, EventArgs e)
        {
            if (lblTitle.Text == "Crear")
            {
                Dominio.Usuario usuario = new Dominio.Usuario();
                Dominio.Cuenta cuenta = new Dominio.Cuenta();
                
                cuenta.Email = TxbEMail.Text;
                cuenta.Password = TxbPassword.Text;
                usuario.Nombre = txbUsuarioNombre.Text;
                usuario.Apellido = TxbUsuarioApellido.Text;
                usuario.Domicilio = TxbUsuarioDomicilio.Text;
                usuario.Telefono = TxbUsuarioTelefono.Text;
                usuario.DNI = TxbUsuarioDNI.Text;
            }
            else
            {
                
            }

            Response.Redirect("Usuario.aspx");
        }

        protected void cancelarModal(object sender, EventArgs e)
        {

            modalUsuarios.Style["display"] = "none";
            txbUsuarioNombre.Text = "";
            alertPrio.Style["display"] = "none";


        }
    }
}