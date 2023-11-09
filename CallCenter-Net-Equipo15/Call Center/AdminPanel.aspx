<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AdminPanel.aspx.cs" Inherits="Call_Center.AdminPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .ver-mas {
            color: inherit;
            text-decoration: none;
            /* Restablece el cursor a su valor predeterminado */
            cursor: pointer;
        }
    </style>

    <div class="row">
        <div class="col-md-3">
            <div class="card mb-4">
                <div class="card-header d-flex justify-content-between align-items-center">
                    <h5 class="card-title">Prioridad</h5>
                    <a href="Admin/Prioridad.aspx" class="ver-mas">
                        <i class="bi bi-gear me-2"></i>
                        Ver mas
                    </a>
                </div>
                <div class="card-body">
                    <p>Mide el grado de importancia de un ticket</p>
                </div>
            </div>
        </div>

        <div class="col-md-3">
            <div class="card mb-4">
                <div class="card-header d-flex justify-content-between align-items-center">
                    <h5 class="card-title">Estado</h5>
                    <a href="Admin/Estado.aspx" class="ver-mas">
                        <i class="bi bi-gear me-2"></i>
                        Ver mas
                    </a>
                </div>
                <div class="card-body">
                    <p>Se encarga de brindar el estado actual de cualquier incidencia</p>
                </div>
            </div>
        </div>

        <div class="col-md-3">
            <div class="card mb-4">
                <div class="card-header d-flex justify-content-between align-items-center">
                    <h5 class="card-title">Tipo Incidencia</h5>
                    <a href="Admin/TipoIncidencia.aspx" class="ver-mas">
                        <i class="bi bi-gear me-2"></i>
                        Ver mas
                    </a>
                </div>
                <div class="card-body">
                    <p>Administra los diferentes tipos de incidencia que pueden haber</p>
                </div>
            </div>
        </div>

        <div class="col-md-3">
            <div class="card mb-4">
                <div class="card-header d-flex justify-content-between align-items-center">
                    <h5 class="card-title">Usuario</h5>
                    <a href="Admin/Usuario.aspx" class="ver-mas">
                        <i class="bi bi-gear me-2"></i>
                        Ver mas
                    </a>
                </div>
                <div class="card-body">
                    <p>Todos los usuarios exitentes en la DB</p>
                </div>
            </div>
        </div>

        <div class="col-md-3">
            <div class="card mb-4">
                <div class="card-header d-flex justify-content-between align-items-center">
                    <h5 class="card-title">Cuenta</h5>
                    <a href="Admin/Cuenta.aspx" class="ver-mas">
                        <i class="bi bi-gear me-2"></i>
                        Ver mas
                    </a>
                </div>
                <div class="card-body">
                    <p>Todas las cuentas existentes en la DB</p>
                </div>
            </div>
        </div>

        
        <div class="col-md-3">
            <div class="card mb-4">
                <div class="card-header d-flex justify-content-between align-items-center">
                    <h5 class="card-title">Rol</h5>
                    <a href="Admin/Rol.aspx" class="ver-mas">
                        <i class="bi bi-gear me-2"></i>
                        Ver mas
                    </a>
                </div>
                <div class="card-body">
                    <p>Todas las cuentas existentes en la DB</p>
                </div>
            </div>
        </div>


    </div>
</asp:Content>
