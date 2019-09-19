<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="webforms_exercise.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>Hello, my dear world!
            <asp:Button ID="btn_click_me" runat="server" Text="Click me!" OnClick="btn_click_me_Click" />
        </div>

    </form>
</body>
</html>
