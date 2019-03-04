<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmUser.aspx.cs" Inherits="IndicadoresWeb.frmUser" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="100%" style="border-width: 1px; border-style: solid;">
                <caption>
                    INDICADORES DE AGRONEGOCIO</caption>
                <thead>
                    <tr>
                        <td>Cooperativa
                        </td>
                        <td>Safra:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSafra" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>Produto:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlProduto" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click1" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                        </td>
                        <td colspan="5">
                            <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="125px">
                            </asp:DetailsView>
                            <asp:Repeater ID="rptIndicadores" runat="server">
                                <HeaderTemplate>
                                    <div style="font-weight: bold;">My Repeater</div>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div>
                                       <asp:Label ID="myLabel" runat="server" Text='<%#Eval ("Nome") %>'/></div>
                                     <asp:Label ID="Label1" runat="server" Text='<%#Eval ("Id") %>'/></div>
                                </ItemTemplate>
                            </asp:Repeater>

                        </td>
                    </tr>
                </thead>
                <tbody runat="server" id="listacontenido">
                </tbody>
            </table>
            <br />
            <br />
            <br />
            <asp:CheckBoxList ID="CheckBoxList1" runat="server">
            </asp:CheckBoxList>

        </div>
    </form>
</body>
</html>

