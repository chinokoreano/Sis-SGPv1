<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmConsultaReporteGestiones.aspx.cs" Inherits="SIS_CARLITOS.Vistas.frmConsultaReporteGestiones" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>



<%@ Register Assembly="DevExpress.Web.v22.2, Version=22.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">

        <ContentTemplate>
            <div class="card border-dark" style="max-width: 100rem;">
                <div class="card-header ph-card-header">Re - Impresión de Manifiestos y Listado de Gestiones</div>
                <div class="card-body" style="background-color: white">
                    <div class="table-responsive">
                        <dx:ASPxFileManager ID="ASPxFileManager1" runat="server" >
                            <Settings RootFolder="~/RepositorioReportes/" ThumbnailFolder="~/Thumb/" />

                            <SettingsFileList View="Details">
                                <DetailsViewSettings AllowColumnResize="true" AllowColumnDragDrop="true"
                                    AllowColumnSort="true" ShowHeaderFilterButton="false" />
                            </SettingsFileList>


                            <SettingsEditing AllowDownload="True" />


                            <SettingsUpload Enabled="False">
                                <AdvancedModeSettings EnableMultiSelect="True">
                                </AdvancedModeSettings>
                            </SettingsUpload>
                        </dx:ASPxFileManager>
                    </div>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
