<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmConsultaEnvios.aspx.cs" Inherits="SIS_CARLITOS.Vistas.frmConsultaEnvios" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>



<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="card border-dark" style="max-width: 100rem;">
                <div class="card-header ph-card-header">Consulta de eventos</div>
                <div class="card-body" style="background-color: white">
                    <asp:Label ID="lblMensaje" class="btn btn-success" runat="server" Visible="false" Text="" Style="margin-bottom: 10px;"></asp:Label>
                    <dx:ASPxButton ID="btnExportar1" runat="server" Text="Exportar a Excel" OnClick="btnExportar1_Click"></dx:ASPxButton>
                    <dx:ASPxGridView ID="ASPxGridView1" runat="server" DataSourceID="ds" AutoGenerateColumns="False" EnableTheming="True" Theme="PlasticBlue" Width="100%" KeyFieldName="identificador">
                        <SettingsDetail ShowDetailRow="True" />
                        <Settings ShowFilterRow="True" ShowFilterRowMenuLikeItem="True" ShowFooter="True" VerticalScrollableHeight="300" VerticalScrollBarMode="Visible" ShowGroupPanel="True"></Settings>
                        <SettingsDataSecurity AllowEdit="False" AllowInsert="False" AllowDelete="False"></SettingsDataSecurity>

                        <SettingsSearchPanel Visible="True"></SettingsSearchPanel>
                        <Columns>
                            <dx:GridViewDataTextColumn FieldName="orden" ReadOnly="True" VisibleIndex="0" Caption="No."></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="identificador" ReadOnly="True" VisibleIndex="1" Visible="false"></dx:GridViewDataTextColumn>

                            <dx:GridViewDataTextColumn FieldName="codigo" VisibleIndex="2" Caption="Cód.Paquete"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="codigo_alterno" VisibleIndex="3" Caption="Cód.Alterno"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataDateColumn FieldName="fecha_evento_carga" VisibleIndex="4" Caption="Fec. Carga"></dx:GridViewDataDateColumn>
                            <dx:GridViewDataDateColumn FieldName="fecha_ultimo_evento" VisibleIndex="5" Caption="Fec. Ultimo Evento"></dx:GridViewDataDateColumn>
                            <dx:GridViewDataTextColumn FieldName="destinatario" VisibleIndex="6" Caption="Destinatario"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="direccion" ReadOnly="True" VisibleIndex="7" Caption="Dirección"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="referencia" VisibleIndex="8" Caption="Referencia"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="provincia" ReadOnly="True" VisibleIndex="9" Caption="Provicia"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="canton" ReadOnly="True" VisibleIndex="10" Caption="Cantón"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="codigo_postal" VisibleIndex="11" Caption="Cód.Postal"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="ultima_gestion" VisibleIndex="12" Caption="Ultima Gestión"></dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="oficina" ReadOnly="True" VisibleIndex="13" Caption="Oficina"></dx:GridViewDataTextColumn>
                        </Columns>
                        <Templates>
                            <DetailRow>
                                Historial de eventos:
                <dx:ASPxLabel runat="server" Font-Bold="true" />
                                
                                <br />
                                <br />
                                <dx:ASPxGridView ID="detailGrid" runat="server" DataSourceID="dsEventos" KeyFieldName="identificador"
                                    Width="100%" EnablePagingGestures="False" OnBeforePerformDataSelect="detailGrid_DataSelect" Theme="PlasticBlue">
                                    <Columns>
                                        <dx:GridViewDataColumn FieldName="orden" Caption="No." VisibleIndex="1" />
                                        <dx:GridViewDataColumn FieldName="gestion" Caption="Gestión" VisibleIndex="2" />
                                        <dx:GridViewDataColumn FieldName="oficina" Caption="Oficina" VisibleIndex="3" />
                                        <dx:GridViewDataColumn FieldName="fecha_registro" Caption="Fecha registro" VisibleIndex="4" Name="fecha_registro" />
                                        <dx:GridViewDataColumn FieldName="observacion" Caption="Observacion" VisibleIndex="5" />
                                        <dx:GridViewDataColumn FieldName="usuario" Caption="Usuario" VisibleIndex="6" />
                                    </Columns>
                                    <Settings ShowFooter="True" />
                                    <SettingsPager EnableAdaptivity="true" />
                                    <Styles Header-Wrap="True" />

                                </dx:ASPxGridView>
                            </DetailRow>
                        </Templates>

                    </dx:ASPxGridView>

                    <asp:SqlDataSource runat="server" ID="dsEventos" ConnectionString='<%$ ConnectionStrings:conDev %>' ProviderName='<%$ ConnectionStrings:conDev.ProviderName %>' SelectCommand="SPR_CONSULTA_EVENTOS" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="1" Name="OPCION" Type="Int32"></asp:Parameter>
                            <asp:SessionParameter SessionField="identificador" DbType="Guid" DefaultValue="" Name="IDENTIFICADOR_PAQUETE" ></asp:SessionParameter>
                        </SelectParameters>
                    </asp:SqlDataSource>
                    
                    <asp:SqlDataSource runat="server" ID="ds" ConnectionString='<%$ ConnectionStrings:conDev %>' ProviderName='<%$ ConnectionStrings:conDev.ProviderName %>' SelectCommand="SPR_CONSULTA_ENVIO" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="1" Name="OPCION" Type="Int32"></asp:Parameter>
                            <asp:Parameter DefaultValue="NULL" Name="@CODIGO_ENVIO" Type="String"></asp:Parameter>
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="ASPxGridView1" ExportSelectedRowsOnly="True">
                    </dx:ASPxGridViewExporter>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
