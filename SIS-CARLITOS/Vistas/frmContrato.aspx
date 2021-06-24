<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmContrato.aspx.cs" Inherits="SIS_CARLITOS.Vistas.frmContrato" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>



<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          
        <ContentTemplate>
            <div class="card border-dark" style="max-width: 100rem;">
                <div class="card-header ph-card-header">Mantenimiento de Contratos</div>
                <div class="card-body" style="background-color: white">
                    
                        <div class="table-responsive">
                            <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="dsContratos" KeyFieldName="id" Theme="PlasticBlue">
                                <Settings ShowFilterRow="True"></Settings>
                                <SettingsDataSecurity AllowDelete="False"></SettingsDataSecurity>

                                <SettingsSearchPanel Visible="True"></SettingsSearchPanel>
                                <Columns>
                                    <dx:GridViewCommandColumn ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
                                    </dx:GridViewCommandColumn>
                                    <dx:GridViewDataTextColumn FieldName="id" ReadOnly="True" VisibleIndex="1" Caption="Id">
                                        <EditFormSettings Visible="False" />
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="numero_contrato" VisibleIndex="2" Caption="Contrato"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataDateColumn FieldName="fecha_inicio" VisibleIndex="4" Caption="Fecha inicio"></dx:GridViewDataDateColumn>
                                    <dx:GridViewDataDateColumn Caption="Fecha fin" FieldName="fecha_fin" VisibleIndex="5">
                                    </dx:GridViewDataDateColumn>
                                    <%--<dx:GridViewDataTextColumn FieldName="id_asesor" VisibleIndex="6" Caption="Asesor"></dx:GridViewDataTextColumn>--%>

                                    <dx:GridViewDataComboBoxColumn FieldName="id_asesor" Caption="Asesor" SortIndex="0" SortOrder="Ascending" AdaptivePriority="1" Settings-AllowAutoFilter="Default" Settings-AllowFilterBySearchPanel="True" VisibleIndex="8">
                                        <PropertiesComboBox DataSourceID="dsAsesores" ValueField="id" TextField="nm" ValueType="System.Int32" />
                                        <Settings AllowHeaderFilter="True" AllowAutoFilter="False" SortMode="DisplayText" />
                                        <SettingsHeaderFilter Mode="CheckedList" />
                                    </dx:GridViewDataComboBoxColumn>


                                    <dx:GridViewDataDateColumn Caption="Fecha registro" FieldName="fecha_registro" VisibleIndex="7">
                                        <EditFormSettings Visible="False" />
                                    </dx:GridViewDataDateColumn>
                                   <%-- <dx:GridViewDataTextColumn FieldName="id_cliente" VisibleIndex="8" Caption="Cliente"></dx:GridViewDataTextColumn>--%>

                                    <dx:GridViewDataComboBoxColumn FieldName="id_cliente" Caption="Cliente" SortIndex="0" SortOrder="Ascending" AdaptivePriority="1" Settings-AllowAutoFilter="Default" Settings-AllowFilterBySearchPanel="True" VisibleIndex="8">
                                        <PropertiesComboBox DataSourceID="dsCliente" ValueField="id" TextField="nm_cliente" ValueType="System.Int32" />
                                        <Settings AllowHeaderFilter="True" AllowAutoFilter="False" SortMode="DisplayText" />
                                        <SettingsHeaderFilter Mode="CheckedList" />
                                    </dx:GridViewDataComboBoxColumn>

                                    <%--<dx:GridViewDataTextColumn Caption="Estado" FieldName="estado" VisibleIndex="9">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="renovacion" VisibleIndex="10" Caption="Renovación"></dx:GridViewDataTextColumn>--%>

                                     <dx:GridViewDataComboBoxColumn FieldName="estado" Caption="Estado" SortIndex="0" SortOrder="Ascending" AdaptivePriority="1" Settings-AllowAutoFilter="Default" Settings-AllowFilterBySearchPanel="True" VisibleIndex="5">
                                    <PropertiesComboBox DataSourceID="dsEstado" ValueField="id" TextField="nm" ValueType="System.Int32" />
                                    <Settings AllowHeaderFilter="True" AllowAutoFilter="False" SortMode="DisplayText" />
                                    <SettingsHeaderFilter Mode="CheckedList" />
                                </dx:GridViewDataComboBoxColumn>

                                     <dx:GridViewDataComboBoxColumn FieldName="renovacion" Caption="Renovación" SortIndex="0" SortOrder="Ascending" AdaptivePriority="1" Settings-AllowAutoFilter="Default" Settings-AllowFilterBySearchPanel="True" VisibleIndex="5">
                                    <PropertiesComboBox DataSourceID="dsEstado" ValueField="id" TextField="nm" ValueType="System.Int32" />
                                    <Settings AllowHeaderFilter="True" AllowAutoFilter="False" SortMode="DisplayText" />
                                    <SettingsHeaderFilter Mode="CheckedList" />
                                </dx:GridViewDataComboBoxColumn>


                                    <dx:GridViewDataTextColumn Caption="Descripción" FieldName="descripcion" VisibleIndex="3">
                                    </dx:GridViewDataTextColumn>
                                </Columns>
                            </dx:ASPxGridView>
                            <asp:SqlDataSource ID="dsEstado" runat="server" ConnectionString="<%$ ConnectionStrings:OPERADB_DAO %>" SelectCommand="SELECT * FROM [estado]">
                        </asp:SqlDataSource>
                            <asp:SqlDataSource ID="dsAsesores" runat="server" ConnectionString="<%$ ConnectionStrings:OPERADB_DAO %>" SelectCommand="SELECT * FROM [asesor_comercial]">
                        </asp:SqlDataSource>
                            <asp:SqlDataSource ID="dsContratos" runat="server" ConnectionString="<%$ ConnectionStrings:OPERADB_DAO %>" DeleteCommand="DELETE FROM [contrato] WHERE [id] = @id" InsertCommand="INSERT INTO [contrato] ([numero_contrato], [fecha_inicio], [fecha_fin], [id_asesor], [fecha_registro], [id_cliente], [estado], [renovacion], [descripcion]) VALUES ( @numero_contrato, @fecha_inicio, @fecha_fin, @id_asesor, getdate(), @id_cliente, @estado, @renovacion, @descripcion)" SelectCommand="SELECT [id], [numero_contrato], [fecha_inicio], [fecha_fin], [id_asesor], [fecha_registro], [id_cliente], [estado], [renovacion], [descripcion] FROM [contrato]" UpdateCommand="UPDATE [contrato] SET [numero_contrato] = @numero_contrato, [fecha_inicio] = @fecha_inicio, [fecha_fin] = @fecha_fin, [id_asesor] = @id_asesor, [fecha_registro] = @fecha_registro, [id_cliente] = @id_cliente, [estado] = @estado, [renovacion] = @renovacion, [descripcion] = @descripcion WHERE [id] = @id">
                                <DeleteParameters>
                                    <asp:Parameter Name="id" Type="Int32" />
                                </DeleteParameters>
                                <InsertParameters>
                                    <asp:Parameter Name="id" Type="Int32" />
                                    <asp:Parameter Name="numero_contrato" Type="String" />
                                    <asp:Parameter Name="fecha_inicio" Type="DateTime" />
                                    <asp:Parameter Name="fecha_fin" Type="DateTime" />
                                    <asp:Parameter Name="id_asesor" Type="Int32" />
                                    <asp:Parameter Name="fecha_registro" Type="DateTime" />
                                    <asp:Parameter Name="id_cliente" Type="Int32" />
                                    <asp:Parameter Name="estado" Type="Int32" />
                                    <asp:Parameter Name="renovacion" Type="Int32" />
                                    <asp:Parameter Name="descripcion" Type="String" />
                                </InsertParameters>
                                <UpdateParameters>
                                    <asp:Parameter Name="numero_contrato" Type="String" />
                                    <asp:Parameter Name="fecha_inicio" Type="DateTime" />
                                    <asp:Parameter Name="fecha_fin" Type="DateTime" />
                                    <asp:Parameter Name="id_asesor" Type="Int32" />
                                    <asp:Parameter Name="fecha_registro" Type="DateTime" />
                                    <asp:Parameter Name="id_cliente" Type="Int32" />
                                    <asp:Parameter Name="estado" Type="Int32" />
                                    <asp:Parameter Name="renovacion" Type="Int32" />
                                    <asp:Parameter Name="descripcion" Type="String" />
                                    <asp:Parameter Name="id" Type="Int32" />
                                </UpdateParameters>
                            </asp:SqlDataSource>
                            
                            <asp:SqlDataSource ID="dsCliente" runat="server" ConnectionString="<%$ ConnectionStrings:OPERADB_DAO %>" SelectCommand="SELECT * FROM [cliente]">
                            </asp:SqlDataSource>
                        </div>
                    
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
