<%@ Page Language="C#" MasterPageFile="~/Master.Master" CodeBehind="UsuarioPanel.aspx.cs" Inherits="Call_Center.UsuarioPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="">
        <div class="row">
            <div class="col-4">
                <side>
                    <div class="container">
                        <div class="row">
                            <div class="col-12">
                                <asp:Image ID="imagenUsuario" runat="server" CssClass="img-thumbnail" AlternateText="icon-picture" ImageUrl="~/Images/profile_3135768.png" />
                            </div>
                            <div>
                                <asp:Label ID="lblNombre" runat="server"></asp:Label>
                                <asp:Label ID="lblApellido" runat="server"></asp:Label>
                                <asp:Label ID="lblDomicilio" runat="server"></asp:Label>
                                <asp:Label ID="lblTelefono" runat="server"></asp:Label>
                                <asp:Label ID="lblDNI" runat="server"></asp:Label>
                                <asp:Label ID="lblGenero" runat="server"></asp:Label>
                                <asp:Label ID="lblRol" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                </side>
            </div>
            <div class="col-8">
                <main>
                </main>
            </div>



        </div>

    </section>

</asp:Content>
