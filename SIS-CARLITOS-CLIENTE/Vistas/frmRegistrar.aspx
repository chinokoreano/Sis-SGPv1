<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRegistrar.aspx.cs" Inherits="SIS_CARLITOS.Vistas.frmRegistrar" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card container p-5 my-5" style="max-width: 100rem;" runat="server">

        <div class="card-body" style="background-color: white">
            <h3 class="card-title">Registrarse</h3>
            <h6 class="card-subtitle mb-2 text-muted">Información personal</h6>
            <p class="card-text">Por favor registre los datos a continuación.</p>
            <div class="container py-5">
                <div id="informacion-personal">
                    <div class="row justify-content-center">
                        <!--Doble columna!-->
                        <div class="col-12 col-md-12">
                            <div class="form-group first">
                                <div class="col-sm-10">
                                    <dx:ASPxComboBox ID="cmbTipoDocumento" runat="server"  CssClass="form-control dropdown form-control-sm"  Theme="PlasticBlue" DataSourceID="dsTipoDocumento" TextField="nm" ValueField="id" ValueType="System.Int32">
                                        
                                    </dx:ASPxComboBox>
                                    <asp:SqlDataSource ID="dsTipoDocumento" runat="server" ConnectionString="<%$ ConnectionStrings:OPERADB_DAO %>" SelectCommand="SELECT [id], [nm] FROM [tipo_documento]"></asp:SqlDataSource>
                                </div>
                            </div>
                            <div class="form-group first">
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtDocumentoIdentificacion" runat="server" placeholder="Cédula/RUC/Pasaporte" MaxLength="30" CssClass="form-control form-control-sm" TextMode="SingleLine"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" FilterMode="ValidChars" TargetControlID="txtDocumentoIdentificacion" ValidChars="abcdefghijklmnñopqrstuvwxyz ABCDEFGHIJKLMNÑOPQRSTUVWXYZ 0123456789"></cc1:FilteredTextBoxExtender>
                                </div>
                            </div>
                            <div class="form-group first">
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtNombres" runat="server" placeholder="Nombres" MaxLength="30" CssClass="form-control form-control-sm" TextMode="SingleLine"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" FilterMode="ValidChars" TargetControlID="txtNombres" ValidChars="abcdefghijklmnñopqrstuvwxyz ABCDEFGHIJKLMNÑOPQRSTUVWXYZ 0123456789"></cc1:FilteredTextBoxExtender>
                                </div>
                            </div>
                            <div class="form-group first">
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtApellidos" runat="server" placeholder="Apellidos" MaxLength="30" CssClass="form-control form-control-sm" TextMode="SingleLine"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterMode="ValidChars" TargetControlID="txtApellidos" ValidChars="abcdefghijklmnñopqrstuvwxyz ABCDEFGHIJKLMNÑOPQRSTUVWXYZ 0123456789"></cc1:FilteredTextBoxExtender>
                                </div>
                            </div>
                            <div class="form-group first">
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtCorreo" runat="server" placeholder="Correo electrónico" MaxLength="30" CssClass="form-control form-control-sm" TextMode="SingleLine"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterMode="ValidChars" TargetControlID="txtCorreo" ValidChars="abcdefghijklmnñopqrstuvwxyz ABCDEFGHIJKLMNÑOPQRSTUVWXYZ 0123456789"></cc1:FilteredTextBoxExtender>
                                </div>
                            </div>
                            <div class="form-group first">
                                <div class="col-sm-10">
                                    <dx:ASPxComboBox ID="cmbLocalidad" runat="server" CssClass="form-control dropdown form-control-sm" 
                                        Width="100%" NullValueItemDisplayText="{0} ({1})" NullText="Punto de Carga o Retiro" 
                                        NullTextDisplayMode="UnfocusedAndFocused" ToolTip="Punto de Origen" 
                                        OnSelectedIndexChanged="cmbLocalidad_SelectedIndexChanged">
                                    </dx:ASPxComboBox>
                                </div>

                            </div>

                            <div class="form-group first">
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtDireccion1" runat="server" placeholder="Dirección" MaxLength="30" CssClass="form-control form-control-sm" TextMode="SingleLine"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" FilterMode="ValidChars" TargetControlID="txtDireccion1" ValidChars="abcdefghijklmnñopqrstuvwxyz ABCDEFGHIJKLMNÑOPQRSTUVWXYZ 0123456789"></cc1:FilteredTextBoxExtender>
                                </div>
                            </div>
                            <div class="form-group first">
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtReferencia" runat="server" placeholder="Referencia" MaxLength="30" CssClass="form-control form-control-sm" TextMode="SingleLine"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" FilterMode="ValidChars" TargetControlID="txtReferencia" ValidChars="abcdefghijklmnñopqrstuvwxyz ABCDEFGHIJKLMNÑOPQRSTUVWXYZ 0123456789"></cc1:FilteredTextBoxExtender>
                                </div>
                            </div>
                            <div class="form-group first">
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtTelefono" runat="server" placeholder="Teléfono" MaxLength="30" CssClass="form-control form-control-sm" TextMode="SingleLine"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" FilterMode="ValidChars" TargetControlID="txtTelefono" ValidChars="abcdefghijklmnñopqrstuvwxyz ABCDEFGHIJKLMNÑOPQRSTUVWXYZ 0123456789"></cc1:FilteredTextBoxExtender>
                                </div>
                            </div>
                            <div class="form-group first">
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtContrasenia" runat="server" placeholder="Contraseña" MaxLength="30" CssClass="form-control form-control-sm" TextMode="SingleLine"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterMode="ValidChars" TargetControlID="txtContrasenia" ValidChars="abcdefghijklmnñopqrstuvwxyz ABCDEFGHIJKLMNÑOPQRSTUVWXYZ 0123456789"></cc1:FilteredTextBoxExtender>
                                </div>
                            </div>
                            <div class="form-group last mb-3">
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtConfirmarContrasenia" runat="server" placeholder="Confirmar Contraseña" MaxLength="30" CssClass="form-control form-control-sm" TextMode="SingleLine"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" FilterMode="ValidChars" TargetControlID="txtConfirmarContrasenia" ValidChars="abcdefghijklmnñopqrstuvwxyz ABCDEFGHIJKLMNÑOPQRSTUVWXYZ 0123456789"></cc1:FilteredTextBoxExtender>
                                </div>
                            </div>
                             <div class="form-group first">
                                <div class="col-sm-10">
                                    <asp:Button ID="btnGrabar" runat="server" class="btn btn-primary text-decoration-none text-white" OnClientClick="mostrar_procesar();" Text="Guardar" OnClick="btnGrabar_Click" />
                                </div>
                            </div>
                        </div>

                       <%-- <div class="col-12 col-md-6">


                            
                            <div class="form-group first">
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txt" runat="server" placeholder="Telefono" MaxLength="30" CssClass="form-control form-control-sm" TextMode="SingleLine"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" FilterMode="ValidChars" TargetControlID="txt" ValidChars="abcdefghijklmnñopqrstuvwxyz ABCDEFGHIJKLMNÑOPQRSTUVWXYZ 0123456789"></cc1:FilteredTextBoxExtender>
                                </div>
                            </div>
                            <div class="form-group first">
                                <div class="col-sm-10">
                                    <asp:TextBox ID="TextBox3" runat="server" placeholder="Apellidos" MaxLength="30" CssClass="form-control form-control-sm" TextMode="SingleLine"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server" FilterMode="ValidChars" TargetControlID="txtApellidos" ValidChars="abcdefghijklmnñopqrstuvwxyz ABCDEFGHIJKLMNÑOPQRSTUVWXYZ 0123456789"></cc1:FilteredTextBoxExtender>
                                </div>
                            </div>
                            <div class="form-group first">
                                <div class="col-sm-10">
                                    <asp:TextBox ID="TextBox4" runat="server" placeholder="Correo electrónico" MaxLength="30" CssClass="form-control form-control-sm" TextMode="SingleLine"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server" FilterMode="ValidChars" TargetControlID="txtCorreo" ValidChars="abcdefghijklmnñopqrstuvwxyz ABCDEFGHIJKLMNÑOPQRSTUVWXYZ 0123456789"></cc1:FilteredTextBoxExtender>
                                </div>
                            </div>
                            <div class="form-group first">
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtDireccionCliente" runat="server" placeholder="Dirección" MaxLength="30" CssClass="form-control form-control-sm" TextMode="SingleLine"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" runat="server" FilterMode="ValidChars" TargetControlID="txtDireccionCliente" ValidChars="abcdefghijklmnñopqrstuvwxyz ABCDEFGHIJKLMNÑOPQRSTUVWXYZ 0123456789"></cc1:FilteredTextBoxExtender>
                                </div>
                            </div>
                            <div class="form-group first">
                                <div class="col-sm-10">
                                    <asp:TextBox ID="TextBox6" runat="server" placeholder="Contraseña" MaxLength="30" CssClass="form-control form-control-sm" TextMode="SingleLine"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" runat="server" FilterMode="ValidChars" TargetControlID="txtContrasenia" ValidChars="abcdefghijklmnñopqrstuvwxyz ABCDEFGHIJKLMNÑOPQRSTUVWXYZ 0123456789"></cc1:FilteredTextBoxExtender>
                                </div>
                            </div>
                            <div class="form-group last mb-3">
                                <div class="col-sm-10">
                                    <asp:TextBox ID="TextBox7" runat="server" placeholder="Confirmar Contraseña" MaxLength="30" CssClass="form-control form-control-sm" TextMode="SingleLine"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender14" runat="server" FilterMode="ValidChars" TargetControlID="txtConfirmarContrasenia" ValidChars="abcdefghijklmnñopqrstuvwxyz ABCDEFGHIJKLMNÑOPQRSTUVWXYZ 0123456789"></cc1:FilteredTextBoxExtender>
                                </div>
                            </div>
                           
                        </div>--%>

                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
