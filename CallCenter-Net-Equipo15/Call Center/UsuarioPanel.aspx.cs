using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;
using DAO;
using Dominio;
using Call_Center.ABML;

namespace Call_Center
{
    public partial class UsuarioPanel : System.Web.UI.Page
    {
        UsuarioDAO usuarioDAO = new UsuarioDAO();
        RolDAO rolDAO = new RolDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                setearImagenSegunRol();
            }
            if (Session["Usuario"] != null && Session["Cuenta"] != null)
            {
                h4NomApe.InnerText = (Session["Usuario"] as Dominio.Usuario).Nombre + " " + (Session["Usuario"] as Dominio.Usuario).Apellido;
                txtNombre.Text = (Session["Usuario"] as Dominio.Usuario).Nombre;
                txtApellido.Text = (Session["Usuario"] as Dominio.Usuario).Apellido;
                txtDNI.Text = (Session["Usuario"] as Dominio.Usuario).DNI;
                txtDomicilio.Text = (Session["Usuario"] as Dominio.Usuario).Domicilio;
                txtTelefono.Text = (Session["Usuario"] as Dominio.Usuario).Telefono;
                txtGenero.Text = (Session["Usuario"] as Dominio.Usuario).Genero.ToString();
                txtRol.Text = (Session["Cuenta"] as Dominio.Cuenta).Rol.Nombre;
                txtMail.Text = (Session["Cuenta"] as Dominio.Cuenta).Email;
                txtPassword.Text = (Session["Cuenta"] as Dominio.Cuenta).Password;

            }
            else
            {
                Response.Redirect("Login.aspx", false);
            }

        }

        protected void abrirModal(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            modalUsuarios.Style["display"] = "block";

            switch (btn.Attributes["action"])
            {
                case "modify":
                    int id = (Session["Usuario"] as Dominio.Usuario).Id;

                    Dominio.Usuario usuario = usuarioDAO.GetUsuario(id);
                    Session.Add("ModificandoUsuario", usuario);
                    txbUsuarioNombre.Text = usuario.Nombre;
                    lblTitle.Text = "Modificar a ";
                    lblNombre.Text = txbUsuarioNombre.Text;
                    TxbUsuarioApellido.Text = usuario.Apellido;
                    TxbUsuarioDNI.Text = usuario.DNI;
                    TxbUsuarioDomicilio.Text = usuario.Domicilio;
                    TxbUsuarioTelefono.Text = usuario.Telefono;
                    TxbEMail.Text = usuario.CuentaId.Email;
                    TxbPassword.Text = usuario.CuentaId.Password;
                    string genero = usuario.Genero.ToString();
                    GenderRadioButtons.SelectedValue = genero;
                    txtRolActua.Text = txtRol.Text;

                    break;

                default:

                    break;
            }
        }

        protected void submitModal(object sender, EventArgs e)
        {
            Dominio.Usuario usuario = Session["ModificandoUsuario"] as Dominio.Usuario;

            usuario.Nombre = txbUsuarioNombre.Text;
            usuario.Apellido = TxbUsuarioApellido.Text;
            usuario.Domicilio = TxbUsuarioDomicilio.Text;
            usuario.Telefono = TxbUsuarioTelefono.Text;
            usuario.DNI = TxbUsuarioDNI.Text;
            usuario.Genero = Convert.ToChar(GenderRadioButtons.SelectedValue);
            usuario.CuentaId.Email = TxbEMail.Text;
            usuario.CuentaId.Password = TxbPassword.Text;
            usuario.CuentaId.Rol.Nombre = txtRolActua.Text;

            usuarioDAO.Update(usuario);
            Session["Usuario"] = usuario;
            Session["Cuenta"] = usuario.CuentaId;

            Response.Redirect("UsuarioPanel.aspx");
        }
        protected void cancelarModal(object sender, EventArgs e)
        {
            modalUsuarios.Style["display"] = "none";
            txbUsuarioNombre.Text = "";
            alertPrio.Style["display"] = "none";
        }

        public string setearImagenSegunRol()
        {
            return image1.ImageUrl = setearURLImagenSegunRol();
        }

        private string setearURLImagenSegunRol()
        {
            if (Session["Cuenta"] != null)
            {
                string userRol = (Session["Cuenta"] as Dominio.Cuenta).Rol.Nombre;

                switch (userRol)
                {
                    case "Administrador":
                        return "~/Images/admin.png";

                    case "Cliente":
                        return "~/Images/businessman.png";

                    case "Telefonista":
                        return "~/Images/customer-service.png";

                    case "Supervisor":
                        return "~/Images/supervisor.png";

                    default:
                        return "~/Images/client.png";

                }
            }
            else
            {
                return "~/Images/default.png";
            }
                
        }
    }
}