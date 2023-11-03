<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Call_Center.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="hero-section vw-100 vh-100 d-flex align-items-center justify-content-center bg-body">
        <div class="px-4 py-5 my-5 text-center">
            <h1>Bienvenido a tu gestor de incidencias!</h1>
            <div class="col-lg-6 mx-auto">
                <p>Para comenzar a usar nuestro increible sistema debes tener una cuenta. Para esto contacta a tu administrador o si ya tenes una cuenta, logueate!</p>
                <div class="d-grid gap-2 d-sm-flex justify-content-sm-center">
                    <span class="navbar-text">
                        <button class="btn btn-primary text-white">Logueate</button>
                    </span>
                    <span class="navbar-text">
                        <button class="btn btn-outline-secondary">Crear cuenta</button>
                    </span>
                </div>
            </div>
        </div>
        
    </section>
    
</asp:Content>
