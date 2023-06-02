<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRegistrarPaquete.aspx.cs" Inherits="SIS_CARLITOS.Vistas.frmRegistrarPaquete" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="udp1" runat="server">
        <ContentTemplate>
            <div class="container">
                <section class="mt-4">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="card shadow-lg p-3">
                                <div class="card-body">
                                    <h3 class="text-center font-spe">Registrar Compras</h3>


                                    <div class="row">
                                        <div class="col-12 col-lg-6 mb-3">
                                            <label for="txtNumeroTracking" class="form-label">Número de Tracking</label>
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNombres" ValidationGroup="formulario_registro" 
                                                CssClass="text-danger" ErrorMessage="(obligatorio)" />
                                            <asp:TextBox ID="txtNombres" runat="server" CssClass="form-control capLock" autocomplete="off" 
                                                AutoCompleteType="Disabled" type="text" placeholder="Nombres"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" FilterMode="ValidChars" TargetControlID="txtNombres" ValidChars="abcdefghijklmnñopqrstuvwxyz ABCDEFGHIJKLMNÑOPQRSTUVWXYZ"></cc1:FilteredTextBoxExtender>
                                        </div>

                                        <div class="col-12 col-lg-6 mb-3">
                                            <label for="txtApellidos" class="form-label">Valor de compra</label>
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtApellidos" ValidationGroup="formulario_registro" 
                                                CssClass="text-danger" ErrorMessage="(obligatorio)" />
                                            <asp:TextBox ID="txtApellidos" runat="server" CssClass="form-control capLock" autocomplete="off" AutoCompleteType="Disabled" placeholder="Apellidos" type="text"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server" FilterMode="ValidChars" TargetControlID="txtApellidos" ValidChars="abcdefghijklmnñopqrstuvwxyz ABCDEFGHIJKLMNÑOPQRSTUVWXYZ"></cc1:FilteredTextBoxExtender>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-12 mb-3">
                                            <label for="txtCorreo" class="form-label">Correo electrónico</label>
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCorreo" ValidationGroup="correo" 
                                                CssClass="text-danger" ErrorMessage="(obligatorio)" />
                                            <div class="input-group">
                                                <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control text-lowercase txt_correo" type="email" ValidationGroup="correo"
                                                    data-bs-toggle="tooltip" data-bs-placement="top" title="Verifíca que tu correo este ingresado correctamente" placeholder="usr@dominio.com"></asp:TextBox>
                                                <asp:LinkButton ID="btn_solicitarCodigo" runat="server" CssClass="btn btn-primary" ValidationGroup="correo">
                                                    <i class="far fa-envelope me-2"></i>Solicitar código</asp:LinkButton>
                                            </div>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationGroup="correo"
                                                ControlToValidate="txtCorreo" runat="server" ErrorMessage="correo incorrecto Ejm: usr@dominio.com" CssClass="text-danger"
                                                ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"
                                                Display="Dynamic"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-12 mb-3">
                                            <asp:Label runat="server" ID="lbl_codigo" class="form-label">Código de verificación</asp:Label>
                                            <div class="input-group mb-3">
                                                <asp:TextBox ID="txt_codigo" runat="server" CssClass="form-control text-lowercase text-center" type="tel" ValidationGroup="codigo" placeholder="Revisa tu correo" MaxLength="4"
                                                    data-bs-toggle="tooltip" data-bs-placement="top" title="Ingresa el código que se envió a tu correo para continuar" aria-describedby="txt_codigo"></asp:TextBox>
                                                <asp:LinkButton ID="btn_validarCodigo" runat="server" CssClass="btn btn-outline-success" ValidationGroup="correo" Visible="false"><i class="fas fa-check me-2"></i>Verificar código</asp:LinkButton>
                                            </div>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterMode="ValidChars" TargetControlID="txt_codigo" ValidChars="1234567890"></cc1:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-12 col-lg-6 mb-3">
                                            <label for="cmbLocalidad" class="form-label">Ciudad</label>
                                            <dx:ASPxComboBox ID="cmbLocalidad" runat="server" CssClass="form-control dropdown form-control-sm"
                                                Width="100%" NullValueItemDisplayText="{0} ({1})" NullText="Locación"
                                                NullTextDisplayMode="UnfocusedAndFocused" ToolTip="Punto de Origen"
                                                OnSelectedIndexChanged="cmbLocalidad_SelectedIndexChanged">
                                            </dx:ASPxComboBox>
                                        </div>

                                        <div class="col-12 col-lg-6 mb-3">
                                            <label for="txtDireccion1" class="form-label">Dirección</label>
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDireccion1" 
                                                ValidationGroup="formulario_registro" CssClass="text-danger" ErrorMessage="(obligatorio)" />
                                            <asp:TextBox ID="txtDireccion1" runat="server" CssClass="form-control capLock" placeholder="Dirección" 
                                                autocomplete="off" AutoCompleteType="Disabled" type="text"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterMode="ValidChars" TargetControlID="txtDireccion1" ValidChars="abcdefghijklmnñopqrstuvwxyz ABCDEFGHIJKLMNÑOPQRSTUVWXYZ 1234567890 -"></cc1:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-12 col-lg-6 mb-3">
                                            <label for="txtReferencia" class="form-label">Referencia</label>
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtReferencia" 
                                                ValidationGroup="formulario_registro" CssClass="text-danger" ErrorMessage="(obligatorio)" />
                                            <asp:TextBox ID="txtReferencia" runat="server" CssClass="form-control capLock" placeholder="Referencia" 
                                                autocomplete="off" AutoCompleteType="Disabled" type="text"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" FilterMode="ValidChars" TargetControlID="txtReferencia" ValidChars="abcdefghijklmnñopqrstuvwxyz ABCDEFGHIJKLMNÑOPQRSTUVWXYZ 1234567890 -"></cc1:FilteredTextBoxExtender>
                                        </div>

                                        <div class="col-12 col-lg-6 mb-3">
                                            <label for="txtTelefono" class="form-label">Teléfono</label>
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtTelefono" ValidationGroup="formulario_registro" CssClass="text-danger" ErrorMessage="(obligatorio)" />
                                            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" placeholder="Teléfono" autocomplete="off" AutoCompleteType="Disabled" type="text"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" FilterMode="ValidChars" TargetControlID="txtTelefono" ValidChars="1234567890 "></cc1:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-12 col-lg-6 mb-3">
                                            <asp:Label runat="server" ID="lbl_contrasena" Text="" Visible="true">Contraseña</asp:Label>
                                            <img src="/Content/Assets/Ico/Caps_Lock-512.png" class="d-24x24 me-1 d-none capLockIndicator" />
                                            <asp:TextBox ID="txtContrasenia" runat="server" CssClass="form-control capLock" TextMode="Password"
                                                oncopy="return false" onpaste="return false" oncut="return false" Visible="true"
                                                autocomplete="off"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                                                ControlToValidate="txtContrasenia" runat="server" ErrorMessage="Debe contener al menos una letra mayúscula,  minúsculas y un número. Longitud de 6 a 20 caracteres" ValidationGroup="formulario_registro"
                                                CssClass="text-danger" ValidationExpression="^.*(?=.{6})(?=.*[\d])(?=.*[A-Z])(?=.*[a-z]).*$" Display="Dynamic"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtContrasenia" ValidationGroup="formulario_registro"
                                                CssClass="text-danger position-absolute" ErrorMessage="(obligatorio)" />
                                        </div>

                                        <div class="col-12 col-lg-6 mb-3">
                                            <asp:Label runat="server" ID="lbl_confirmar" Text="Confirmar contraseña" Visible="true"></asp:Label><img src="/Content/Assets/Ico/Caps_Lock-512.png" class="d-24x24 me-1 d-none capLockIndicator" />
                                            <asp:TextBox ID="txtConfirmarContrasenia" runat="server" CssClass="form-control capLock" TextMode="Password"
                                                oncopy="return false" onpaste="return false" oncut="return false" Visible="true"
                                                autocomplete="off"></asp:TextBox>
                                            <asp:CompareValidator runat="server" ControlToCompare="txtContrasenia" ControlToValidate="txtConfirmarContrasenia"
                                                ValidationGroup="formulario_registro"
                                                CssClass="text-danger" Display="Dynamic" ErrorMessage="Las contraseñas no coinciden" />
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtConfirmarContrasenia" ValidationGroup="formulario_registro"
                                                CssClass="text-danger position-absolute" ErrorMessage="(Debes confirmar la contraseña)" />
                                        </div>
                                    </div>

                                    <div class="col-12 mb-3">
                                        <asp:Button ID="btnGrabar" runat="server" class="btn btn-primary text-decoration-none text-white" 
                                            Text="Guardar" OnClick="btnGrabar_Click" ValidationGroup="formulario_registro"/>
                                    </div>
                                </div>
                            </div>

                        </div>

                    </div>
            </div>
            </section>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="udp1">
        <ProgressTemplate>
            <div id="Background"></div>
            <div id="Loader"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
