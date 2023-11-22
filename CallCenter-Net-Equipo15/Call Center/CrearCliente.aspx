<%@ Page Title="Registrarse" Language="C#" MasterPageFile="~/Login-CrearCliente.Master" AutoEventWireup="true" CodeBehind="CrearCliente.aspx.cs" Inherits="Call_Center.CrearCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="sectionRegis" class="vh-100 d-flex justify-content-center align-items-center">
        <div class="container">
            <div class="row d-flex justify-content-center">
                <div class="col-6 text-center">
                    <div class="form-container shadow-lg mb-5 rounded p-5 bg-dark-subtle">
                        <div class="header mb-5">
                            <h3 class="display-5">Registrarse!</h3>
                        </div>
                        <div class="input-group mb-2">
                            <input runat="server" id="Nombre" type="text" class="form-control rounded" placeholder="Su nombre" aria-label="Username" aria-describedby="basic-addon1" />
                        </div>
                        <div class="d-flex mt-2">
                            <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="Nombre" InitialValue="" ErrorMessage=" Nombre es obligatorio" Display="Dynamic" ForeColor="Red" CssClass="validationError" />
                        </div>
                        <div class="input-group mb-2">
                            <input runat="server" id="Apellido" type="text" class="form-control rounded" placeholder="Su apellido" aria-label="Username" aria-describedby="basic-addon1" />
                        </div>
                        <div class="d-flex mt-2">
                            <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="Apellido" InitialValue="" ErrorMessage=" Apellido es obligatorio" Display="Dynamic" ForeColor="Red" CssClass="validationError" />
                        </div>
                        <div class="input-group mb-2">
                            <input runat="server" id="DNI" type="text" class="form-control rounded" placeholder="Su DNI" aria-label="Username" aria-describedby="basic-addon1" />
                        </div>
                        <div class="d-flex mt-2">
                            <asp:RequiredFieldValidator ID="rfvDNI" runat="server" ControlToValidate="DNI" InitialValue="" ErrorMessage=" DNI es obligatorio" Display="Dynamic" ForeColor="Red" CssClass="validationError" />
                        </div>
                        <div class="d-flex mt-2">
                            <asp:RegularExpressionValidator ID="revDNI" runat="server" ControlToValidate="DNI" ValidationExpression="^\d{8}$" ErrorMessage=" DNI debe ser un número entero de 8 dígitos" ForeColor="Red" Style="font-size: 13px;"></asp:RegularExpressionValidator>
                        </div>
                        <div class="input-group mb-2">
                            <input runat="server" id="Domicilio" type="text" class="form-control rounded" placeholder="Su domicilio" aria-label="Username" aria-describedby="basic-addon1" />
                        </div>
                        <div class="d-flex mt-2">
                            <asp:RequiredFieldValidator ID="rfvDomicilio" runat="server" ControlToValidate="Domicilio" InitialValue="" ErrorMessage=" Domicilio es obligatorio" Display="Dynamic" ForeColor="Red" CssClass="validationError" />
                        </div>
                        <div class="input-group mb-2">
                            <input runat="server" id="Telefono" type="text" class="form-control rounded" placeholder="Su telefono" aria-label="Username" aria-describedby="basic-addon1" />
                        </div>
                        <div class="d-flex mt-2">
                            <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="Telefono" InitialValue="" ErrorMessage="Telefono es obligatorio" Display="Dynamic" ForeColor="Red" CssClass="validationError" />
                        </div>
                        <div class="d-flex mt-2">
                            <asp:RegularExpressionValidator ID="revTelefono" runat="server" ControlToValidate="Telefono" ValidationExpression="^\d{10}$" ErrorMessage=" Telefono debe ser un número entero de 10 dígitos" ForeColor="Red" Style="font-size: 13px;"></asp:RegularExpressionValidator>
                        </div>
                        <div class="input-group mb-2">
                            <input runat="server" id="Genero" type="text" class="form-control rounded" placeholder="Su genero (M, F o X)" aria-label="Username" aria-describedby="basic-addon1" />
                        </div>
                        <div class="d-flex mt-2">
                            <asp:RequiredFieldValidator ID="rfvGenero" runat="server" ControlToValidate="Genero" InitialValue="" ErrorMessage=" Genero es obligatorio" Display="Dynamic" ForeColor="Red" CssClass="validationError" />
                        </div>
                        <div class="d-flex mt-2">
                            <asp:RegularExpressionValidator ID="revGenero" runat="server" ControlToValidate="Genero" ValidationExpression="^[MFX]$" ErrorMessage=" El género debe ser M, F o X" ForeColor="Red" Style="font-size: 13px;"></asp:RegularExpressionValidator>
                        </div>
                        <div class="input-group mb-2">
                            <input runat="server" id="EmailInput" type="email" class="form-control rounded" placeholder="Dirección de email" aria-label="Username" aria-describedby="basic-addon1" />
                        </div>
                        <div class="d-flex mt-2">
                            <asp:RequiredFieldValidator ID="rfvMail" runat="server" ControlToValidate="EmailInput" InitialValue="" ErrorMessage=" Mail es obligatorio" Display="Dynamic" ForeColor="Red" CssClass="validationError" />
                        </div>
                        <div class="input-group mb-2">
                            <input runat="server" id="PasswordInput" type="password" class="form-control rounded" placeholder="Contraseña" aria-label="Password" aria-describedby="basic-addon1" />
                        </div>
                        <div class="d-flex mt-2">
                            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="PasswordInput" InitialValue="" ErrorMessage=" Contraseña es obligatorio" Display="Dynamic" ForeColor="Red" CssClass="validationError" />
                        </div>
                        <div class="button-container d-grid gap-2">
                            <asp:Button ID="RegistrarseButton" runat="server" Text="Registrarse" CssClass="btn btn-success" OnClick="RegistrarseButton_Click" autopostback="false" />
                            <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn btn-primary" OnClick="btnVolver_Click" CausesValidation="False" />
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </section>
    <script src="https://kit.fontawesome.com/your-fontawesome-kit.js" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>
</asp:Content>
