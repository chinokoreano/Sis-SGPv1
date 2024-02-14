<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmOficinas.aspx.cs" Inherits="SIS_CARLITOS.Vistas.frmOficinas" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>



<%@ Register Assembly="DevExpress.Web.v22.2, Version=22.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          
        <ContentTemplate>
            <div class="card border-dark" style="max-width: 100rem;">
                <div class="card-header ph-card-header">Mantenimiento de Oficinas</div>
                <div class="card-body" style="background-color: white">
                    <div class="table-responsive">

                        <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="dsOficinas" KeyFieldName="id" Theme="PlasticBlue">
                            <Settings ShowFilterRow="True"></Settings>
                            <SettingsDataSecurity AllowDelete="False"></SettingsDataSecurity>

                            <SettingsSearchPanel Visible="True"></SettingsSearchPanel>
                            <Columns>
                                <dx:GridViewCommandColumn ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataTextColumn FieldName="id" ReadOnly="True" VisibleIndex="1" Caption="Id">
                                    <EditFormSettings Visible="False" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="nm_oficina" VisibleIndex="2" Caption="Oficina"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="codigo_oficina" VisibleIndex="3" Caption="Codigo"></dx:GridViewDataTextColumn>
                               <%-- <dx:GridViewDataTextColumn FieldName="estado" VisibleIndex="4" Caption="Estado"></dx:GridViewDataTextColumn>--%>
                                 <dx:GridViewDataComboBoxColumn FieldName="estado" Caption="Estado" SortIndex="0" SortOrder="Ascending" AdaptivePriority="1" Settings-AllowAutoFilter="Default" Settings-AllowFilterBySearchPanel="True" VisibleIndex="5">
                                    <PropertiesComboBox DataSourceID="dsEstado" ValueField="id" TextField="nm" ValueType="System.Int32" />
                                    <Settings AllowHeaderFilter="True" AllowAutoFilter="False" SortMode="DisplayText" />
                                    <SettingsHeaderFilter Mode="CheckedList" />
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataDateColumn FieldName="fecha_registro" VisibleIndex="5" Caption="Fecha registro"></dx:GridViewDataDateColumn>
                            </Columns>
                        </dx:ASPxGridView>
                        <asp:SqlDataSource ID="dsEstado" runat="server" ConnectionString="<%$ ConnectionStrings:OPERADB_DAO %>" SelectCommand="SELECT * FROM [estado]">
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="dsOficinas" runat="server" ConnectionString="<%$ ConnectionStrings:OPERADB_DAO %>" DeleteCommand="DELETE FROM [oficina] WHERE [id] = @id" InsertCommand="INSERT INTO [oficina] ([nm_oficina], [codigo_oficina], [estado], [fecha_registro]) VALUES (@nm_oficina, @codigo_oficina, @estado, getdate())" SelectCommand="SELECT * FROM [oficina]" UpdateCommand="UPDATE [oficina] SET [nm_oficina] = @nm_oficina, [codigo_oficina] = @codigo_oficina, [estado] = @estado, [fecha_registro] = @fecha_registro WHERE [id] = @id">
                            
                            <DeleteParameters>
                                <asp:Parameter Name="id" Type="Int32" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:Parameter Name="nm_oficina" Type="String" />
                                <asp:Parameter Name="codigo_oficina" Type="String" />
                                <asp:Parameter Name="estado" Type="Int32" />
                                <asp:Parameter Name="fecha_registro" Type="DateTime" />
                            </InsertParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="nm_oficina" Type="String" />
                                <asp:Parameter Name="codigo_oficina" Type="String" />
                                <asp:Parameter Name="estado" Type="Int32" />
                                <asp:Parameter Name="fecha_registro" Type="DateTime" />
                                <asp:Parameter Name="id" Type="Int32" />
                            </UpdateParameters>
                        </asp:SqlDataSource>

                    </div>
                    </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
