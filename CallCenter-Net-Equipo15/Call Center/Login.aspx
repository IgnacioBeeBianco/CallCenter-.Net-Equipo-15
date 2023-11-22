<%@ Page Title="Login" Language="C#" MasterPageFile="~/Login-CrearCliente.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Call_Center.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="sectionLogin" class="vh-100 d-flex justify-content-center align-items-center">
        <div class="container d-flex shadow mb-5 rounded-4 p-5 bg-dark-subtle">
            <div class="form-container col-6 p-5">
                <div class="header mb-5 text-center">
                    <h1 class="display-5">Inicia sesión</h1>
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

                <div class="forgot-text text-center">
                    <a href="OlvidoPassword.aspx" class="btn">
                        <p>Olvidó su contraseña?</p>
                    </a>
                </div>

                <div class="button-container text-center">
                    <asp:Button ID="LoginButton" runat="server" Text="Iniciar sesión" CssClass="btn btn-primary w-50" OnClick="LoginButton_Click" />
                </div>

                <% if (Session["NoAccountFound"] != null && (bool)Session["NoAccountFound"])
                    { %>
                <div class="alert alert-danger transition-effect mt-3" role="alert">
                    Oops...
                     <br />
                    Email o contraseña incorrectos
                </div>
                <% } %>
            </div>
            <div class="col-6 text-center d-flex flex-column justify-content-center align-items-center">
                <h1>Bienvenido!</h1>
                <p>Si no tenés una cuenta, registrate para usar nuestra app</p>
                <asp:Button ID="RegisterButton" runat="server" Text="Registrarse" CssClass="btn btn-outline-primary" OnClick="RegistrarseButton_Click" />
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
