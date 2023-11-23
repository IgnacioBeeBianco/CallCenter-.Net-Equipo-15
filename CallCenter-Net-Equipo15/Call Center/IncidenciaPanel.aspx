<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="IncidenciaPanel.aspx.cs" Inherits="Call_Center.IncidenciaPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 

    <div class="row">
        <div class="col-md-12">
            <div class="header-container d-flex mb-3 gap-2">
                <h4>Creado por:</h4>
                <asp:Repeater ID="rptAsignados" runat="server">
                    <ItemTemplate>
                        <a href='<%# Request.QueryString["requested"] == Eval("id").ToString() ? "IncidenciaPanel.aspx" : "?requested=" + Eval("id") %>'
                            class='<%# Request.QueryString["requested"] == Eval("id").ToString() ? "h4 btn btn-primary" : "h4 btn" %>'>
                            <%# Eval("nombre") %>
                        </a>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>


    <h1>Dashboard</h1>
    <p>Aquí verás de una forma por columnas los tickets</p>
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
                            <div class="card mb-2">
                                <div class="card-header d-flex justify-content-between align-items-center">
                                    <p class="card-title">Numero: <%# Eval("id") %></p>

                                    <asp:Button ID="btnMasOpciones" runat="server" Text="Más..." CssClass="btn btn-primary btn-sm" OnClick="optionsTicket" CommandArgument='<%#Eval("id") %>' CommandName="id" />
                                </div>
                                <div class="card-body text-start">
                                    <p class="card-text"><%# Eval("problematica") %></p>
                                    <p class="card-text">Prioridad: <%# Eval("prioridad.nombre") %></p>
                                    <p>Creador: <%# Eval("creador.nombre") %></p>

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
            width: 32%;
            height: 40%;
        }
    </style>

    <asp:ScriptManager ID="SMModal" runat="server" />
    <asp:UpdatePanel ID="upModal" runat="server">
        <ContentTemplate>
            <div id="modal" runat="server" style="display: none;">
                <div class="custom-modal card">
                    <div class="card-header">
                        <div class="card-Title  d-flex justify-content-between align-items-center">
                            <asp:Label ID="lblId" runat="server" Text="" CssClass=""></asp:Label>
                            <asp:Button runat="server" CssClass="btn btn-primary" Text="Ver" ID="BtnSeeMore" OnClick="BtnSeeMore_Click"/>
                            
                            <%if ((Session["Cuenta"] as Dominio.Cuenta).Rol.Nombre == "Administrador")
                            { %>
                                <asp:Button ID="btnMoverA" runat="server" Text="Mover" CssClass="btn btn-primary" OnClick="btnMoverA_Click" />
                                <div id="moverAOpts" runat="server" class="bg-dark-subtle rounded" style="display: none; position: absolute; right: -15%; top: 0px; border: 1px solid black; display: flex; flex-direction: column">
                                    <asp:Repeater ID="rptMoverA" runat="server">
                                        <ItemTemplate>
                                            <asp:Button ID="btnCambiarEstado" runat="server" Text='<%# Eval("Nombre") %>' CssClass="btn btn-secondary btn-sm m-2" CommandArgument='<%# lblId.Text %>' CommandName="id" OnClick="btnCambiarEstado_Click" idEstado='<%# Eval("Id") %>' />
                                        </ItemTemplate>
                                    </asp:Repeater>

                                    <asp:Button ID="btnCerrarMoverA" runat="server" Text="Cancelar" OnClick="cerrarMoverA" CssClass="btn m-3" />
                                </div>


                            <%} %>
                        </div>
                    </div>
                    <div class="card-body">
                        <div class="form-group d-flex flex-column">
                            <asp:Label ID="lblProblematica" runat="server" Text=""></asp:Label>
                            <asp:Label ID="lblOwner" runat="server" Text=""></asp:Label>
                            <asp:Label ID="lblIssuer" runat="server" Text=""></asp:Label>
                            <asp:Label ID="lblEstado" runat="server" Text=""></asp:Label>


                            <div class="alert alert-danger" id="alert" runat="server" style="display: none;">
                                <asp:Label ID="lblRolErrores" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="card-footer">
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="cancelarModal" CssClass="btn btn-secondary" />
                        <asp:Button ID="BtnResolveTicket" runat="server" Text="Resolver" OnClick="BtnResolveTicket_Click" CssClass="btn btn-success"/>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
