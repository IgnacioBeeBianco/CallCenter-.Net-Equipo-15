<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CrearIncidencia.aspx.cs" Inherits="Call_Center.CrearIncidencia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
      <h2>Crear una Incidencia</h2>
        <div class="mb-3">
          <label for="estado" class="form-label">Estado:</label>
          <select class="form-select" id="estado">
            <option selected>Selecciona un estado</option>
            <option value="abierto">Abierto</option>
            <option value="en_proceso">En proceso</option>
            <option value="cerrado">Cerrado</option>
          </select>
        </div>
        <div class="mb-3">
          <label for="asignado" class="form-label">Asignado:</label>
          <input type="text" class="form-control" id="asignado">
        </div>
        <div class="mb-3">
          <label for="problematica" class="form-label">Problemática:</label>
          <textarea class="form-control" id="problematica" rows="3"></textarea>
        </div>
        <div class="mb-3">
          <label for="prioridad" class="form-label">Prioridad:</label>
          <select class="form-select" id="prioridad">
            <option selected>Selecciona una prioridad</option>
            <option value="baja">Baja</option>
            <option value="media">Media</option>
            <option value="alta">Alta</option>
          </select>
        </div>
        <div class="mb-3">
          <label for="tipoIncidencia" class="form-label">Tipo de Incidencia:</label>
          <asp:DropDownList ID="ddlTipoIncidencia" runat="server" CssClass="form-select"></asp:DropDownList>
        </div>
        <button type="submit" class="btn btn-primary">Crear</button>
    </div>
</asp:Content>
