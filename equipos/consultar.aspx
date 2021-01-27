<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="consultar.aspx.cs" Inherits="LigaFutbol.equipos.consultar" MasterPageFile="~/MasterPage.master" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="container mt-4 main">        
        <h3 runat="server" id="title">Equipos participantes</h3>
        <hr />

        <div class="row justify-content-center">            
            
                <div class="col">
                    <asp:Panel ID="pan1" runat="server">
                        <asp:Label ID="lbl1" runat="server" CssClass="text-danger small" Text="Eliminar un equipo también elimina a sus jugadores" />                               
                        <asp:GridView ID="gv1" HeaderStyle-HorizontalAlign="Center" RowStyle-HorizontalAlign="Center" runat="server" GridLines="None" AutoGenerateColumns="False" CssClass="mt-3 table table-borderless" OnRowDeleting="Eliminar" OnRowEditing="Editar" DataKeyNames="id_equipo">
                            <Columns>
                        
                                <asp:BoundField DataField="Equipo" HeaderText="Nombre"/>
                        
                                <asp:TemplateField>
                                  <ItemTemplate>
                                    <asp:Image ID="img" runat="server" Width="60px" CssClass="m-1" ImageUrl='<%# Eval("Escudo") %>'/>
                                  </ItemTemplate>
                                    <HeaderTemplate>
                                        Escudo
                                    </HeaderTemplate>
                                </asp:TemplateField>

                                <asp:CommandField ShowEditButton="true" EditText="&#128221;" HeaderText="Editar" />
                                <asp:CommandField ShowDeleteButton="true" DeleteText="&#10060;" HeaderText="Eliminar" />                                                
                            </Columns>
                        </asp:GridView> 
                    </asp:Panel>
                    <asp:Panel ID="pan2" runat="server" Visible="false">
                        <div class="row justify-content-center">
                            <div class="col-md-6">
                                <asp:Label ID="Label1" runat="server" CssClass="text-success" Text=""></asp:Label>                     
                                <div class="form-group">
                                    <asp:Label runat="server">Nombre</asp:Label>
                                    <asp:TextBox ID="txtNom" MaxLength="35" runat="server" CssClass="form-control text-uppercase"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" id="reqNomE" controltovalidate="txtNom" class="text-danger" errormessage="Ingresa nombre de equipo" />
                                    <asp:RegularExpressionValidator id="regex1" runat="server" class="text-danger" 
                                        errormessage="Ingrese un nombre valido (solo letras y números)" 
                                        ValidationExpression="^[A-Za-z1-9 ]+$" 
                                        controltovalidate="txtNom" />
                                </div>           
                                <div class="form-group"> 
                                    <div class="row">
                                        <div class="col-lg-8">
                                            <asp:Label runat="server">Escudo (carga una imagen si deseas cambiarlo)</asp:Label>
                                            <asp:FileUpload ID="upl1" accept="image/*" multiple="false" runat="server" BorderStyle="None" CssClass="form-control"/>
                                        </div>
                                        <div class="col mx-auto justify-content-center">                                                                                      
                                            <asp:Image ID="imged" runat="server" Width="100px" CssClass="m-1" ImageUrl=""/>    
                                        </div>
                                    </div>                                    
                                </div>
                                <div class="row justify-content-center my-3">        
                                    <asp:Button ID="btn1" runat="server" Text="Actualizar" CssClass="btn btn-primary" OnClick="Actualizar"/>
                                    <a href="consultar.aspx" class="btn btn-secondary ml-3">No guardar</a>
                                </div>
                            </div>
                        </div>

                    </asp:Panel>
                </div>            
        </div>
            
    </div>
</asp:Content>
