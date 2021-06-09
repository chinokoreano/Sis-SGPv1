<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmUsuarioNoAutenticado.aspx.cs" Inherits="SIS_CARLITOS.frmUsuarioNoAutenticado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="container">
        <div id="content">
            <div id="main">

                <div id="principal-form">
                    <div id="principal-form-content" style="padding-left: 30px; padding-right: 30px;">
                        <br />
                        <div class="panel panel-danger">
                            <div class="panel-heading h4">Usuario no autenticado</div>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="form-group" style="padding-left: 70px; padding-right: 70px;">
                                        <asp:Label ID="lblMensaje" runat="server" Text="" class="h4"></asp:Label>
                                    </div>

                                    <div class="form-group" style="padding-left: 70px; padding-right: 70px;">
                                        <asp:LinkButton ID="lnkLogin" runat="server" OnClick="lnkLogin_Click" Text="Iniciar sesión" class="btn btn-primary"></asp:LinkButton>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
