<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCargaManual.aspx.cs" Inherits="SIS_CARLITOS.Vistas.frmCargaManual" %>

<%@ Register Assembly="DevExpress.Web.v22.2, Version=22.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
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
                <div class="card-header ph-card-header">Buscar Cliente</div>
                <div class="card-body" style="background-color: white">
                    <div class="row">
                        <div class="col-sm-3" style="padding-bottom: 5px;">

                            <asp:DropDownList class="form-control dropdown form-control-sm" ID="ddlTipoFiltro" runat="server" AutoPostBack="true">
                                <asp:ListItem Value="1" Selected="True">Nombre o Razón Social</asp:ListItem>
                                <asp:ListItem Value="2">Número de identificación</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-3" style="padding-bottom: 5px;">
                            <asp:TextBox ID="txtfiltro1" placeholder="Cliente" class="form-control form-control-sm" runat="server" onkeypress="hideOnKeyPress()"></asp:TextBox>
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
                                        <asp:Label ID="lblNumeroContrato" runat="server" Text='<%# Bind("contrato") %>'></asp:Label>
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
                                        <asp:Label ID="lblIdContrato" runat="server" Text='<%# Bind("id_codigo_contrato") %>'></asp:Label>
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
                <div class="card-body" style="background-color: white">
                    <div class="container py-3">
                        <div id="informacion-personal">
                            <div class="row justify-content-center">
                                <!--Doble columna!-->

                                <div class="col-12 col-md-6">
                                    
                                        <div class="col-sm-12" style="padding-bottom: 5px;">
                                            <dx:ASPxComboBox ID="cmbLocalidad" runat="server" CssClass="form-control dropdown form-control-sm" Width="100%" NullValueItemDisplayText="{0} ({1})" NullText="Punto de Carga o Retiro" NullTextDisplayMode="UnfocusedAndFocused" ToolTip="Punto de Origen" OnSelectedIndexChanged="cmbLocalidad_SelectedIndexChanged">
                                            </dx:ASPxComboBox>
                                        </div>
                                        <div class="col-sm-12" style="padding-bottom: 5px;">
                                            <asp:DropDownList ID="ddlServicio" runat="server" CssClass="form-control dropdown form-control-sm" AutoPostBack="true" ToolTip="Servicio"></asp:DropDownList>
                                        </div>
                                        <div class="col-sm-12">
                                            <asp:TextBox runat="server" ID="txtObservacion" CssClass="form-control form-control-sm text-uppercase" AutoCompleteType="Enabled" placeholder="Detalle" MaxLength="100" />
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtObservacion"
                                                ValidChars="ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz0123456789 "></cc1:FilteredTextBoxExtender>
                                        </div>
                                       
                                    
                                </div>

                                <div class="col-12 col-md-6">
                                   
                                        <div class="col-sm-10" style="padding-bottom: 5px;">
                                            <asp:TextBox runat="server" ID="txtIdCliente" CssClass="form-control form-control-sm" placeholder="IdCliente" MaxLength="100" ReadOnly="True" BackColor="#FFFF99"/>
                                        </div>
                                    
                                    
                                        <div class="col-sm-10" style="padding-bottom: 5px;">
                                            <asp:TextBox runat="server" ID="txtIdentificacion" CssClass="form-control form-control-sm text-uppercase" AutoCompleteType="Enabled" placeholder="Número de Identificación" MaxLength="20" ReadOnly="True" BackColor="#FFFF99" />
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtIdentificacion"
                                                ValidChars="ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz0123456789:/ "></cc1:FilteredTextBoxExtender>
                                        </div>
                                   
                                        <div class="col-sm-10" style="padding-bottom: 5px;">
                                            <asp:TextBox runat="server" ID="txtCliente" CssClass="form-control form-control-sm text-uppercase" AutoCompleteType="Enabled" placeholder="Nombre o Razón Social" MaxLength="100" ReadOnly="True" BackColor="#FFFF99" />
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtCliente"
                                                ValidChars="ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz0123456789 "></cc1:FilteredTextBoxExtender>
                                        </div>
                                    
                                </div>
                                
                            </div>
                        </div>
                    </div>




                </div>
            </div>

        <br />
            <div class="card border-dark" style="max-width: 100rem;" runat="server" id="divRegistros">
                <div class="card-header ph-card-header">Listado de envíos</div>
                <div class="card-body" style="background-color: white">
                    <div class="container py-3">
                        <div id="divDetalleEnvios">
                            <asp:TextBox ID="txtOT" runat="server" Visible="false"></asp:TextBox>
                             <div class="table-responsive">
                                 <asp:HiddenField ID="hdfOtTemporal" runat="server" />

                                <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" EnableTheming="True" Theme="PlasticBlue" DataSourceID="dsRegEnviosManual" KeyFieldName="id" OnRowValidating="ASPxGridView1_RowValidating">
                                    
                                    <SettingsEditing Mode="Inline">
                                    </SettingsEditing>
                                    <SettingsBehavior ConfirmDelete="True" />
                                    
                                    <EditFormLayoutProperties ColCount="3" ColumnCount="3" AlignItemCaptionsInAllGroups="True">
                                        <Items>
                                            <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="codigo" HorizontalAlign="Left">
                                            </dx:GridViewColumnLayoutItem>
                                            <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="codigo_alterno">
                                            </dx:GridViewColumnLayoutItem>
                                            <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="dato_adicional1">
                                            </dx:GridViewColumnLayoutItem>
                                            <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="destinatario">
                                            </dx:GridViewColumnLayoutItem>
                                            <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="locacion">
                                            </dx:GridViewColumnLayoutItem>
                                                                                                                                                                             <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="dato_adicional2">
                                            </dx:GridViewColumnLayoutItem>
                                            <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="direccion">
                                            </dx:GridViewColumnLayoutItem>
                                            <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="referencia">
                                            </dx:GridViewColumnLayoutItem>
                                            <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="seguro">
                                            </dx:GridViewColumnLayoutItem>
                                            <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="codigo_postal">
                                            </dx:GridViewColumnLayoutItem>
                                            <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="telefono">
                                            </dx:GridViewColumnLayoutItem>
                                            <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="monto_seguro">
                                            </dx:GridViewColumnLayoutItem>
                                            <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="peso">
                                            </dx:GridViewColumnLayoutItem>
                                            <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="tipo_contenido">
                                            </dx:GridViewColumnLayoutItem>
                                            <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="alto" Visible="False">
                                            </dx:GridViewColumnLayoutItem>
                                            <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="profundidad" Visible="False">
                                            </dx:GridViewColumnLayoutItem>
                                            <dx:GridViewColumnLayoutItem ColSpan="1" ColumnName="ancho" Visible="False">
                                            </dx:GridViewColumnLayoutItem>
                                            <dx:EditModeCommandLayoutItem ColSpan="2" ColumnSpan="2" HorizontalAlign="Right">
                                            </dx:EditModeCommandLayoutItem>
                                        </Items>
                                        <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit">
                                            <GridSettings StretchLastItem="True">
                                            </GridSettings>
                                        </SettingsAdaptivity>
                                        <SettingsItems Width="250px" />
                                    </EditFormLayoutProperties>
                                    <Columns>
                                        <%--<dx:GridViewDataDropDownEditColumn Caption="Locación1" VisibleIndex="3">
                                        </dx:GridViewDataDropDownEditColumn>--%>

                                        <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewDataTextColumn Caption="Id" VisibleIndex="1" FieldName="id" ReadOnly="True" Visible="False">
                                            <EditFormSettings Visible="False" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn VisibleIndex="2" FieldName="identificador" Visible="False">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Código" VisibleIndex="3" FieldName="codigo" Visible="False">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Código alterno" VisibleIndex="5" FieldName="codigo_alterno">
                                        </dx:GridViewDataTextColumn>

                                        <dx:GridViewDataComboBoxColumn FieldName="locacion" Caption="Destino" SortIndex="0" SortOrder="Ascending" AdaptivePriority="1" Settings-AllowAutoFilter="Default" Settings-AllowFilterBySearchPanel="True" VisibleIndex="6">
                                            <PropertiesComboBox DataSourceID="dsLocacion" ValueField="id_canton" TextField="nm_canton" ValueType="System.String" />
                                            <Settings AllowHeaderFilter="True" AllowAutoFilter="False" SortMode="DisplayText" />
                                            <SettingsHeaderFilter Mode="CheckedList" />
                                        </dx:GridViewDataComboBoxColumn>

                                        <%--<dx:GridViewDataTextColumn Caption="Locación" VisibleIndex="6" FieldName="locacion">
                                        </dx:GridViewDataTextColumn>--%>
                                        <dx:GridViewDataTextColumn Caption="Dirección" VisibleIndex="7" FieldName="direccion">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Referencia" VisibleIndex="8" FieldName="referencia">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Código postal" VisibleIndex="9" FieldName="codigo_postal">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Monto seguro" FieldName="monto_seguro" VisibleIndex="14">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Contenido" FieldName="tipo_contenido" VisibleIndex="12">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataCheckColumn Caption="Seguro" VisibleIndex="13" FieldName="seguro">
                                        </dx:GridViewDataCheckColumn>
                                        <dx:GridViewDataTextColumn Caption="Peso" VisibleIndex="11" FieldName="peso">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Teléfono" VisibleIndex="10" FieldName="telefono">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Destinatario" FieldName="destinatario" VisibleIndex="4">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Dato adicional1" FieldName="dato_adicional1" VisibleIndex="15">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Dato adicional2" FieldName="dato_adicional2" VisibleIndex="16">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Alto" FieldName="alto" VisibleIndex="17" Visible="False">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Profundidad" FieldName="profundidad" VisibleIndex="18" Visible="False">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Ancho" FieldName="ancho" VisibleIndex="19" Visible="False">
                                        </dx:GridViewDataTextColumn>
                                    </Columns>
                                    <Styles>
                                        <EditForm>
                                            <Paddings Padding="0px" PaddingBottom="0px" PaddingLeft="0px" PaddingRight="0px" PaddingTop="0px" />
                                        </EditForm>
                                    </Styles>
                                </dx:ASPxGridView> 
                                <asp:SqlDataSource ID="dsRegEnviosManual" runat="server" ConnectionString="<%$ ConnectionStrings:OPERADB_DAO %>" 
                                    DeleteCommand="DELETE FROM [paquete_temporal_cm] WHERE [id] = @id" 
                                    InsertCommand="INSERT INTO [paquete_temporal_cm] ([identificador], [codigo], [codigo_alterno], [locacion], [direccion], [referencia], [codigo_postal], [monto_seguro], [tipo_contenido], [seguro], [peso], [telefono], [destinatario], [dato_adicional1], [dato_adicional2], [alto], [profundidad], [ancho]) 
                                                    VALUES (@identificador, @codigo, @codigo_alterno, @locacion, @direccion, @referencia, @codigo_postal, @monto_seguro, @tipo_contenido, @seguro, @peso, @telefono, @destinatario, @dato_adicional1, @dato_adicional2, @alto, @profundidad, @ancho)" 
                                    SelectCommand="SELECT [id], [identificador], [codigo], [codigo_alterno], [locacion], [direccion], [referencia], [codigo_postal], 
                                                    [monto_seguro], [tipo_contenido], [seguro], [peso], [telefono], [destinatario], [dato_adicional1], [dato_adicional2],
                                                    [alto], [profundidad], [ancho] FROM [paquete_temporal_cm] where [identificador]=@identificador" 
                                    UpdateCommand="UPDATE [paquete_temporal_cm] SET [identificador] = @identificador, [codigo] = @codigo, [codigo_alterno] = @codigo_alterno, [locacion] = @locacion, [direccion] = @direccion, [referencia] = @referencia, [codigo_postal] = @codigo_postal, [monto_seguro] = @monto_seguro, [tipo_contenido] = @tipo_contenido, [seguro] = @seguro, [peso] = @peso, [telefono] = @telefono, [destinatario] = @destinatario, [dato_adicional1] = @dato_adicional1, [dato_adicional2] = @dato_adicional2, [alto] = @alto, [profundidad] = @profundidad, [ancho] = @ancho WHERE [id] = @id">
                                  
                                    <DeleteParameters>
                                        <asp:Parameter Name="id" Type="Int32" />
                                    </DeleteParameters>
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="txtOT" Name="identificador" PropertyName="Text" Type="String" />
                                    </SelectParameters>

                                    <InsertParameters>
                                        <%--<asp:Parameter Name="identificador" Type="String" />--%>
                                        <asp:Parameter Name="codigo" Type="String" />
                                        <asp:Parameter Name="codigo_alterno" Type="String" />
                                        <asp:Parameter Name="locacion" Type="String" />
                                        <asp:Parameter Name="direccion" Type="String" />
                                        <asp:Parameter Name="referencia" Type="String" />
                                        <asp:Parameter Name="codigo_postal" Type="String" />
                                        <asp:Parameter Name="monto_seguro" Type="String" />
                                        <asp:Parameter Name="tipo_contenido" Type="String" />
                                        <asp:Parameter Name="seguro" Type="Boolean" />
                                        <asp:Parameter Name="peso" Type="String" />
                                        <asp:Parameter Name="telefono" Type="String" />
                                        <asp:Parameter Name="destinatario" Type="String" />
                                        <asp:Parameter Name="dato_adicional1" Type="String" />
                                        <asp:Parameter Name="dato_adicional2" Type="String" />
                                        <asp:Parameter Name="alto" Type="String" />
                                        <asp:Parameter Name="profundidad" Type="String" />
                                        <asp:Parameter Name="ancho" Type="String" />
                                        <asp:ControlParameter ControlID="txtOT" Name="identificador" PropertyName="Text" Type="String" />
                                        
                                    </InsertParameters>
                                    <UpdateParameters>
                                        <asp:Parameter Name="identificador" Type="String" />
                                        <asp:Parameter Name="codigo" Type="String" />
                                        <asp:Parameter Name="codigo_alterno" Type="String" />
                                        <asp:Parameter Name="locacion" Type="String" />
                                        <asp:Parameter Name="direccion" Type="String" />
                                        <asp:Parameter Name="referencia" Type="String" />
                                        <asp:Parameter Name="codigo_postal" Type="String" />
                                        <asp:Parameter Name="monto_seguro" Type="String" />
                                        <asp:Parameter Name="tipo_contenido" Type="String" />
                                        <asp:Parameter Name="seguro" Type="Boolean" />
                                        <asp:Parameter Name="peso" Type="String" />
                                        <asp:Parameter Name="telefono" Type="String" />
                                        <asp:Parameter Name="destinatario" Type="String" />
                                        <asp:Parameter Name="dato_adicional1" Type="String" />
                                        <asp:Parameter Name="dato_adicional2" Type="String" />
                                        <asp:Parameter Name="alto" Type="String" />
                                        <asp:Parameter Name="profundidad" Type="String" />
                                        <asp:Parameter Name="ancho" Type="String" />
                                        <asp:Parameter Name="id" Type="Int32" />
                                    </UpdateParameters>
                                </asp:SqlDataSource>
                                 <asp:SqlDataSource ID="dsLocacion" runat="server" ConnectionString="<%$ ConnectionStrings:OPERADB_DAO %>" SelectCommand="SPR_CONSULTA_UBICACIONES_GEOGRAFICAS" SelectCommandType="StoredProcedure">

                                     <SelectParameters>
                                         <asp:Parameter DefaultValue="1" Name="opcion" Type="Int32"></asp:Parameter>
                                     </SelectParameters>
                                 </asp:SqlDataSource>
                                
                            </div>
                        </div>
                    </div>




                </div>
            </div>
            <br />
            <div runat="server" id="divControl" visible="false">
                <div class="row">
                    <div class="col-sm-2">
                        <asp:LinkButton ID="btnGuardar" runat="server" class="btn btn-warning" OnClick="btnGuardar_Click" Text="Grabar" OnClientClick="mostrar_procesar();"></asp:LinkButton>
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
    <script type="text/javascript">               
        function hideOnKeyPress() {
            document.getElementById("<%=lblMensaje1.ClientID%>").style.visibility = "hidden";
        }

    </script>
</asp:Content>
