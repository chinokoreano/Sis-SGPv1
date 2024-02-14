<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmEntrega.aspx.cs" Inherits="SIS_CARLITOS.Vistas.frmEntrega" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v22.2, Version=22.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="DevExpress.Web.v22.2, Version=22.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        .allUpper input {
            text-transform: uppercase;
        }
    </style>


</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <%--<h3>Registro de Gestiones</h3>--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" DefaultBotton="btnBuscar">
        <ContentTemplate>
            <div class="card border-dark" style="max-width: 100rem;">
                <div class="card-header ph-card-header">Registro de Entrega</div>
                <div class="card-body" style="background-color: white">
                    <form>

                        <div class="form-group row">
                            <div class="col-sm-10">

                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" FilterMode="ValidChars" TargetControlID="txtCodigoEnvio1" ValidChars="abcdefghijklmnñopqrstuvwxyz ABCDEFGHIJKLMNÑOPQRSTUVWXYZ 0123456789"></cc1:FilteredTextBoxExtender>
                                <asp:TextBox ID="txtCodigoEnvio1" runat="server" placeholder="Código de envío" MaxLength="30" CssClass="form-control form-control-sm" TextMode="SingleLine"></asp:TextBox>
                            </div>
                            <div class="col-sm-2" style="padding-bottom: 5px;">
                                
                                <asp:Button ID="btnBuscar" runat="server" Text="..."  CssClass="btn btn-warning" OnClick="btnBuscar_Click"/>

                            </div>
                          
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-10">

                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterMode="ValidChars" TargetControlID="txtRecibidoPor" ValidChars="abcdefghijklmnñopqrstuvwxyz ABCDEFGHIJKLMNÑOPQRSTUVWXYZ 0123456789"></cc1:FilteredTextBoxExtender>
                                <asp:TextBox ID="txtRecibidoPor" runat="server" placeholder="Recibido por" MaxLength="200" CssClass="form-control form-control-sm" TextMode="SingleLine"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-10">

                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" FilterMode="ValidChars" TargetControlID="txtIdentificacionReceptor" ValidChars="abcdefghijklmnñopqrstuvwxyz ABCDEFGHIJKLMNÑOPQRSTUVWXYZ 0123456789"></cc1:FilteredTextBoxExtender>
                                <asp:TextBox ID="txtIdentificacionReceptor" runat="server" placeholder="Identificación" MaxLength="20" CssClass="form-control form-control-sm" TextMode="SingleLine"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-2">

                                <dx:ASPxTextBox ID="txtFechaEntrega1" placeholder="DD-MM-AAAA" CssClass="form-control form-control-sm" runat="server" Width="170px">
                                    <MaskSettings Mask="00-00-0000" />
                                </dx:ASPxTextBox>
                            </div>
                            <div class="col-sm-2">

                                <dx:ASPxTextBox ID="txtHoraEntrega1" runat="server" placeholder="HH:MM" CssClass="form-control form-control-sm" Width="170px">
                                    <MaskSettings Mask="00:00" />
                                </dx:ASPxTextBox>
                            </div>
                        </div>

                        <div class="form-group row">
                            <div class="col-sm-10">

                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" FilterMode="ValidChars" TargetControlID="txtObservacion" ValidChars="abcdefghijklmnñopqrstuvwxyz ABCDEFGHIJKLMNÑOPQRSTUVWXYZ 0123456789"></cc1:FilteredTextBoxExtender>
                                <asp:TextBox ID="txtObservacion" runat="server" placeholder="Observación" MaxLength="200" CssClass="form-control form-control-sm" TextMode="SingleLine"></asp:TextBox>
                            </div>
                        </div>
                      
                        <div class="form-group row">
                            <div class="col-sm-4">
                                <asp:CheckBox ID="chk" runat="server" CssClass="form-control-sm" Text="&nbsp;Direccion efectiva" TextAlign="Right" Font="" AutoPostBack="True" OnCheckedChanged="chk_CheckedChanged" />
                            </div>
                            <div class="col-sm-6" style="padding-bottom: 5px;">
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" FilterMode="ValidChars" TargetControlID="txtDireccionActualizada" ValidChars="abcdefghijklmnñopqrstuvwxyz ABCDEFGHIJKLMNÑOPQRSTUVWXYZ 0123456789"></cc1:FilteredTextBoxExtender>
                                <asp:TextBox ID="txtDireccionActualizada" Visible="false" runat="server" placeholder="Dirección efectiva de entrega" MaxLength="200" CssClass="form-control form-control-sm" TextMode="SingleLine"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-sm-2" style="padding-bottom: 5px;">
                                <asp:LinkButton ID="btnGrabar" runat="server" visible="false" class="btn btn-warning" OnClientClick="mostrar_procesar();" CssClass="btn btn-warning" OnClick="btnGrabar_Click" >Grabar</asp:LinkButton>
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


</asp:Content>
