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
                                        <asp:Image ID="image1" runat="server" Width="200" CssClass="img-thumbnail" AlternateText="icon-picture" ImageUrl='<%# setearImagenSegunRol() %>' />
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
                                        <asp:TextBox CssClass="form-control" ID="txtPassword" runat="server" placeholder="" ReadOnly="True" type="password"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <div class="form-group">
                                        <br />
                                        <center>
                                            <asp:Button class="btn btn-primary btn-block btn-lg" ID="btnActualizar" runat="server" Text="Actualizar perfil" OnClick="abrirModal" CommandArgument='<%#Eval("id") %>' CommandName="id" action="modify" />
                                        </center>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <style>
        .custom-modal {
            position: absolute;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
            width: 60%;
            height: 80%;
            background-color: white;
            border: 1px solid black;
        }
    </style>

    <asp:ScriptManager ID="SMModal" runat="server" />
    <asp:UpdatePanel ID="upModal" runat="server">
        <ContentTemplate>
            <div id="modalUsuarios" runat="server" style="display: none;">
                <div class="custom-modal card">
                    <div class="card-header">
                        <div class="card-Title">
                            <asp:Label ID="lblTitle" runat="server" Text="" CssClass=""></asp:Label>
                            <asp:Label ID="lblNombre" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="card-body">
                        <div class="form-group">
                            <div class="section mb-3">
                                <asp:Label runat="server" CssClass="mb-3">Datos del usuario</asp:Label>

                            </div>
                            <asp:TextBox ID="txbId" runat="server" Text="" Style="display: none;"></asp:TextBox>

                            <div class="row d-flex">
                                <div class="input-group mb-3">
                                    <asp:TextBox ID="txbUsuarioNombre" runat="server" placeholder="Nombre:" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="input-group mb-3">
                                    <asp:TextBox ID="TxbUsuarioApellido" runat="server" placeholder="Apellido:" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>

                            <div class="input-group mb-3">
                                <asp:TextBox ID="TxbUsuarioDNI" runat="server" placeholder="DNI:" CssClass="form-control" TextMode="Number" MaxLength="8"></asp:TextBox>
                            </div>

                            <div class="input-group mb-3">
                                <asp:TextBox ID="TxbUsuarioDomicilio" runat="server" placeholder="Domicilio:" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="input-group mb-3">
                                <asp:TextBox ID="TxbUsuarioTelefono" runat="server" placeholder="Teléfono:" CssClass="form-control" TextMode="Phone"></asp:TextBox>
                            </div>
                            <asp:RadioButtonList ID="GenderRadioButtons" runat="server">
                                <asp:ListItem Text="M" Value="M" />
                                <asp:ListItem Text="F" Value="F" />
                                <asp:ListItem Text="X" Value="X" />
                            </asp:RadioButtonList>


                            <div class="section mb-3">
                                <asp:Label runat="server" CssClass="mb-3">Datos de la cuenta</asp:Label>
                            </div>

                            <div class="input-group mb-3">
                                <asp:TextBox ID="TxbEMail" runat="server" placeholder="Email:" CssClass="form-control" TextMode="Email"></asp:TextBox>
                            </div>
                            <div class="input-group mb-3">
                                <asp:TextBox ID="TxbPassword" runat="server" placeholder="Contraseña:" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="input-group mb-3">
                                <asp:TextBox CssClass="form-control" ID="txtRolActua" runat="server" placeholder="" ReadOnly="true"></asp:TextBox>
                            </div>
                            <div class="alert alert-danger" id="alertPrio" runat="server" style="display: none;">
                                <asp:Label ID="lblPrioErrores" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="card-footer">
                        <asp:TextBox ID="txbAction" runat="server" Text="" Style="display: none;"></asp:TextBox>
                        <asp:Button ID="btnPrioSub" runat="server" Text="Confirmar" OnClick="submitModal" CssClass="btn btn-primary" />
                        <asp:Button ID="btnPrioCancelar" runat="server" Text="Cancelar" OnClick="cancelarModal" CssClass="btn btn-secondary" />

                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
