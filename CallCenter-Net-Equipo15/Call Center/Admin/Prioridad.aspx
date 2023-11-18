<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Prioridad.aspx.cs" Inherits="Call_Center.ABML.Prioridad" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="table table-bordered">
                <thead>
                    <tr>
                        <!-- ACA PONER TODOS LOS MIEMBROS DEL OBJETO QUE SE TENGA -->
                        <th class="d-none">Id</th>
                        <th>Nombre</th>
                        <th style="width: 10%" class="text-center">Modificar</th>
                        <th style="width: 10%" class="text-center">Eliminar</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td class="d-none" name="id"><%# Eval("id") %></td>
                                <td><%# Eval("nombre") %></td>
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


            <!-- ACA PONER EL FORMULARIO ENTERO DE AGREGAR/MODIFICAR -->
            <asp:ScriptManager ID="ScriptManager1" runat="server" />
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div id="Div1" runat="server" style="display: none;">
                                <div class="custom-modal card">
                                    <div class="card-header">
                                        <div class="card-Title">
                                        <asp:Label ID="Label1" runat="server" Text="" CssClass=""></asp:Label>
                                         <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                    <div class="card-body">
                                        <div class="form-group">

                                            <asp:TextBox ID="TextBox1" runat="server" Text="" style="display: none;"></asp:TextBox>
                                            <asp:TextBox ID="TextBox2" runat="server" placeholder="Nombre:" CssClass="form-control"></asp:TextBox>
                                            <div class="alert alert-danger" id="Div2" runat="server" style="display: none;">
                                                <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="card-footer">
                                        <asp:TextBox ID="TextBox3" runat="server" Text="" style="display: none;"></asp:TextBox>
                                        <asp:Button ID="Button2" runat="server" Text="Confirmar" OnClick="submitModal" CssClass="btn btn-primary"/>
                                        <asp:Button ID="Button3" runat="server" Text="Cancelar" OnClick="cancelarModal" CssClass="btn btn-secondary"/>

                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                </asp:UpdatePanel>

            <asp:Button ID="Button4" runat="server" Text="Crear" OnClick="abrirModal" CssClass="btn btn-primary" action="create" />
            <asp:Button ID="Button5" runat="server" Text="Volver" OnClick="Volver_Click" CssClass="btn btn-primary" action="volver" />
        </div>
    </form>
</body>
</html>

<!--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">
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
                        <td class="d-none" name="id"><%# Eval("id") %></td>
                        <td><%# Eval("nombre") %></td>
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
        </asp:UpdatePanel>

    <asp:Button ID="Button1" runat="server" Text="Crear" OnClick="abrirModal" CssClass="btn btn-primary" action="create" />
    <asp:Button ID="Volver" runat="server" Text="Volver" OnClick="Volver_Click" CssClass="btn btn-primary" action="volver" />

</asp:Content>!-->
