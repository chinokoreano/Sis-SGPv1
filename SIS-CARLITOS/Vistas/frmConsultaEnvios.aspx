<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmConsultaEnvios.aspx.cs" Inherits="SIS_CARLITOS.Vistas.frmConsultaEnvios" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <script type="text/javascript">
        function mostrar_procesar() {
            document.getElementById('procesando_div').style.display = "";
            setTimeout('document.images["procesando_gif"].src="../Imagenes/ajax-loader.gif"', 200);
         }
         function mostrar_procesar2() {
            document.getElementById('procesando_div2').style.display = "";
            setTimeout('document.images["procesando_gif"].src="../Imagenes/ajax-loader.gif"', 200);
        }
    </script>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>

            <asp:PostBackTrigger ControlID="btnImprimir" />
            <asp:PostBackTrigger ControlID="btnbuscar" />
        </Triggers>
        <ContentTemplate>
            <div class="card border-dark" style="max-width: 100rem;">
                <div class="card-header ph-card-header">Consulta de eventos</div>
                <div class="card-body" style="background-color: white">
                    <asp:Label ID="lblMensaje" class="btn btn-success" runat="server" Visible="false" Text="" Style="margin-bottom: 10px;"></asp:Label>
                   
                    <div class="row">
                        <div class="col-sm-3" style="padding-bottom: 5px;">

                            <asp:DropDownList ID="ddlFiltro" CssClass="form-control dropdown form-control-sm" Visible="true" runat="server" OnSelectedIndexChanged="ddlFiltro_SelectedIndexChanged1" AutoPostBack="True">
                                <asp:ListItem Value="1">Codigo Paquete</asp:ListItem>
                                <asp:ListItem Value="2">Destinatario</asp:ListItem>
                                <asp:ListItem Value="3">Orden Trabajo</asp:ListItem>
                                <asp:ListItem Value="4">Fecha Carga</asp:ListItem>

                            </asp:DropDownList>
                        </div>
                    </div>
                     <div class="row" runat="server" >
                        <div class="col-sm-3" style="padding-bottom: 5px;">
                            <dx:ASPxComboBox ID="cmbClientes" runat="server" CssClass="form-control dropdown form-control-sm" Width="100%" NullValueItemDisplayText= "{0} ({1})" NullText="Cliente Empresarial" NullTextDisplayMode="UnfocusedAndFocused" ToolTip="Punto de Origen" AutoPostBack="True" Enabled="False" LoadDropDownOnDemand="True" >
                            </dx:ASPxComboBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-3" style="padding-bottom: 5px;">
                            <asp:TextBox ID="txtFiltro1" runat="server" placeholder="" MaxLength="100" CssClass="form-control form-control-sm" TextMode="SingleLine"></asp:TextBox>

                        </div>

                    </div>
                    <div class="row">
                        <div class="col-sm-3" style="padding-bottom: 5px;">
                            <asp:TextBox ID="txtFechaCargaInicio" runat="server" Visible="false" placeholder="Fecha inicio" MaxLength="20" CssClass="form-control form-control-sm" TextMode="Date" ToolTip="Fecha carga inicial"></asp:TextBox>
                        </div>
                        <div class="col-sm-3" style="padding-bottom: 5px;">
                            <asp:TextBox ID="txtFechaCargaFin" runat="server" Visible="false" placeholder="Fecha final" MaxLength="20" CssClass="form-control form-control-sm" TextMode="Date" ToolTip="Fecha carga final"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-3" style="padding-bottom: 5px;">
                            <asp:Button ID="btnBuscar" class="btn btn-warning" runat="server" Text="Buscar" OnClientClick="mostrar_procesar();" OnClick="btnBuscar_Click" />
                             <span id="procesando_div" style="display: none; position: absolute; text-align: center">
                            <img src="../Imagenes/ajax-loader.gif" id="procesando" alt="" />
                        </span>
                        </div>
                    </div>
                    <div class="table-responsive">
                        <asp:GridView ID="grvEnvios"
                            CssClass="tabla_datos col-xs-12 table-bordered"
                            runat="server"
                            PagerStyle-CssClass="pager-style"
                            AutoGenerateColumns="False" ViewStateMode="Enabled" EmptyDataText="No existe información" PageSize="5" AllowPaging="True" OnPageIndexChanging="grvEnvios_PageIndexChanging">

                            <PagerStyle CssClass="pager-style" />

                            <RowStyle CssClass="row-style" />
                            <AlternatingRowStyle CssClass="alernativedRow-style" />
                            <SelectedRowStyle CssClass="editRow-style" />
                            <EditRowStyle CssClass="editRow-style" />
                            <Columns>
                                <asp:TemplateField HeaderText="Seleccionar">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnImgSeleccionar" runat="server" OnClick="btnImgSeleccionar_Click" ImageUrl="~/Imagenes/seleccionar.png" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="30px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="No.">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("orden") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("orden") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Identificador" Visible="false">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox100" runat="server" Text='<%# Bind("identificador") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblId" runat="server" Text='<%# Bind("identificador") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Código">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("codigo") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("codigo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cod. Alterno">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("codigo_alterno") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("codigo_alterno") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fecha carga">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("fecha_evento_carga") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("fecha_evento_carga") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fec. Ultm. Evento">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("fecha_ultimo_evento") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("fecha_ultimo_evento") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Destinatario">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("destinatario") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("destinatario") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Dirección">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("direccion") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("direccion") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Referencia">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("referencia") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label9" runat="server" Text='<%# Bind("referencia") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Provincia">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("provincia") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label10" runat="server" Text='<%# Bind("provincia") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cantón">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("canton") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label11" runat="server" Text='<%# Bind("canton") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cod. Postal">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox12" runat="server" Text='<%# Bind("codigo_postal") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label12" runat="server" Text='<%# Bind("codigo_postal") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ultm. Gestión">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox13" runat="server" Text='<%# Bind("ultima_gestion") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label13" runat="server" Text='<%# Bind("ultima_gestion") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Oficina">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox14" runat="server" Text='<%# Bind("Oficina") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label14" runat="server" Text='<%# Bind("Oficina") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Orden Servicio">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox15" runat="server" Text='<%# Bind("orden_servicio") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label15" runat="server" Text='<%# Bind("orden_servicio") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Usuario">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox16" runat="server" Text='<%# Bind("usuario") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label16" runat="server" Text='<%# Bind("usuario") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Receptor">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox17" runat="server" Text='<%# Bind("receptor") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label17" runat="server" Text='<%# Bind("receptor") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 
                            </Columns>
                        </asp:GridView>
                    </div>

                    <div class="row" runat="server" visible="false" id="divBotonImprimir" style="padding-top: 10px;">
                        <div class="col-sm-3" style="padding-bottom: 5px;">
                            <asp:Button ID="btnImprimir" runat="server" class="btn btn-success" Text="Exportar a Excel" OnClientClick="mostrar_procesar2();" OnClick="btnImprimir_Click" />
                            <span id="procesando_div2" style="display: none; position: absolute; text-align: center">
                            <img src="../Imagenes/ajax-loader.gif" id="procesando" alt="" />
                        </div>
                    </div>
                                       
                    <div class="table-responsive">
                        <asp:GridView ID="grvEventos" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="tabla_datos col-xs-12 table-bordered" EmptyDataText="No existe información" OnPageIndexChanging="grvEnvios_PageIndexChanging" PagerStyle-CssClass="pager-style" PageSize="5" ViewStateMode="Enabled">
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
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("orden") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ID" Visible="False">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("id") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblId" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Identificador" Visible="False">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("identificador") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("identificador") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Código">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("codigo") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("codigo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Gestión">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("gestion") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("gestion") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fecha registro">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("fecha_registro") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("fecha_registro") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Oficina">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("oficina") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("oficina") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="usuario" HeaderText="Usuario" />
                                <asp:BoundField DataField="observacion" HeaderText="Observación" />
                            </Columns>
                        </asp:GridView>
                    </div>

                </div>
            </div>
            <div runat="server" id="divReporte" style="margin-right: 100px; margin-left: 100px;">
                <rsweb:ReportViewer ID="rpvReporte" Visible="false" runat="server" Height="300px" ShowPageNavigationControls="False" ShowZoomControl="False" Width="80%" ShowRefreshButton="False" ShowCredentialPrompts="False" ShowBackButton="False" ShowFindControls="False" ShowDocumentMapButton="False" ShowParameterPrompts="False" ShowPromptAreaButton="False" ShowWaitControlCancelLink="True"></rsweb:ReportViewer>
            </div>


            </span>


        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
