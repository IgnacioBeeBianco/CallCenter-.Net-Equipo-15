<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Survey.aspx.cs" Inherits="Call_Center.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="vh-100 d-flex align-items-center">
        <div class="container bg-dark rounded shadow p-5">
            <div class="row text-center mb-3">
                <h5>Encuesta</h5>
            </div>
                        <hr />
            <div class="row d-flex justify-content-center align-items-center flex-column mt-4 mb-4">
                <asp:Label ID="LblSurvey" runat="server" Text="Califica al telefonista" CssClass="form-label text-center h3"></asp:Label>
                <asp:TextBox ID="TxbCalification" runat="server" CssClass="form-range w-50" TextMode="Range" min="1" max="5"></asp:TextBox>
            </div>
            <div class="row mb-4">
                <asp:Label ID="LblComments" runat="server" Text="Tu feedback nos ayuda a crecer!" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="TxbComments" runat="server" CssClass="form-control" TextMode="MultiLine">

                </asp:TextBox>
            </div>
            <div class="row d-flex">
                <div class="text-center">
                    <asp:Button ID="BtnGoBack" runat="server" Text="Volver" CssClass="btn btn-secondary" OnClick="BtnGoBack_Click"/>
                    <asp:Button ID="BtnResolveTicket" runat="server" Text="Resolver" CssClass="btn btn-primary" OnClick="BtnResolveTicket_Click"/>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

