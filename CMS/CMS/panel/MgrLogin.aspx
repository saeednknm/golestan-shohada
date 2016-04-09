<%@ Page Language="C#" AutoEventWireup="true" Inherits="aspx_MgrLogin" Codebehind="MgrLogin.aspx.cs" %>

<!DOCTYPE html>
<html>
<head>
    <!--META-->
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>ورود به کنترل پنل مدیریت</title>
    <!--STYLESHEETS-->
    <link href="../css/MgrLogin_style.css" rel="stylesheet" type="text/css" />
    <!--SCRIPTS-->
    <script type="text/javascript" src="../js/jquery-1.6.3.min.js"></script>
    <!--Slider-in icons-->
    <script type="text/javascript">
        $(document).ready(function () {
            $(".username").focus(function () {
                $(".user-icon").css("left", "-48px");
            });
            $(".username").blur(function () {
                $(".user-icon").css("left", "0px");
            });

            $(".password").focus(function () {
                $(".pass-icon").css("left", "-48px");
            });
            $(".password").blur(function () {
                $(".pass-icon").css("left", "0px");
            });
        });
    </script>
</head>
<body>
    <!--WRAPPER-->
    <div id="wrapper">
        <!--SLIDE-IN ICONS-->
        <div class="user-icon">
        </div>
        <div class="pass-icon">
        </div>
        <!--END SLIDE-IN ICONS-->
        <!--LOGIN FORM-->
        <form name="login-form" class="login-form"  runat="server">
        <!--HEADER-->
        <div class="header">
            <!--TITLE-->
            <h1>
                ورود به کنترل پنل مدیریت</h1>
            <!--END TITLE-->
            <!--DESCRIPTION-->
            <span>
                <asp:Label ID="lblSiteTitle" runat="server"></asp:Label>
                <br />
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </span>
            <!--END DESCRIPTION-->
        </div>
        <!--END HEADER-->
        <!--CONTENT-->
        <div class="content">
            <!--USERNAME-->
            <input runat="server" id="txtUser" name="username" type="text" class="input username"
                value="شناسه کاربری" onfocus="this.value=''" /><!--END USERNAME-->
            <!--PASSWORD-->
            
            <input id="txtPass" runat="server" name="password" type="password" class="input password"
                value="Password" onfocus="this.value=''" /><!--END PASSWORD-->
        </div>
        <!--END CONTENT-->
        <!--FOOTER-->
        <div class="footer">
            <!--LOGIN BUTTON-->
            <asp:Button ID="submit" runat="server" Text="ورود" CssClass="button" OnClick="submit_Click" /><!--END LOGIN BUTTON-->
        </div>
        <!--END FOOTER-->
        </form>
        <!--END LOGIN FORM-->
    </div>
    <!--END WRAPPER-->
    <!--GRADIENT-->
    <div class="gradient">
    </div>
    <!--END GRADIENT-->
</body>
</html>
