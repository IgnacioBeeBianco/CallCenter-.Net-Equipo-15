<%@ Page Title="" Language="C#" MasterPageFile="~/Login-CrearCliente.Master" AutoEventWireup="true" CodeBehind="OlvidoPassword.aspx.cs" Inherits="Call_Center.OlvidoPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="sectionOlvidoPass" class="vh-100 d-flex justify-content-center align-items-center" style="max-width: 1000px; margin: 0 auto;">
        <div class="container shadow mb-4 rounded-4 p-5 bg-dark-subtle">
            <div class="form-container p-5 justify-content-center align-items-center">
                <div class="header mb-5 text-center">
                    <h1 class="display-5">Cambiar contraseña</h1>
                </div>
                <div class="input-group mb-4">
                    <input runat="server" id="EmailInput" type="email" class="form-control rounded" placeholder="Dirección de email" aria-label="Username" aria-describedby="basic-addon1" />
                </div>

                <div class="input-group mb-4">
                    <input runat="server" id="PasswordInput" type="password" class="form-control rounded" placeholder="Contraseña" aria-label="Password" aria-describedby="basic-addon1" />
                    <div class="input-group-append">
                        <span class="input-group-text" id="password-toggle" onclick="togglePasswordVisibility()">
                            <i class="bi bi-eye" id="password-toggle-icon"></i>
                        </span>
                    </div>
                </div>
                <div class="button-container text-center d-grid gap-2">
                    <asp:Button ID="CamPassButton" runat="server" Text="Cambiar contraseña" CssClass="btn btn-success" OnClick="CamPassButton_Click" />
                    <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn btn-primary" OnClick="btnVolver_Click" CausesValidation="False" />
                </div>



                <% if (Session["NoAccountFound"] != null && (bool)Session["NoAccountFound"])
                    { %>
                <div class="alert alert-danger transition-effect mt-3" role="alert">
                    Oops...
                 <br />
                    El email ingresado no existe
                </div>
                <% } %>
            </div>

        </div>
    </section>
    <script>
        setTimeout(function () {
            var element = document.querySelector(".transition-effect");
            if (element) {
                element.style.opacity = 1;
            }
        }, 100);
        function togglePasswordVisibility() {
            var passwordInput = document.getElementById('<%= PasswordInput.ClientID %>');
            var passwordToggleIcon = document.getElementById('password-toggle-icon');

            if (passwordInput) {
                if (passwordInput.type === 'password') {
                    passwordInput.type = 'text';
                    passwordToggleIcon.classList.remove('bi-eye');
                    passwordToggleIcon.classList.add('bi-eye-slash');
                } else {
                    passwordInput.type = 'password';
                    passwordToggleIcon.classList.remove('bi-eye-slash');
                    passwordToggleIcon.classList.add('bi-eye');
                }
            } else {
                console.error('Element with ID "PasswordInput" not found.');
            }
        }
    </script>

    <script src="https://kit.fontawesome.com/your-fontawesome-kit.js" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>
</asp:Content>
