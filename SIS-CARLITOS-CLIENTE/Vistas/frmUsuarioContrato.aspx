<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmUsuarioContrato.aspx.cs" Inherits="SIS_CARLITOS.Vistas.frmUsuarioContrato" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>



<%@ Register Assembly="DevExpress.Web.v22.2, Version=22.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          
        <ContentTemplate>
            <div class="card border-dark" style="max-width: 100rem;">
                <div class="card-header ph-card-header">Mantenimiento de Usuarios Contratos</div>
                <div class="card-body" style="background-color: white">
                    
                        <div class="table-responsive">
                            <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="dsUsuarioContrato" 
                                KeyFieldName="id" Theme="PlasticBlue">
                                <Settings ShowFilterRow="True"></Settings>
                                <SettingsDataSecurity AllowDelete="False"></SettingsDataSecurity>

                                <SettingsSearchPanel Visible="True"></SettingsSearchPanel>
                                <Columns>
                                 

                                    <dx:GridViewCommandColumn ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
                                    </dx:GridViewCommandColumn>
                                 

                                    <dx:GridViewDataTextColumn FieldName="id" ReadOnly="True" VisibleIndex="1" Caption="Id">
                                        <EditFormSettings Visible="False" />
                                    </dx:GridViewDataTextColumn>
                                    <%--<dx:GridViewDataTextColumn FieldName="id_usuario" VisibleIndex="1">
                                        <EditFormSettings Visible="False" />
                                    </dx:GridViewDataTextColumn>--%>
                                    <%--<dx:GridViewDataTextColumn FieldName="id_contrato" VisibleIndex="2">
                                    </dx:GridViewDataTextColumn>--%>
                                    <dx:GridViewDataComboBoxColumn FieldName="id_usuario" Caption="Usuario" SortIndex="0" SortOrder="Ascending" AdaptivePriority="1" 
                                        Settings-AllowAutoFilter="Default" Settings-AllowFilterBySearchPanel="True" VisibleIndex="2">
                                        <PropertiesComboBox DataSourceID="dsUsuario" ValueField="id" TextField="nm" ValueType="System.Int32" />
                                        <Settings AllowHeaderFilter="True" AllowAutoFilter="False" SortMode="DisplayText" />
                                        <SettingsHeaderFilter Mode="CheckedList" />
                                    </dx:GridViewDataComboBoxColumn>
                                    
                                 

                                     <dx:GridViewDataComboBoxColumn FieldName="id_contrato" Caption="Contrato" SortIndex="0" SortOrder="Ascending" AdaptivePriority="1" 
                                         Settings-AllowAutoFilter="Default" Settings-AllowFilterBySearchPanel="True" VisibleIndex="3">
                                        <PropertiesComboBox DataSourceID="dsContrato" ValueField="id" TextField="numero_contrato" ValueType="System.Int32" />
                                        <Settings AllowHeaderFilter="True" AllowAutoFilter="False" SortMode="DisplayText" />
                                        <SettingsHeaderFilter Mode="CheckedList" />
                                    </dx:GridViewDataComboBoxColumn>

                                    <%--<dx:GridViewDataTextColumn FieldName="estado" VisibleIndex="4" Caption="Estado">
                                    </dx:GridViewDataTextColumn>--%>

                                     <dx:GridViewDataComboBoxColumn FieldName="estado" Caption="Estado" SortIndex="0" SortOrder="Ascending" AdaptivePriority="1" Settings-AllowAutoFilter="Default" Settings-AllowFilterBySearchPanel="True" VisibleIndex="5">
                                    <PropertiesComboBox DataSourceID="dsEstado" ValueField="id" TextField="nm" ValueType="System.Int32" />
                                    <Settings AllowHeaderFilter="True" AllowAutoFilter="False" SortMode="DisplayText" />
                                    <SettingsHeaderFilter Mode="CheckedList" />
                                </dx:GridViewDataComboBoxColumn>
                                    <dx:GridViewDataDateColumn FieldName="fecha_registro" VisibleIndex="5" Caption="Fecha registro">
                                        <EditFormSettings Visible="False" />
                                    </dx:GridViewDataDateColumn>
                                </Columns>
                            </dx:ASPxGridView>

                            <asp:SqlDataSource ID="dsUsuarioContrato" runat="server" ConnectionString="<%$ ConnectionStrings:OPERADB_DAO %>" DeleteCommand="DELETE FROM [usuario_contrato] WHERE [id] = @id" InsertCommand="INSERT INTO [usuario_contrato] ([id_usuario], [id_contrato], [estado], [fecha_registro]) VALUES (@id_usuario, @id_contrato, @estado, getdate())" SelectCommand="SELECT [id], [id_usuario], [id_contrato], [estado], [fecha_registro] FROM [usuario_contrato] ORDER BY [id]" UpdateCommand="UPDATE [usuario_contrato] SET [id_usuario] = @id_usuario, [id_contrato] = @id_contrato, [estado] = @estado, [fecha_registro] = @fecha_registro WHERE [id] = @id">
                                <DeleteParameters>
                                    <asp:Parameter Name="id" Type="Int32" />
                                </DeleteParameters>
                                <InsertParameters>
                                    <asp:Parameter Name="id_usuario" Type="Int32" />
                                    <asp:Parameter Name="id_contrato" Type="Int32" />
                                    <asp:Parameter Name="estado" Type="Int32" />
                                    <asp:Parameter Name="fecha_registro" Type="DateTime" />
                                </InsertParameters>
                                <UpdateParameters>
                                    <asp:Parameter Name="id_usuario" Type="Int32" />
                                    <asp:Parameter Name="id_contrato" Type="Int32" />
                                    <asp:Parameter Name="estado" Type="Int32" />
                                    <asp:Parameter Name="fecha_registro" Type="DateTime" />
                                    <asp:Parameter Name="id" Type="Int32" />
                                </UpdateParameters>
                            </asp:SqlDataSource>
                            
                            <asp:SqlDataSource ID="dsContrato" runat="server" ConnectionString="<%$ ConnectionStrings:OPERADB_DAO %>" SelectCommand="SELECT * FROM [contrato]">
                            </asp:SqlDataSource>
                             <asp:SqlDataSource ID="dsUsuario" runat="server" ConnectionString="<%$ ConnectionStrings:OPERADB_DAO %>" SelectCommand="SELECT * FROM [usuario]">
                            </asp:SqlDataSource>
                            <asp:SqlDataSource ID="dsEstado" runat="server" ConnectionString="<%$ ConnectionStrings:OPERADB_DAO %>" SelectCommand="SELECT * FROM [estado]">
                        </asp:SqlDataSource>
                        </div>
                    
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
