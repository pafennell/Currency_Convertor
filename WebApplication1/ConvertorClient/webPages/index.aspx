<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Currency_Convertor</title>
    <link href="http://localhost:49174/css/styleSheet.css" rel="stylesheet" />
</head>
<body>
    <div id="header"></div>
    <div id="sideBarLeft"></div>   
    
    <div id="main">
        <form id="form1" runat="server">
            <fieldset>
                <legend></legend>
                <div>
                <p>
                    <b>
                        <asp:Label ID="lbl_Number" runat="server" Font-Style="Bold" Text="Enter Number"></asp:Label>

                    </b>
                        <asp:TextBox ID="txt_prefix" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>

                    <b>
                        <asp:Label ID="lbl_amount" runat="server" Font-Style="Bold" Text="Enter Amount"></asp:Label>

                    </b>
                        <asp:TextBox ID="txt_Amount" runat="server"></asp:TextBox>
                </p>

                <p>
                    <asp:DropDownList ID="code_List" runat="server">
                        <asp:ListItem Value="1" Text="EUR"></asp:ListItem>
                        <asp:ListItem Value="2" Text="GBP"></asp:ListItem>
                        <asp:ListItem Value="3" Text="USD"></asp:ListItem>
                        <asp:ListItem Value="4" Text="AUD"></asp:ListItem>
                        <asp:ListItem Value="5" Text="NZD"></asp:ListItem>
                        <asp:ListItem Value="6" Text="JPY"></asp:ListItem>
                        <asp:ListItem Value="7" Text="BGN"></asp:ListItem>
                        <asp:ListItem Value="8" Text="DKK"></asp:ListItem>
                        <asp:ListItem Value="9" Text="LTL"></asp:ListItem>
                        <asp:ListItem Value="10" Text="PLN"></asp:ListItem>
                        <asp:ListItem Value="11" Text="NOK"></asp:ListItem>
                        <asp:ListItem Value="12" Text="RUB"></asp:ListItem>
                        <asp:ListItem Value="13" Text="TRY"></asp:ListItem>
                        <asp:ListItem Value="14" Text="BRL"></asp:ListItem>
                        <asp:ListItem Value="15" Text="CAD"></asp:ListItem>
                        <asp:ListItem Value="16" Text="IDR"></asp:ListItem>
                        <asp:ListItem Value="17" Text="ILS"></asp:ListItem>
                        <asp:ListItem Value="18" Text="INR"></asp:ListItem>
                        <asp:ListItem Value="19" Text="KRW"></asp:ListItem>
                        <asp:ListItem Value="20" Text="MXN"></asp:ListItem>
                        <asp:ListItem Value="21" Text="MYR"></asp:ListItem>
                        <asp:ListItem Value="22" Text="PHP"></asp:ListItem>
                        <asp:ListItem Value="23" Text="SGD"></asp:ListItem>
                        <asp:ListItem Value="24" Text="THB"></asp:ListItem>
                        <asp:ListItem Value="25" Text="ZAR"></asp:ListItem>
                        <asp:ListItem Value="26" Text="CZK"></asp:ListItem>
                        <asp:ListItem Value="27" Text="HUF"></asp:ListItem>
                        <asp:ListItem Value="28" Text="RON"></asp:ListItem>
                        <asp:ListItem Value="29" Text="SEK"></asp:ListItem>
                        <asp:ListItem Value="30" Text="CHF"></asp:ListItem>
                        <asp:ListItem Value="31" Text="HRK"></asp:ListItem>
                        <asp:ListItem Value="32" Text="CNY"></asp:ListItem>
                        <asp:ListItem Value="33" Text="HKD"></asp:ListItem>
                    </asp:DropDownList>

                    &nbsp&nbsp&nbsp&nbsp&nbsp
                    <asp:Button ID="btn_Submit" runat="server" Text="Submit"
                        OnClick="btn_Submit_Click" />
                </p>
                <hr />
                
                
                <h4>
                    <asp:Label ID="lbl_Display" runat="server" Font-Style="Bold">&nbsp&nbsp</asp:Label>
                </h4>

                <h4>
                    <asp:Label ID="lbl_Error" runat="server" Font-Style="Bold" ForeColor="Red">&nbsp&nbsp</asp:Label>
                </h4>
                </div>
            </fieldset>
        </form>
    </div>
</body>
</html>
