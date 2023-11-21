<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CrearIncidencia.aspx.cs" Inherits="Call_Center.CrearIncidencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        function validarFecha(fecha) {
            var regexFecha = /^\d{2}\/\d{2}\/\d{4} \d{2}:\d{2}:\d{2}$/;

            if (!regexFecha.test(fecha)) {
                alert('Formato de fecha y hora inválido. Utiliza el formato DD/MM/YYYY HH:mm:ss');
                document.getElementById('<%= txtbFechaCreacion.ClientID %>').value = '';
                document.getElementById('<%= txtbFechaCambio.ClientID %>').value = '';
            }
        }
    </script>

    <div class="container mt-4">
        <h2>Crear incidencia</h2>
        <div class="mb-3">
            <label for="creador" class="form-label">Solicitado por:</label>
            <asp:DropDownList ID="DropDownCreador" runat="server" CssClass="form-select"></asp:DropDownList>
        </div>
        <div class="mb-3">
            <label for="asignado" class="form-label">Asignado:</label>
            <asp:DropDownList ID="DropDownAsignado" runat="server" CssClass="form-select"></asp:DropDownList>
        </div>
        <div class="mb-3">
            <label for="fechaCreacion" class="form-label">Fecha creacion:</label>
            <asp:TextBox runat="server" ID="txtbFechaCreacion" onblur="validarFecha(this.value)" />
        </div>
        <div class="mb-3">
            <label for="fechaUltimoCambio" class="form-label">Fecha ultimo cambio:</label>
            <asp:TextBox runat="server" ID="txtbFechaCambio" onblur="validarFecha(this.value)" />
        </div>
        <div class="mb-3">
            <label for="estado" class="form-label">Estado:</label>
            <asp:DropDownList ID="DropDownEstados" runat="server" CssClass="form-select"></asp:DropDownList>
        </div>
        <div class="mb-3">
            <label for="prioridad" class="form-label">Prioridad:</label>
            <asp:DropDownList ID="DropDownPrio" runat="server" CssClass="form-select"></asp:DropDownList>
        </div>
        <div class="mb-3">
            <label for="tipoIncidencia" class="form-label">Tipo de Incidencia:</label>
            <asp:DropDownList ID="ddlTipoIncidencia" runat="server" CssClass="form-select"></asp:DropDownList>
        </div>
        <div class="mb-3">
            <label for="problematica" class="form-label">Problemática:</label>
            <textarea class="form-control" id="problematica" rows="3" runat="server"></textarea>
        </div>
        <div class="mb-3">
            <asp:Button Text="Crear" runat="server" ID="btnCrear" OnClick="btnCrear_Click" class="btn btn-primary" type="submit" />
            <asp:Button Text="Volver" runat="server" ID="btnVolver" OnClick="btnVolver_Click" class="btn btn-primary"/>
        </div>
    </div>
</asp:Content>
