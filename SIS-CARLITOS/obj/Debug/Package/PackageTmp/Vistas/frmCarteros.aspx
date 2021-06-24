<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCarteros.aspx.cs" Inherits="SIS_CARLITOS.Vistas.frmCarteros" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>



<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          
        <ContentTemplate>
            <div class="card border-dark" style="max-width: 100rem;">
                <div class="card-header ph-card-header">Mantenimiento de Carteros</div>
                <div class="card-body" style="background-color: white">
                    
                        <div class="table-responsive">
                            <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="dsCarteros" KeyFieldName="id" Theme="PlasticBlue">
                                <Settings ShowFilterRow="True"></Settings>
                                <SettingsDataSecurity AllowDelete="False"></SettingsDataSecurity>

                                <SettingsSearchPanel Visible="True"></SettingsSearchPanel>
                                <Columns>
                                    <dx:GridViewCommandColumn ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
                                    </dx:GridViewCommandColumn>
                                    <dx:GridViewDataTextColumn FieldName="id" ReadOnly="True" VisibleIndex="1" Caption="Id" ShowInCustomizationForm="True">
                                        <EditFormSettings Visible="False" />
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="numero_identificacion" VisibleIndex="2" Caption="Identificación" ShowInCustomizationForm="True"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="nm_cartero" VisibleIndex="3" Caption="Nombres" ShowInCustomizationForm="True"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="direccion" VisibleIndex="4" Caption="Dirección" ShowInCustomizationForm="True"></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Teléfono" FieldName="telefono" ShowInCustomizationForm="True" VisibleIndex="5">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="correo_electronico" VisibleIndex="6" Caption="Correo electrónico" ShowInCustomizationForm="True"></dx:GridViewDataTextColumn>
                                    <%--<dx:GridViewDataTextColumn Caption="Estado" FieldName="estado" ShowInCustomizationForm="True" VisibleIndex="7">
                                    </dx:GridViewDataTextColumn>--%>
                                     <dx:GridViewDataComboBoxColumn FieldName="estado" Caption="Estado" SortIndex="0" SortOrder="Ascending" AdaptivePriority="1" Settings-AllowAutoFilter="Default" Settings-AllowFilterBySearchPanel="True" VisibleIndex="5">
                                    <PropertiesComboBox DataSourceID="dsEstado" ValueField="id" TextField="nm" ValueType="System.Int32" />
                                    <Settings AllowHeaderFilter="True" AllowAutoFilter="False" SortMode="DisplayText" />
                                    <SettingsHeaderFilter Mode="CheckedList" />
                                </dx:GridViewDataComboBoxColumn>
                                    <dx:GridViewDataDateColumn FieldName="fecha_ingreso" VisibleIndex="8" Caption="Fecha ingreso" ShowInCustomizationForm="True"></dx:GridViewDataDateColumn>
                                </Columns>
                            </dx:ASPxGridView>
                            <asp:SqlDataSource ID="dsEstado" runat="server" ConnectionString="<%$ ConnectionStrings:OPERADB_DAO %>" SelectCommand="SELECT * FROM [estado]">
                        </asp:SqlDataSource>
                            <asp:SqlDataSource ID="dsCarteros" runat="server" ConnectionString="<%$ ConnectionStrings:OPERADB_DAO %>" DeleteCommand="DELETE FROM [cartero] WHERE [id] = @id" InsertCommand="INSERT INTO [cartero] ([numero_identificacion], [nm_cartero], [direccion], [telefono], [correo_electronico], [estado], [fecha_ingreso]) VALUES (@numero_identificacion, @nm_cartero, @direccion, @telefono, @correo_electronico, @estado, getdate())" SelectCommand="SELECT * FROM [cartero]" UpdateCommand="UPDATE [cartero] SET [numero_identificacion] = @numero_identificacion, [nm_cartero] = @nm_cartero, [direccion] = @direccion, [telefono] = @telefono, [correo_electronico] = @correo_electronico, [estado] = @estado, [fecha_ingreso] = @fecha_ingreso WHERE [id] = @id">
                                <DeleteParameters>
                                    <asp:Parameter Name="id" Type="Int32" />
                                </DeleteParameters>
                                <InsertParameters>
                                    <asp:Parameter Name="numero_identificacion" Type="String" />
                                    <asp:Parameter Name="nm_cartero" Type="String" />
                                    <asp:Parameter Name="direccion" Type="String" />
                                    <asp:Parameter Name="telefono" Type="String" />
                                    <asp:Parameter Name="correo_electronico" Type="String" />
                                    <asp:Parameter Name="estado" Type="Int32" />
                                    <asp:Parameter Name="fecha_ingreso" Type="DateTime" />
                                </InsertParameters>
                                <UpdateParameters>
                                    <asp:Parameter Name="numero_identificacion" Type="String" />
                                    <asp:Parameter Name="nm_cartero" Type="String" />
                                    <asp:Parameter Name="direccion" Type="String" />
                                    <asp:Parameter Name="telefono" Type="String" />
                                    <asp:Parameter Name="correo_electronico" Type="String" />
                                    <asp:Parameter Name="estado" Type="Int32" />
                                    <asp:Parameter Name="fecha_ingreso" Type="DateTime" />
                                    <asp:Parameter Name="id" Type="Int32" />
                                </UpdateParameters>
                            </asp:SqlDataSource>

                        </div>
                    
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
