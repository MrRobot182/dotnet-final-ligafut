<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="insertar.aspx.cs" Inherits="LigaFutbol.partidos.insertar" MasterPageFile="~/MasterPage.master" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="container mt-4 main">        
        <h3 runat="server" id="title">Añadir partido</h3>
        <hr />

        <div class="row justify-content-center"> 
            <div class="col-5">
                <asp:Label ID="lbl1" runat="server" CssClass="text-success" Text=""></asp:Label>                                            
                <div class="form-row">
                    <div class="form-group col-md-6">
                        <asp:Label runat="server">Equipo local</asp:Label>
                        <asp:DropDownList ID="dd1" runat="server" CssClass="form-control" OnSelectedIndexChanged="SeleccionLocal" AutoPostBack="true"></asp:DropDownList>   
                        <asp:RequiredFieldValidator runat="server" controltovalidate="dd1" class="text-danger" errormessage="Selecciona equipo" />
                    </div>
                    <div class="form-group col-md-6">
                        <asp:Label runat="server">Equipo visitante</asp:Label>
                        <asp:DropDownList ID="dd2" runat="server" Enabled="false" CssClass="form-control"></asp:DropDownList>  
                        <asp:RequiredFieldValidator runat="server" controltovalidate="dd2" class="text-danger" errormessage="Selecciona equipo" /> 
                    </div>
                </div>

                <div class="form-group">                     
                    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.9.0/js/bootstrap-datepicker.js"></script>
                    <asp:Label runat="server">Fecha</asp:Label>
                    <asp:Calendar ID="fecha" runat="server" Width="100%" ondayrender="Calendar_DayRender"></asp:Calendar>
                    <asp:Label ID="lbl2" runat="server" CssClass="text-danger" Text=""></asp:Label>                     
                </div>

                <div class="form-group">                               
                    <asp:Label runat="server">Hora</asp:Label>
                    <input type="time" id="hora" runat="server" min="07:00" max="16:00" class="form-control" required />
                </div>

            

            </div>
        </div>
        <div class="row justify-content-center my-3">        
            <asp:Button ID="btn1" runat="server" Text="Agregar" CssClass="btn btn-primary" OnClick="Insertar"/>                
        </div>                     
            
    </div>
</asp:Content>
