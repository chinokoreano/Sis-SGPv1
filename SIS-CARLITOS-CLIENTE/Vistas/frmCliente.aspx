<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCliente.aspx.cs" Inherits="SIS_CARLITOS.Vistas.frmCliente" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>



<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          
        <ContentTemplate>
            <div class="card border-dark" style="max-width: 100rem;">
                <div class="card-header ph-card-header">Mantenimiento de Clientes</div>
                <div class="card-body" style="background-color: white">
                    <div class="table-responsive">
                        <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="dsClientes" KeyFieldName="id" Theme="PlasticBlue">
                            <Columns>
                                <dx:GridViewCommandColumn ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataTextColumn FieldName="id" ReadOnly="True" Caption="Id" VisibleIndex="1">
                                    <EditFormSettings Visible="False" />
                                </dx:GridViewDataTextColumn>
                                
                               <%-- <dx:GridViewDataTextColumn FieldName="tipo_identificacion" VisibleIndex="2">
                                </dx:GridViewDataTextColumn>--%>

                                <dx:GridViewDataComboBoxColumn FieldName="tipo_identificacion" Caption="Tipo Documento" SortIndex="0" SortOrder="Ascending" AdaptivePriority="1" Settings-AllowAutoFilter="Default" Settings-AllowFilterBySearchPanel="True" VisibleIndex="3">
                                        <PropertiesComboBox DataSourceID="dsTipoDocumento" ValueField="id" TextField="nm" ValueType="System.Int32" />
                                        <Settings AllowHeaderFilter="True" AllowAutoFilter="False" SortMode="DisplayText" />
                                        <SettingsHeaderFilter Mode="CheckedList" />
                                    </dx:GridViewDataComboBoxColumn>

                                <dx:GridViewDataTextColumn FieldName="numero_identificacion" Caption="Identificación" VisibleIndex ="3">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="nm_cliente" Caption="Cliente" VisibleIndex="4">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="nm_cliente_corto" Caption="Nombre corto" VisibleIndex="5">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="direccion" Caption="Dirección" VisibleIndex="6">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="telefono" Caption="Teléfono" VisibleIndex="7">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataCheckColumn FieldName="estado" Caption="Estado" VisibleIndex="8">
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataDateColumn FieldName="fecha_ingreso" Caption="Fecha ingreso" VisibleIndex="9">
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn FieldName="correo_electronico" Caption="Correo electrónico" VisibleIndex="10">
                                </dx:GridViewDataTextColumn>
                            </Columns>
                        </dx:ASPxGridView>
                        <asp:SqlDataSource ID="dsClientes" runat="server" ConnectionString="<%$ ConnectionStrings:OPERADB_DAO %>" DeleteCommand="DELETE FROM [cliente] WHERE [id] = @id" InsertCommand="INSERT INTO [cliente] ([tipo_identificacion], [numero_identificacion], [nm_cliente], [nm_cliente_corto], [direccion], [telefono], [estado], [fecha_ingreso], [correo_electronico]) VALUES (@tipo_identificacion, @numero_identificacion, @nm_cliente, @nm_cliente_corto, @direccion, @telefono, @estado, GETDATE(), @correo_electronico)" SelectCommand="SELECT * FROM [cliente]" UpdateCommand="UPDATE [cliente] SET [tipo_identificacion] = @tipo_identificacion, [numero_identificacion] = @numero_identificacion, [nm_cliente] = @nm_cliente, [nm_cliente_corto] = @nm_cliente_corto, [direccion] = @direccion, [telefono] = @telefono, [estado] = @estado, [fecha_ingreso] = @fecha_ingreso, [correo_electronico] = @correo_electronico WHERE [id] = @id">
                            <DeleteParameters>
                                <asp:Parameter Name="id" Type="Int32" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:Parameter Name="tipo_identificacion" Type="Int32" />
                                <asp:Parameter Name="numero_identificacion" Type="String" />
                                <asp:Parameter Name="nm_cliente" Type="String" />
                                <asp:Parameter Name="nm_cliente_corto" Type="String" />
                                <asp:Parameter Name="direccion" Type="String" />
                                <asp:Parameter Name="telefono" Type="String" />
                                <asp:Parameter Name="estado" Type="Boolean" />
                                <asp:Parameter Name="fecha_ingreso" Type="DateTime" />
                                <asp:Parameter Name="correo_electronico" Type="String" />
                            </InsertParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="tipo_identificacion" Type="Int32" />
                                <asp:Parameter Name="numero_identificacion" Type="String" />
                                <asp:Parameter Name="nm_cliente" Type="String" />
                                <asp:Parameter Name="nm_cliente_corto" Type="String" />
                                <asp:Parameter Name="direccion" Type="String" />
                                <asp:Parameter Name="telefono" Type="String" />
                                <asp:Parameter Name="estado" Type="Boolean" />
                                <asp:Parameter Name="fecha_ingreso" Type="DateTime" />
                                <asp:Parameter Name="correo_electronico" Type="String" />
                                <asp:Parameter Name="id" Type="Int32" />
                            </UpdateParameters>
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="dsTipoDocumento" runat="server" ConnectionString="<%$ ConnectionStrings:OPERADB_DAO %>" SelectCommand="SELECT * FROM [tipo_documento]"></asp:SqlDataSource>
                    </div>
                    
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
