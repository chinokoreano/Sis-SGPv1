<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="SIS_CARLITOS.Vistas.frmLogin" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card container p-5 my-5" style="max-width: 100rem;" runat="server">

        <div class="card-body" style="background-color: white">
            <h3 class="card-title">Inicio de sesión</h3>
            <%--<h6 class="card-subtitle mb-2 text-muted">Información personal</h6>--%>
            <p class="card-text">Ingrese su correo electrónico y contraseña.</p>
            <div class="container py-5">
                <div id="informacion-personal">
                    <%--<div class="mb-4">
                        <h3>Inicio de sesión</h3>
                        <p class="mb-4">Ingrese su correo electrónico y contraseña.</p>
                    </div>--%>


                    <div class="form-group first">
                        <%--<label for="username">Correo electrónico</label>--%>
                        <%--<input type="text" class="form-control" id="username">--%>
                        <asp:TextBox ID="txtUsuario" placeholder="Correo electrónico" MaxLength="50" class="form-control" runat="server"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterMode="ValidChars" TargetControlID="txtUsuario" ValidChars="abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ0123456789_-@."></cc1:FilteredTextBoxExtender>
                    </div>
                    <div class="form-group last mb-3">
                        <%--<label for="password">Contraseña</label>--%>
                        <%--<input type="password" class="form-control" id="password">--%>
                        <asp:TextBox ID="txtContrasenia" placeholder="Contraseña" MaxLength="8" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterMode="ValidChars" TargetControlID="txtContrasenia" ValidChars="abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ0123456789_-@."></cc1:FilteredTextBoxExtender>
                    </div>

                    <div class="d-flex mb-5 align-items-center">
                        <label class="control control--checkbox mb-0">
                            <span class="caption">Recordarme</span>
                            <input type="checkbox" checked="checked" />
                            <div class="control__indicator"></div>
                        </label>
                        <span class="ml-auto"><a href="#" class="forgot-pass">Recuperar contraseña</a></span>

                    </div>
                    <asp:Label ID="Label1" class="text-danger" runat="server" Text="" Visible="false"></asp:Label>
                    <asp:LinkButton runat="server" ID="LinkButton1" class="btn btn-block btn-primary text-decoration-none text-white" Text="Iniciar sesión" />


                </div>
            </div>
        </div>
    </div>


</asp:Content>



