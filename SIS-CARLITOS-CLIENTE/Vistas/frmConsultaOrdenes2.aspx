<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmConsultaOrdenes2.aspx.cs" Inherits="SIS_CARLITOS.Vistas.frmConsultaOrdenes2" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>



<%@ Register Assembly="DevExpress.Web.v22.2, Version=22.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register TagPrefix="dx" Namespace="DevExpress.Data.Linq" Assembly="DevExpress.Web.v22.2, Version=22.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function mostrar_procesar() {
            document.getElementById('procesando_div').style.display = "";
            setTimeout('document.images["procesando_gif"].src="../Imagenes/ajax-loader.gif"', 200);
        }
    </script>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="card border-dark" style="max-width: 100rem;">
                <div class="card-header ph-card-header">Generación de órdenes de servicio - Guías de envío</div>
                <%--<span id="procesando_div" style="display: none; position: relative; text-align: center">
                    <img src="../Imagenes/ajax-loader.gif" id="procesando" alt="" />
                </span>--%>
                <div class="card-body" style="background-color: white">
                    <asp:Label ID="lblMensaje" class="btn btn-success" runat="server" Visible="false" Text="" Style="margin-bottom: 10px;"></asp:Label>
                    <asp:HyperLink ID="urlReporte" runat="server" class="btn btn-success" Visible="true" Target="_blank">Desargar archivo generado</asp:HyperLink>

                    <dx:ASPxGridView ID="grvOrdenesServicio" runat="server" DataSourceID="dsOrdenes" AutoGenerateColumns="False" KeyFieldName="id" OnCustomButtonCallback="grvOrdenesServicio_CustomButtonCallback1">
                        <Settings ShowFilterRow="True" />
                        <SettingsDataSecurity AllowEdit="False" AllowInsert="False" />
                        <SettingsSearchPanel Visible="True" />
                        <Columns>
                            <dx:GridViewDataTextColumn FieldName="orden" ReadOnly="True" VisibleIndex="0">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="id" ReadOnly="True" VisibleIndex="1">
                                <EditFormSettings Visible="False" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="codigo_orden_servicio" VisibleIndex="2">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="cliente" VisibleIndex="3">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="servicio" VisibleIndex="4">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataDateColumn FieldName="fecha_carga" VisibleIndex="5">
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataTextColumn FieldName="oficina_carga" VisibleIndex="6">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="numero_registros_cargados" VisibleIndex="7">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="usuario_carga" VisibleIndex="8">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="estado" ReadOnly="True" VisibleIndex="9">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="detalle" ReadOnly="True" VisibleIndex="10">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataDateColumn FieldName="fecha_ultima_gestion" VisibleIndex="11">
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataTextColumn FieldName="usuario_ultima_transaccion" VisibleIndex="12">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="provincia" ReadOnly="True" VisibleIndex="13">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="canton" ReadOnly="True" VisibleIndex="14">
                            </dx:GridViewDataTextColumn>
                            
                           
                            <dx:GridViewCommandColumn VisibleIndex="15" ButtonRenderMode="Image">
                        <CustomButtons>
                           
                            <dx:GridViewCommandColumnCustomButton ID="ImprimirOS">
                                <Image ToolTip="Generar Orden de Servicio" Url="../imagenes/documento.png" />
                            </dx:GridViewCommandColumnCustomButton>
                            <%--<dx:GridViewCommandColumnCustomButton ID="ImprimirGuia">
                                <Image ToolTip="Imprimir Guías" Url="../imagenes/guia.png" />
                            </dx:GridViewCommandColumnCustomButton>--%>
                        </CustomButtons>
                    </dx:GridViewCommandColumn>
                        </Columns>
                    </dx:ASPxGridView>

                    <asp:SqlDataSource ID="dsOrdenes" runat="server" ConnectionString="<%$ ConnectionStrings:OPERADB_DAO %>" SelectCommand="SPR_CONSULTA_ORDENES_SERVICIO" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="lblMensaje" DefaultValue="1" Name="opcion" PropertyName="Text" Type="Int32" />
                            <asp:SessionParameter DefaultValue="" Name="id_usuario" SessionField=IdUsuario Type="Int32" />
                            <asp:Parameter DefaultValue="1" Name="orden_id" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
            </div>


        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function onCustomButtonClick(s, e) {
            if (e.buttonID == "ImprimirOS") {
                e.processOnServer = true;
            }
        }
    </script>

</asp:Content>
