﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AdminPanel.aspx.cs" Inherits="Call_Center.AdminPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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

    <div class="row">
        <div class="col-md-3">
            <div class="card mb-4">
                <div class="card-header d-flex justify-content-between align-items-center">
                    <h5 class="card-title">Prioridad</h5>
                    <div class="d-flex justify-content-end">
                        <i class="bi bi-gear me-2"></i>

                        <asp:Button ID="Priocreate" runat="server" Text="Opciones" OnClick="mostrarModal" CssClass="" table="Prioridad" />
                    </div>
                </div>
                <div class="card-body">
                    <p>Mide el grado de importancia de un ticket</p>
                </div>
            </div>
        </div>

        <asp:ScriptManager ID="SMmodalPrioridad" runat="server" />
        <asp:UpdatePanel ID="upPrioridad" runat="server">
            <ContentTemplate>
                <div id="modalPrioridad" runat="server" style="display: none;">
                    <div class="custom-modal card">
                        <div class="card-header">
                            <h5 class="card-title">Prioridades</h5>
                        </div>
                        <div class="card-body">
                            <div class="form-group">
                                <asp:TextBox ID="txbSearhPrio" placeholder="Busqueda..." runat="server" CssClass="form-control dropdown-item" table="Prioridad"></asp:TextBox>
                                <asp:Button ID="btnSearchPrio" runat="server" Text="Buscar!" OnClick="realizarBusqueda" CssClass="btn btn-primary" table="Prioridad" />
                                <asp:Label ID="lblPrioBuscada" runat="server" Text="" prioId=""></asp:Label>
                                <asp:TextBox ID="txbPrioNombre" runat="server" placeholder="Nombre:" CssClass="form-control"></asp:TextBox>
                                <div class="alert alert-danger" id="alertPrio" runat="server" style="display: none;">
                                    <asp:Label ID="lblPrioErrores" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="card-footer">
                            <asp:Button ID="btnPrioSub" runat="server" Text="Crear" OnClick="submitModal" CssClass="btn btn-primary" table="Prioridad" action="create" />
                            <asp:Button ID="btnPrioModify" runat="server" Text="Modificar" OnClick="submitModal" CssClass="btn btn-warning" table="Prioridad" action="modify" />
                            <asp:Button ID="btnPriodelete" runat="server" Text="Eliminar" OnClick="submitModal" CssClass="btn btn-danger" table="Prioridad" action="delete" />
                            <asp:Button ID="btnPrioCancelar" runat="server" Text="Cancelar" OnClick="cancelarModal" CssClass="btn btn-secondary" table="Prioridad" />

                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>




        <!--
        <div class="col-md-3">
            <div class="card mb-4">
                <div class="card-header d-flex justify-content-between align-items-center">
                    <h5 class="card-title">Estado</h5>
                    <div class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Mas...
                        </a>
                        <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                            <asp:HyperLink runat="server" NavigateUrl="~/" CssClass="dropdown-item">Crear</asp:HyperLink>
                            <asp:HyperLink runat="server" NavigateUrl="~/" CssClass="dropdown-item">Editar</asp:HyperLink>
                            <asp:HyperLink runat="server" NavigateUrl="~/" CssClass="dropdown-item">Eliminar</asp:HyperLink>
                            <asp:TextBox ID="txbBusquedaEstado" placeholder="Busqueda..." runat="server" CssClass="form-control dropdown-item"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="card-body">
                    <label>Cant. estados:</label>
                    <asp:Label ID="lblEstado" runat="server" Text="0"></asp:Label>
                </div>
            </div>
        </div>

        <div class="col-md-3">
            <div class="card mb-4">
                <div class="card-header d-flex justify-content-between align-items-center">
                    <h5 class="card-title">TipoIncidencia</h5>
                    <div class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Mas...
                        </a>
                        <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                            <asp:HyperLink runat="server" NavigateUrl="~/" CssClass="dropdown-item">Crear</asp:HyperLink>
                            <asp:HyperLink runat="server" NavigateUrl="~/" CssClass="dropdown-item">Editar</asp:HyperLink>
                            <asp:HyperLink runat="server" NavigateUrl="~/" CssClass="dropdown-item">Eliminar</asp:HyperLink>
                            <asp:TextBox ID="txbBusquedaTipoIncidencia" placeholder="Busqueda..." runat="server" CssClass="form-control dropdown-item"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="card-body">
                    <label>Cant. TipoIncidencia:</label>
                    <asp:Label ID="lblTipoIncidencia" runat="server" Text="0"></asp:Label>
                </div>
            </div>
        </div>

        <div class="col-md-3">
            <div class="card mb-4">
                <div class="card-header d-flex justify-content-between align-items-center">
                    <h5 class="card-title">Incidencia</h5>
                    <div class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Mas...
                        </a>
                        <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                            <asp:HyperLink runat="server" NavigateUrl="~/" CssClass="dropdown-item">Crear</asp:HyperLink>
                            <asp:HyperLink runat="server" NavigateUrl="~/" CssClass="dropdown-item">Editar</asp:HyperLink>
                            <asp:HyperLink runat="server" NavigateUrl="~/" CssClass="dropdown-item">Eliminar</asp:HyperLink>
                            <asp:TextBox ID="txbBusquedaIncidencia" placeholder="Busqueda..." runat="server" CssClass="form-control dropdown-item"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="card-body">
                    <label>Cant. Incidencias:</label>
                    <asp:Label ID="lblIncidencia" runat="server" Text="0"></asp:Label>
                </div>
            </div>
        </div>

        <div class="col-md-3">
            <div class="card mb-4">
                <div class="card-header d-flex justify-content-between align-items-center">
                    <h5 class="card-title">Usuario</h5>
                    <div class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Mas...
                        </a>
                        <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                            <asp:HyperLink runat="server" NavigateUrl="~/" CssClass="dropdown-item">Crear</asp:HyperLink>
                            <asp:HyperLink runat="server" NavigateUrl="~/" CssClass="dropdown-item">Editar</asp:HyperLink>
                            <asp:HyperLink runat="server" NavigateUrl="~/" CssClass="dropdown-item">Eliminar</asp:HyperLink>
                            <asp:TextBox ID="txbBusquedaUsuario" placeholder="Busqueda..." runat="server" CssClass="form-control dropdown-item"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="card-body">
                    <label>Cant. Usuarios:</label>
                    <asp:Label ID="lblUsuario" runat="server" Text="0"></asp:Label>
                </div>
            </div>
        </div>

        <div class="col-md-3">
            <div class="card mb-4">
                <div class="card-header d-flex justify-content-between align-items-center">
                    <h5 class="card-title">Cliente</h5>
                    <div class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Mas...
                        </a>
                        <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                            <asp:HyperLink runat="server" NavigateUrl="~/" CssClass="dropdown-item">Crear</asp:HyperLink>
                            <asp:HyperLink runat="server" NavigateUrl="~/" CssClass="dropdown-item">Editar</asp:HyperLink>
                            <asp:HyperLink runat="server" NavigateUrl="~/" CssClass="dropdown-item">Eliminar</asp:HyperLink>
                            <asp:TextBox ID="txbBusquedaCliente" placeholder="Busqueda..." runat="server" CssClass="form-control dropdown-item"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="card-body">
                    <label>Cant. Clientes:</label>
                    <asp:Label ID="lblCliente" runat="server" Text="0"></asp:Label>
                </div>
            </div>
        </div>

        <div class="col-md-3">
            <div class="card mb-4">
                <div class="card-header d-flex justify-content-between align-items-center">
                    <h5 class="card-title">Cuenta</h5>
                    <div class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Mas...
                        </a>
                        <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                            <asp:HyperLink runat="server" NavigateUrl="~/" CssClass="dropdown-item">Crear</asp:HyperLink>
                            <asp:HyperLink runat="server" NavigateUrl="~/" CssClass="dropdown-item">Editar</asp:HyperLink>
                            <asp:HyperLink runat="server" NavigateUrl="~/" CssClass="dropdown-item">Eliminar</asp:HyperLink>
                            <asp:TextBox ID="txbBusquedaCuenta" placeholder="Busqueda..." runat="server" CssClass="form-control dropdown-item"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="card-body">
                    <label>Cant. Cuentas:</label>
                    <asp:Label ID="lblCuenta" runat="server" Text="0"></asp:Label>
                </div>
            </div>
        </div>

        <div class="col-md-3">
            <div class="card mb-4">
                <div class="card-header d-flex justify-content-between align-items-center">
                    <h5 class="card-title">Rol</h5>
                    <div class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Mas...
                        </a>
                        <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                            <asp:HyperLink runat="server" NavigateUrl="~/" CssClass="dropdown-item">Crear</asp:HyperLink>
                            <asp:HyperLink runat="server" NavigateUrl="~/" CssClass="dropdown-item">Editar</asp:HyperLink>
                            <asp:HyperLink runat="server" NavigateUrl="~/" CssClass="dropdown-item">Eliminar</asp:HyperLink>
                            <asp:TextBox ID="txbBusquedaRol" placeholder="Busqueda..." runat="server" CssClass="form-control dropdown-item"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="card-body">
                    <label>Cant. Roles:</label>
                    <asp:Label ID="txbRol" runat="server" Text="0"></asp:Label>
                </div>
            </div>
        </div>

    -->

    </div>
</asp:Content>
