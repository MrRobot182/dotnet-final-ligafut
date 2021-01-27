<%@ Page Language="C#" AutoEventWireup="true"EnableEventValidation="false" CodeBehind="consultar.aspx.cs" Inherits="LigaFutbol.partidos.consultar" MasterPageFile="~/MasterPage.master" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="container mt-4 main">        
        <h3 runat="server" id="title">Partidos programados</h3>
        <hr />

        <asp:Panel runat="server" ID="pan1">
            <div class="row justify-content-center">
                <div class="col">
                    <asp:GridView ID="gv1" runat="server" GridLines="None" AutoGenerateColumns="False" CssClass="table mt-3" RowStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" DataKeyNames="id_partido" OnRowDataBound="gv1_RowDataBound">
                        <Columns>                                        
                            <asp:TemplateField>
                              <ItemTemplate>
                                <asp:Image ID="img1" runat="server" Width="40px" ImageUrl='<%# "/assets/img/escudos/"+Eval("EscudoL") %>'/>
                              </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="Local" HeaderText="Local" ReadOnly="True" SortExpression="Local"/>
                            <asp:BoundField DataField="Goles(L)" HeaderText="Goles(L)" SortExpression="Goles(L)"/>
                            <asp:BoundField DataField="Goles(V)" HeaderText="Goles(V)" SortExpression="Goles(V)"/>
                            <asp:BoundField DataField="Visita" HeaderText="Visita" SortExpression="Visita"/>
                            
                            <asp:TemplateField>
                              <ItemTemplate>
                                <asp:Image ID="img2" runat="server" Width="40px" ImageUrl='<%# "/assets/img/escudos/"+Eval("EscudoV") %>'/>
                              </ItemTemplate>
                            </asp:TemplateField>
                    
                            <asp:BoundField DataField="Fecha/hora" HeaderText="Fecha/hora" SortExpression="Fecha/hora" DataFormatString="{0:dd/MM/yyyy HH:mm}"/>

                            <asp:TemplateField Visible="true">
                                <ItemTemplate>                                    
                                    <asp:Label ID="btn1" runat="server" Text="Finalizado" cssClass="text-danger" />                                    
                                    <asp:Button CommandArgument='<%# Container.DataItemIndex %>' ID="btn2" runat="server" Text="&#9917;" BorderStyle="None" OnClick="PanelJugar"/>
                                    <asp:Button CommandArgument='<%# Container.DataItemIndex %>' ID="btn3" runat="server" Text="📝" BorderStyle="None" OnClick="PanelEditar"/>
                                </ItemTemplate>
                                <HeaderTemplate>
                                    Detalles
                                </HeaderTemplate>
                            </asp:TemplateField>
                            
                            <asp:BoundField DataField="finalizado" HeaderText="Finalizado" ReadOnly="True"/>
                            
                        </Columns>
                    </asp:GridView>            
            
                </div>
            </div>                         
        </asp:Panel>

        <asp:Panel runat="server" ID="pan3" Visible="false">


            <div class="row justify-content-center">
                <div class="col">
                    <asp:GridView ID="gv2" runat="server" GridLines="None" AutoGenerateColumns="False" CssClass="table mt-3" RowStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" DataKeyNames="id_partido" >
                        <Columns>                                        
                            <asp:TemplateField>
                              <ItemTemplate>
                                <asp:Image ID="img31" runat="server" Width="40px" ImageUrl='<%# "/assets/img/escudos/"+Eval("EscudoL") %>'/>
                              </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="Local" HeaderText="Local" ReadOnly="True" SortExpression="Local"/>
                            <asp:BoundField DataField="Goles(L)" HeaderText="Goles(L)" SortExpression="Goles(L)"/>
                            <asp:BoundField DataField="Goles(V)" HeaderText="Goles(V)" SortExpression="Goles(V)"/>
                            <asp:BoundField DataField="Visita" HeaderText="Visita" SortExpression="Visita"/>
                            
                            <asp:TemplateField>
                              <ItemTemplate>
                                <asp:Image ID="img32" runat="server" Width="40px" ImageUrl='<%# "/assets/img/escudos/"+Eval("EscudoV") %>'/>
                              </ItemTemplate>
                            </asp:TemplateField>
                    
                            <asp:BoundField DataField="Fecha/hora" HeaderText="Fecha/hora" SortExpression="Fecha/hora" DataFormatString="{0:dd/MM/yyyy HH:mm}"/>
                            
                        </Columns>
                    </asp:GridView>            
            
                </div>
            </div>    





            <div class="row justify-content-center"> 
        
        <div class="col-4">
            <h5>Local</h5>
                               
            <div class="form-group">                
                <asp:Label runat="server">Jugador</asp:Label>
                <asp:DropDownList ID="ddjl" runat="server" CssClass="form-control"></asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddjl" ErrorMessage="No hay jugadores"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">                
                <asp:Label runat="server">Incidente</asp:Label>
                <asp:DropDownList ID="ddi1" runat="server" CssClass="form-control"></asp:DropDownList>                
            </div>

            <div class="form-group">
                <asp:Label runat="server">Minuto</asp:Label>
                <input type="number" id="min1" runat="server" value="0" class="form-control" min="0" max="40" /> 
            </div>

            <div class="row justify-content-center my-3">        
                <asp:Button ID="btnL" runat="server" Text="Agregar" CssClass="btn btn-primary" OnClick="IncidenteLocal"/>                
            </div>

        </div>

        <div class="col-4">
            <h5>Visitante</h5> 
                               
            <div class="form-group">                
                <asp:Label runat="server">Jugador</asp:Label>
                <asp:DropDownList ID="ddjv" runat="server" CssClass="form-control"></asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddjv" ErrorMessage="No hay jugadores"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">                
                <asp:Label runat="server">Incidente</asp:Label>
                <asp:DropDownList ID="ddi2" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>

            <div class="form-group">
                <asp:Label runat="server">Minuto</asp:Label>
                <input type="number" id="min2" runat="server" value="0" class="form-control" min="0" max="40" /> 
            </div>

            <div class="row justify-content-center my-3">        
                <asp:Button ID="btnV" runat="server" Text="Agregar" CssClass="btn btn-primary" OnClick="IncidenteVisita"/>                
            </div>
        </div>
    </div>

    <div class="row justify-content-center my-3">        
        <asp:Button ID="btnFin" runat="server" Text="Finalizar partido" CssClass="btn btn-danger" OnClick="Finalizar"/>                
    </div>


        </asp:Panel>




        <asp:Panel runat="server" ID="pan4" Visible="false">

                <div class="row justify-content-center"> 
        <div class="col-5">
            <asp:Label ID="lbl41" runat="server" CssClass="text-success" Text=""></asp:Label>                                            
            <div class="form-row">
                <div class="form-group col-md-6">
                    <asp:Label runat="server">Equipo local</asp:Label>
                    <asp:TextBox ID="txtLocal" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>
                <div class="form-group col-md-6">
                    <asp:Label runat="server">Equipo visitante</asp:Label>
                    <asp:TextBox ID="txtVisita" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox> 
                </div>
            </div>

            <div class="form-group">                     
                    <asp:Label runat="server">Fecha</asp:Label>
                    <asp:Calendar ID="fecha" runat="server" Width="100%" ondayrender="Calendar_DayRender"></asp:Calendar>
                    <asp:Label ID="lbl42" runat="server" CssClass="text-danger" Text=""></asp:Label>                     
                </div>

            <div class="form-group">                               
                <asp:Label runat="server">Hora</asp:Label>
                <input type="time" id="hora" runat="server" min="07:00" max="16:00" class="form-control" required />
            </div>

            <div class="form-group text-center"> 
                <asp:Button ID="btn41" runat="server" Text="Actualizar" CssClass="btn btn-primary" OnClick="Actualizar"/>
                <a href="consultar.aspx" class="btn btn-secondary ml-3">No guardar</a>
            </div>

        </div>
    </div>
        
        </asp:Panel>

    </div>
</asp:Content>