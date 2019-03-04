<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Portada.aspx.cs" Inherits="Presentation.Portada" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
.button {
  background-color: #4CAF50;
  border: none;
  color: white;
  padding: 15px 32px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 16px;
  margin: 4px 2px;
  cursor: pointer;
}
body{
    background-image: url("~/Imagens/Portada.png");
    background-color: #C9F5DF;
}
</style>

</head>
<body>
    <form id="form1" runat="server">
     <div style="text-align:center; position:absolute; width:100px; left:25%">
         <table style="border-width: 1px; align-content:center; text-align:center; border-style: solid; width:60%; color:antiquewhite">
            <thead>
            </thead>
            <tbody>          
                <tr>
                    <td colspan="2">
                        <asp:Image ID="Image1" runat="server" Height="424px" ImageAlign="Middle" ImageUrl="~/Imagens/Portada.png" Width="822px" />
                    </td>
                </tr>
                 <tr style="align-items :center">
                <td style="width: 50%; height: 30px" >    
        <asp:Button ID="btnAdmin" class="button" runat="server" Text="Admin" OnClick="btnAdmin_Click" />
                    </td>
                     <td> 
                         <asp:Button ID="btnUser" class="button" runat="server" Text="User" OnClick="btnUser_Click"  />
                     </td>
                     </tr>
                </tbody>
             </table>
    
    </div>
    </form>
</body>
</html>
