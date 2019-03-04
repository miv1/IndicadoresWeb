<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmUser.aspx.cs" Inherits="IndicadoresWeb.frmUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style>
        table, th{ border: 1px solid black; align-items:center; }
        td{color: white}
        div{ height:50px; left:25%; position:absolute}
    </style>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title> INDICADORES DE AGRONEGOCIO</title>
</head>
<body style=' background-color: cadetblue'>
    <form id="form1" runat="server">
        <div>     
        <table>
              <tr>
                <td style="width: 100%; height: 30px">
                      <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagens/Panel.png" Width="780px" />
                  </td>
              </tr>    
              </table>
                  <table>
                <caption>
                    <asp:Label ID="Label4" runat="server" Text="INDICADORES DE AGRONEGOCIO" Font-Bold="True" ForeColor="white"></asp:Label>
                </caption>
                <thead>
                
                    <tr>
                        <td style="width: 150px">
                              <asp:Label 
                            ID="lblTitleCooperativas"
                            runat="server" 
                            Text="Selecione Cooperativas" 
                            AssociatedControlID="chbSelectAll"
                            Font-Underline="true"
                            Font-Bold="true"
                            />   
                       <br />  </td>
                       
                        <td style="width: 30px">Safra:
                        </td>
                        <td style=" align-content:flex-start; width: 130px">
                            <asp:DropDownList ID="ddlSafra" runat="server"></asp:DropDownList>
                        </td>
                        <td style="width: 30px">Hasta:
                        </td>
                        <td style=" align-content:flex-start; width: 130px">
                            <asp:DropDownList ID="ddlHasta" runat="server"></asp:DropDownList>
                        </td>
                        <td style="width: 30px">Produto:
                        </td>
                        <td style=" align-content:flex-start; width: 140px">
                            <asp:DropDownList ID="ddlProduto" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td style="width:100px">
                            <asp:Button ID="Button1" runat="server" Text="Procurar" OnClick="Button1_Click1" />
                        </td>
                    </tr>
               </thead>
                    <tr style="height:50px">
                        <td >
                            <asp:CheckBox ID="ckbSelecionarTudo" Text="Selecionar tudo" runat="server" AutoPostBack="True" OnCheckedChanged="ckbSelecionarTudo_CheckedChanged" />                                   
                            <asp:CheckBoxList ID="chbSelectAll" 
                                runat="server" 
                                Font-Italic="true"
                               Font-Names="Courier New">
                                
                              </asp:CheckBoxList><br />  
                        </td>
                        <td colspan="7" rowspan="3">
                            <asp:Repeater ID="rptIndicadores" runat="server" Visible="False">
                                <HeaderTemplate>
                                    <div style="font-weight: bold; height:300px">Resultados</div>
                                    <br />
                                    <table style="border: 1px solid black; width: 80%">
                                        <thead>
                                            <tr>
                                                <th style="width: 20%; align-content:flex-start">Cooperativa</th>
                                                <th style="width: 20%; align-content:flex-start">Safra</th>
                                                <th style="width: 25%; align-items:center">Produto</th>
                                                <th style="width: 30%; align-content:flex-start">Descrição</th>
                                                <th style="width: 25%; align-content:flex-start">Quantidade</th>
                                            </tr>
                                        </thead>
                                </HeaderTemplate>
                                <ItemTemplate>
                                   <tbody> 
                                       <tr>
                                            <td >
                                            <asp:Label ID="Label5" runat="server" Text='<%#Eval ("Cooperativa") %>' />
                                        </td>
                                        <td >
                                            <asp:Label ID="myLabel" runat="server" Text='<%#Eval ("Safra") %>' />
                                        </td>
                                        <td style= "align-content: center">
                                            <asp:Label ID="Label2" runat="server" Text='<%#Eval ("Produto") %>'/>
                                        </td>
                                      <td style="align-items:center" >
                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval ("Descrição") %>'/>
                                      </td>
                                     <td  >
                                            <asp:Label ID="Label3" runat="server" Text='<%#Eval ("Quantidade") %>'/>
                                      </td>
                                        </tr> 
                                   </tbody>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table> 
                                </FooterTemplate>                               
                            </asp:Repeater>
                        </td>
                    </tr>
                      <tr>
                          <td> 
                              
                              <asp:HiddenField ID="hddfSelecionarTudo" runat="server" />
                              
                          </td>
                      </tr>
                      <tr>
<td>
                            <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
                          </td>
                      </tr>
                <tbody runat="server" id="listacontenido">
                </tbody>
            </table>
            <br />
            <br />
            <br />
            
        </div>
          </form>
</body>
</html>

