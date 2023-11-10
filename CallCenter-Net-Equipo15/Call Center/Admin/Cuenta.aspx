<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Cuenta.aspx.cs" Inherits="Call_Center.ABML.Cuenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
            <asp:Repeater ID="RptCuentas" runat="server">
                <ItemTemplate>
                    <tr>
                        <td> class="d-none" name="id"<%# Eval("id") %></td>
                        <td><%# Eval("Email") %></td>
                        <td><%# Eval("Password") %></td>
                        <td style="width: 6%; text-align: center;">

                            <asp:Button ID="btnModificar" CssClass="btn btn-warning" runat="server" Text="⛏️" OnClick="abrirModal" CommandArgument='<%#Eval("id") %>' CommandName="id" action="modify"/>
                        </td>
                        <td style="width: 6%; text-align: center;">
                            <asp:Button Enabled="false" ID="btnQuitar" CssClass="btn btn-danger" runat="server" Text="🗑️" CommandArgument='<%#Eval("id") %>' CommandName="id"/>
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

                                    <asp:TextBox ID="txbId" runat="server" Text="" style="display: none;"></asp:TextBox>

                                    <div class="input-group mb-3">
                                        <asp:TextBox ID="TxbEmail" runat="server" placeholder="DNI:" CssClass="form-control" TextMode="Email"></asp:TextBox>
                                    </div>
                                    <div class="input-group mb-3">
                                        <asp:TextBox ID="TxbPassword" runat="server" placeholder="Localidad:" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                    </div>
                                   

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
