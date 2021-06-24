<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmUsuarios.aspx.cs" Inherits="SIS_CARLITOS.Vistas.frmUsuarios" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>



<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">

        <ContentTemplate>
            <div class="card border-dark" style="max-width: 100rem;">
                <div class="card-header ph-card-header">Mantenimiento de Usuarios</div>
                <div class="card-body" style="background-color: white">
                    <div class="table-responsive">
                        <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="dsUsuarios" KeyFieldName="id" Theme="PlasticBlue">
                            <Settings ShowFilterRow="True"></Settings>
                            <SettingsDataSecurity AllowDelete="False"></SettingsDataSecurity>

                            <SettingsSearchPanel Visible="True"></SettingsSearchPanel>
                            <Columns>
                                <dx:GridViewCommandColumn ShowNewButtonInHeader="True" VisibleIndex="0" ShowEditButton="True"></dx:GridViewCommandColumn>
                                <dx:GridViewDataTextColumn FieldName="id" ReadOnly="True" VisibleIndex="1" Caption="Id">
                                    <EditFormSettings Visible="False" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="nm" VisibleIndex="2" Caption="Nombres"></dx:GridViewDataTextColumn>
                                <%--<dx:GridViewDataTextColumn FieldName="tipo_documento1" VisibleIndex="2"></dx:GridViewDataTextColumn>--%>

                                <dx:GridViewDataComboBoxColumn FieldName="tipo_documento" Caption="Tipo Documento" SortIndex="0" SortOrder="Ascending" AdaptivePriority="1" Settings-AllowAutoFilter="Default" Settings-AllowFilterBySearchPanel="True" VisibleIndex="3">
                                    <PropertiesComboBox DataSourceID="dsTipoDocumento" ValueField="id" TextField="nm" ValueType="System.Int32" />
                                    <Settings AllowHeaderFilter="True" AllowAutoFilter="False" SortMode="DisplayText" />
                                    <SettingsHeaderFilter Mode="CheckedList" />
                                </dx:GridViewDataComboBoxColumn>

                                <dx:GridViewDataTextColumn FieldName="numero_documento" VisibleIndex="6" Caption="Identificación"></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="direccion" VisibleIndex="7" Caption="Dirección">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="telefono" VisibleIndex="8" Caption="Teléfonos">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataCheckColumn FieldName="activo" VisibleIndex="9" Caption="Estado">
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataDateColumn FieldName="fecha_ingreso" VisibleIndex="10" Caption="Fecha ingreso"></dx:GridViewDataDateColumn>
                                <dx:GridViewDataDateColumn FieldName="fecha_ultm_act" readonly="true" VisibleIndex="11" Caption="Fecha act.">
                                    <EditFormSettings Visible="False" />
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn FieldName="usuario" VisibleIndex="12" Caption="Usuario">
                                </dx:GridViewDataTextColumn>
                                <%--<dx:GridViewDataTextColumn FieldName="tipo_usuario" VisibleIndex="11">
                                </dx:GridViewDataTextColumn>--%>

                                <dx:GridViewDataComboBoxColumn FieldName="tipo_usuario" Caption="Tipo Usuario" SortIndex="0" SortOrder="Ascending" AdaptivePriority="1" Settings-AllowAutoFilter="Default" Settings-AllowFilterBySearchPanel="True" VisibleIndex="4">
                                    <PropertiesComboBox DataSourceID="dsTipoUsuario" ValueField="id" TextField="nm" ValueType="System.Int32" />
                                    <Settings AllowHeaderFilter="True" AllowAutoFilter="False" SortMode="DisplayText" />
                                    <SettingsHeaderFilter Mode="CheckedList" />
                                </dx:GridViewDataComboBoxColumn>

                                <dx:GridViewDataTextColumn FieldName="contrasenia" VisibleIndex="13" Caption="Contrasenia">
                                    <PropertiesTextEdit Password="True" Size="8">
                                    </PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn FieldName="fecha_ultm_act_contrasenia" Visible="false" VisibleIndex="14">
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataDateColumn FieldName="fecha_ultm_autenticacion" visible="false" VisibleIndex="15">
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataCheckColumn FieldName="cambio_contrasenia" VisibleIndex="16" Caption="Contraseña cambiada">
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataComboBoxColumn FieldName="id_oficina" Caption="Oficina" SortIndex="0" SortOrder="Ascending" AdaptivePriority="1" Settings-AllowAutoFilter="Default" Settings-AllowFilterBySearchPanel="True" VisibleIndex="5">
                                    <PropertiesComboBox DataSourceID="dsOficina" ValueField="id" TextField="nm_oficina" ValueType="System.Int32" />
                                    <Settings AllowHeaderFilter="True" AllowAutoFilter="False" SortMode="DisplayText" />
                                    <SettingsHeaderFilter Mode="CheckedList" />
                                </dx:GridViewDataComboBoxColumn>
                            </Columns>
                        </dx:ASPxGridView>
                        <asp:SqlDataSource ID="dsUsuarios" runat="server" ConnectionString="<%$ ConnectionStrings:OPERADB_DAO %>" DeleteCommand="DELETE FROM [usuario] WHERE [id] = @id" InsertCommand="INSERT INTO [usuario] ([nm], [tipo_documento], [numero_documento], [direccion], [telefono], [activo], [fecha_ingreso], [fecha_ultm_act], [usuario], [tipo_usuario], [contrasenia_encriptada], [fecha_ultm_act_contrasenia], [fecha_ultm_autenticacion], [id_oficina],[cambio_contrasenia]) VALUES (@nm, @tipo_documento, @numero_documento, @direccion, @telefono, @activo, GETDATE(), GETDATE(), @usuario, @tipo_usuario, [dbo].[ENCRIPTA_PASS](@contrasenia) , @fecha_ultm_act_contrasenia, @fecha_ultm_autenticacion, @id_oficina,0)" SelectCommand="SELECT [id],[nm],[tipo_documento],[numero_documento],[direccion],[telefono],[activo],[fecha_ingreso],[fecha_ultm_act],[usuario],[tipo_usuario],[dbo].[desencriptar_pass](contrasenia_encriptada) as contrasenia,[fecha_ultm_act_contrasenia],[fecha_ultm_autenticacion],[id_oficina],[cambio_contrasenia] FROM [dbo].[usuario] order by [fecha_ingreso]" UpdateCommand="UPDATE [usuario] SET [nm] = @nm, [tipo_documento] = @tipo_documento, [numero_documento] = @numero_documento, [direccion] = @direccion, [telefono] = @telefono, [activo] = @activo, [fecha_ingreso] = @fecha_ingreso, [fecha_ultm_act] = getdate(), [usuario] = @usuario, [tipo_usuario] = @tipo_usuario, [contrasenia] = @contrasenia, [fecha_ultm_act_contrasenia] = @fecha_ultm_act_contrasenia, [fecha_ultm_autenticacion] = GETDATE(), [id_oficina] = @id_oficina ,[contrasenia_encriptada] = [dbo].[ENCRIPTA_PASS](@contrasenia),[cambio_contrasenia]=@cambio_contrasenia WHERE [id] = @id">
                            <DeleteParameters>
                                <asp:Parameter Name="id" Type="Int32" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:Parameter Name="nm" Type="String" />
                                <asp:Parameter Name="tipo_documento" Type="Int32" />
                                <asp:Parameter Name="numero_documento" Type="String" />
                                <asp:Parameter Name="direccion" Type="String" />
                                <asp:Parameter Name="telefono" Type="String" />
                                <asp:Parameter Name="activo" Type="Boolean" />
                                <asp:Parameter Name="fecha_ingreso" Type="DateTime" />
                                <asp:Parameter Name="fecha_ultm_act" Type="DateTime" />
                                <asp:Parameter Name="usuario" Type="String" />
                                <asp:Parameter Name="tipo_usuario" Type="Int32" />
                                <asp:Parameter Name="contrasenia" Type="String" />
                                <asp:Parameter Name="fecha_ultm_act_contrasenia" Type="DateTime" />
                                <asp:Parameter Name="fecha_ultm_autenticacion" Type="DateTime" />
                                <asp:Parameter Name="id_oficina" Type="Int32" />
                                <asp:Parameter Name="cambio_contrasenia" Type="Boolean" />
                            </InsertParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="nm" Type="String" />
                                <asp:Parameter Name="tipo_documento" Type="Int32" />
                                <asp:Parameter Name="numero_documento" Type="String" />
                                <asp:Parameter Name="direccion" Type="String" />
                                <asp:Parameter Name="telefono" Type="String" />
                                <asp:Parameter Name="activo" Type="Boolean" />
                                <asp:Parameter Name="fecha_ingreso" Type="DateTime" />
                                <asp:Parameter Name="usuario" Type="String" />
                                <asp:Parameter Name="tipo_usuario" Type="Int32" />
                                <asp:Parameter Name="contrasenia" Type="String" />
                                <asp:Parameter Name="fecha_ultm_act_contrasenia" Type="DateTime" />
                                <asp:Parameter Name="fecha_ultm_autenticacion" Type="DateTime" />
                                <asp:Parameter Name="id_oficina" Type="Int32" />
                                <asp:Parameter Name="id" Type="Int32" />
                                <asp:Parameter Name="cambio_contrasenia" Type="Boolean" />
                            </UpdateParameters>
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="dsTipoDocumento" runat="server" ConnectionString="<%$ ConnectionStrings:OPERADB_DAO %>" SelectCommand="SELECT * FROM [tipo_documento]">
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="dsTipoUsuario" runat="server" ConnectionString="<%$ ConnectionStrings:OPERADB_DAO %>" SelectCommand="SELECT * FROM [tipo_usuario]">
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="dsOficina" runat="server" ConnectionString="<%$ ConnectionStrings:OPERADB_DAO %>" SelectCommand="SELECT * FROM [oficina]">
                        </asp:SqlDataSource>
                    </div>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
