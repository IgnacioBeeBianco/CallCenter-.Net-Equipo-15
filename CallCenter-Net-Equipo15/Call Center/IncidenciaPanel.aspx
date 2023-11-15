<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="IncidenciaPanel.aspx.cs" Inherits="Call_Center.IncidenciaPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .custom-column {
            height: 80vh; /* Establece la altura al 80% de la altura visible del dispositivo */
            border: 1px solid #ddd; /* Añade un borde para mayor claridad */
            text-align: center; /* Centra el contenido */
            padding: 15px; /* Añade un espacio interno para el contenido */
            max-width: 25%;
        }

        .row {
            display: flex; /* Usa un modelo de caja flexible para los elementos hijos */
            flex-wrap: nowrap; /* Evita que las columnas se envuelvan a la siguiente línea */
            overflow-x: auto; /* Permite desplazamiento horizontal si el contenido es demasiado ancho */
        }
    </style>

    <div class="row" style="overflow-x: scroll">
        <asp:Repeater ID="rptColumnas" runat="server" OnItemDataBound="rptColumnas_ItemDataBound">
            <ItemTemplate>
                <div class="col-md-4 custom-column">
                    <p><%# Eval("nombre") %></p>
                    <asp:Repeater ID="rptIncidencias" runat="server">
                        <ItemTemplate>
                            <div class="card">
                                <div class="card-header">
                                    <h5 class="card-title">ID: <%# Eval("id") %></h5>
                                    <asp:Button ID="btnMasOpciones" runat="server" Text="Button" CssClass="btn btn-secondary" OnClick="optionsTicket" CommandArgument='<%#Eval("id") %>' CommandName="id" />
                                </div>
                                <div class="card-body">
                                    <p class="card-text"><%# Eval("problematica") %></p>
                                </div>
                                <div class="card-footer">
                                    Creador: <%# Eval("creador.nombre") %>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <style>
        .custom-modal {
            position: absolute;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
            width: 30%;
            height: 40%;
            background-color: white;
            border: 1px solid black;
        }

    </style>

    <asp:ScriptManager ID="SMModal" runat="server" />
    <asp:UpdatePanel ID="upModal" runat="server">
        <ContentTemplate>
            <div id="modal" runat="server" style="display: none;">
                <div class="custom-modal card">
                    <div class="card-header">
                        <div class="card-Title">
                            <asp:Label ID="lblId" runat="server" Text="" CssClass=""></asp:Label>
                            <asp:Label ID="lblProblematica" runat="server" Text=""></asp:Label>
                            <asp:Label ID="lblEstado" runat="server" Text=""></asp:Label>
                            <asp:Button ID="btnMoverA" runat="server" Text="Button" CssClass="btn btn-secondary" OnClick="btnMoverA_Click" />
                            <div id="moverAOpts" runat="server" style="display: none; position: absolute; right: 8%; top: 0px; border: 1px solid black; display:flex; flex-direction:column">
                                <asp:Repeater ID="rptMoverA" runat="server">
                                    <ItemTemplate>
                                        <asp:Button ID="btnCambiarEstado" runat="server" Text="Test" CssClass="btn btn-secondary" />
                                    </ItemTemplate>
                                </asp:Repeater>
                                <asp:Button ID="btnCerrarMoverA" runat="server" Text="Cancelar" OnClick="cerrarMoverA" CssClass="btn btn-secondary" />
                            </div>
                        </div>
                    </div>
                    <div class="card-body">
                        <div class="form-group">


                            <div class="alert alert-danger" id="alert" runat="server" style="display: none;">
                                <asp:Label ID="lblRolErrores" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="card-footer">
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="cancelarModal" CssClass="btn btn-secondary" />

                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
