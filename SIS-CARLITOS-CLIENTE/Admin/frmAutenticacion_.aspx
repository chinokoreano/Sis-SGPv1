<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmAutenticacion_.aspx.cs" Inherits="SIS_CARLITOS.Admin.frmAutenticacion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html lang="en" class="no-focus">
<!--<![endif]-->
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=0">

    <title>Sis - SGP Sistema Gestion de Paquetería &amp;</title>

    <meta name="description" content="Codebase - Bootstrap 4 Admin Template &amp; UI Framework created by pixelcave and published on Themeforest">
    <meta name="author" content="pixelcave">
    <meta name="robots" content="noindex, nofollow">

    <!-- Open Graph Meta -->
    <meta property="og:title" content="Codebase - Bootstrap 4 Admin Template &amp; UI Framework">
    <meta property="og:site_name" content="Codebase">
    <meta property="og:description" content="Codebase - Bootstrap 4 Admin Template &amp; UI Framework created by pixelcave and published on Themeforest">
    <meta property="og:type" content="website">
    <meta property="og:url" content="">
    <meta property="og:image" content="">

    <!-- Icons -->
    <!-- The following icons can be replaced with your own, they are used by desktop and mobile browsers -->
    <link rel="shortcut icon" href="public/assets/img/favicons/favicon.png">
    <link rel="icon" type="image/png" sizes="192x192" href="public/assets/img/favicons/favicon-192x192.png">
    <link rel="apple-touch-icon" sizes="180x180" href="../public/assets/img/favicons/apple-touch-icon-180x180.png">

    <!-- END Icons -->

    <!-- Stylesheets -->
    <!-- Codebase framework -->
    <link rel="stylesheet" id="css-main" href="../public/assets/css/codebase.min.css">

    <!-- You can include a specific file from css/themes/ folder to alter the default color theme of the template. eg: -->
    <!-- <link rel="stylesheet" id="css-theme" href="public/assets/css/themes/flat.min.css"> -->
    <!-- END Stylesheets -->
</head>
<body>
    <div id="page-container" class="main-content-boxed">
        <!-- Main Container -->
        <main id="main-container">

            <!-- Page Content -->
            <div class="bg-image2" style="background-image: url('../public/assets/img/photos/img_inicio_sesion_ce.jpg');">
                <div class="row mx-0 bg-black-op-20">
                    <div class="hero-static col-md-6 col-xl-8 d-none d-md-flex align-items-md-end">
                        <div class="p-30 invisible" data-toggle="appear">
                            <%--<p class="font-size-h4 font-w600 text-black">
                                    CourieExpress - 2021
                                </p>--%>
                            <p class="font-italic text-white-op">
                                Copyright &copy; <span class="js-year-copy">2023</span>
                            </p>
                        </div>
                    </div>
                    <div class="hero-static col-md-6 col-xl-4 d-flex align-items-center bg-white invisible" data-toggle="appear" data-class="animated fadeInRight">
                        <div class="content content-full">
                            <!-- Header -->
                            <h6 class="h5 text-muted mb-0 font-size-h6 mb-10">Recomendamos: Firefox ó Chrome</h6>
                            <div class="px-30 py-10">
                                <a class="link-effect font-w700" href="index.html">
                                    <%-- <i class="si si-fire"></i>--%>
                                    <span class="font-size-xl text-primary-dark">Sis-Delivery</span><span class="font-size-xl"> v1.0</span>
                                </a>

                                <h1 class="h3 font-w700 mt-30 mb-10">Bienvenido</h1>
                                <h2 class="h5 font-w400 text-muted mb-0">Inicio de sesión</h2>

                            </div>
                            <!-- END Header -->

                            <!-- Sign In Form -->
                            <!-- jQuery Validation (.js-validation-signin class is initialized in js/pages/op_auth_signin.js) -->
                            <!-- For more examples you can check out https://github.com/jzaefferer/jquery-validation -->
                            <form runat="server">
                                <asp:ScriptManager ID="smMain" runat="server"></asp:ScriptManager>
                                <div class="form-group row">
                                    <div class="col-12">
                                        <div class="form-material floating">

                                            <asp:TextBox ID="txtUsuario" placeholder="Usuario" MaxLength="10" class="form-control" runat="server"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" FilterMode="ValidChars" TargetControlID="txtUsuario" ValidChars="abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ0123456789/*-+!@$()"></cc1:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group row" runat="server" id="divCorreo" visible="false">
                                    <div class="col-12">
                                        <div class="form-material floating">

                                            <asp:TextBox ID="txtCorreoElectronico" placeholder="Correo Electrónico" MaxLength="50" class="form-control" runat="server"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" FilterMode="ValidChars" TargetControlID="txtCorreoElectronico" ValidChars="abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ0123456789-_.@"></cc1:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group row" runat="server" id="divContrasenia" visible="true">
                                    <div class="col-12">
                                        <div class="form-material floating">
                                            <asp:TextBox ID="txtContrasenia" placeholder="Contraseña" MaxLength="8" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterMode="ValidChars" TargetControlID="txtContrasenia" ValidChars="abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ0123456789/*-+!@$()"></cc1:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group row">
                                    <div class="col-12">
                                        <div class="form-material floating">
                                            <asp:LinkButton ID="lnkRecuperarContrasenia" runat="server" Visible="false" OnClick="lnkRecuperarContrasenia_Click">Recuperar contraseña</asp:LinkButton>
                                        </div>
                                    </div>
                                </div>



                                <div class="form-group row">
                                    <div class="col-12">
                                        <div class="form-material floating">
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterMode="ValidChars" TargetControlID="txtContraseniaNueva" ValidChars="abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ0123456789/*-+!@$()"></cc1:FilteredTextBoxExtender>
                                            <asp:TextBox ID="txtContraseniaNueva" Visible="false" MaxLength="8" placeholder="Nueva contraseña" class="form-control" runat="server" TextMode="Password" ToolTip="Max. 8 carácteres y debe contener letras números y algunos de estos carácteres especiales /*-+!@$()"></asp:TextBox>

                                        </div>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-12">
                                        <div class="form-material floating">
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterMode="ValidChars" TargetControlID="txtConfirmarContrasenia" ValidChars="abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ0123456789/*-+!@$()"></cc1:FilteredTextBoxExtender>
                                            <asp:TextBox ID="txtConfirmarContrasenia" Visible="false" MaxLength="8" placeholder="Vuelva a registrar contraseña" class="form-control" runat="server" TextMode="Password" ToolTip="Max. 8 carácteres y debe contener letras números y algunos de estos carácteres especiales /*-+!@$()"></asp:TextBox>

                                        </div>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-12">
                                        <div class="form-material floating">
                                            <asp:Label ID="lblMensaje" class="text-danger" runat="server" Text="" Visible="false"></asp:Label>

                                        </div>
                                    </div>
                                </div>
                                <%-- <div class="form-group row">
                                        <div class="col-12">
                                            <label class="custom-control custom-checkbox">
                                                <input type="checkbox" class="custom-control-input" id="login-remember-me" name="login-remember-me">
                                                <span class="custom-control-indicator"></span>
                                                <span class="custom-control-description">Recuerdame</span>
                                            </label>
                                        </div>
                                        
                                    </div>--%>
                                <div class="form-group">
                                    <%--<button type="submit" class="btn btn-sm btn-hero btn-alt-primary">
                                            <i class="si si-login mr-10"></i> Ingresar
                                        </button>--%>


                                    <%--<button runat="server" id="btnIniciarSesion" class="btn btn-sm btn-hero btn-alt-primary" title="Ingresar">
                                            <i class="si si-login mr-10"></i>Ingresar
                                        </button>--%>

                                    <asp:LinkButton runat="server" ID="btnIniciarSesion" Text="<i class='si si-login mr-10'></i> Ingresar"
                                        ValidationGroup="edt" class="btn btn-info" OnClick="btnIniciarSesion_Click1" />
                                    <asp:LinkButton runat="server" ID="btnCambiarContrasenia" Visible="false" Text="<i class='si si-login mr-10'></i> Cambiar contraseña"
                                        ValidationGroup="edt" class="btn btn-sm btn-hero btn-alt-primary" OnClick="btnCambiarContrasenia_Click1" />
                                    <asp:LinkButton runat="server" ID="btnRecuperarContrasenia" Visible="false" Text="<i class='si si-login mr-10'></i> Aceptar"
                                        ValidationGroup="edt" class="btn btn-sm btn-hero btn-alt-primary" OnClick="btnRecuperarContrasenia_Click" />

                                    <a class="link-effect text-muted mr-10 mb-5 d-inline-block" href="Registrarse">
                                        <i class="fa fa-plus mr-5"></i>Crear cuenta
                                    </a>
                                    <div class="mt-30">

                                        <%-- <a class="link-effect text-muted mr-10 mb-5 d-inline-block" href="op_auth_reminder2.html">
                                                <i class="fa fa-warning mr-5"></i> Recuperar contraseña
                                            </a>--%>
                                    </div>
                                </div>
                            </form>
                            <!-- END Sign In Form -->
                        </div>
                    </div>
                </div>
            </div>
            <!-- END Page Content -->
        </main>
        <!-- END Main Container -->
    </div>
    <!-- END Page Container -->

    <!-- Codebase Core JS -->
    <script src="../public/assets/js/core/jquery.min.js"></script>
    <%--<script src="../public/assets/js/core/popper.min.js"></script>
        <script src="../public/assets/js/core/bootstrap.min.js"></script>--%>
    <script src="../public/assets/js/core/jquery.slimscroll.min.js"></script>
    <script src="../public/assets/js/core/jquery.scrollLock.min.js"></script>
    <script src="../public/assets/js/core/jquery.appear.min.js"></script>
    <%--<script src="../public/assets/js/core/jquery.countTo.min.js"></script>--%>
    <%--<script src="../public/assets/js/core/js.cookie.min.js"></script>--%>
    <script src="../public/assets/js/codebase.js"></script>

    <!-- Page JS Plugins -->
    <%-- <script src="../public/assets/js/plugins/jquery-validation/jquery.validate.min.js"></script>--%>

    <!-- Page JS Code -->
    <%--<script src="../public/assets/js/pages/op_auth_signin.js"></script>--%>
</body>
</html>
