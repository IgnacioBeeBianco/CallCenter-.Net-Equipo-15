<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Call_Center.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .table-container {
            max-height: 400px;
            overflow-y: auto;
        }

        thead th {
            position: sticky;
            top: 0;
            background-color: #f2f2f2; /* Puedes ajustar el color de fondo según tus preferencias */
            z-index: 2;
        }

        .info-container {
            display: flex;
            justify-content: space-between;
            margin-bottom: 10px;
        }

            .info-container div {
                text-align: center;
                border: 1px solid #ccc;
                border-radius: 10px;
                padding: 10px;
                box-sizing: border-box;
            }

        .oculto {
            display: none;
        }
    </style>
    <script>
        function mostrarOcultarSegunRol() {
            var elementosMostrarOcultar = document.querySelectorAll('.elementoMostrarOcultar');

            for (var i = 0; i < elementosMostrarOcultar.length; i++) {
                var elemento = elementosMostrarOcultar[i];
                if (rolUsuario === 'Cliente') {
                    elemento.classList.add('oculto');
                }
                else {
                    elemento.classList.remove('oculto');
                }
            }
        }

        window.onload = function () {
            mostrarOcultarSegunRol();
        };
    </script>
    <section>
        <div class="row">
            <div class="col-12">
                <h4>Bienvenido <span id="h1NomApe" runat="server"></span></h4>
            </div>
        </div>
    </section>
    <section id="cantInci" visible="false" runat="server">
        <div class="info-container">
            <div>
                <h4>Incidencias totales</h4>
                <asp:Label Text="" runat="server" ID="inciTotales" />
            </div>
            <div>
                <h4>Incidencias urgentes</h4>
                <asp:Label Text="" runat="server" ID="inciUrg" />
            </div>
            <div>
                <h4>Incidencias pendientes</h4>
                <asp:Label Text="" runat="server" ID="inciPen" />
            </div>
            <div>
                <h4>Incidencias resueltas</h4>
                <asp:Label Text="" runat="server" ID="inciFin" />
            </div>
            <div>
                <h4>Incidencias cerradas</h4>
                <asp:Label Text="" runat="server" ID="inciClose" />
            </div>
        </div>
    </section>
    <section>
        <p>Registro de Incidencias</p>
        <div class="row">
            <div class="col-6">
                <div class="mb-3">
                    <asp:Label Text="Filtrar por ID usuario" runat="server" ID="filtroIDusu" Visible="false" />
                    <asp:TextBox runat="server" ID="filtro" CssClass="" AutoPostBack="true" OnTextChanged="filtro_TextChanged" Visible="false" />
                </div>
            </div>
        </div>
        <div class="table-container">
            <table class="table table-bordered">
                <thead>
                    <tr>
                        <th>Id incidencia</th>
                        <th class="d-none">Id usuario</th>
                        <th class="oculto elementoMostrarOcultar">Solicitado por</th>
                        <th>Tipo de incidencia</th>
                        <th>Problematica</th>
                        <th class="oculto elementoMostrarOcultar">Asignado</th>
                        <th class="oculto elementoMostrarOcultar">Prioridad</th>
                        <th>Estado</th>
                        <th>Fecha de creacion</th>
                        <th>Fecha ultimo cambio</th>
                        <th>Comentario de cierre</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptIncidencias" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("Id") %></td>
                                <td class="d-none"><%# Eval("Creador.id") %></td>
                                <td class="oculto elementoMostrarOcultar"><%# Eval("Creador.nombre") %></td>
                                <td><%# Eval("TipoIncidencia.nombre") %></td>
                                <td><%# Eval("problematica") %></td>
                                <td class="oculto elementoMostrarOcultar"><%# Eval("Asignado.nombre") %></td>
                                <td class="oculto elementoMostrarOcultar"><%# Eval("Prioridad.nombre") %></td>
                                <td><%# Eval("Estado.nombre") %></td>
                                <td><%# Eval("FechaCreacion") %></td>
                                <td><%# Eval("FechaCierre") %></td>
                                <td><%# Eval("ComentarioCierre") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </section>
    <b></b>
    <section>
        <div class="row">
            <div class="col-6">
                <div class="mb-3">
                    <asp:Button Text="Crear incidencia" runat="server" ID="crearIncidencia" OnClick="crearIncidencia_Click" Visible="false" />
                </div>
            </div>
        </div>
    </section>
    <section id="usuDatos" visible="false" runat="server">
        <div class="row">
            <div class="col-6">
                <div class="mb-3">
                    <asp:Label Text="Filtrar por DNI" runat="server" ID="lblFiltro" Visible="false" />
                    <asp:TextBox runat="server" ID="txbFiltraDNI" CssClass="" AutoPostBack="true" OnTextChanged="txbFiltraDNI_TextChanged" Visible="false" />
                </div>
            </div>
        </div>
        <div class="table-container">
            <table class="table table-bordered">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Nombre</th>
                        <th>Apellido</th>
                        <th>DNI</th>
                        <th>Teléfono</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptUsuarios" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("id") %></td>
                                <td><%# Eval("Nombre") %></td>
                                <td><%# Eval("Apellido") %></td>
                                <td><%# Eval("DNI") %></td>
                                <td><%# Eval("Telefono") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </section>
    <section>
        <div class="row">
            <div class="col-6">
                <div class="mb-3">
                    <asp:Label ID="lblMensajeError" Text="" runat="server" Visible="false" />
                </div>
            </div>
        </div>
    </section>
</asp:Content>
