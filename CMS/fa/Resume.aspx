<%@ Page Language="C#" AutoEventWireup="true" Inherits="Professor_Resume" MasterPageFile="~/MasterPages/WebMaster.master" Codebehind="Resume.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Head" runat="Server">
    <title><%=PageTitle%></title>
</asp:Content>
<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
    <div class="SingleItem">
    <h3>
        <asp:Label ID="lblTopic" runat="server"></asp:Label></h3>
    <asp:Image ID="imgResume" runat="server" Height="175px" Width="150px" CssClass="itemImg" />
    <div id="DivItem" runat="server" class="SingleItem">
        <asp:Label ID="lblTXt" runat="server"></asp:Label>
    </div>
    <div class="cleaner">
    </div>
    <div id="DivDownload" class="DnlFile last_row color2">
         &nbsp;<asp:LinkButton ID="LinkButton1" runat="server" CssClass="MyLink" 
             onclick="LinkButton1_Click" >Download</asp:LinkButton>
        &nbsp;<asp:ImageButton ID="ImageButton1" runat="server" 
            ImageUrl="~/images/download.png" Height="30px" 
             Width="30px" onclick="ImageButton1_Click" />
   
    </div>
    </div>
</asp:Content>
