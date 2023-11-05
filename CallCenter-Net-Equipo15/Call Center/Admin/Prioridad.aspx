<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Prioridad.aspx.cs" Inherits="Call_Center.ABML.Prioridad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table table-bordered">
        <thead>
            <tr>
                <th class="d-none">Id</th>
                <th>Nombre</th>
                <th style="width: 10%" class="text-center">Modificar</th>
                <th style="width: 10%" class="text-center">Eliminar</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rptPrioridades" runat="server">
                <ItemTemplate>
                    <tr>
                        <td class="d-none" name="id"<%# Eval("id") %></td>
                        <td><%# Eval("nombre") %></td>
                        <td style="width: 6%; text-align: center;">
                            <asp:Button ID="btnModificar" CssClass="btn btn-warning" runat="server" Text="⛏️" OnClick="abrirModal" CommandArgument='<%#Eval("id") %>' CommandName="id" action="modificar"/>
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

    <asp:ScriptManager ID="SMModal" runat="server">
            <ContentTemplate>
                <div id="modalPrioridad" runat="server" style="display: none;">
                    <div class="custom-modal card">
                        <div class="card-header">
                            <asp:Label ID="lblTitle" runat="server" Text="" CssClass="card-title"></asp:Label>
                        </div>
                        <div class="card-body">
                            <div class="form-group">

                                <asp:TextBox ID="txbId" runat="server" Text="" style="display: none;"></asp:TextBox>
                                <asp:TextBox ID="txbPrioNombre" runat="server" placeholder="Nombre:" CssClass="form-control"></asp:TextBox>
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
    </asp:ScriptManager>

    <asp:Button ID="Button1" runat="server" Text="Crear" OnClick="abrirModal" CssClass="btn btn-primary" action="create" />


</asp:Content>
