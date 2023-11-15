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
</asp:Content>
