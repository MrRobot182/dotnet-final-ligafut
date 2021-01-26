<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jugadores.aspx.cs" Inherits="LigaFutbol.estadisticas.jugadores" MasterPageFile="~/MasterPage.master" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="container mt-4 main">        
        <h3>Estadísticas de jugador</h3>
        <hr />

        <div class="row justify-content-center"> 
            <div class="col-sm-10 col-md-6">     
                <div class="form-group">               
                    <asp:Label runat="server">Equipo</asp:Label>
                    <asp:DropDownList ID="dd1" runat="server" CssClass="form-control" ></asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" id="reqEqu" controltovalidate="dd1" class="text-danger" errormessage="Ingresa equipo" />
                </div>          
            </div>
        </div>  

        <div class="row justify-content-center">        
            <asp:Button ID="btn1" runat="server" Text="Mostrar" CssClass="btn btn-primary" OnClick="MostrarJugadores" />            
        </div>

        <div class="row justify-content-center pt-3">        
            <asp:Label ID="jugVal" runat="server" CssClass="text-danger" Visible="false" Text="Equipo sin jugadores registrados"></asp:Label> 
            <div class="col">               
                <asp:GridView ID="gv1" runat="server" GridLines="None" AutoGenerateColumns="True" CssClass="table table-hover">
                </asp:GridView>                        
            </div>
        </div>
    </div>
</asp:Content>