<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Call_Center.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="hero-section vh-30 d-flex bg-primary-subtle">
        <div class="row">
            <div class="col-12">
                <h4>Bienvenido</h4>
                <h4 id="h1NomApe" runat="server"></h4>
            </div>
        </div>
    </section>
    <section>
        <p>Cantidad de incidencias por Telefonista</p>
        <div>
            <div>
                <asp:Label Text="Incidencias realizadas" runat="server" />
                <asp:Label Text="0" runat="server" ID="inciReali" />
            </div>
            <div>
                <asp:Label Text="Incidencias pendientes" runat="server" />
                <asp:Label Text="0" runat="server" ID="inciPen" />
            </div>
            <div>
                <asp:Label Text="Incidencias urgentes" runat="server" />
                <asp:Label Text="0" runat="server" ID="inciUrg" />
            </div>
        </div>
    </section>
    <section>
        <p>Incidencias</p>
        <table class="table table-bordered">
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Fecha de creacion</th>
                    <th>Fecha de cierre</th>
                    <th>Estado</th>
                    <th>Tipo de incidencia</th>
                    <th>Problematica</th>
                    <th>Comentario de cierre</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptIncidencias" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("id") %></td>
                            <td><%# Eval("fecha_creacion") %></td>
                            <td><%# Eval("fecha_cierre") %></td>
                            <td><%# Eval("estado_id") %></td>
                            <td><%# Eval("tipo_incidencia_id") %></td>
                            <td><%# Eval("problematica") %></td>
                            <td><%# Eval("comentario_cierra") %></td>
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
