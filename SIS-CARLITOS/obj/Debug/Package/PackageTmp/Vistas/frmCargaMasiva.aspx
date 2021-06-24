<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCargaMasiva.aspx.cs" Inherits="SIS_CARLITOS.Vistas.frmCargaMasiva" %>

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
    <%--<h3>Carga Masiva</h3>--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnGuardar" />
        </Triggers>
        <ContentTemplate>

            <div class="card border-dark" style="max-width: 100rem;" runat="server" id="divBuscar">
                <div class="card-header ph-card-header">Cliente</div>
                <div class="card-body" style="background-color:white">
            

                    <div class="row">
                        <div class="col-sm-3" style="padding-bottom: 5px;">

                            <asp:DropDownList class="form-control dropdown form-control-sm" ID="ddlTipoFiltro" runat="server" AutoPostBack="true">
                                <asp:ListItem Value="1" Selected="True">Nombre o Razón Social</asp:ListItem>
                                <asp:ListItem Value="2">Número de identificación</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-3" style="padding-bottom: 5px;">
                            <asp:TextBox ID="txtfiltro1" placeholder="Cliente" class="form-control form-control-sm" runat="server"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtfiltro1" ValidChars="ABCDEFGHIJKLMNÑOPQRSTUVWXYZ1234567890abcdefghijklmnñopqrstuvwxyz " />
                        </div>
                        <div class="col-sm-1" style="padding-bottom: 5px;">
                            <asp:Button ID="btnBuscar" class="btn btn-warning btn-sm" runat="server" Text="..." OnClick="btnBuscar_Click" />
                        </div>
                        <div class="col-sm-4" style="padding-bottom: 5px;">
                            <asp:Label ID="lblMensaje" class="text-danger" runat="server" Text="" Visible="false"></asp:Label>
                        </div>
                    </div>

                    <div class="table-responsive" runat="server" id="divClientes">
                                    <asp:GridView ID="grvClientes"
                                        CssClass="tabla_datos col-xs-12 table-bordered"
                                        runat="server"
                                        PagerStyle-CssClass="pager-style"
                                        AutoGenerateColumns="False" ViewStateMode="Enabled" EmptyDataText="No existe información" PageSize="5" AllowPaging="True" OnPageIndexChanging="grvClientes_PageIndexChanging">
                                        
                                        <RowStyle CssClass="row-style" />
                                        <AlternatingRowStyle CssClass="alernativedRow-style" />
                                        <SelectedRowStyle CssClass="editRow-style" />
                                        <EditRowStyle CssClass="editRow-style" />
                                        <Columns>

                                             <asp:TemplateField HeaderText="IdCliente">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("id_cliente") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblId" runat="server" Text='<%# Bind("id_cliente") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Contrato">
                                                <EditItemTemplate>
                                                    <asp:TextBox runat="server" Text='<%# Bind("contrato") %>' ID="TextBox6"></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblNumeroContrato" runat="server" Text='<%# Bind("contrato") %>' ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                                                                       
                                            <asp:TemplateField HeaderText="Nombre o Razón Social">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("nm_cliente") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Nm_Cliente" runat="server" Text='<%# Bind("nm_cliente") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Identificación">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("numero_identificacion") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Numero_Identificacion" runat="server" Text='<%# Bind("numero_identificacion") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Dirección">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("direccion") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("direccion") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Teléfono">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("telefono") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("telefono") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="IdContrato" Visible="false">
                                                <EditItemTemplate>
                                                    <asp:TextBox runat="server" Text='<%# Bind("id_codigo_contrato") %>' ID="TextBox7"></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIdContrato" runat="server" Text='<%# Bind("id_codigo_contrato") %>' ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Seleccionar">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnImgSeleccionar" runat="server" OnClick="btnImgSeleccionar_Click" ImageUrl="~/Imagenes/seleccionar.png" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="30px" />
                                            </asp:TemplateField>
                                        </Columns>

                                    </asp:GridView>
                                </div>

                </div>
            </div>

           
            <br />
             <div class="card border-dark" style="max-width: 100rem;" runat="server" id="divDatosCarga">
                <div class="card-header ph-card-header">Carga de datos</div>
                <div class="card-body" style="background-color:white">
                    <div class="row">
                        <div class="col-sm-3" style="padding-bottom: 5px;">
                            <asp:TextBox runat="server" ID="txtIdCliente" CssClass="form-control form-control-sm" placeholder="IdCliente" MaxLength="100" ReadOnly="True" />
                        </div>
                         <div class="col-sm-3" style="padding-bottom: 5px;">
                            <asp:TextBox runat="server" ID="txtIdentificacion" CssClass="form-control form-control-sm text-uppercase" AutoCompleteType="Enabled" placeholder="Número de Identificación" MaxLength="20" ReadOnly="True" />
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtIdentificacion"
                                ValidChars="ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz0123456789 "></cc1:FilteredTextBoxExtender>
                        </div>
                        <div class="col-sm-6" style="padding-bottom: 5px;">
                            <asp:TextBox runat="server" ID="txtCliente" CssClass="form-control form-control-sm text-uppercase" AutoCompleteType="Enabled" placeholder="Nombre o Razón Social" MaxLength="100" ReadOnly="True" />
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtCliente"
                                ValidChars="ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz0123456789 "></cc1:FilteredTextBoxExtender>
                        </div>
                       
                    </div>
                    <div class="row">
                        <div class="col-sm-3" style="padding-bottom: 5px;">
                            <dx:ASPxComboBox ID="cmbLocalidad" runat="server" CssClass="form-control dropdown form-control-sm" Width="100%" NullValueItemDisplayText="{0} ({1})" NullText="Punto de Carga o Retiro" NullTextDisplayMode="UnfocusedAndFocused" ToolTip="Punto de Origen">
                                    
                                </dx:ASPxComboBox>
                        </div>
                        <div class="col-sm-3" style="padding-bottom: 5px;">
                            <asp:DropDownList ID="ddlServicio" runat="server" CssClass="form-control dropdown form-control-sm" AutoPostBack="true" ToolTip="Servicio"></asp:DropDownList>
                        </div>
                        <div class="col-sm-6">
                            <asp:TextBox runat="server" ID="txtObservacion" CssClass="form-control form-control-sm text-uppercase" AutoCompleteType="Enabled" placeholder="Detalle" MaxLength="100" />
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtObservacion"
                                ValidChars="ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz0123456789 "></cc1:FilteredTextBoxExtender>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-9">
                            <asp:FileUpload ID="FupArchivo" CssClass="form-control form-control-sm text-uppercase" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <div runat="server" id="divControl" visible="false">
                <div class="row">
                    <div class="col-sm-2">
                        <asp:LinkButton ID="btnGuardar" runat="server" class="btn btn-warning" OnClick="btnGuardar_Click" text="Grabar" OnClientClick="mostrar_procesar();"></asp:LinkButton>
                        <span id="procesando_div" style="display: none; position: absolute; text-align: center">
                            <img src="../Imagenes/ajax-loader.gif" id="procesando" alt="" />
                        </span>
                    </div>
                    <div class="col-sm-6">
                        <asp:Label ID="lblMensaje1" class="label label-success" runat="server" Text=""></asp:Label>
                    </div>
                </div>

            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
