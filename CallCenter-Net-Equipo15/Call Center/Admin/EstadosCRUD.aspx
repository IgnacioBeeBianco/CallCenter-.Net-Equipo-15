﻿<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="EstadosCRUD.aspx.cs" Inherits="Call_Center.Admin.EstadosCRUD" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" data-bs-theme="dark">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Estados</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous"/>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.1/font/bootstrap-icons.css"/>
    <link rel="preconnect" href="https://fonts.googleapis.com"/>
    <link rel="preconnect" href="https://fonts.gstatic.com"/>
    <link href="https://fonts.googleapis.com/css2?family=Inter&display=swap" rel="stylesheet"/>
    <link rel="stylesheet" href="Css/Main.css"/>
</head>
<body>
    <style>
        .custom-modal {
            position: absolute;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
            width: 60%;
            height: 80%;
        }
    </style>
    <form id="form1" runat="server" class="p-3 bg-body">
        <div class="buttons d-flex justify-content-end align-items-center mb-3">
            <asp:LinkButton ID="btnCrear" runat="server" OnClick="abrirModal" CssClass="btn btn-primary" action="create">
                Crear
            </asp:LinkButton>
        </div>
        <div>
            <table class="table table-bordered">
                <thead>
                    <tr>
                        <th class="d-none">Id</th>
                        <th>Nombre</th>
                        <th>Nivel de Estado</th>
                        <th>Estado</th>
                        <th style="width: 10%" class="text-center">Modificar</th>
                        <th style="width: 10%" class="text-center">Eliminar</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptEstado" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td class="d-none" name="id"><%# Eval("id") %></td>
                                <td><%# Eval("nombre") %></td>
                                <td><%# Eval("nivelEstado") %></td>
                                <td><%# Eval("estado") %></td>
                                <td style="width: 6%; text-align: center;">
                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="abrirModal" CommandArgument='<%#Eval("id") %>' CommandName="id" action="modify" CssClass="btn btn-secondary">
                                        <i class="bi bi-pencil-fill"></i>
                                    </asp:LinkButton>
                                </td>
                                <td style="width: 6%; text-align: center;">
                                    <asp:Button ID="btnQuitar" CssClass="btn btn-danger" runat="server" Text="🗑️" OnClick="btnQuitar" CommandArgument='<%#Eval("id") %>' CommandName="id" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>

        <asp:ScriptManager ID="SMModal" runat="server" />
        <asp:UpdatePanel ID="upModal" runat="server">
            <ContentTemplate>
                <div id="modalEstado" runat="server" style="display: none;">
                    <div class="custom-modal card">
                        <div class="card-header">
                            <div class="card-Title">
                                <asp:Label ID="lblTitle" runat="server" Text="" CssClass=""></asp:Label>
                                <asp:Label ID="lblNombre" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lblNivelEstado" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="card-body">
                            <div class="form-group">

                                <asp:TextBox ID="txbId" runat="server" Text="" Style="display: none;"></asp:TextBox>
                                <asp:TextBox ID="txbEstadoNombre" runat="server" placeholder="Nombre:" CssClass="form-control"></asp:TextBox>
                                <asp:TextBox ID="txbNivelEstado" runat="server" placeholder="Nivel de Estado:" CssClass="form-control"></asp:TextBox>
                                <div class="alert alert-danger" id="alertEstado" runat="server" style="display: none;">
                                    <asp:Label ID="lblEstadoErrores" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="card-footer">
                            <asp:TextBox ID="txbAction" runat="server" Text="" Style="display: none;"></asp:TextBox>
                            <asp:Button ID="btnEstadoSub" runat="server" Text="Confirmar" OnClick="submitModal" CssClass="btn btn-primary" />
                            <asp:Button ID="btnEstadoCancelar" runat="server" Text="Cancelar" OnClick="cancelarModal" CssClass="btn btn-secondary" />

                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </form>
</body>
</html>
