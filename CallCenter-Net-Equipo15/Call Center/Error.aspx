<%@ Page Title="" Language="C#" MasterPageFile="~/Login-CrearCliente.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Call_Center.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="sectionError" class="vh-100 d-flex justify-content-center align-items-center" style="max-width: 1000px; margin: 0 auto;">
        <div class="container shadow mb-4 rounded-4 p-5 bg-dark-subtle">
            <div class="form-container p-5 justify-content-center align-items-center">
                <div class="header mb-5 text-center">
                    <h1 class="display-5">Ha ocurrido un error!</h1>
                    <h2>Contactese con soporte tecnico!</h2>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
