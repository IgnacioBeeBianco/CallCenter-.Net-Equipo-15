﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Call_Center.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>HomePage</h1>
    <p>HomePage en creación... ir a crear incidencia para ver contenido</p>
    <div>
        <asp:GridView ID="dgvTiposIncidencias" runat="server" CssClass="table"></asp:GridView>
    </div>
    
</asp:Content>