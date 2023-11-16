<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Call_Center.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" data-bs-theme="dark">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Call Center</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous"/>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.1/font/bootstrap-icons.css"/>
    <link rel="preconnect" href="https://fonts.googleapis.com"/>
    <link rel="preconnect" href="https://fonts.gstatic.com"/>
    <link href="https://fonts.googleapis.com/css2?family=Inter&display=swap" rel="stylesheet"/>
    <link rel="stylesheet" href="Css/Main.css"/>
    <link rel="stylesheet" href="Css/Login.css"/>
</head>
<body>
    
    <form id="form1" runat="server" class="vh-100 d-flex justify-content-center align-items-center">
        <div class="row">

        </div>
        <div class="container d-flex shadow mb-5 rounded-4 p-5 bg-dark">
            <div class="form-container col-6 p-5">
                <div class="header mb-5 text-center">
                    <h1 class="display-5">Inicia sesión</h1>
                </div>
                <div class="input-group mb-4">
                    <input runat="server" id="EmailInput" type="email" class="form-control rounded" placeholder="Dirección de email" aria-label="Username" aria-describedby="basic-addon1" />
                </div>

                <div class="input-group mb-4">
                    <input runat="server" id="PasswordInput" type="password" class="form-control rounded" placeholder="Contraseña" aria-label="Password" aria-describedby="basic-addon1" />
                </div>

                <div class="forgot-text text-center">
                    <a class="btn">
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
        

        

                    


       
                
    </form>


    <script>
        setTimeout(function () {
            var element = document.querySelector(".transition-effect");
            if (element) {
                element.style.opacity = 1;
            }
        }, 100);
    </script>

    <script src="https://kit.fontawesome.com/your-fontawesome-kit.js" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>
</body>
</html>
