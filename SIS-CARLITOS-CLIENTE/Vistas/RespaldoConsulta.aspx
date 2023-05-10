<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RespaldoConsulta.aspx.cs" Inherits="SIS_CARLITOS.Vistas.RespaldoConsulta" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>



<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function mostrar_procesar() {
            document.getElementById('procesando_div').style.display = "";
            setTimeout('document.images["procesando_gif"].src="../Imagenes/ajax-loader.gif"', 200);
        }
    </script>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Consulta de Órdenes</h3>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
       <Triggers>
                       
        </Triggers>
  

    <contenttemplate>
        
            <div class="panel panel-default" runat="server" id="divBuscar">
                <div class="panel-heading"><strong>Parámetros de Búsqueda</strong></div>
                <div class="panel-body">
                    <div class="row">
                       
                        <div class="col-sm-3" style="padding-bottom: 5px;">
                            <asp:TextBox ID="txtfiltro1" placeholder="Parámetro de búsqueda" class="form-control" runat="server"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtfiltro1" ValidChars="ABCDEFGHIJKLMNÑOPQRSTUVWXYZ1234567890abcdefghijklmnñopqrstuvwxyz/-: " />
                        </div>
                        <div class="col-sm-1" style="padding-bottom: 5px;">
                            <asp:Button ID="btnBuscar" class="btn btn-info btn-sm" runat="server" Text="..." OnClick="btnBuscar_Click" />
                        </div>
                        <div class="col-sm-4" style="padding-bottom: 5px;">
                            <asp:Label ID="lblMensaje" class="text-danger" runat="server" Text="" Visible="false"></asp:Label>
                        </div>
                    </div>


                </div>
            </div>
            <%--<div class="form-horizontal" runat="server" id="divOrdenesServicio" visible="true">
                <div class="form-inline">
                    <div class="div-formualario">
                        <div class="table-responsive">
                            <asp:GridView ID="grvOrdenesServicio"
                                CssClass="tabla_datos col-xs-12 table-bordered"
                                runat="server"
                                PagerStyle-CssClass="pager-style"
                                AutoGenerateColumns="False" ViewStateMode="Enabled" EmptyDataText="No existe información" PageSize="5" AllowPaging="True" OnPageIndexChanging="grvOrdenesServicio_PageIndexChanging" AlternatingRowStyle-CssClass="EmptyDataRowStyle-BackColor" OnRowDataBound="grvOrdenesServicio_RowDataBound">
                                <PagerStyle CssClass="pager-style" />
                                <RowStyle CssClass="row-style" />
                                <AlternatingRowStyle CssClass="alernativedRow-style" />
                                <SelectedRowStyle CssClass="editRow-style" />
                                <EditRowStyle CssClass="editRow-style" />
                                <Columns>
                                    <asp:TemplateField HeaderText="No.">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox0" runat="server" Text='<%# Bind("orden") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblOrden" runat="server" Text='<%# Bind("orden") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Id" Visible="false">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("id") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblId" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Orden servicio">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("codigo_orden_servicio") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_codigo_orden_servicio" runat="server" Text='<%# Bind("codigo_orden_servicio") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cliente">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("cliente") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_cliente" runat="server" Text='<%# Bind("cliente") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Servicio">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("servicio") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_servicio" runat="server" Text='<%# Bind("servicio") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fecha carga">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("fecha_carga") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_fecha_carga" runat="server" Text='<%# Bind("fecha_carga") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Oficina carga">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("oficina_carga") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_oficina_carga" runat="server" Text='<%# Bind("oficina_carga") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Registros">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("numero_registros_cargados") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_numero_registros_cargados" runat="server" Text='<%# Bind("numero_registros_cargados") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Usuario">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("usuario_carga") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_usuario_carga" runat="server" Text='<%# Bind("usuario_carga") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Estado">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("estado") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_estado" runat="server" Text='<%# Bind("estado") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                           
                                            <asp:Button ID="btnEliminar" runat="server" class="btn btn-danger btn-sm" Text="Eliminar" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="30px" />
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                          
                                            <asp:Button ID="btnImprimirOrdenesServicio" runat="server" class="btn btn-success btn-sm" Text="Orden de Servicio" OnClick="btnImprimirOrdenesServicio_Click" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="30px" />
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                             <asp:Button ID="btnImprimirGuías" runat="server" class="btn btn-warning btn-sm" Text="Guías" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="30px" />
                                    </asp:TemplateField>
                                </Columns>

                            </asp:GridView>
                         
                        </div>
                    </div>
                </div>
            </div>--%>
        <dx:ASPxGridView ID="ASPxGridView1" KeyFieldName="id" OnCustomButtonCallback="ASPxGridView1_CustomButtonCallback" runat="server" DataSourceID="dsConsultaOrdenesServicio" Theme="Office2010Silver" ViewStateMode="Enabled">
            <Settings ShowFilterRow="True" HorizontalScrollBarMode="Visible" VerticalScrollBarMode="Visible"></Settings>
                <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True" ProcessFocusedRowChangedOnServer="True"></SettingsBehavior>
            <Columns>
                <dx:GridViewDataTextColumn FieldName="id" ReadOnly="True" VisibleIndex="0" Visible="False"></dx:GridViewDataTextColumn>    
                <dx:GridViewDataTextColumn FieldName="orden" ReadOnly="True" VisibleIndex="1" Caption="No."></dx:GridViewDataTextColumn>
                    
                    <dx:GridViewDataTextColumn FieldName="codigo_orden_servicio" VisibleIndex="2" Caption="Codigo orden"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="cliente" VisibleIndex="3" Caption="Cliente"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="servicio" VisibleIndex="4" Caption="Servicio"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn FieldName="fecha_carga" VisibleIndex="5" Caption="Fecha carga"></dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn FieldName="oficina_carga" VisibleIndex="6" Caption="Oficina carga"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="numero_registros_cargados" VisibleIndex="7" Caption="Envios"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="usuario_carga" VisibleIndex="8" Caption="Usuario"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="estado" VisibleIndex="9"></dx:GridViewDataTextColumn>
                    <dx:GridViewCommandColumn ShowNewButton="true" ShowEditButton="true" VisibleIndex="10" ButtonRenderMode="Image">
                        <CustomButtons>
                            <dx:GridViewCommandColumnCustomButton ID="Eliminar">
                                <Image ToolTip="Eliminar Orden de Servicio" Url="../imagenes/documento_eliminar.png" />
                            </dx:GridViewCommandColumnCustomButton>
                            <dx:GridViewCommandColumnCustomButton ID="ImprimirOS">
                                <Image ToolTip="Generar Orden de Servicio" Url="../imagenes/documento.png" />
                            </dx:GridViewCommandColumnCustomButton>
                            <dx:GridViewCommandColumnCustomButton ID="ImprimirGuia">
                                <Image ToolTip="Imprimir Guías" Url="../imagenes/guia.png" />
                            </dx:GridViewCommandColumnCustomButton>
                        </CustomButtons>
                    </dx:GridViewCommandColumn>
                </Columns>
        </dx:ASPxGridView>
        <asp:SqlDataSource runat="server" ID="dsConsultaOrdenesServicio" ConnectionString='<%$ ConnectionStrings:conDev %>' ProviderName='<%$ ConnectionStrings:conDev.ProviderName %>' SelectCommand="SPR_CONSULTA_ORDENES_SERVICIO" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:Parameter DefaultValue="1" Name="opcion" Type="Int32"></asp:Parameter>
                <asp:SessionParameter SessionField="idUsuario" DefaultValue="0" Name="id_usuario" Type="Int32"></asp:SessionParameter>
                <asp:Parameter DefaultValue="0" Name="orden_id" Type="Int32"></asp:Parameter>
            </SelectParameters>
        </asp:SqlDataSource>
         
    </contenttemplate>
     </asp:UpdatePanel>

    <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div runat="server" id="divReporte" style="margin-right: 100px; margin-left: 100px;">
                <rsweb:ReportViewer ID="rpvReporte" runat="server" Width="939px"></rsweb:ReportViewer>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>--%>
  
 
</asp:Content>
