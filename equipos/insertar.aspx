<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="insertar.aspx.cs" Inherits="LigaFutbol.equipos.insertar" MasterPageFile="~/MasterPage.master" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="container mt-4 main">        
        <h3>Añadir equipo</h3>
        <hr />

        <div class="row justify-content-center"> 
            <div class="col-md-6">        
                <asp:Label ID="lbl1" runat="server" CssClass="text-success" Text=""></asp:Label>                     
                <div class="form-group">
                    <asp:Label runat="server">Nombre</asp:Label>
                    <asp:TextBox ID="txtNom" runat="server" CssClass="form-control text-uppercase"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" id="reqNomE" controltovalidate="txtNom" class="text-danger" errormessage="Ingresa nombre de equipo" />
                    <asp:RegularExpressionValidator id="regex1" runat="server" class="text-danger" 
                        errormessage="Ingrese un nombre valido (solo letras y números)" 
                        ValidationExpression="^[A-Za-z1-9 ]+$" 
                        controltovalidate="txtNom" />
                </div>           
                <div class="form-group">                               
                    <asp:Label runat="server">Escudo</asp:Label>
                    <asp:FileUpload ID="upl1" accept="image/*" multiple="false" runat="server" BorderStyle="None" CssClass="form-control"/>                    
                </div>
            </div>
        </div>
        <div class="row justify-content-center my-3">        
            <asp:Button ID="btn1" runat="server" Text="Añadir" CssClass="btn btn-primary" OnClick="Insertar"/>             
        </div>
    </div>
</asp:Content>
