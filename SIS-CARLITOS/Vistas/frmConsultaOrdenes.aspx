<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmConsultaOrdenes.aspx.cs" Inherits="SIS_CARLITOS.Vistas.frmConsultaOrdenes" %>

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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="card border-dark" style="max-width: 100rem;">
                <div class="card-header ph-card-header">Generación de órdenes de servicio - Guías de envío</div>
                 <span id="procesando_div" style="display: none; position: relative; text-align: center">
                                        <img src="../Imagenes/ajax-loader.gif" id="procesando" alt="" />
                                    </span>
                <div class="card-body" style="background-color:white">
                    <asp:Label ID="lblMensaje" class="btn btn-success"  runat="server" visible="false" Text="" style="margin-bottom: 10px;"></asp:Label>
                    <asp:HyperLink ID="urlReporte" runat="server" class="btn btn-success" visible="false" Target="_blank">Desargar archivo generado</asp:HyperLink>
                    <div class="table-responsive">
                           <asp:GridView ID="grvOrdServicios"
                            CssClass="tabla_datos col-xs-12 table-bordered"
                            runat="server"
                            PagerStyle-CssClass="pager-style"
                            AutoGenerateColumns="False" ViewStateMode="Enabled" EmptyDataText="No existe información" AllowPaging="True" OnPageIndexChanging="grvClientes_PageIndexChanging" PageSize="5">

                            <PagerStyle CssClass="pager-style" />

                            <RowStyle CssClass="row-style" />
                            <AlternatingRowStyle CssClass="alernativedRow-style" />
                            <SelectedRowStyle CssClass="editRow-style" />
                            <EditRowStyle CssClass="editRow-style" />
                            <Columns>

                                <asp:TemplateField HeaderText="No.">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("orden") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl" runat="server" Text='<%# Bind("orden") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Id">
                                    <EditItemTemplate>
                                        <asp:TextBox runat="server" Text='<%# Bind("id") %>' ID="TextBox6"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblId" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Orden de Servicio">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("codigo_orden_servicio") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblOrdenServicio" runat="server" Text='<%# Bind("codigo_orden_servicio") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cliente">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("cliente") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblCliente" runat="server" Text='<%# Bind("cliente") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Servicio">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("servicio") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblServicio" runat="server" Text='<%# Bind("servicio") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fecha carga">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("fecha_carga") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblFechaCarga" runat="server" Text='<%# Bind("fecha_carga") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Oficina Carga" Visible="true">
                                    <EditItemTemplate>
                                        <asp:TextBox runat="server" Text='<%# Bind("oficina_carga") %>' ID="TextBox7"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblOficinaCarga" runat="server" Text='<%# Bind("oficina_carga") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Registros cargados" Visible="true">
                                    <EditItemTemplate>
                                        <asp:TextBox runat="server" Text='<%# Bind("numero_registros_cargados") %>' ID="TextBox7"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblRegistrosCargados" runat="server" Text='<%# Bind("numero_registros_cargados") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Usuario" Visible="true">
                                    <EditItemTemplate>
                                        <asp:TextBox runat="server" Text='<%# Bind("usuario_carga") %>' ID="TextBox7"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblUsuario" runat="server" Text='<%# Bind("usuario_carga") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Estado" Visible="true">
                                    <EditItemTemplate>
                                        <asp:TextBox runat="server" Text='<%# Bind("estado") %>' ID="TextBox7"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblEstado" runat="server" Text='<%# Bind("estado") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Detalle" Visible="true">
                                    <EditItemTemplate>
                                        <asp:TextBox runat="server" Text='<%# Bind("detalle") %>' ID="TextBox7"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblDetalle" runat="server" Text='<%# Bind("detalle") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Orden Servicio">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnImpOrdenServicio" runat="server" ImageUrl="~/Imagenes/documento.png" OnClientClick="mostrar_procesar()" OnClick="btnImpOrdenServicio_Click" />

                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="30px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Guías">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnImpGuias" runat="server" ImageUrl="~/Imagenes/documento.png" OnClientClick="mostrar_procesar()" OnClick="btnImpGuias_Click" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="30px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Eliminar" Visible="false">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnEliminarOrden" runat="server" ImageUrl="~/Imagenes/documento_eliminar.png" OnClick="btnEliminarOrden_Click" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="30px" />
                                </asp:TemplateField>
                            </Columns>

                        </asp:GridView>
                    </div>
                </div>
            </div>

          
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
