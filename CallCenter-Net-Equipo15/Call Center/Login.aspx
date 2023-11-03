<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Call_Center.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Call Center</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.1/font/bootstrap-icons.css">
</head>
<body>
    <form id="form1" runat="server" class="vh-100 vw-100 d-flex justify-content-center align-items-center bg-primary-subtle">
        <div class="container">
            <div class="row d-flex justify-content-center">
                <div class="col-6 text-center">
                    <div class="form-container shadow-lg mb-5 bg-white rounded p-5">
                        <div class="header mb-5">
                            <h3 class="display-5">Bienvenido!</h3>
                        </div>
                        <div class="input-group mb-4">                            
                            <input runat="server" id="EmailInput" type="email" class="form-control rounded" placeholder="Dirección de email" aria-label="Username" aria-describedby="basic-addon1"/>
                        </div>

                        <div class="input-group mb-4">
                            <input runat="server" id="PasswordInput" type="password" class="form-control rounded" placeholder="Contraseña" aria-label="Password" aria-describedby="basic-addon1"/>
                        </div>

                        <div class="forgot-text text-end">
                            <a class="btn"><p>Olvidó su contraseña?</p></a>
                        </div>

                        <div class="button-container d-grid">
                            <asp:Button ID="LoginButton" runat="server" Text="Iniciar sesión" CssClass="btn btn-primary" OnClick="LoginButton_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>


    </form>



    <script src="https://kit.fontawesome.com/your-fontawesome-kit.js" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>
</body>
</html>
