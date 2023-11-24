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
        <div class="row mb-3">
            <div class="d-flex justify-content-between align-items-center">
                <h1>Incidencia</h1>
                <div>
                    <asp:Button Text="Volver" runat="server" ID="btnVolver" OnClick="btnVolver_Click" class="btn btn-secondary"/>
                    <asp:Button Text="Guardar" runat="server" ID="btnCrear" OnClick="btnCrear_Click" class="btn btn-primary" type="submit" />
                    <asp:Button ID="BtnResolveTicket" runat="server" Text="Resolver" OnClick="BtnResolveTicket_Click" CssClass="btn btn-success" />
                    <asp:Button ID="BtnCloseTicket" runat="server" Text="Cerrar" OnClick="BtnCloseTicket_Click" CssClass="btn btn-danger" />
                </div>

            </div>
        </div>
        <div class="row mb-3">
            <div class="col">
                <asp:HiddenField ID="IncidenciaId" runat="server" />
                <label for="creador" class="form-label">Solicitado por:</label>
                <asp:DropDownList ID="DropDownCreador" runat="server" CssClass="form-select"></asp:DropDownList>
            </div>
            <div class="col">
                <label for="asignado" class="form-label">Asignado:</label>
                <asp:Label ID="OwnerId" runat="server" CssClass="form-control d-none"></asp:Label>
                <asp:Label ID="Owner" runat="server" CssClass="form-control" Enabled="false"></asp:Label>

            </div>
            <div class="col">
                <label for="reasignacion" class="form-label">Reasignar:</label>
                <asp:DropDownList ID="DropDownAsignado" runat="server" CssClass="form-select" OnSelectedIndexChanged="DropDownAsignado_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            </div>

        </div>
        <div class="row mb-3">
            <div class="col">
                <label for="fechaCreacion" class="form-label">Fecha creacion:</label>
                <asp:TextBox runat="server" ID="txtbFechaCreacion" onblur="validarFecha(this.value)" CssClass="form-control" Enabled="false"/>
            </div>
            <div class="col">
                <label for="fechaUltimoCambio" class="form-label">Fecha ultimo cambio:</label>
                <asp:TextBox runat="server" ID="txtbFechaCambio" onblur="validarFecha(this.value)" CssClass="form-control" Enabled="false"/>
            </div>

        </div>
        <div class="row mb-3">
            <div class="col">
                <label for="estado" class="form-label">Estado:</label>
                <asp:DropDownList ID="DropDownEstados" runat="server" CssClass="form-select"></asp:DropDownList>
            </div>
            <div class="col">
                <label for="prioridad" class="form-label">Prioridad:</label>
                <asp:DropDownList ID="DropDownPrio" runat="server" CssClass="form-select"></asp:DropDownList>
            </div>
            <div class="col">
                <label for="tipoIncidencia" class="form-label">Tipo de Incidencia:</label>
                <asp:DropDownList ID="ddlTipoIncidencia" runat="server" CssClass="form-select"></asp:DropDownList>
            </div>
        </div>
        <div class="mb-3">
            <label for="problematica" class="form-label">Problemática:</label>
            <textarea class="form-control" id="problematica" rows="3" runat="server"></textarea>
        </div>

        <%if (hasError)
            { %>
                <div class="alert alert-danger transition-effect mt-3" role="alert">
                    Error persistiendo la entidad
                </div>
            <% } %>

        

        <section class="comments mt-3">
            <div class="header-section d-flex justify-content-between align-items-center mb-3">
                <h3>Comentarios</h3>
                <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal" <%# EnableAddCommentButton() %>>
                    Agregar comentario
                </button>
         

            </div>
            <asp:Repeater ID="RptComments" runat="server">
                <ItemTemplate>
                    <div class="bg-dark rounded shadow mb-3 p-3">
                        <div>
                            <p><%# Eval("Fecha") %></p>
                        </div>
                        <div class="info d-flex justify-content-between">
                            <div class="user-info">
                                <p><%# Eval("Usuario.nombre") %></p>
                            </div>
                            <div class="delete-button mb-3">
                                <asp:LinkButton ID="BtnDeleteComment" runat="server" CssClass="btn btn-danger">
                                    <i class="bi bi-trash-fill"></i>                                
                                </asp:LinkButton>

                            </div>
                        </div>
                        <textarea class="form-control"><%# Eval("texto") %></textarea>
                    </div>
                </ItemTemplate>
            </asp:Repeater>



        </section>
        
        <asp:ScriptManager ID="SMModal" runat="server" />
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                        <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                            <h1 class="modal-title fs-5" id="exampleModalLabel">Agregar comentario</h1>
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body">
                            <div class="form-floating">
                                <asp:TextBox ID="CommentTextArea" runat="server" CssClass="form-control"></asp:TextBox>
                                <label for="CommentTextArea">Comentario</label>
                            </div> 
                                  
                            <%if (hasError)
                                { %>
                                    <div class="alert alert-danger transition-effect mt-3" role="alert">
                                        Hubo un error al agregar el comentario
                                    </div>
                                <% } %>
                            </div>
                            <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                            <asp:Button ID="BtnSaveComment" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="BtnSaveComment_Click" />
                            </div>
                        </div>
                        </div>
                    </div>
                </ContentTemplate>
                </asp:UpdatePanel>

    </div>
</asp:Content>
