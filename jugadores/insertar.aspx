<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="insertar.aspx.cs" Inherits="LigaFutbol.jugadores.insertar" MasterPageFile="~/MasterPage.master" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="container mt-4 main">        
        <h3>Añadir jugador</h3>
        <hr />

        <div class="row justify-content-center"> 
        <div class="col-md-6">
            <asp:Label ID="lbl1" runat="server" CssClass="text-success" Text=""></asp:Label>  
                               
            <div class="form-group">                
                <asp:Label runat="server">Equipo</asp:Label>
                <asp:DropDownList ID="dd1" runat="server" CssClass="form-control"></asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" id="req1" controltovalidate="dd1" class="text-danger" errormessage="Ingrese equipo" />
            </div>

            <div class="form-group">
                <asp:Label runat="server">Nombre</asp:Label>
                <asp:TextBox ID="txtNom" runat="server" CssClass="form-control text-uppercase"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" id="reqNom" controltovalidate="txtNom" class="text-danger" errormessage="Ingrese nombre de jugador" />
                <asp:RegularExpressionValidator id="regex1" runat="server" class="text-danger" 
                        errormessage="Ingrese un nombre valido" 
                        ValidationExpression="^[A-Za-z ]+$" 
                        controltovalidate="txtNom" />
            </div>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <asp:Label runat="server">Apellido paterno</asp:Label>
                    <asp:TextBox ID="txtApp" runat="server" CssClass="form-control text-uppercase"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" id="reqApp" controltovalidate="txtApp" class="text-danger" errormessage="Ingrese apellido paterno" />
                    <asp:RegularExpressionValidator id="regex2" runat="server" class="text-danger" 
                            errormessage="Ingrese un apellido paterno valido" 
                            ValidationExpression="^[A-Za-z ]+$" 
                            controltovalidate="txtApm" />
                </div>
                <div class="form-group col-md-6">
                    <asp:Label runat="server">Apellido materno</asp:Label>
                    <asp:TextBox ID="txtApm" runat="server" CssClass="form-control text-uppercase"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" id="reqApm" controltovalidate="txtApm" class="text-danger" errormessage="Ingrese apellido paterno" />
                    <asp:RegularExpressionValidator id="regex3" runat="server" class="text-danger" 
                            errormessage="Ingrese un apellido materno valido" 
                            ValidationExpression="^[A-Za-z ]+$" 
                            controltovalidate="txtApm" />
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <asp:Label runat="server">Fecha de nacimiento</asp:Label>            
                    <input type="date" id="dateFn" runat="server" class="form-control" min="1900-01-01" max="2016-01-01" required/> 
                </div>
                <div class="form-group col-md-6">
                    <asp:Label runat="server">Número</asp:Label>
                    <input type="number" id="txtNum" runat="server" class="form-control" min="1" max="99" required/> 
                </div>
            </div>

            <div class="form-group">                               
                <asp:Label runat="server">Posición</asp:Label>
                <asp:DropDownList ID="dd2" runat="server" CssClass="form-control"></asp:DropDownList>                                    
            </div>
        </div>
    </div>
    <div class="row justify-content-center my-3">        
        <asp:Button ID="btn1" runat="server" Text="Agregar" CssClass="btn btn-primary" OnClick="Insertar"/>                
    </div>

    </div>       
</asp:Content>
