﻿using DAO;
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
        protected bool hasError = false;
        protected bool hasSuccess = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack) {

                rptUsuarios.DataSource = usuarioDAO.GetUsuarios().Where(user => user.Estado);
                rptUsuarios.DataBind();
            }
        }

        protected void btnQuitar(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(((LinkButton)sender).CommandArgument);
                usuarioDAO.Delete(id);
                Response.Redirect("Usuario.aspx");
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        protected void abrirModal(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            modalUsuarios.Style["display"] = "block";

            switch (btn.Attributes["action"])
            {
                case "create":
                    RolDAO rolDAO = new RolDAO();
                    RoleDropdown.DataSource = rolDAO.List();
                    RoleDropdown.DataTextField = "Nombre";
                    RoleDropdown.DataValueField = "Id";
                    RoleDropdown.DataBind();
                    lblTitle.Text = "Crear";
                    break;

                case "modify":
                    int id = int.Parse(((LinkButton)sender).CommandArgument);
                 
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
                    GenderRadioButtons.SelectedValue  = genero;
                    break;

                default:

                    break;
            }
        }

        protected void submitModal(object sender, EventArgs e)
        {
            try
            {
                if (lblTitle.Text == "Crear")
                {
                    Dominio.Usuario usuario = new Dominio.Usuario();
                    Dominio.Cuenta cuenta = new Dominio.Cuenta();
                
                    cuenta.Email = TxbEMail.Text;
                    cuenta.Password = TxbPassword.Text;
                    cuenta.Rol = new Dominio.Rol();
                    cuenta.Rol.Id = int.Parse(RoleDropdown.SelectedValue);
                    usuario.Nombre = txbUsuarioNombre.Text;
                    usuario.Apellido = TxbUsuarioApellido.Text;
                    usuario.Domicilio = TxbUsuarioDomicilio.Text;
                    usuario.Telefono = TxbUsuarioTelefono.Text;
                    usuario.DNI = TxbUsuarioDNI.Text;
                    usuario.Genero = Convert.ToChar(GenderRadioButtons.SelectedValue);

                    usuarioDAO.Create(cuenta, usuario);

                }
                else
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

                    usuarioDAO.Update(usuario);
                }

                Response.Redirect("Usuario.aspx");
                hasSuccess = true;
                Session["hasSuccess"] = hasSuccess;
            }catch (Exception)
            {
                hasError = true;
            }
        }

        protected void cancelarModal(object sender, EventArgs e)
        {

            modalUsuarios.Style["display"] = "none";
            txbUsuarioNombre.Text = "";
            alertPrio.Style["display"] = "none";


        }

    }
}