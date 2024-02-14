<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmManifiestoCartero.aspx.cs" Inherits="SIS_CARLITOS.Vistas.frmManifiestoCartero" %>

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
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" DefaultButton="btnAgregar1">
    <%--<h3>Manifiesto de Cartero</h3>--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="card border-dark" style="max-width: 100rem;" runat="server" id="divBuscar">
                <div class="card-header ph-card-header">Manifiesto de Cartero: Asignación</div>
                <div class="card-body" style="background-color: white">

                    <div class="row">
                        <div class="col-sm-3" style="padding-bottom: 5px;">
                            <dx:ASPxComboBox ID="cmbCartero" runat="server" CssClass="form-control dropdown form-control-sm" Width="100%" NullValueItemDisplayText="{0} ({1})" NullText="Cartero" NullTextDisplayMode="UnfocusedAndFocused" ToolTip="Cartero" AutoPostBack="True" OnSelectedIndexChanged="cmbCartero_SelectedIndexChanged">
                            </dx:ASPxComboBox>
                        </div>
                        <div class="col-sm-3" style="padding-bottom: 5px;">

                            <asp:TextBox ID="txtCodigoEnvio1" runat="server" class="form-control form-control-sm" placeholder="Código de envío" MaxLength="30"></asp:TextBox>


                        </div>
                        <div class="col-sm-2" style="padding-bottom: 5px;">
                            <asp:Button ID="btnAgregar1" runat="server" Text="Agregar" class="btn btn-warning" OnClientClick="mostrar_procesar();" OnClick="btnAgregar1_Click" />
                        </div>
                        <div class="col-sm-4" style="padding-bottom: 5px;">
                            <asp:Label ID="lblMensaje" class="btn btn-info" runat="server" Visible="false" Text="" Style="margin-bottom: 10px;"></asp:Label>
                        </div>

                         <div id="divReporte" visible="false" runat="server">                     
                            <div class="col-sm-6">
                                <asp:Label ID="lblMensaje1" runat="server" Text=""></asp:Label>
                                <asp:HyperLink ID="urlReporte" CssClass="btn btn-success" runat="server" Visible="false" Target="_blank">Desargar manifiesto generado</asp:HyperLink>
                            </div>                       
                        </div>

                    </div>
                </div>
            </div>

            <%--<div class="panel panel-default" runat="server" id="divListadoPaquetes">
                <div class="panel-heading"><strong>Listado de Paquetes</strong></div>
                <div class="panel-body">--%>
            <br />

            <div id="divListadoPaquetes" runat="server" visible="false" class="card border-dark" style="max-width: 100rem;">
                <div class="card-header ph-card-header">
                    Listado de envíos
                </div>
                <div class="card-body" style="background-color: white">
                    <div class="row">
                        <div class="col-sm-3" style="padding-bottom: 5px;">

                            <asp:ListBox ID="ddlListado" runat="server" CssClass="form-control dropdown h2" Height="200px" Width="200px"></asp:ListBox>

                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-3" style="padding-bottom: 5px;">
                            <asp:Label ID="lblTotalEnvios" runat="server" Text="" Visible="false"></asp:Label>
                        </div>
                    </div>
                    <div id="divGrabar" visible="false" runat="server">
                        <div class="row">
                            <div class="col-sm-2">
                                <asp:LinkButton ID="btnGrabar" runat="server" CssClass="btn btn-warning" OnClick="btnGrabar_Click" OnClientClick="mostrar_procesar();" Text="Grabar"></asp:LinkButton>

                                <span id="procesando_div" style="display: none; position: absolute; text-align: center">
                                    <img src="../Imagenes/ajax-loader.gif" id="procesando" alt="" />
                                </span>
                            </div>
                        </div>
                      </div>
                   

                </div>
            </div>
            <br />





        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
