<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="Call_Center.ABML.Usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
    .table {
        width: 100%;
        border-collapse: collapse;
        margin: 20px 0;
    }

    .table thead {
        background-color: #007BFF;
        color: #fff;
    }

    .table th {
        padding: 10px;
        font-weight: bold;
        text-align: center;
    }

    .table td {
        padding: 10px;
        text-align: center;
    }

    .table tbody tr:nth-child(odd) {
        background-color: #f5f5f5;
    }

    .table tbody tr:hover {
        background-color: #e0e0e0;
    }

    .btn {
        padding: 5px 10px;
        border: none;
        cursor: pointer;
        font-size: 16px;
    }

    .btn-warning {
        background-color: #FFC107;
        color: #fff;
    }

    .btn-danger {
        background-color: #DC3545;
        color: #fff;
    }

    .btn:hover {
        opacity: 0.8;
    }
</style>

    <table class="table table-bordered">
        <thead>
            <tr>
                <th class="d-none">Id</th>
                <th>Nombre</th>
                <th>Apellido</th>
                <th>DNI</th>
                <th>Teléfono</th>
                <th>Domicilio</th>
                <th style="width: 10%" class="text-center">Modificar</th>
                <th style="width: 10%" class="text-center">Eliminar</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rptUsuarios" runat="server">
                <ItemTemplate>
                    <tr>
                        <td class="d-none" name="id"<%# Eval("id") %></td>
                        <td><%# Eval("Nombre") %></td>
                        <td><%# Eval("Apellido") %></td>
                        <td><%# Eval("DNI") %></td>
                        <td><%# Eval("Telefono") %></td>
                        <td><%# Eval("Domicilio") %></td>
                        <td style="width: 6%; text-align: center;">

                            <asp:Button ID="btnModificar" CssClass="btn btn-warning" runat="server" Text="⛏️" OnClick="abrirModal" CommandArgument='<%#Eval("id") %>' CommandName="id" action="modify"/>
                        </td>
                        <td style="width: 6%; text-align: center;">
                            <asp:Button ID="btnQuitar" CssClass="btn btn-danger" runat="server" Text="🗑️" OnClick="btnQuitar" CommandArgument='<%#Eval("id") %>' CommandName="id"/>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>

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
                                    <asp:TextBox ID="txbId" runat="server" Text="" style="display: none;"></asp:TextBox>

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
                                        <asp:TextBox ID="TxbUsuarioLocalidad" runat="server" placeholder="Localidad:" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="input-group mb-3">
                                        <asp:TextBox ID="TxbUsuarioDomicilio" runat="server" placeholder="Domicilio:" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="input-group mb-3">
                                        <asp:TextBox ID="TxbUsuarioTelefono" runat="server" placeholder="Teléfono:" CssClass="form-control" TextMode="Phone"></asp:TextBox>
                                    </div>

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
                                            <asp:ListItem Text='<%#Eval("Nombre") %>' Value='<%#Eval("Id") %>'></asp:ListItem>
                                    </asp:DropDownList>
                                    <div class="alert alert-danger" id="alertPrio" runat="server" style="display: none;">
                                        <asp:Label ID="lblPrioErrores" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="card-footer">
                                <asp:TextBox ID="txbAction" runat="server" Text="" style="display: none;"></asp:TextBox>
                                <asp:Button ID="btnPrioSub" runat="server" Text="Confirmar" OnClick="submitModal" CssClass="btn btn-primary"/>
                                <asp:Button ID="btnPrioCancelar" runat="server" Text="Cancelar" OnClick="cancelarModal" CssClass="btn btn-secondary"/>

                            </div>
                        </div>
                    </div>
                </ContentTemplate>
        </asp:UpdatePanel>

    <asp:Button ID="Button1" runat="server" Text="Crear" OnClick="abrirModal" CssClass="btn btn-primary" action="create" />
</asp:Content>
