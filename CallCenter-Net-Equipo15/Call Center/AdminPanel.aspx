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

        body {
            background-color: #f4f4f4;
        }

        .card {
            background-color: #ffffff;
            border: 1px solid #e0e0e0;
            border-radius: 8px;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
            transition: transform 0.3s;
        }

        .card:hover {
            transform: translateY(-5px);
        }

        .card-header {
            background-color: #f0f0f0;
            padding: 10px;
            border-bottom: 1px solid #e0e0e0;
        }

        .card-title {
            font-size: 18px;
            color: #333333;
        }

        .card-body {
            padding: 15px;
        }

        .ver-mas {
            color: #555555;
            text-decoration: none;
            cursor: pointer;
        }

        .ver-mas:hover {
            color: #007bff;
        }

        /* Colors for different sections */
        .prioridad {
            background-color: #F9EBEA;
        }

        .estado {
            background-color: #D5F5E3;
        }

        .tipo-incidencia {
            background-color: #FCF3CF;
        }

        .usuario {
            background-color: #D6EAF8;
        }

        .rol {
            background-color: #E8DAEF;
        }

    </style>

    <div class="row">
        <div class="col-md-3">
            <div class="card mb-4">
                <div class="card-header d-flex justify-content-between align-items-center prioridad">
                    <h5 class="card-title">Prioridad</h5>
                    <a href="Admin/Prioridad.aspx" class="ver-mas">
                        <i class="bi bi-gear me-2"></i>
                    </a>
                </div>
                <div class="card-body">
                    <p>Mide el grado de importancia de un ticket</p>
                </div>
            </div>
        </div>

        <div class="col-md-3">
            <div class="card mb-4">
                <div class="card-header d-flex justify-content-between align-items-center estado">
                    <h5 class="card-title">Estado</h5>
                    <a href="Admin/Estado.aspx" class="ver-mas">
                        <i class="bi bi-gear me-2"></i>
                    </a>
                </div>
                <div class="card-body">
                    <p>Se encarga de brindar el estado actual de cualquier incidencia</p>
                </div>
            </div>
        </div>

        <div class="col-md-3">
            <div class="card mb-4">
                <div class="card-header d-flex justify-content-between align-items-center tipo-incidencia">
                    <h5 class="card-title">Tipo Incidencia</h5>
                    <a href="Admin/TipoIncidencia.aspx" class="ver-mas">
                        <i class="bi bi-gear me-2"></i>
                    </a>
                </div>
                <div class="card-body">
                    <p>Administra los diferentes tipos de incidencia que pueden haber</p>
                </div>
            </div>
        </div>

        <div class="col-md-3">
            <div class="card mb-4">
                <div class="card-header d-flex justify-content-between align-items-center usuario">
                    <i class="bi bi-people"></i>
                    <h5 class="card-title">Usuario</h5>
                    <a href="Admin/Usuario.aspx" class="ver-mas">
                        <i class="bi bi-gear me-2"></i>
                    </a>
                </div>
                <div class="card-body">
                    <p>Todos los usuarios exitentes en la DB</p>
                </div>
            </div>
        </div>

        <!--TODO: Definir si el alta de cuenta sera desde Usuario !-->
        <!--<div class="col-md-3">
            <div class="card mb-4">
                <div class="card-header d-flex justify-content-between align-items-center">
                    <h5 class="card-title">Cuenta</h5>
                    <a href="Admin/Cuenta.aspx" class="ver-mas">
                        <i class="bi bi-gear me-2"></i>
                    </a>
                </div>
                <div class="card-body">
                    <p>Todas las cuentas existentes en la DB</p>
                </div>
            </div>
        </div>!-->

        
        <div class="col-md-3">
            <div class="card mb-4">
                <div class="card-header d-flex justify-content-between align-items-center rol">
                    <h5 class="card-title">Rol</h5>
                    <a href="Admin/Rol.aspx" class="ver-mas">
                        <i class="bi bi-gear me-2"></i>
                    </a>
                </div>
                <div class="card-body">
                    <p>Todas las cuentas existentes en la DB</p>
                </div>
            </div>
        </div>


    </div>
</asp:Content>
