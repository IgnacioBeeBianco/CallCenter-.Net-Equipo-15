<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CloseComment.aspx.cs" Inherits="Call_Center.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="vh-100 d-flex justify-content-center align-items-center">
        <div class="container bg-dark rounded shadow p-5 text-center">
            <div class="row">
                <h5>Comentario de cierre</h5>
            </div>
            <hr />
            <div class="row mt-3">
                <asp:Label ID="LblCloseComment" runat="server" Text="Para cerrar el ticket es necesario un comentario de cierre" CssClass="form-label h4 mb-3"></asp:Label>
                <asp:TextBox ID="TxbCloseComment" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="row mt-3">
                <div class="container">
                    <asp:Button ID="BtnGoBack" runat="server" Text="Volver" CssClass="btn btn-secondary" OnClick="BtnGoBack_Click" />
                    <asp:Button ID="BtnCloseTicket" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="BtnCloseTicket_Click" />
                </div>
            </div>
            <%if (hasError) { %> 
                <div class="row mt-3">
                    <div class="alert alert-danger" role="alert">
                      Hubo un error al cerrar el ticket
                    </div>
                </div>
            <% }%> 
        </div>
    </section>
</asp:Content>
