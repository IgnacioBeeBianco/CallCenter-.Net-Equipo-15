<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Call_Center.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>

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
                <h1 class="mb-3">Bienvenido <span class="fw-bold" id="h1NomApe" runat="server"></span>!</h1>
            </div>
        </div>
    </section>
    <section id="cantInci" visible="false" runat="server" class="shadow rounded p-3 bg-dark-subtle">
            <div class="info-container d-flex justify-content-around gap-3">
                <div class="row w-100">
                    <div class="container-fluid rounded shadow bg-dark col-2">
                        <div class="d-flex justify-content-around align-items-center p-2 gap-3 mt-2">
                            <i class="bi bi-box h3"></i>
                            <div class="d-flex flex-column align-items-center text-center">
                                <asp:Label Text="" runat="server" ID="inciTotales" CssClass="h4 fw-bold" />
                                <p>Incidencias totales</p>
                            </div>
                        </div>

                    </div>
                    <div class="container-fluid rounded shadow bg-dark col-2">
                        <div class="d-flex justify-content-around align-items-center p-2 gap-3 mt-2">
                            <i class="bi bi-exclamation-circle h3"></i>
                            <div class="d-flex flex-column align-items-center text-center">
                                <asp:Label Text="" runat="server" ID="inciUrg" CssClass="h4 fw-bold" />
                                <p>Incidencias urgentes</p>
                            </div>
                        </div>
                
                    </div>
                    <div class="container-fluid rounded shadow bg-dark col-2">
                        <div class="d-flex justify-content-around align-items-center p-2 gap-3 mt-2">
                            <i class="bi bi-hourglass-split h3"></i>
                            <div class="d-flex flex-column align-items-center text-center">
                                <asp:Label Text="" runat="server" ID="inciPen" CssClass="h4 fw-bold"/>
                                <p>Incidencias pendientes</p>
                            </div>
                        </div>
                
                    </div>
                    <div class="container-fluid rounded shadow bg-dark col-2">
                        <div class="d-flex justify-content-around align-items-center p-2 gap-3 mt-2">
                            <i class="bi bi-check-circle h3"></i>
                            <div class="d-flex flex-column align-items-center text-center">
                                <asp:Label Text="" runat="server" ID="inciFin" CssClass="h4 fw-bold" />
                                <p>Incidencias resueltas</p>
                            </div>
                        </div>
                    </div>
                    <div class="container-fluid rounded shadow bg-dark col-2">
                        <div class="d-flex justify-content-around align-items-center p-2 gap-3 mt-2">
                            <i class="bi bi-x-circle h3"></i>
                            <div class="d-flex flex-column align-items-center text-center">
                                <asp:Label Text="" runat="server" ID="inciClose" CssClass="h4 fw-bold" />
                                <p>Incidencias cerradas</p>
                            </div>
                        </div>
                    </div>
                </div>
        
            </div>
        </section>
    <section class="shadow rounded mt-3 bg-dark-subtle">
        <div class="p-3">
            <ul class="nav nav-tabs" id="myTab" role="tablist">
              <li class="nav-item" role="presentation">
                  <button class="nav-link active" id="tickets-tab" data-bs-toggle="tab" data-bs-target="#tickets-tab-pane" type="button" role="tab" aria-controls="tickets-tab-pane" aria-selected="true">Tickets</button>
              </li>
              <li class="nav-item" role="presentation">
                  <button class="nav-link" id="search-tickets-tab" data-bs-toggle="tab" data-bs-target="#search-tickets-tab-pane" type="button" role="tab" aria-controls="search-tickets-tab-pane" aria-selected="false">Busqueda</button>
              </li>
          
            </ul>

        </div>

        <div class="tab-content" id="myTabContent">
          <div class="tab-pane fade p-4" id="search-tickets-tab-pane" role="tabpanel" aria-labelledby="search-tickets-tab" tabindex="0">
              <section id="usuDatos" visible="false" runat="server" class="p-3">
                    <h1 class="fw-bold">Tickets</h1>
                    <p>En esta sección verás todos los tickets</p>
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
                    <aside class="col-2 filters rounded shadow">
                        <h3>Filtros</h3>
        
                        <div class="row">
                            <div class="col-6">
                                <div class="mb-3">
                                    <asp:Label Text="DNI" runat="server" ID="lblFiltro" Visible="false" />
                                    <asp:TextBox runat="server" ID="txbFiltraDNI" CssClass="" AutoPostBack="true" OnTextChanged="txbFiltraDNI_TextChanged" Visible="false" />
                                </div>
                            </div>
                        </div>
                    </aside>
            </section>
          </div>
          <div class="tab-pane fade show active p-4" id="tickets-tab-pane" role="tabpanel" aria-labelledby="tickets-tab" tabindex="0">
              <section class="col-10">
                <h1 class="fw-bold">Tickets</h1>
                <p>En esta sección verás todos los tickets</p>
    
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
                </section> 
                <aside class="col-2 filters rounded shadow m-2">
                    <h3>Filtros</h3>
                    <div class="row">
                        <div class="col-12">
                            <div class="mb-3 d-flex flex-column gap-1">
                                <asp:Label Text="ID usuario" runat="server" ID="filtroIDusu" Visible="false" CssClass="form-label"/>
                                <asp:TextBox runat="server" ID="filtro" CssClass="form-control d-block" AutoPostBack="true" OnTextChanged="filtro_TextChanged" Visible="false" />
                            </div>
                        </div>
                    </div>
                </aside>
          </div>
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
