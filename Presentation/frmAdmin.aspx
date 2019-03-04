<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmAdmin.aspx.cs" Inherits="Presentation.frmAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <style>
        table, th{ border: 1px solid black; align-items:center; color:burlywood}
        td{color: black}
    </style>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="background:antiquewhite">
    <form id="form1" runat="server">
    <div style="text-align:center; position:absolute; width:100px; height:50px; left:25%">
       <table style="border-width: 1px; align-content:center; text-align:center; border-style: solid; width:60%; color:antiquewhite">
            <thead>

            </thead>
            <tbody>          
                 <tr>
                <td style="width: 100%; height: 30px" colspan="3">
                     <div style="border-bottom:outset">  <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagens/Panel2.png" Width="780px" />
                     </div>
                  </td>
              </tr>  
            <tr>
                <td style="width:20%">
                    <asp:FileUpload ID="fulData" runat="server" />
            </td>
                <td style="width:30%">
                            <asp:Button ID="Button1" runat="server" Text="Selecionar" OnClick="Button1_Click" />
                </td>
                <td>
                    <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
                    <%--<asp:Button ID="btnAceitar" runat="server" Text="Fechar" />--%>
                </td>                
            </tr>
         
            <tr>
                <td style="width:20%; text-align:right">
                         <asp:Label ID="lblEscolher" runat="server" Text="Escolha a folha (se precisar)" Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlFolha" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFolha_SelectedIndexChanged" Visible="False"></asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
                </td>
            </tr>
                <tr >
                    
                    <td colspan="3" style="height:80%">
                         <asp:Label ID="lblStatus" runat="server" Text="Escolha a folha" Visible="False" ForeColor="Red"></asp:Label>
                        <br />
                        <asp:HiddenField ID="hdnfldFile" runat="server" />
                        <br /></td>
                </tr>
                <tr>
                    <td colspan="3" style=" text-align:center">
                        <asp:Label ID="Label1" runat="server" Text="DADOS A INSERIR"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="height:80px">
                        
        <asp:GridView ID="gvwResultado" runat="server" BackColor="White" 
            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
            HorizontalAlign="Center" AutoGenerateColumns="False">
             <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" 
                HorizontalAlign="Center" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />

              <Columns>
       <asp:BoundField DataField="Cooperativa" HeaderText="Cooperativa" />
                  <asp:BoundField DataField="Safra" HeaderText="Safra" />
                  <asp:BoundField DataField="Produto" HeaderText="Produto" />
                  <asp:BoundField DataField="Descrição" HeaderText="Descrição" />
                  <asp:BoundField DataField="Quantidade" HeaderText="Quantidade" />
      <%-- <asp:BoundField DataField="Produtividade" HeaderText="Produtividade" />        
       <asp:BoundField DataField="Area Plantada" HeaderText="Area Plantada" />
       <asp:BoundField DataField="Producao" HeaderText="Producao" />--%>
    </Columns>
        </asp:GridView>
                   
                          <asp:GridView ID="gvwResultadoXmlx" runat="server" BackColor="White" 
            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
            HorizontalAlign="Center" AutoGenerateColumns="False">
             <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" 
                HorizontalAlign="Center" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />

              <Columns>
    
                  <asp:BoundField DataField="Safra" HeaderText="Safra" />
                 
       <asp:BoundField DataField="Produtividade" HeaderText="Produtividade" />        
       <asp:BoundField DataField="Area Plantada" HeaderText="Area Plantada" />
       <asp:BoundField DataField="Producao" HeaderText="Producao" />
    </Columns>
        </asp:GridView>
                   
                        
                         </td>
                </tr>
                  </tbody>
        </table>
         </div>
    </form>
</body>
</html>
