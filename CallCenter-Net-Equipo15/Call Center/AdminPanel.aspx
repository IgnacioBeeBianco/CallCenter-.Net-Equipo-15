<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AdminPanel.aspx.cs" Inherits="Call_Center.AdminPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="mb-3">
        <h1>Gestor de entidades</h1>
    </section>
    
    <section>
        <nav>
          <ul class="nav nav-tabs" id="nav-tab" role="tablist">
                <li class="nav-item" id="priorities" runat="server">
                    <button class="nav-link active" id="nav-priorities-tab" data-bs-toggle="tab" data-bs-target="#nav-priorities" type="button" role="tab" aria-controls="nav-priorities" aria-selected="true">Prioridades</button>
                 </li>
                <li class="nav-item" id="states" runat="server">
                    <button class="nav-link" id="nav-states-tab" data-bs-toggle="tab" data-bs-target="#nav-states" type="button" role="tab" aria-controls="nav-states" aria-selected="false">Estados</button>
                </li>
                <li class="nav-item" id="roles" runat="server">
                    <button class="nav-link" id="nav-roles-tab" data-bs-toggle="tab" data-bs-target="#nav-roles" type="button" role="tab" aria-controls="nav-roles" aria-selected="false">Roles</button>
                </li>
                <li class="nav-item" id="incidenceTypes" runat="server">
                    <button class="nav-link" id="nav-incidences-types-tab" data-bs-toggle="tab" data-bs-target="#nav-incidences-types" type="button" role="tab" aria-controls="nav-incidences-types" aria-selected="false">Tipos de incidencia</button>
                </li>
                <li class="nav-item" id="users" runat="server">
                    <button class="nav-link" id="nav-users-tab" data-bs-toggle="tab" data-bs-target="#nav-users" type="button" role="tab" aria-controls="nav-users" aria-selected="false">Usuarios</button>
                </li>

          </ul>
        </nav>
        <div class="tab-content" id="nav-tabContent" style="height: 60vh;">
          <div class="tab-pane fade show active h-100" id="nav-priorities" role="tabpanel" aria-labelledby="nav-priorities-tab" tabindex="0">
              <iframe src="~/Admin/Prioridad.aspx" runat="server" width="100" style="width: 100%; height: 100%"></iframe>
          </div>
          <div class="tab-pane fade h-100" id="nav-states" role="tabpanel" aria-labelledby="nav-states-tab" tabindex="0">
              <iframe runat="server" style="width: 100%; height: 100%" src="~/Admin/Estado.aspx" ></iframe>
          </div>
          <div class="tab-pane fade h-100" id="nav-roles" role="tabpanel" aria-labelledby="nav-roles-tab" tabindex="0">
              <iframe runat="server" src="~/Admin/Rol.aspx" style="width: 100%; height: 100%"></iframe>
          </div>
          <div class="tab-pane fade h-100" id="nav-incidences-types" role="tabpanel" aria-labelledby="nav-incidences-types-tab" tabindex="0">
              <iframe src="Admin/TipoIncidencia.aspx" runat="server" style="width: 100%; height: 100%"></iframe>
          </div>
            <div class="tab-pane fade h-100" id="nav-users" role="tabpanel" aria-labelledby="nav-users-tab" tabindex="0">
                <iframe src="Admin/Usuario.aspx" runat="server" style="width: 100%; height: 100%"></iframe>
            </div>
        </div>
    </section>



    
</asp:Content>
