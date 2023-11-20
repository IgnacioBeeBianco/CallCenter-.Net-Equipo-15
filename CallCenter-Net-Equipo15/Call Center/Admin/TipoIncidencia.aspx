<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/CRUD.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="TipoIncidencia.aspx.cs" Inherits="Call_Center.ABML.TipoIncidencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="buttons d-flex justify-content-end align-items-center mb-3">
        <asp:LinkButton ID="btnCrear" runat="server" OnClick="abrirModal" CssClass="btn btn-primary" action="create">
            Crear
        </asp:LinkButton>
    </div>
    <table class="table table-bordered">
        <thead>
            <tr>
                <th class="d-none">Id</th>
                <th>Nombre</th>
                <th>Descripción</th>
                <th style="width: 10%" class="text-center">Modificar</th>
                <th style="width: 10%" class="text-center">Eliminar</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rptPrioridades" runat="server">
                <ItemTemplate>
                    <tr>
                        <td class="d-none" name="id"><%# Eval("id") %></td>
                        <td><%# Eval("nombre") %></td>
                        <td><%# Eval("descripcion") %></td>
                        <td style="width: 6%; text-align: center;">
                            <asp:LinkButton ID="btnModificar" runat="server" OnClick="abrirModal" CommandArgument='<%#Eval("id") %>' CommandName="id" action="modify" CssClass="btn btn-secondary">
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


    <!-- ACA PONER EL FORMULARIO ENTERO DE AGREGAR/MODIFICAR -->
    <asp:ScriptManager ID="SMModal" runat="server" />
    <asp:UpdatePanel ID="upModal" runat="server">
        <ContentTemplate>
            <div id="modalPrioridad" runat="server" style="display: none;">
                <div class="custom-modal card">
                    <div class="card-header">
                        <div class="card-Title">
                            <asp:Label ID="lblTitle" runat="server" Text="" CssClass=""></asp:Label>
                            <asp:Label ID="lblNombre" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="card-body">
                        <div class="form-group">

                            <asp:TextBox ID="txbId" runat="server" Text="" Style="display: none;"></asp:TextBox>
                            <asp:TextBox ID="txbPrioNombre" runat="server" placeholder="Nombre:" CssClass="form-control"></asp:TextBox>
                            <asp:TextBox ID="txbPrioDesc" runat="server" placeholder="Descripcion:" CssClass="form-control"></asp:TextBox>
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
