<%@ Page Language="C#" MasterPageFile="~/Master.Master" CodeBehind="UsuarioPanel.aspx.cs" Inherits="Call_Center.UsuarioPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-5">
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col">
                                    <center>
                                        <asp:Image ID="image1" runat="server" Width="200" CssClass="img-thumbnail" AlternateText="icon-picture" ImageUrl="~/Images/profile_3135768.png" />
                                    </center>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <center>
                                        <h4 id="h4NomApe" runat="server"></h4>
                                    </center>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <hr>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <label>Nombre/s</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtNombre" runat="server" placeholder="" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <label>Apellido/s</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtApellido" runat="server" placeholder="" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <label>Domicilio</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtDomicilio" runat="server" placeholder="" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <label>Telefono</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtTelefono" runat="server" placeholder="" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <label>DNI</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtDNI" runat="server" placeholder="" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <label>Genero</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtGenero" runat="server" placeholder="" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <label>Rol</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtRol" runat="server" placeholder="" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <label>Mail</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtMail" runat="server" placeholder="" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col">
                                    <label>Contraseña</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtPassword" runat="server" placeholder="" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <%/* 
                            <div class="row">
                                <div class="col">
                                    <div class="form-group">
                                        <br />
                                        <center>
                                            <asp:Button class="btn btn-primary btn-block btn-lg" ID="btnActualizar" runat="server" Text="Actualizar perfil" OnClick="btnActualizar_Click" />
                                            <asp:Label Text="" runat="server" ID="lblMensaje" />
                                        </center>
                                    </div>
                                </div>
                            </div>
                            */%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
