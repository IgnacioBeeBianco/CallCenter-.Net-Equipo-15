<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ActualizarPerfil.aspx.cs" Inherits="Call_Center.ActualizarPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                                <asp:TextBox ID="TxbPassword" runat="server" placeholder="Contraseña:" CssClass="form-control" TextMode="Password"></asp:TextBox>
                            </div>
                            <asp:DropDownList ID="RoleDropdown" runat="server">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
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
