<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmAsesorComercial.aspx.cs" Inherits="SIS_CARLITOS.Vistas.frmAsesorComercial" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>



<%@ Register Assembly="DevExpress.Web.v22.2, Version=22.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          
        <ContentTemplate>
            <div class="card border-dark" style="max-width: 100rem;">
                <div class="card-header ph-card-header">Mantenimiento de Asesores Comerciales</div>
                <div class="card-body" style="background-color: white">
                    <div class="table-responsive">

                        <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="dsAsesorComercial" KeyFieldName="id" Theme="PlasticBlue">
                            <Settings ShowFilterRow="True"></Settings>
                            <SettingsDataSecurity AllowDelete="False"></SettingsDataSecurity>

                            <SettingsSearchPanel Visible="True"></SettingsSearchPanel>
                            <Columns>
                               <%-- <dx:GridViewDataTextColumn FieldName="estado" VisibleIndex="4" Caption="Estado"></dx:GridViewDataTextColumn>--%>
                                 <dx:GridViewCommandColumn ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataTextColumn FieldName="id" ReadOnly="True" VisibleIndex="1" Caption="Id">
                                    <EditFormSettings Visible="False" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="nm" VisibleIndex="2" Caption="Asesor comercial"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="numero_identificacion" VisibleIndex="3" Caption="Identificación"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Dirección" FieldName="direccion" VisibleIndex="4">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Teléfono" FieldName="telefono" VisibleIndex="5">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Correo electrónico" FieldName="correo_electronico" VisibleIndex="6">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataCheckColumn Caption="Estado" FieldName="estado" VisibleIndex="7">
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataDateColumn FieldName="fecha_registro" VisibleIndex="8" visible="false" Caption="Fecha registro"></dx:GridViewDataDateColumn>
                            </Columns>
                        </dx:ASPxGridView>
                        <asp:SqlDataSource ID="dsAsesorComercial" runat="server" ConnectionString="<%$ ConnectionStrings:OPERADB_DAO %>" SelectCommand="SELECT [id], [nm], [numero_identificacion], [direccion], [telefono], [correo_electronico], [estado], [fecha_registro] FROM [asesor_comercial] ORDER BY [id]" DeleteCommand="DELETE FROM [asesor_comercial] WHERE [id] = @id" InsertCommand="INSERT INTO [asesor_comercial] ([nm], [numero_identificacion], [direccion], [telefono], [correo_electronico], [estado], [fecha_registro]) VALUES (@nm, @numero_identificacion, @direccion, @telefono, @correo_electronico, @estado, getdate())" UpdateCommand="UPDATE [asesor_comercial] SET [nm] = @nm, [numero_identificacion] = @numero_identificacion, [direccion] = @direccion, [telefono] = @telefono, [correo_electronico] = @correo_electronico, [estado] = @estado, [fecha_registro] = @fecha_registro WHERE [id] = @id">
                            <DeleteParameters>
                                <asp:Parameter Name="id" Type="Int32" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:Parameter Name="nm" Type="String" />
                                <asp:Parameter Name="numero_identificacion" Type="String" />
                                <asp:Parameter Name="direccion" Type="String" />
                                <asp:Parameter Name="telefono" Type="String" />
                                <asp:Parameter Name="correo_electronico" Type="String" />
                                <asp:Parameter Name="estado" Type="Boolean" />
                                <asp:Parameter Name="fecha_registro" Type="DateTime" />
                            </InsertParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="nm" Type="String" />
                                <asp:Parameter Name="numero_identificacion" Type="String" />
                                <asp:Parameter Name="direccion" Type="String" />
                                <asp:Parameter Name="telefono" Type="String" />
                                <asp:Parameter Name="correo_electronico" Type="String" />
                                <asp:Parameter Name="estado" Type="Boolean" />
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
