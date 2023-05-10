<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmAutenticacion.aspx.cs" Inherits="SIS_CARLITOS.Admin.frmLogin" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<!doctype html>
<html lang="en">
<head>
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <link href="https://fonts.googleapis.com/css?family=Roboto:300,400&display=swap" rel="stylesheet">

    <link rel="stylesheet" href="fonts/icomoon/style.css">

    <link rel="stylesheet" href="css/owl.carousel.min.css">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="css/bootstrap.min.css">

    <!-- Style -->
    <link rel="stylesheet" href="css/style.css">

    <title>Login #6</title>
</head>
<body>


    <div class="d-lg-flex half">
        <div class="bg order-1 order-md-2" style="background-image: url('images/bg_1.jpg');"></div>
        <div class="contents order-2 order-md-1">

            <div class="container">
                <div class="row align-items-center justify-content-center">
                    <div class="col-md-7">
                        <div class="mb-4">
                            <h3>Inicio de sesión</h3>
                            <p class="mb-4">Ingrese su correo electrónico y contraseña.</p>
                        </div>
                        <form  runat="server">
                             <asp:ScriptManager ID="smMain" runat="server"></asp:ScriptManager>
                            <div class="form-group first">
                                <%--<label for="username">Correo electrónico</label>--%>
                                <%--<input type="text" class="form-control" id="username">--%>
                                <asp:TextBox ID="txtUsuario" placeholder="Correo electrónico" MaxLength="50" class="form-control" runat="server"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" FilterMode="ValidChars" TargetControlID="txtUsuario" ValidChars="abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ0123456789_-@."></cc1:FilteredTextBoxExtender>
                            </div>
                            <div class="form-group last mb-3">
                                <%--<label for="password">Contraseña</label>--%>
                                <%--<input type="password" class="form-control" id="password">--%>
                                <asp:TextBox ID="txtContrasenia" placeholder="Contraseña" MaxLength="8" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterMode="ValidChars" TargetControlID="txtContrasenia" ValidChars="abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ0123456789_-@."></cc1:FilteredTextBoxExtender>
                            </div>

                            <div class="d-flex mb-5 align-items-center">
                                <label class="control control--checkbox mb-0">
                                    <span class="caption">Recordarme</span>
                                    <input type="checkbox" checked="checked" />
                                    <div class="control__indicator"></div>
                                </label>
                                <span class="ml-auto"><a href="#" class="forgot-pass">Recuperar contraseña</a></span>

                            </div>
                             <asp:Label ID="lblMensaje" class="text-danger" runat="server" Text="" Visible="false"></asp:Label>
                             <asp:LinkButton runat="server" ID="btnIniciarSesion" class="btn btn-block btn-primary text-decoration-none text-white" Text="Iniciar sesión"
                                        OnClick="btnIniciarSesion_Click1" />
                            <%--<input type="submit" value="Iniciar sesión" class="btn btn-block btn-primary">--%>
                            <asp:LinkButton runat="server" ID="btnRegistrarse" class="btn btn-block btn-warning text-decoration-none text-dark" Text="Registrarse" OnClick="btnRegistrarse_Click"
                                       />

                            <%--<span class="d-block text-center my-4 text-muted">&mdash; or &mdash;</span>--%>

                            <%--<div class="social-login">
                <a href="#" class="facebook btn d-flex justify-content-center align-items-center">
                  <span class="icon-facebook mr-3"></span> Login with Facebook
                </a>
                <a href="#" class="twitter btn d-flex justify-content-center align-items-center">
                  <span class="icon-twitter mr-3"></span> Login with  Twitter
                </a>
                <a href="#" class="google btn d-flex justify-content-center align-items-center">
                  <span class="icon-google mr-3"></span> Login with  Google
                </a>
              </div>--%>
                        </form>
                    </div>
                </div>
            </div>
        </div>


    </div>



    <script src="js/jquery-3.3.1.min.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/main.js"></script>
</body>
</html>
