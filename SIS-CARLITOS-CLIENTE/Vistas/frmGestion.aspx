<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmGestion.aspx.cs" Inherits="SIS_CARLITOS.Vistas.frmGestion" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v22.2, Version=22.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="DevExpress.Web.v22.2, Version=22.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function mostrar_procesar() {
            document.getElementById('procesando_div').style.display = "";
            setTimeout('document.images["procesando_gif"].src="../Imagenes/ajax-loader.gif"', 200);
        }
    </script>

</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <%--<h3>Registro de Gestiones</h3>--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" DefaultButton="btnGrabar1">
        <ContentTemplate>
            <div class="card border-dark" style="max-width: 100rem;">
                <div class="card-header ph-card-header">Registro de Gestiones</div>
                <div class="card-body" style="background-color: white">
                    <form>
                        <div class="form-group row">
                            <div class="col-sm-10">

                                <dx:ASPxComboBox ID="cmbGestion" runat="server" CssClass="form-control dropdown form-control-sm" Width="100%" NullValueItemDisplayText="{0} ({1})" NullText="Gestión" NullTextDisplayMode="UnfocusedAndFocused" ToolTip="Gestión" AutoPostBack="True" OnSelectedIndexChanged="cmbGestion_SelectedIndexChanged">
                                </dx:ASPxComboBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <div class="col-sm-10">

                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" FilterMode="ValidChars" TargetControlID="txtCodigoEnvio1" ValidChars="abcdefghijklmnñopqrstuvwxyz ABCDEFGHIJKLMNÑOPQRSTUVWXYZ 0123456789"></cc1:FilteredTextBoxExtender>
                                <asp:TextBox ID="txtCodigoEnvio1" runat="server" placeholder="Código de envío" MaxLength="30" CssClass="form-control form-control-sm" TextMode="SingleLine"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-10">

                                <asp:TextBox ID="txtObservacion1" runat="server" placeholder="Observación" MaxLength="30" CssClass="form-control form-control-sm" TextMode="SingleLine"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-sm-2" style="padding-bottom: 5px;">

                                <asp:Button ID="btnGrabar1" runat="server" class="btn btn-warning" OnClientClick="mostrar_procesar();" Text="Grabar" OnClick="btnGrabar1_Click" />
                            </div>
                            <div class="col-sm-6" style="padding-bottom: 5px;">
                                <asp:Label ID="lblMensaje" runat="server" Visible="true" Text="" Style="margin-bottom: 10px;"></asp:Label>

                            </div>
                             <div class="col-sm-6" style="padding-bottom: 5px;">
                                <asp:HyperLink ID="urlReporte" CssClass="btn btn-success" runat="server" Visible="false" Target="_blank">Desargar listado generado</asp:HyperLink>
                            </div>
                        </div>


                    </form>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div class="card border-dark" style="max-width: 100rem;" runat="server" id="divListadoEnvios" visible="false">
                <div class="card-header ph-card-header">Listado de envíos</div>
                <div class="card-body" style="background-color: white">
                    <form>

                        <div class="row">
                            <div class="col-sm-3" style="padding-bottom: 5px;">

                                <asp:ListBox ID="ddlListado" runat="server" CssClass="form-control dropdown h2" Height="200px" Width="200px"></asp:ListBox>

                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-3" style="padding-bottom: 5px;">
                                <asp:Label ID="lblTotalEnvios" runat="server" Text="" Visible="false"></asp:Label>
                            </div>
                            <div class="col-sm-3" style="padding-bottom: 5px;">
                                <asp:Button ID="btnImprimirListado" class="btn btn-warning" Visible="false" OnClientClick="mostrar_procesar();" runat="server" Text="Imprimir" OnClick="btnImprimirListado_Click" />
                                <span id="procesando_div" style="display: none; position: absolute; text-align: center">
                            <img src="../Imagenes/ajax-loader.gif" id="procesando" alt="" />
                        </span>
                            </div>
                           
                        </div>
                    </form>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
