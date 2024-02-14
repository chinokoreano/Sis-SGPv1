<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmServicios.aspx.cs" Inherits="SIS_CARLITOS.Vistas.frmServicios" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>



<%@ Register Assembly="DevExpress.Web.v22.2, Version=22.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          
        <ContentTemplate>
            <div class="card border-dark" style="max-width: 100rem;">
                <div class="card-header ph-card-header">Mantenimiento de Servicios</div>
                <div class="card-body" style="background-color: white">
                    <div class="table-responsive">

                        <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="dsServicio" KeyFieldName="id" Theme="PlasticBlue">
                            <Settings ShowFilterRow="True"></Settings>
                            <SettingsDataSecurity AllowDelete="False"></SettingsDataSecurity>

                            <SettingsSearchPanel Visible="True"></SettingsSearchPanel>
                            <Columns>
                                <dx:GridViewCommandColumn ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataTextColumn FieldName="id" ReadOnly="True" VisibleIndex="1" Caption="Id">
                                    <EditFormSettings Visible="False" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="nm_servicio" VisibleIndex="2" Caption="Servicio"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="prefijo" VisibleIndex="3" Caption="Prefijo"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="secuencia_inicial" VisibleIndex="4" Caption="Secuencia inicial"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Secuencia actual" FieldName="secuencia_actual" VisibleIndex="5">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataCheckColumn Caption="Estado" FieldName="estado" VisibleIndex="6">
                                </dx:GridViewDataCheckColumn>
                                
                                <dx:GridViewDataDateColumn FieldName="fecha_ingreso" VisibleIndex="7" Caption="Fecha ingreso"></dx:GridViewDataDateColumn>
                            </Columns>
                        </dx:ASPxGridView>
                         

                        <asp:SqlDataSource ID="dsServicio" runat="server" ConnectionString="<%$ ConnectionStrings:OPERADB_DAO %>" DeleteCommand="DELETE FROM [servicio] WHERE [id] = @id" InsertCommand="INSERT INTO [servicio] ([nm_servicio], [prefijo], [secuencia_inicial], [secuencia_actual], [estado], [fecha_ingreso]) VALUES (@nm_servicio, @prefijo, @secuencia_inicial, @secuencia_actual, @estado, getdate())" SelectCommand="SELECT * FROM [servicio]" UpdateCommand="UPDATE [servicio] SET [nm_servicio] = @nm_servicio, [prefijo] = @prefijo, [secuencia_inicial] = @secuencia_inicial, [secuencia_actual] = @secuencia_actual, [estado] = @estado, [fecha_ingreso] = @fecha_ingreso WHERE [id] = @id">
                            <DeleteParameters>
                                <asp:Parameter Name="id" Type="Int32" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:Parameter Name="nm_servicio" Type="String" />
                                <asp:Parameter Name="prefijo" Type="String" />
                                <asp:Parameter Name="secuencia_inicial" Type="Int32" />
                                <asp:Parameter Name="secuencia_actual" Type="Int32" />
                                <asp:Parameter Name="estado" Type="Boolean" />
                                <asp:Parameter Name="fecha_ingreso" Type="DateTime" />
                            </InsertParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="nm_servicio" Type="String" />
                                <asp:Parameter Name="prefijo" Type="String" />
                                <asp:Parameter Name="secuencia_inicial" Type="Int32" />
                                <asp:Parameter Name="secuencia_actual" Type="Int32" />
                                <asp:Parameter Name="estado" Type="Boolean" />
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
