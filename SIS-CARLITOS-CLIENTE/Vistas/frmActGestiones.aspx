<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmActGestiones.aspx.cs" Inherits="SIS_CARLITOS.Vistas.frmActGestiones" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>



<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          
        <ContentTemplate>
            <div class="card border-dark" style="max-width: 100rem;">
                <div class="card-header ph-card-header">Eliminación de Gestiones</div>
                <div class="card-body" style="background-color: white">
                      <form>

                        <div class="form-group row">
                            <div class="col-sm-10">

                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" FilterMode="ValidChars" TargetControlID="txtCodigoEnvio1" ValidChars="abcdefghijklmnñopqrstuvwxyz ABCDEFGHIJKLMNÑOPQRSTUVWXYZ 0123456789"></cc1:FilteredTextBoxExtender>
                                <asp:TextBox ID="txtCodigoEnvio1" runat="server" placeholder="Código de envío" MaxLength="30" CssClass="form-control form-control-sm" TextMode="SingleLine"></asp:TextBox>
                            </div>
                            
                          
                        </div>
                     
                        <div class="row">
                            <div class="col-sm-2" style="padding-bottom: 5px;">
                                <asp:LinkButton ID="btnProcesar" runat="server" visible="true" class="btn btn-warning" OnClientClick="mostrar_procesar();" CssClass="btn btn-warning" OnClick="btnProcesar_Click" >Procesar</asp:LinkButton>
                            </div>
                            <div class="col-sm-6" style="padding-bottom: 5px;">
                                <asp:Label ID="lblMensaje" runat="server" Visible="true" Text="" Style="margin-bottom: 10px;"></asp:Label>

                            </div>
                        </div>

                    </form>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
