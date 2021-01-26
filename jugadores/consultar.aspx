<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="consultar.aspx.cs" Inherits="LigaFutbol.jugadores.consultar" MasterPageFile="~/MasterPage.master" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="container mt-4 main">        
        <h3 id="title" runat="server">Jugadores por equipo</h3>
        <hr />

        <asp:Panel id="pan1" runat="server">

            <div class="row justify-content-center"> 
                <div class="col-6">     
                    <asp:Label ID="lbl1" runat="server" CssClass="text-danger small text-align-center" Text="Eliminar un jugador también borra sus estadisticas e incidentes en partidos"></asp:Label>             
                    <div class="form-group">               
                        <asp:Label runat="server">Equipo</asp:Label>
                        <asp:DropDownList ID="dd1" runat="server" CssClass="form-control"></asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" id="req1" controltovalidate="dd1" class="text-danger" errormessage="Ingrese equipo" />
                    </div>          
                </div>
            </div>
            <div class="row justify-content-center my-3">        
                <asp:Button ID="btn1" runat="server" Text="Mostrar" CssClass="btn btn-primary" OnClick="MostrarJugadores"/>            
            </div>        
            <div class="row justify-content-center"> 
                <div class="col">
                    <asp:GridView ID="gv1" HeaderStyle-HorizontalAlign="Center" RowStyle-HorizontalAlign="Center" runat="server" GridLines="None" AutoGenerateColumns="False" CssClass="mt-3 table table-borderless" OnRowDeleting="Eliminar" OnRowEditing="Editar" DataKeyNames="id_jugador">
                        <Columns>                        
                            <asp:BoundField DataField="Nombre completo" HeaderText="Nombre"/> 
                            <asp:BoundField DataField="Playera" HeaderText="Playera"/> 
                            <asp:BoundField DataField="Posicion" HeaderText="Posición"/> 
                            <asp:BoundField DataField="Fecha de nacimiento" HeaderText="Fecha de nacimiento" DataFormatString = "{0:yyyy/MM/dd}"/> 
                            <asp:BoundField DataField="Edad" HeaderText="Edad"/> 
                            <asp:CommandField ShowEditButton="true" EditText="&#128221;" HeaderText="Editar" />
                            <asp:CommandField ShowDeleteButton="true" DeleteText="&#10060;" HeaderText="Eliminar" />                                                
                        </Columns>
                    </asp:GridView>
                </div> 
            </div>          
        </asp:Panel>

        <asp:Panel id="pan2" runat="server" Visible="false">
            <div class="row justify-content-center">
                <div class="col-md-6">


                    <asp:Label ID="lbl2" runat="server" CssClass="text-success" Text=""></asp:Label>  
                                               
                    <div class="form-group">
                        <asp:Label runat="server">Nombre</asp:Label>
                        <asp:TextBox ID="txtNom" runat="server" CssClass="form-control text-uppercase"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" id="reqNom" controltovalidate="txtNom" class="text-danger" errormessage="Ingrese nombre de jugador" />
                        <asp:RegularExpressionValidator id="regex1" runat="server" class="text-danger" 
                                errormessage="Ingrese un nombre valido" 
                                ValidationExpression="^[A-Za-z ]+$" 
                                controltovalidate="txtNom" />
                

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
                            <asp:Label runat="server" ID="fn">Fecha de nacimiento</asp:Label>            
                            <input type="date" id="dateFn" runat="server" class="form-control" min="1900-01-01" max="2016-01-01" required/> 
                        </div>
                        <div class="form-group col-md-6">
                            <asp:Label runat="server">Número</asp:Label>
                            <input type="number" id="txtNum" runat="server" class="form-control" value="69" min="1" max="99" required/> 
                        </div>
                    </div>

                    <div class="form-group">                               
                        <asp:Label runat="server">Posición</asp:Label>
                        <asp:DropDownList ID="dd2" runat="server" CssClass="form-control"></asp:DropDownList>                                    
                    </div>

                    <div class="row justify-content-center my-3">        
                        <asp:Button ID="btn2" runat="server" Text="Actualizar" CssClass="btn btn-primary" OnClick="Actualizar"/>
                        <a href="consultar.aspx" class="btn btn-secondary ml-3">No guardar</a>
                    </div>

                </div>


                </div>                
            </div>                        
        </asp:Panel>
                    
    </div>
</asp:Content>
