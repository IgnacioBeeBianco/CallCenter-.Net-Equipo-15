<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AdminPanel.aspx.cs" Inherits="Call_Center.AdminPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="mb-3">
        <h1>Gestor de entidades</h1>
    </section>
    <section>
        <nav>
          <div class="nav nav-tabs" id="nav-tab" role="tablist">
            <button class="nav-link active" id="nav-priorities-tab" data-bs-toggle="tab" data-bs-target="#nav-priorities" type="button" role="tab" aria-controls="nav-priorities" aria-selected="true">Prioridades</button>
            <button class="nav-link" id="nav-states-tab" data-bs-toggle="tab" data-bs-target="#nav-states" type="button" role="tab" aria-controls="nav-states" aria-selected="false">Estados</button>
            <button class="nav-link" id="nav-contact-tab" data-bs-toggle="tab" data-bs-target="#nav-contact" type="button" role="tab" aria-controls="nav-contact" aria-selected="false">Contact</button>
            <button class="nav-link" id="nav-disabled-tab" data-bs-toggle="tab" data-bs-target="#nav-disabled" type="button" role="tab" aria-controls="nav-disabled" aria-selected="false" disabled>Disabled</button>
          </div>
        </nav>
        <div class="tab-content" id="nav-tabContent" style="height: 60vh;">
          <div class="tab-pane fade show active h-100" id="nav-priorities" role="tabpanel" aria-labelledby="nav-priorities-tab" tabindex="0">
              <iframe src="~/Admin/PrioridadesCRUD.aspx" runat="server" width="100" style="width: 100%; height: 100%"></iframe>
          </div>
          <div class="tab-pane fade h-100" id="nav-states" role="tabpanel" aria-labelledby="nav-states-tab" tabindex="0">
              <iframe runat="server" style="width: 100%; height: 100%" src="~/Admin/EstadosCRUD.aspx" ></iframe>
          </div>
          <div class="tab-pane fade" id="nav-contact" role="tabpanel" aria-labelledby="nav-contact-tab" tabindex="0">...</div>
          <div class="tab-pane fade" id="nav-disabled" role="tabpanel" aria-labelledby="nav-disabled-tab" tabindex="0">...</div>
        </div>
    </section>



    
</asp:Content>
