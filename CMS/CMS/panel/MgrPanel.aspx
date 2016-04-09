<%@ Page Language="C#" AutoEventWireup="true" Inherits="Control_Panel_aspx_MgrPanel"  MasterPageFile="~/CMS/masterpages/MgrMaster.master" Codebehind="MgrPanel.aspx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    
    <title>کنترل پنل مدیریت</title>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="TitleContentPH">
    <div id="roadmap">
    
    </div>
    <div class="clear">
    </div>
    <div id="title_bar">
        <h1>
        </h1>
        <span></span>
    </div>
    <div class="clear">
    </div>
    <div id="main_content">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="Server" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                </div>
                <div class="RemarkDiv">
                    <p class="titleremark">
                        دفترچه یادداشت:</p>
                    <div class="confirmMSG" id="confirmDiv" visible="false" runat="server" style="margin:0 auto; width:auto;">
                        <asp:Label ID="lblOk" runat="server"></asp:Label></div>
                    <div class="clearFloat">
                    </div>
                    <div class="errorMSG" id="errorDiv" runat="server" visible="false">
                        <asp:Label ID="lblError" runat="server"></asp:Label></div>
                    <div class="clear">
                    </div>
                    <asp:TextBox ID="txtRemark" runat="server" CssClass="Remarktxt persian" TextMode="MultiLine"></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="یادداشت کن"
                        CssClass="Mybtn" Style="float: left; font-size: 11px; border-radius: 5px;" Height="20px"
                        Width="60px" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
