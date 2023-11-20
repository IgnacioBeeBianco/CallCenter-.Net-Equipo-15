<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/CRUD.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="Call_Center.ABML.Usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .custom-modal{
           height: 100% !important; 
           position: relative !important;
        }

    </style>
    <div class="buttons d-flex justify-content-end align-items-center mb-3">
        
        <asp:LinkButton ID="btnCrear" runat="server" OnClick="abrirModal" CssClass="btn btn-primary" action="create">
            Crear
        </asp:LinkButton>
    </div>
    <table class="table table-bordered">
        <thead>
            <tr>
                <th class="d-none">Id</th>
                <th>Nombre</th>
                <th>Apellido</th>
                <th>DNI</th>
                <th>Teléfono</th>
                <th>Domicilio</th>
                <th style="width: 10%" class="text-center">Modificar</th>
                <th style="width: 10%" class="text-center">Eliminar</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rptUsuarios" runat="server">
                <ItemTemplate>
                    <tr>
                        <td class="d-none" name="id"<%# Eval("id") %> ></td>
                        <td><%# Eval("Nombre") %></td>
                        <td><%# Eval("Apellido") %></td>
                        <td><%# Eval("DNI") %></td>
                        <td><%# Eval("Telefono") %></td>
                        <td><%# Eval("Domicilio") %></td>
                        <td style="width: 6%; text-align: center;">
                            <asp:LinkButton ID="btnModificar" runat="server" OnClick="abrirModal" CommandArgument='<%#Eval("id") %>' CommandName="id" action="modify" CssClass="btn btn-secondary">
                                <i class="bi bi-pencil-fill"></i>
                            </asp:LinkButton>
                        </td>
                        <td style="width: 6%; text-align: center;">
                            <asp:LinkButton ID="btnQuitar" CssClass="btn btn-danger" runat="server" OnClick="btnQuitar" CommandArgument='<%#Eval("id") %>' CommandName="id">
                                <i class="bi bi-trash3-fill"></i>
                            </asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>    

    
    

    <asp:ScriptManager ID="SMModal" runat="server" />
        <asp:UpdatePanel ID="upModal" runat="server">
                <ContentTemplate>
                    <div id="modalUsuarios" runat="server" style="display: none;">
                        <div class="custom-modal card">
                            <div class="card-header mb-3">
                                <div class="card-Title">
                                    <asp:Label ID="lblTitle" runat="server" Text="" CssClass=""></asp:Label>
                                    <asp:Label ID="lblNombre" runat="server" Text=""></asp:Label>
                                </div>
                            </div>

                            <div class="card-body">
                                
                                <div class="tab-pane fade show active" id="personal-data-tab-pane" role="tabpanel" aria-labelledby="personal-data-tab" tabindex="0">
                                    <div class="form-group">
                                            
                                            <asp:TextBox ID="txbId" runat="server" Text="" style="display: none;"></asp:TextBox>

                                            <div class="row d-flex">
                                                <div class="input-group mb-3">
                                                    <asp:TextBox ID="txbUsuarioNombre" runat="server" placeholder="Nombre:" CssClass="form-control"></asp:TextBox>
                                                </div>
                                                <div class="input-group mb-3">
                                                    <asp:TextBox ID="TxbUsuarioApellido" runat="server" placeholder="Apellido:" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
 
                                            <div class="input-group mb-3">
                                                <asp:TextBox ID="TxbUsuarioDNI" runat="server" placeholder="DNI:" CssClass="form-control" TextMode="Number" MaxLength="8"></asp:TextBox>
                                            </div>
                     
                                            <div class="input-group mb-3">
                                                <asp:TextBox ID="TxbUsuarioDomicilio" runat="server" placeholder="Domicilio:" CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <div class="input-group mb-3">
                                                <asp:TextBox ID="TxbUsuarioTelefono" runat="server" placeholder="Teléfono:" CssClass="form-control" TextMode="Phone"></asp:TextBox>
                                            </div>
                                            <asp:RadioButtonList ID="GenderRadioButtons" runat="server" CssClass="mb-3">
                                                <asp:ListItem Text="M" Value="M" />
                                                <asp:ListItem Text="F" Value="F" />
                                                <asp:ListItem Text="X" Value="X" />
                                            </asp:RadioButtonList>

                                        <div class="input-group mb-3">
                                            <asp:TextBox ID="TxbEMail" runat="server" placeholder="Email:" CssClass="form-control" TextMode="Email"></asp:TextBox>
                                        </div>
                                        <div class="input-group mb-3">
                                            <asp:TextBox ID="TxbPassword" runat="server" placeholder="Contraseña:" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                        </div>
                                        <asp:DropDownList ID="RoleDropdown" runat="server" CssClass="form-select">
                                                <asp:ListItem></asp:ListItem>
                                        </asp:DropDownList>

                                        <%if (hasError)
                                        { %>
                                            <div class="alert alert-danger mt-3 transition-effect" id="alertPrio" runat="server">
                                                <asp:Label ID="LblUserFormError" runat="server" Text="Hubo un error al persistir la entidad"></asp:Label>
                                            </div>

                                       <% } %>
                                        


                                    </div>
                                </div>
                                                        
                            </div>

                            <div class="card-footer">
                                <asp:TextBox ID="txbAction" runat="server" Text="" style="display: none;"></asp:TextBox>
                                <asp:Button ID="btnPrioSub" runat="server" Text="Confirmar" OnClick="submitModal" CssClass="btn btn-primary"/>
                                <asp:Button ID="btnPrioCancelar" runat="server" Text="Cancelar" OnClick="cancelarModal" CssClass="btn btn-secondary"/>

                            </div>
                            
                        </div>

                        
                    </div>
                </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>
