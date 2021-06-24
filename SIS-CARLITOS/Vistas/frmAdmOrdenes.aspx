<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmAdmOrdenes.aspx.cs" Inherits="SIS_CARLITOS.Vistas.frmAdmOrdenes" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>



<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          
        <ContentTemplate>
            <div class="card border-dark" style="max-width: 100rem;">
                <div class="card-header ph-card-header">Administración de órdenes de servicio</div>
                <div class="card-body" style="background-color: white">
                    <div class="table-responsive">

                        <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="dsOrdenes" KeyFieldName="id" Theme="PlasticBlue">
                            <SettingsAdaptivity>
                                <AdaptiveDetailLayoutProperties>
                                    <Items>
                                        <dx:GridViewColumnLayoutItem ColSpan="1">
                                        </dx:GridViewColumnLayoutItem>
                                        <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="id">
                                        </dx:GridViewColumnLayoutItem>
                                        <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="codigo_orden_servicio">
                                        </dx:GridViewColumnLayoutItem>
                                        <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="id_cliente">
                                        </dx:GridViewColumnLayoutItem>
                                        <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="id_tipo_servicio">
                                        </dx:GridViewColumnLayoutItem>
                                        <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="fecha_carga">
                                        </dx:GridViewColumnLayoutItem>
                                        <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="id_usuario">
                                        </dx:GridViewColumnLayoutItem>
                                        <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="estado">
                                        </dx:GridViewColumnLayoutItem>
                                        <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="id_contrato">
                                        </dx:GridViewColumnLayoutItem>
                                        <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="id_oficina_carga">
                                        </dx:GridViewColumnLayoutItem>
                                        <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="numero_registros_cargados">
                                        </dx:GridViewColumnLayoutItem>
                                        <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="detalle">
                                        </dx:GridViewColumnLayoutItem>
                                    </Items>
                                </AdaptiveDetailLayoutProperties>
                            </SettingsAdaptivity>
                            <SettingsEditing Mode="PopupEditForm">
                            </SettingsEditing>
                            <Settings ShowFilterRow="True"></Settings>
                            <SettingsDataSecurity AllowDelete="False"></SettingsDataSecurity>

                            <SettingsSearchPanel Visible="True"></SettingsSearchPanel>
                            <EditFormLayoutProperties ColCount="2" ColumnCount="2">
                                <Items>
                                    <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="codigo_orden_servicio">
                                    </dx:GridViewColumnLayoutItem>
                                    <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="id_cliente">
                                    </dx:GridViewColumnLayoutItem>
                                    <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="id_tipo_servicio">
                                    </dx:GridViewColumnLayoutItem>
                                    <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="fecha_carga">
                                    </dx:GridViewColumnLayoutItem>
                                    <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="id_usuario">
                                    </dx:GridViewColumnLayoutItem>
                                    <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="estado">
                                    </dx:GridViewColumnLayoutItem>
                                    <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="id_contrato">
                                    </dx:GridViewColumnLayoutItem>
                                    <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="id_oficina_carga">
                                    </dx:GridViewColumnLayoutItem>
                                    <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="numero_registros_cargados">
                                    </dx:GridViewColumnLayoutItem>
                                    <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="detalle">
                                    </dx:GridViewColumnLayoutItem>
                                    <dx:EditModeCommandLayoutItem ColSpan="2" ColumnSpan="2" HorizontalAlign="Right" Width="100%">
                                    </dx:EditModeCommandLayoutItem>
                                </Items>
                                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit">
                                </SettingsAdaptivity>
                            </EditFormLayoutProperties>
                            <Columns>
                                <dx:GridViewCommandColumn ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataTextColumn FieldName="id" ReadOnly="True" VisibleIndex="1" Caption="Id">
                                    <EditFormSettings Visible="False" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="codigo_orden_servicio" VisibleIndex="2" Caption="Orden de Servicio" MaxWidth="100" MinWidth="100" ReadOnly="True"></dx:GridViewDataTextColumn>
                                <%--<dx:GridViewDataTextColumn FieldName="id_cliente" VisibleIndex="3"></dx:GridViewDataTextColumn>--%>
                              
                                <dx:GridViewDataComboBoxColumn FieldName="id_cliente" Caption="Cliente" SortIndex="0" SortOrder="Ascending" AdaptivePriority="1" Settings-AllowAutoFilter="Default" Settings-AllowFilterBySearchPanel="True" VisibleIndex="5" MaxWidth="100" MinWidth="100" ReadOnly="True">
                                    <PropertiesComboBox DataSourceID="dsCliente" ValueField="id" TextField="nm_cliente" ValueType="System.Int32" />
                                    <Settings AllowHeaderFilter="True" AllowAutoFilter="False" SortMode="DisplayText" />
                                    <SettingsHeaderFilter Mode="CheckedList" />
                                </dx:GridViewDataComboBoxColumn>

                               <%--  <dx:GridViewDataTextColumn FieldName="id_tipo_servicio" VisibleIndex="4">
                                </dx:GridViewDataTextColumn>--%>
                                 <dx:GridViewDataComboBoxColumn FieldName="id_tipo_servicio" Caption="Servicio" SortIndex="0" SortOrder="Ascending" AdaptivePriority="1" Settings-AllowAutoFilter="Default" Settings-AllowFilterBySearchPanel="True" VisibleIndex="6" MaxWidth="50" MinWidth="50" ReadOnly="True">
                                    <PropertiesComboBox DataSourceID="dsServicio" ValueField="id" TextField="nm_servicio" ValueType="System.Int32" />
                                    <Settings AllowHeaderFilter="True" AllowAutoFilter="False" SortMode="DisplayText" />
                                    <SettingsHeaderFilter Mode="CheckedList" />
                                </dx:GridViewDataComboBoxColumn>

                                <dx:GridViewDataDateColumn FieldName="fecha_carga" VisibleIndex="7" Caption="Fec. carga" MaxWidth="50" MinWidth="50" ReadOnly="True"></dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn Caption="Reg. cargados" FieldName="numero_registros_cargados" VisibleIndex="12" MaxWidth="20" MinWidth="20" ReadOnly="True">
                                </dx:GridViewDataTextColumn>
                                <%--<dx:GridViewDataTextColumn FieldName="id_usuario" VisibleIndex="7">
                                </dx:GridViewDataTextColumn>--%>
                               <%-- <dx:GridViewDataTextColumn Caption="Estado" FieldName="estado" VisibleIndex="8">
                                </dx:GridViewDataTextColumn>--%>
                                 <dx:GridViewDataComboBoxColumn FieldName="id_usuario" Caption="Usuario" SortIndex="0" SortOrder="Ascending" AdaptivePriority="1" Settings-AllowAutoFilter="Default" Settings-AllowFilterBySearchPanel="True" VisibleIndex="8" MaxWidth="50" MinWidth="50" ReadOnly="True">
                                    <PropertiesComboBox DataSourceID="dsUsuario" ValueField="id" TextField="nm" ValueType="System.Int32" />
                                    <Settings AllowHeaderFilter="True" AllowAutoFilter="False" SortMode="DisplayText" />
                                    <SettingsHeaderFilter Mode="CheckedList" />
                                </dx:GridViewDataComboBoxColumn>
                                  <dx:GridViewDataComboBoxColumn FieldName="estado" Caption="Estado" SortIndex="0" SortOrder="Ascending" AdaptivePriority="1" Settings-AllowAutoFilter="Default" Settings-AllowFilterBySearchPanel="True" VisibleIndex="9" MaxWidth="50" MinWidth="50">
                                    <PropertiesComboBox DataSourceID="dsEstado" ValueField="id" TextField="nm" ValueType="System.Int32" />
                                    <Settings AllowHeaderFilter="True" AllowAutoFilter="False" SortMode="DisplayText" />
                                    <SettingsHeaderFilter Mode="CheckedList" />
                                </dx:GridViewDataComboBoxColumn>
                                <%--<dx:GridViewDataTextColumn FieldName="id_contrato" VisibleIndex="9">
                                </dx:GridViewDataTextColumn>--%>
                                 <dx:GridViewDataComboBoxColumn FieldName="id_contrato" Caption="Contrato" SortIndex="0" SortOrder="Ascending" AdaptivePriority="1" Settings-AllowAutoFilter="Default" Settings-AllowFilterBySearchPanel="True" VisibleIndex="10" MaxWidth="50" MinWidth="50" ReadOnly="True">
                                    <PropertiesComboBox DataSourceID="dsContrato" ValueField="id" TextField="numero_contrato" ValueType="System.Int32" />
                                    <Settings AllowHeaderFilter="True" AllowAutoFilter="False" SortMode="DisplayText" />
                                    <SettingsHeaderFilter Mode="CheckedList" />
                                </dx:GridViewDataComboBoxColumn>

                                <dx:GridViewDataTextColumn FieldName="id_canton_carga" visible="false" VisibleIndex="13">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="id_usuario_ultima_gestion" visible="false" VisibleIndex="14">
                                </dx:GridViewDataTextColumn>
                                <%--<dx:GridViewDataTextColumn FieldName="id_oficina_carga" VisibleIndex="12">
                                </dx:GridViewDataTextColumn>--%>
                                  <dx:GridViewDataComboBoxColumn FieldName="id_oficina_carga" Caption="Oficina" SortIndex="0" SortOrder="Ascending" AdaptivePriority="1" Settings-AllowAutoFilter="Default" Settings-AllowFilterBySearchPanel="True" VisibleIndex="11" MaxWidth="50" MinWidth="50" ReadOnly="True">
                                    <PropertiesComboBox DataSourceID="dsOficina" ValueField="id" TextField="nm_oficina" ValueType="System.Int32" />
                                    <Settings AllowHeaderFilter="True" AllowAutoFilter="False" SortMode="DisplayText" />
                                    <SettingsHeaderFilter Mode="CheckedList" />
                                </dx:GridViewDataComboBoxColumn>

                                <dx:GridViewDataDateColumn FieldName="fecha_ultima_gestion" visible="false" VisibleIndex="15">
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn Caption="Detalle" FieldName="detalle" VisibleIndex="16" MaxWidth="50" MinWidth="50">
                                </dx:GridViewDataTextColumn>
                            </Columns>
                        </dx:ASPxGridView>
                         <asp:SqlDataSource ID="dsCliente" runat="server" ConnectionString="<%$ ConnectionStrings:OPERADB_DAO %>" SelectCommand="SELECT * FROM [cliente]">
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="dsEstado" runat="server" ConnectionString="<%$ ConnectionStrings:OPERADB_DAO %>" SelectCommand="SELECT * FROM [estado]">
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="dsUsuario" runat="server" ConnectionString="<%$ ConnectionStrings:OPERADB_DAO %>" SelectCommand="SELECT * FROM [usuario] ">
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="dsContrato" runat="server" ConnectionString="<%$ ConnectionStrings:OPERADB_DAO %>" SelectCommand="SELECT * FROM [contrato]">
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="dsServicio" runat="server" ConnectionString="<%$ ConnectionStrings:OPERADB_DAO %>" SelectCommand="SELECT * FROM [servicio]">
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="dsOficina" runat="server" ConnectionString="<%$ ConnectionStrings:OPERADB_DAO %>" SelectCommand="SELECT * FROM [oficina]">
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="dsOrdenes" runat="server" ConnectionString="<%$ ConnectionStrings:OPERADB_DAO %>" SelectCommand="SELECT [id], [codigo_orden_servicio], [id_cliente], [id_tipo_servicio], [fecha_carga], [numero_registros_cargados], [id_usuario], [estado], [id_contrato], [id_canton_carga], [id_usuario_ultima_gestion], [id_oficina_carga], [fecha_ultima_gestion], [detalle] FROM [orden_servicio]" DeleteCommand="DELETE FROM [orden_servicio] WHERE [id] = @id" InsertCommand="INSERT INTO [orden_servicio] ([codigo_orden_servicio], [id_cliente], [id_tipo_servicio], [fecha_carga], [numero_registros_cargados], [id_usuario], [estado], [id_contrato], [id_canton_carga], [id_usuario_ultima_gestion], [id_oficina_carga], [fecha_ultima_gestion], [detalle]) VALUES (@codigo_orden_servicio, @id_cliente, @id_tipo_servicio, @fecha_carga, @numero_registros_cargados, @id_usuario, @estado, @id_contrato, @id_canton_carga, @id_usuario_ultima_gestion, @id_oficina_carga, @fecha_ultima_gestion, @detalle)" UpdateCommand="UPDATE [orden_servicio] SET [codigo_orden_servicio] = @codigo_orden_servicio, [id_cliente] = @id_cliente, [id_tipo_servicio] = @id_tipo_servicio, [fecha_carga] = @fecha_carga, [numero_registros_cargados] = @numero_registros_cargados, [id_usuario] = @id_usuario, [estado] = @estado, [id_contrato] = @id_contrato, [id_canton_carga] = @id_canton_carga, [id_usuario_ultima_gestion] = @id_usuario_ultima_gestion, [id_oficina_carga] = @id_oficina_carga, [fecha_ultima_gestion] = getdate(), [detalle] = @detalle + ' ' + CAST(getdate() AS VARCHAR(30)) + ' Cambio de estado' WHERE [id] = @id">
                            <DeleteParameters>
                                <asp:Parameter Name="id" Type="Int32" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:Parameter Name="codigo_orden_servicio" Type="String" />
                                <asp:Parameter Name="id_cliente" Type="Int32" />
                                <asp:Parameter Name="id_tipo_servicio" Type="Int32" />
                                <asp:Parameter Name="fecha_carga" Type="DateTime" />
                                <asp:Parameter Name="numero_registros_cargados" Type="Int32" />
                                <asp:Parameter Name="id_usuario" Type="Int32" />
                                <asp:Parameter Name="estado" Type="Int32" />
                                <asp:Parameter Name="id_contrato" Type="Int32" />
                                <asp:Parameter Name="id_canton_carga" Type="String" />
                                <asp:Parameter Name="id_usuario_ultima_gestion" Type="Int32" />
                                <asp:Parameter Name="id_oficina_carga" Type="Int32" />
                                <asp:Parameter Name="fecha_ultima_gestion" Type="DateTime" />
                                <asp:Parameter Name="detalle" Type="String" />
                            </InsertParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="codigo_orden_servicio" Type="String" />
                                <asp:Parameter Name="id_cliente" Type="Int32" />
                                <asp:Parameter Name="id_tipo_servicio" Type="Int32" />
                                <asp:Parameter Name="fecha_carga" Type="DateTime" />
                                <asp:Parameter Name="numero_registros_cargados" Type="Int32" />
                                <asp:Parameter Name="id_usuario" Type="Int32" />
                                <asp:Parameter Name="estado" Type="Int32" />
                                <asp:Parameter Name="id_contrato" Type="Int32" />
                                <asp:Parameter Name="id_canton_carga" Type="String" />
                                <asp:Parameter Name="id_usuario_ultima_gestion" Type="Int32" />
                                <asp:Parameter Name="id_oficina_carga" Type="Int32" />
                                <asp:Parameter Name="fecha_ultima_gestion" Type="DateTime" />
                                <asp:Parameter Name="detalle" Type="String" />
                                <asp:Parameter Name="id" Type="Int32" />
                            </UpdateParameters>
                        </asp:SqlDataSource>

                    </div>
                    </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
