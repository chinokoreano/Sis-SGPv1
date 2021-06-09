<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmGestiones.aspx.cs" Inherits="SIS_CARLITOS.Vistas.frmGestiones" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>



<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          
        <ContentTemplate>
            <div class="card border-dark" style="max-width: 100rem;">
                <div class="card-header ph-card-header">Mantenimiento de Gestiones</div>
                <div class="card-body" style="background-color: white">
                    <div class="table-responsive">
                        <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="dsGestiones1" KeyFieldName="id" Theme="PlasticBlue">
                            <Settings ShowFilterRow="True" />
                            <SettingsDataSecurity AllowDelete="False" />
                            <SettingsSearchPanel Visible="True" />
                            <Columns>
                                <dx:GridViewCommandColumn ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataTextColumn FieldName="id" ReadOnly="True" VisibleIndex="1" Caption="Id">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="nm" VisibleIndex="2" Caption="Gestión">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="estado" VisibleIndex="3" Caption="Estado">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn FieldName="fecha_registro" VisibleIndex="4" Caption="Fecha registro">
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn FieldName="estado_catalogo" VisibleIndex="5" Caption="Catálogo">
                                </dx:GridViewDataTextColumn>
                            </Columns>
                        </dx:ASPxGridView>
                        <asp:SqlDataSource ID="dsGestiones1" runat="server" ConnectionString="<%$ ConnectionStrings:OPERADB_DAO %>" DeleteCommand="DELETE FROM [gestion] WHERE [id] = @id" InsertCommand="INSERT INTO [gestion] ([id], [nm], [estado], [fecha_registro], [estado_catalogo]) VALUES (@id, @nm, @estado, @fecha_registro, @estado_catalogo)" SelectCommand="SELECT * FROM [gestion]" UpdateCommand="UPDATE [gestion] SET [nm] = @nm, [estado] = @estado, [fecha_registro] = @fecha_registro, [estado_catalogo] = @estado_catalogo WHERE [id] = @id">
                            <DeleteParameters>
                                <asp:Parameter Name="id" Type="Int32" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:Parameter Name="id" Type="Int32" />
                                <asp:Parameter Name="nm" Type="String" />
                                <asp:Parameter Name="estado" Type="Int32" />
                                <asp:Parameter Name="fecha_registro" Type="DateTime" />
                                <asp:Parameter Name="estado_catalogo" Type="Int32" />
                            </InsertParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="nm" Type="String" />
                                <asp:Parameter Name="estado" Type="Int32" />
                                <asp:Parameter Name="fecha_registro" Type="DateTime" />
                                <asp:Parameter Name="estado_catalogo" Type="Int32" />
                                <asp:Parameter Name="id" Type="Int32" />
                            </UpdateParameters>
                        </asp:SqlDataSource>
                    </div>
                    </div>

            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
