<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCambioContrasena.aspx.cs" Inherits="SIS_CARLITOS.Vistas.frmCambioContrasena" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v22.2, Version=22.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v22.2, Version=22.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
   


</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" DefaultBotton="btnGrabar">
        <ContentTemplate>
            <div class="card border-dark" style="max-width: 100rem;">
                <div class="card-header ph-card-header">Cambio de contraseña</div>
                <div class="card-body" style="background-color: white">
                    <form>
                        <div class="form-group row">
                            <div class="col-12">
                                <div class="form-material floating">
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterMode="ValidChars" TargetControlID="txtContrasenia" ValidChars="abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ0123456789/*-+!@$()"></cc1:FilteredTextBoxExtender>
                                    <asp:TextBox ID="txtContrasenia" Visible="true" MaxLength="8" placeholder="Contraseña actual" onkeypress="hideOnKeyPress(); return true;" class="form-control" runat="server" TextMode="Password" ToolTip="Max. 8 carácteres y debe contener letras números y algunos de estos carácteres especiales /*-+!@$()"></asp:TextBox>
                                   
                                </div>
                            </div>
                        </div>

                        <div class="form-group row">
                            <div class="col-12">
                                <div class="form-material floating">
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterMode="ValidChars" TargetControlID="txtContraseniaNueva" ValidChars="abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ0123456789/*-+!@$()"></cc1:FilteredTextBoxExtender>
                                    <asp:TextBox ID="txtContraseniaNueva" Visible="true" MaxLength="8" onkeypress="hideOnKeyPress(); return true;" placeholder="Nueva contraseña" class="form-control" runat="server" TextMode="Password" ToolTip="Max. 8 carácteres y debe contener letras números y algunos de estos carácteres especiales /*-+!@$()"></asp:TextBox>
                                   
                                </div>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-12">
                                <div class="form-material floating">
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterMode="ValidChars" TargetControlID="txtConfirmarContrasenia" ValidChars="abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ0123456789/*-+!@$()"></cc1:FilteredTextBoxExtender>
                                    <asp:TextBox ID="txtConfirmarContrasenia" Visible="true" MaxLength="8" onkeypress="hideOnKeyPress(); return true;" placeholder="Confirmar nueva contraseña" class="form-control" runat="server" TextMode="Password" ToolTip="Max. 8 carácteres y debe contener letras números y algunos de estos carácteres especiales /*-+!@$()"></asp:TextBox>
                                  
                                </div>
                            </div>
                        </div>
                        

                        <div class="row">
                            <div class="col-sm-2" style="padding-bottom: 5px;">
                                <asp:LinkButton ID="btnCambiarContrasenia" runat="server" Visible="true" class="btn btn-warning"  OnClick="btnCambiarContrasenia_Click">Guardar</asp:LinkButton>
                            </div>
                            <div class="col-sm-6" style="padding-bottom: 5px;">
                                <asp:Label ID="lblMensaje" runat="server" Visible="true" Text="" Style="margin-bottom: 10px;"></asp:Label>

                            </div>
                        </div>

                    </form>
                </div>
            </div>

       
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">               
        function hideOnKeyPress() {
            document.getElementById("<%=lblMensaje.ClientID%>").style.visibility = "hidden";
        }
    
    </script>

</asp:Content>
