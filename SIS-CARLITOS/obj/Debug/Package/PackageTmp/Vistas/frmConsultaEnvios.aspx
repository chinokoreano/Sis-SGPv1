<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmConsultaEnvios.aspx.cs" Inherits="SIS_CARLITOS.Vistas.frmConsultaEnvios" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>



<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          
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

                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-sm-3" style="padding-bottom: 5px;">
                            <asp:TextBox ID="txtFiltro1" runat="server" placeholder="" MaxLength="100" CssClass="form-control form-control-sm" TextMode="SingleLine"></asp:TextBox>

                        </div>

                    </div>
                    <div class="row">
                        <div class="col-sm-3" style="padding-bottom: 5px;">
                            <asp:TextBox ID="txtFechaCarga" runat="server" Visible="false" placeholder="" MaxLength="100" CssClass="form-control form-control-sm" TextMode="SingleLine"></asp:TextBox>

                        </div>

                    </div>
                    <div class="row">
                        <div class="col-sm-3" style="padding-bottom: 5px;">
                            <asp:Button ID="btnBuscar" class="btn btn-warning" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                        </div>
                    </div>
                    <div class="table-responsive">
                        <asp:GridView ID="grvEnvios"
                            CssClass="tabla_datos col-xs-12 table-bordered"
                            runat="server"
                            PagerStyle-CssClass="pager-style"
                            AutoGenerateColumns="true" ViewStateMode="Enabled" EmptyDataText="No existe información" PageSize="5" AllowPaging="True" OnPageIndexChanging="grvEnvios_PageIndexChanging">

                            <PagerStyle CssClass="pager-style" />

                            <RowStyle CssClass="row-style" />
                            <AlternatingRowStyle CssClass="alernativedRow-style" />
                            <SelectedRowStyle CssClass="editRow-style" />
                            <EditRowStyle CssClass="editRow-style" />
                            <Columns>

                                 <asp:TemplateField HeaderText="Identificador" Visible="false">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("identificador") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblId" runat="server" Text='<%# Bind("identificador") %>'></asp:Label>
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
                    
                  <%--  <div class="row">
                        <div class="col-sm-3" style="padding-bottom: 5px;">
                            <asp:Button ID="btnExportar" runat="server" class="btn btn-info" OnClick="btnExportar_Click1"  Text="Exportar" />
                        </div>
                    </div>--%>
                    <br />
                    <div class="table-responsive">
                        <asp:GridView ID="grvEventos" runat="server" AllowPaging="True" AutoGenerateColumns="true" CssClass="tabla_datos col-xs-12 table-bordered" EmptyDataText="No existe información" OnPageIndexChanging="grvEnvios_PageIndexChanging" PagerStyle-CssClass="pager-style" PageSize="5" ViewStateMode="Enabled">
                            <PagerStyle CssClass="pager-style" />
                            <RowStyle CssClass="row-style" />
                            <AlternatingRowStyle CssClass="alernativedRow-style" />
                            <SelectedRowStyle CssClass="editRow-style" />
                            <EditRowStyle CssClass="editRow-style" />
                            <Columns>
                                <asp:TemplateField HeaderText="Identificador" Visible="false">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("identificador") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblId" runat="server" Text='<%# Bind("identificador") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    </br>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
