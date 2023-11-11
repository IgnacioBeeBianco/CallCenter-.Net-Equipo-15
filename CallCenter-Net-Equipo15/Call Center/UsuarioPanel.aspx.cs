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
        protected void Page_Load(object sender, EventArgs e)
        {

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
        /*
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            //NO me actualiza el perfil!!!!!! :-(

            try
            {
                // Obtén la información actualizada del usuario desde los controles en tu página
                Dominio.Usuario usuarioActualizado = new Dominio.Usuario();
                Dominio.Cuenta cuentaActualizada = new Dominio.Cuenta();
                DAO.RolDAO rolDAO = new DAO.RolDAO();
                Dominio.Rol rol = rolDAO.getRol(txtRol.Text);

                if (rol == null)
                {
                    lblMensaje.Text = "Rol no encontrado";
                    return;
                }

                usuarioActualizado.Id = (Session["Usuario"] as Dominio.Usuario).Id;
                usuarioActualizado.Nombre = txtNombre.Text;
                usuarioActualizado.Apellido = txtApellido.Text;
                usuarioActualizado.DNI = txtDNI.Text;
                usuarioActualizado.Domicilio = txtDomicilio.Text;
                usuarioActualizado.Telefono = txtTelefono.Text;
                usuarioActualizado.Genero = Convert.ToChar(txtGenero.Text);

                cuentaActualizada.Id = (Session["Cuenta"] as Dominio.Cuenta).Id;
                cuentaActualizada.Email = txtMail.Text;
                cuentaActualizada.Password = txtPassword.Text;
                cuentaActualizada.Rol = rol;

                //usuarioActualizado.CuentaId = cuentaActualizada;

                // Llama al método de actualización en el DAO
                UsuarioDAO usuarioDAO = new UsuarioDAO();
                usuarioDAO.Update(usuarioActualizado);
                //lblMensaje.Text = "¡Perfil actualizado correctamente!";
                lblMensaje.Text = "Perfil actualizado correctamente!" +
            $"<br />Nombre: {cuentaActualizada.Id}";
            

            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al actualizar el perfil. Detalles del error: " + ex.Message;
            }

        }
        
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtén la información actualizada del usuario desde los controles en tu página
                Dominio.Usuario usuarioActualizado = new Dominio.Usuario();
                DAO.RolDAO rolDAO = new DAO.RolDAO();
                Dominio.Rol rol = rolDAO.getRol(txtRol.Text);

                if (rol == null)
                {
                    lblMensaje.Text = "Rol no encontrado";
                    return;
                }

                usuarioActualizado.Id = (Session["Usuario"] as Dominio.Usuario).Id;
                usuarioActualizado.Nombre = txtNombre.Text;
                usuarioActualizado.Apellido = txtApellido.Text;
                usuarioActualizado.DNI = txtDNI.Text;
                usuarioActualizado.Domicilio = txtDomicilio.Text;
                usuarioActualizado.Telefono = txtTelefono.Text;
                usuarioActualizado.Genero = Convert.ToChar(txtGenero.Text);
                usuarioActualizado.CuentaId = new Dominio.Cuenta();
                usuarioActualizado.CuentaId.Email = txtMail.Text;
                usuarioActualizado.CuentaId.Password = txtPassword.Text;
                usuarioActualizado.CuentaId.Rol = rol;

                // Llama al método de actualización en el DAO
                UsuarioDAO usuarioDAO = new UsuarioDAO();
                usuarioDAO.UpdatePerfil(usuarioActualizado);
                Session["Usuario"] = usuarioActualizado;
                Session["Cuenta"] = usuarioActualizado.CuentaId;
                lblMensaje.Text = "¡Perfil actualizado correctamente!";
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al actualizar el perfil. Detalles del error: " + ex.Message;
            }
        }
        */
    }
}