<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Call_Center.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
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
    </style>
    <section class="hero-section vh-30 d-flex bg-primary-subtle">
        <div class="row">
            <div class="col-12">
                <h4>Bienvenido <span id="h1NomApe" runat="server"></span></h4>
            </div>
        </div>
    </section>
    <section>
        <p>Cantidad de incidencias por Telefonista</p>
        <div class="info-container">
            <div>
                <h4>Incidencias realizadas</h4>
                <asp:Label Text="0" runat="server" ID="inciReali" />
            </div>
            <div>
                <h4>Incidencias pendientes</h4>
                <asp:Label Text="0" runat="server" ID="inciPen" />
            </div>
            <div>
                <h4>Incidencias finalizadas</h4>
                <asp:Label Text="0" runat="server" ID="inciFin" />
            </div>
            <div>
                <h4>Incidencias urgentes</h4>
                <asp:Label Text="0" runat="server" ID="inciUrg" />
            </div>
        </div>
    </section>
    <section>
        <p>Registro de Incidencias</p>
        <table class="table table-bordered">
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Solicitado por</th>
                    <th>Tipo de incidencia</th>
                    <th>Problematica</th>
                    <th>Asignado a</th>
                    <th>Prioridad</th>
                    <th>Estado</th>
                    <th>Fecha de creacion</th>
                    <th>Fecha de cierre</th>
                    <th>Comentario de cierre</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptIncidencias" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("Id") %></td>
                            <td><%# Eval("Creador.nombre") %></td>
                            <td><%# Eval("TipoIncidencia.nombre") %></td>
                            <td><%# Eval("problematica") %></td>
                            <td><%# Eval("Asignado.nombre") %></td>
                            <td><%# Eval("Prioridad.nombre") %></td>
                            <td><%# Eval("Estado.nombre") %></td>
                            <td><%# Eval("FechaCreacion") %></td>
                            <td><%# Eval("FechaCierre") %></td>
                            <td><%# Eval("ComentarioCierre") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </section>
    <section>
        <table class="table table-bordered">
            <p>Usuarios = Clientes con un filtro para buscar por DNI</p>
            <thead>
                <tr>
                    <th class="d-none">Id</th>
                    <th>Nombre</th>
                    <th>Apellido</th>
                    <th>DNI</th>
                    <th>Teléfono</th>
                    <th>Domicilio</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptUsuarios" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td class="d-none" name="id" <%# Eval("id") %>></td>
                            <td><%# Eval("Nombre") %></td>
                            <td><%# Eval("Apellido") %></td>
                            <td><%# Eval("DNI") %></td>
                            <td><%# Eval("Telefono") %></td>
                            <td><%# Eval("Domicilio") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </section>
</asp:Content>
