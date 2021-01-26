<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mejorOfensiva.aspx.cs" Inherits="LigaFutbol.estadisticas.mejorOfensiva" MasterPageFile="~/MasterPage.master" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="container mt-4 main">        
        <h3>Mejores ataques del torneo</h3>
        <div class="row justify-content-center">
            <div class="col">
                <asp:GridView ID="gv1" runat="server" GridLines="None" AutoGenerateColumns="True" CssClass="table table-hover w-100">                
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>