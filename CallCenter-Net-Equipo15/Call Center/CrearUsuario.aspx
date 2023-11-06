<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrearUsuario.aspx.cs" Inherits="Call_Center.CrearUsuario" Title="Usuarios" MasterPageFile="~/Master.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    
         <div class="container">
             <div class="row d-flex justify-content-center">
                 <div class="col-6 text-center">
                     <div class="form-container shadow-lg mb-5 bg-white rounded p-5">
                         <div class="header mb-5">
                             <h3 class="display-5">Registrarse!</h3>
                         </div>

                         <div class="input-group mb-4">
                             <input runat="server" id="Nombre" type="text" class="form-control rounded" placeholder="Su nombre" aria-label="Username" aria-describedby="basic-addon1" />
                         </div>

                         <div class="input-group mb-4">
                             <input runat="server" id="Apellido" type="text" class="form-control rounded" placeholder="Su apellido" aria-label="Username" aria-describedby="basic-addon1" />
                         </div>

                         <div class="input-group mb-4">
                             <input runat="server" id="DNI" type="text" class="form-control rounded" placeholder="Su DNI" aria-label="Username" aria-describedby="basic-addon1" />
                         </div>

                         <div class="input-group mb-4">
                             <input runat="server" id="Domicilio" type="text" class="form-control rounded" placeholder="Su domicilio" aria-label="Username" aria-describedby="basic-addon1" />
                         </div>

                         <div class="input-group mb-4">
                             <input runat="server" id="Telefono" type="text" class="form-control rounded" placeholder="Su telefono" aria-label="Username" aria-describedby="basic-addon1" />
                         </div>

                         <div class="input-group mb-4">
                             <input runat="server" id="Genero" type="text" class="form-control rounded" placeholder="Su genero (M, F o X)" aria-label="Username" aria-describedby="basic-addon1" />
                         </div>

                         <div class="input-group mb-4">
                             <input runat="server" id="EmailInput" type="email" class="form-control rounded" placeholder="Dirección de email" aria-label="Username" aria-describedby="basic-addon1" />
                         </div>

                         <div class="input-group mb-4">
                             <input runat="server" id="PasswordInput" type="password" class="form-control rounded" placeholder="Contraseña" aria-label="Password" aria-describedby="basic-addon1" />
                         </div>

                         <div class="button-container d-grid gap-2">
                             <asp:Button ID="RegistrarseButton" runat="server" Text="Registrarse" CssClass="btn btn-primary" />
                         </div>

                     </div>

                 </div>
             </div>
         </div>
</asp:Content>

