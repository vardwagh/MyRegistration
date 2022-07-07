<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MyRegistration.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="Css/login.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.4.1.js"></script>
    <script src="Scripts/jquery-3.4.1.min.js"></script>
</head>
<body>
    <div class="container">

        <form runat="server">
            <div class="box">
                <h1>Login</h1>
                <p class="text-muted">Please enter your Mobile Number and OTP!</p>

                <table>
                    <tr>
                        <td style="width: 250px;">
                            <asp:TextBox ID="txtMobile" ValidationGroup="First" MaxLength="10" Placeholder="Enter 10 Digit Mobile Number" class="form-control" runat="server"></asp:TextBox>
                        </td>

                        <td>
                            <asp:Button class="btn btn-success" ValidationGroup="First" Style="margin-left: 10px;" ID="btnSendOtp" runat="server" Text="Send OTP" OnClick="btnSendOtp_Click" />
                        </td>
                        <td style="width: 150px;">
                            <asp:Label ID="lblotpsent" Text="" ForeColor="Green" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RegularExpressionValidator ID="revMobile" ValidationGroup="First" runat="server" ControlToValidate="txtMobile" ErrorMessage="Enter Correct 10 Digit Mobile Number" ForeColor="Red" ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="First" runat="server" ControlToValidate="txtMobile" ForeColor="Red" ErrorMessage="Mobile NO Required"></asp:RequiredFieldValidator>

                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1"></td>
                        <td class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtOTP" Class="form-control" ValidationGroup="Second" Visible="false" Placeholder="OTP" MaxLength="4" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button class="btn btn-primary" Visible="false" ValidationGroup="Second" Style="margin-left: 10px;" ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblOPT" ForeColor="Red" Text="" runat="server" />
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Second" runat="server" ControlToValidate="txtOTP" ForeColor="Red" ErrorMessage="OTP Required"></asp:RequiredFieldValidator></td>
                    </tr>
                </table>
            </div>
        </form>

    </div>
</body>
</html>
